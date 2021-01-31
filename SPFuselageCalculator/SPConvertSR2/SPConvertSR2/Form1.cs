using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Xml.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SPLibrary;

namespace SPConvertSR2
{
    //------------注意事项---------------------
    //-----------------------------------------
    //取值可能隐藏的属性：Attribute() != null ? Attribute().Value : default;
    //添加可隐藏的属性：if(){ ele.Add()  }
    //-----------------------------------------
    //-----------------------------------------


    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //MessageBox.Show(REW_Func.ArrayToString(new int[] { 2,4,6 }));
            textBoxPathSP.Text = "C:\\Users\\" + Environment.UserName + "\\AppData\\LocalLow\\Jundroo\\SimplePlanes\\AircraftDesigns\\*.xml";
        }

        private void ToolStripMenuItemHelp_Click(object sender, EventArgs e)
        {
            new FormHelp().ShowDialog();
        }

        private void buttonConvert_Click(object sender, EventArgs e)
        {
            XDocument documentSP = XDocument.Load(textBoxPathSP.Text);
            List<XElement> partsElementsSP = documentSP.Element("Aircraft").Element("Assembly").Element("Parts").Elements("Part").ToList();

            List<XElement> block1ElementsSP = partsElementsSP.FindAll(x => x.Attribute("partType").Value == "Block-1");
            List<XElement> block2ElementsSP = partsElementsSP.FindAll(x => x.Attribute("partType").Value == "Block-2");

            List<XElement> fuselageElementsSP = partsElementsSP.FindAll(x => x.Attribute("partType").Value == "Fuselage-Body-1");
            List<XElement> hollowfuselageElementsSP = partsElementsSP.FindAll(x => x.Attribute("partType").Value == "Fuselage-Hollow-1");
            List<XElement> fuselageConeElementsSP = partsElementsSP.FindAll(x => x.Attribute("partType").Value == "Fuselage-Cone-1");
            List<XElement> inletFuselageElementsSP = partsElementsSP.FindAll(x => x.Attribute("partType").Value == "Fuselage-Inlet-1");

            List<XElement> wing1ElementsSP = partsElementsSP.FindAll(x => x.Attribute("partType").Value == "Wing-1");
            List<XElement> wing3ElementsSP = partsElementsSP.FindAll(x => x.Attribute("partType").Value == "Wing-3");
            List<XElement> wing2ElementsSP = partsElementsSP.FindAll(x => x.Attribute("partType").Value == "Wing-2");
            List<XElement> structPanelElementsSP = partsElementsSP.FindAll(x => x.Attribute("partType").Value == "Wing-2");//StructWing or StructuralPanel

            List<XElement> hingeRotatorsElementsSP = partsElementsSP.FindAll(x => x.Attribute("partType").Value == "HingeRotator-1");
            List<XElement> smallRotatorsElementsSP = partsElementsSP.FindAll(x => x.Attribute("partType").Value == "SmallRotator-1");
            List<XElement> bigRotatorsElementsSP = partsElementsSP.FindAll(x => x.Attribute("partType").Value == "JointRotator-1");

            List<XElement> shockElementsSP = partsElementsSP.FindAll(x => x.Attribute("partType").Value == "Shock");

            List<XElement> pistonElementsSP = partsElementsSP.FindAll(x => x.Attribute("partType").Value == "Piston");

            List<XElement> wheelsElementsSP = partsElementsSP.FindAll(x => x.Attribute("partType").Value == "Wheel-Resizable-1");

            List<XElement> gear1ElementsSP = partsElementsSP.FindAll(x => x.Attribute("partType").Value == "Wheel-1");
            List<XElement> gear2ElementsSP = partsElementsSP.FindAll(x => x.Attribute("partType").Value == "Wheel-2");
            List<XElement> gear3ElementsSP = partsElementsSP.FindAll(x => x.Attribute("partType").Value == "Wheel-3");
            List<XElement> gear5ElementsSP = partsElementsSP.FindAll(x => x.Attribute("partType").Value == "Wheel-5");

            List<XElement> jet1ElementsSP = partsElementsSP.FindAll(x => x.Attribute("partType").Value == "Engine-Jet-1");
            List<XElement> jet2ElementsSP = partsElementsSP.FindAll(x => x.Attribute("partType").Value == "Engine-Jet-2");
            List<XElement> jet4ElementsSP = partsElementsSP.FindAll(x => x.Attribute("partType").Value == "Engine-Jet-4");//涵道涡扇
            List<XElement> jet6ElementsSP = partsElementsSP.FindAll(x => x.Attribute("partType").Value == "Engine-Jet-6");
            List<XElement> jet7ElementsSP = partsElementsSP.FindAll(x => x.Attribute("partType").Value == "Engine-Jet-7");//涵道涡扇
            
            List<XElement> connElementsSP = documentSP.Element("Aircraft").Element("Assembly").Element("Connections").Elements("Connection").ToList();



            #region =======方块=======
            List<XElement> totalBlocksElementsSP = new List<XElement>();
            totalBlocksElementsSP.AddRange(block1ElementsSP);
            totalBlocksElementsSP.AddRange(block2ElementsSP);

            List<XElement> totalBlocksElementsSR2 = new List<XElement>();
            foreach (XElement blockEleSP in totalBlocksElementsSP)
            {
                //partType
                int type; //0-hingeRotator
                string strPartType = "";

                switch (blockEleSP.Attribute("partType").Value)
                {
                    case "Block-1": type = 0; strPartType = "Block1"; break;
                    case "Block-2": type = 1; strPartType = "Block1"; break;
                    default: type = 0; strPartType = "Block1"; break;
                }
                //Collision
                string strDisableCol = blockEleSP.Attribute("disableAircraftCollisions") != null ? blockEleSP.Attribute("disableAircraftCollisions").Value : "false";
                string strPartCollisionHandling;
                switch (strDisableCol)
                {
                    case "true":
                        strPartCollisionHandling = "Never";
                        break;
                    case "false":
                        strPartCollisionHandling = "Default";
                        break;
                    default:
                        strPartCollisionHandling = "Default";
                        break;
                }
                //materials
                int[] arrayMaterial = REW_Func.ReadIntArrayStr(blockEleSP.Attribute("materials").Value);
                //scale
                string strDragScale = blockEleSP.Attribute("dragScale") != null ? blockEleSP.Attribute("dragScale").Value : "1";
                string strScale = blockEleSP.Attribute("scale") != null ? blockEleSP.Attribute("scale").Value : "1,1,1";
                string strMassScale = blockEleSP.Attribute("massScale") != null ? blockEleSP.Attribute("massScale").Value : "1";
                float[] scaleSP = REW_Func.ReadFloatArrayStr(strScale);
                float[] scaleSR2 = scaleSP;

                //rotation(same)
                string strRotation = blockEleSP.Attribute("rotation").Value;
                float rotationX = REW_Func.ReadFloatArrayStr(strRotation)[0];
                float rotationY = REW_Func.ReadFloatArrayStr(strRotation)[1];
                float rotationZ = REW_Func.ReadFloatArrayStr(strRotation)[2];
                Matrix4x4 m = REW_Func.EulerToMatix(-rotationX, -rotationY, -rotationZ);
                Vector3 euler = REW_Func.MatrixToEuler(m);
                strRotation = euler.x + "," + euler.y + "," + euler.z;



                XElement blockEleSR2 = new XElement("Part",
                    new XAttribute("id", blockEleSP.Attribute("id").Value),
                    new XAttribute("partType", strPartType),
                    new XAttribute("position", blockEleSP.Attribute("position").Value),
                    new XAttribute("rotation", strRotation),
                    new XAttribute("commandPodId", 1),
                    new XAttribute("materials", arrayMaterial[0] + "," + arrayMaterial[0] + "," + arrayMaterial[0] + "," + arrayMaterial[0] + "," + arrayMaterial[0]),
                    new XElement("Drag",
                        new XAttribute("drag", blockEleSP.Attribute("drag").Value),
                        new XAttribute("area", blockEleSP.Attribute("drag").Value)
                    ),
                    new XElement("Config",
                        new XAttribute("dragScale", strDragScale),
                        new XAttribute("massScale", strMassScale),
                        new XAttribute("partCollisionHandling", strPartCollisionHandling),
                        new XAttribute("partScale", scaleSR2[0] + "," + scaleSR2[1] + "," + scaleSR2[2])
                    )
                );
                totalBlocksElementsSR2.Add(blockEleSR2);
            }
            #endregion

            #region =======圆筒=======
            //--------------------------------------转换FuselageBody\FuselageCone--------------------------------------------
            List<XElement> totalFuselageElementsSP = new List<XElement>();
            totalFuselageElementsSP.AddRange(fuselageElementsSP);
            totalFuselageElementsSP.AddRange(fuselageConeElementsSP);
            totalFuselageElementsSP.AddRange(hollowfuselageElementsSP);
            totalFuselageElementsSP.AddRange(inletFuselageElementsSP);


            List<XElement> totalFuselageElementsSR2 = new List<XElement>();
            foreach (XElement fuselageEleSP in totalFuselageElementsSP)
            {
                //partType
                int type; //0-fuselage 1-hollowFuselage 2-cone
                string strPartType = "";
                switch (fuselageEleSP.Attribute("partType").Value)
                {
                    case "Fuselage-Body-1": strPartType = "Fuselage1"; type = 0; break;
                    case "Fuselage-Hollow-1": strPartType = "Inlet1"; type = 1; break;
                    case "Fuselage-Cone-1": strPartType = "NoseCone1"; type = 2; break;
                    case "Fuselage-Inlet-1": strPartType = "Inlet1"; type = 3; break;
                    default: strPartType = "Fuselage1"; type = 0; break;
                }
                //Collision
                string strDisableCol = fuselageEleSP.Attribute("disableAircraftCollisions") != null ? fuselageEleSP.Attribute("disableAircraftCollisions").Value : "false";
                string strPartCollisionHandling;
                switch (strDisableCol)
                {
                    case "true":
                        strPartCollisionHandling = "Never";
                        break;
                    case "false":
                        strPartCollisionHandling = "Default";
                        break;
                    default:
                        strPartCollisionHandling = "Default";
                        break;
                }
                //materials
                int[] arrayMaterial = REW_Func.ReadIntArrayStr(fuselageEleSP.Attribute("materials").Value);
                //scale
                string strDragScale = fuselageEleSP.Attribute("dragScale") != null ? fuselageEleSP.Attribute("dragScale").Value : "1";
                string strScale = fuselageEleSP.Attribute("scale") != null ? fuselageEleSP.Attribute("scale").Value : "1,1,1";
                string strMassScale = fuselageEleSP.Attribute("massScale") != null ? fuselageEleSP.Attribute("massScale").Value : "1";
                float[] scaleSP = REW_Func.ReadFloatArrayStr(strScale);
                float[] scaleSR2 = new float[] { scaleSP[0], scaleSP[2], scaleSP[1] }; ; //1-3-2

                //sectionScale
                string strRear = fuselageEleSP.Element("Fuselage.State").Attribute("rearScale").Value;
                string strFront = fuselageEleSP.Element("Fuselage.State").Attribute("frontScale").Value;
                float rear1 = REW_Func.ReadFloatArrayStr(strRear)[0] * 0.25f;
                float rear2 = REW_Func.ReadFloatArrayStr(strRear)[1] * 0.25f;
                float front1 = REW_Func.ReadFloatArrayStr(strFront)[0] * 0.25f;
                float front2 = REW_Func.ReadFloatArrayStr(strFront)[1] * 0.25f;
                if (type == 2)
                {
                    rear1 = REW_Func.ReadFloatArrayStr(strFront)[0] * 0.25f;
                    rear2 = REW_Func.ReadFloatArrayStr(strFront)[1] * 0.25f;
                    front1 = 0.125f * rear1;
                    front2 = 0.125f * rear2;
                }

                //offset
                string strOffset = fuselageEleSP.Element("Fuselage.State").Attribute("offset").Value;
                float offset1 = REW_Func.ReadFloatArrayStr(strOffset)[0] * 0.25f;
                float offset2 = REW_Func.ReadFloatArrayStr(strOffset)[1] * 0.25f;
                float offset3 = REW_Func.ReadFloatArrayStr(strOffset)[2] * 0.25f;
                if (type == 0 || type == 1 || type == 3)
                {
                    offset1 = -offset1;
                }
                else if (type == 2)
                {
                    offset1 = -offset1;
                    offset2 = -offset2;
                }

                //rotation
                string strRotation = fuselageEleSP.Attribute("rotation").Value;
                float rotationX = REW_Func.ReadFloatArrayStr(strRotation)[0];
                float rotationY = REW_Func.ReadFloatArrayStr(strRotation)[1];
                float rotationZ = REW_Func.ReadFloatArrayStr(strRotation)[2];
                Matrix4x4 m1 = type != 2 ? REW_Func.EulerToMatix(-90f, 0, 0) : REW_Func.EulerToMatix(-90f, -180f, 0);
                Matrix4x4 m2 = REW_Func.EulerToMatix(-rotationX, -rotationY, -rotationZ);
                Vector3 euler = REW_Func.MatrixToEuler(m2 * m1);
                strRotation = euler.x + "," + euler.y + "," + euler.z;

                //cornertype
                string strCornerType = fuselageEleSP.Element("Fuselage.State").Attribute("cornerTypes").Value;
                float[] cornerTypes = REW_Func.ReadFloatArrayStr(strCornerType);
                for (int i = 0; i < cornerTypes.Length; i++)
                {
                    switch ((int)Math.Round(cornerTypes[i]))
                    {
                        case 3:
                            cornerTypes[i] = 1f;
                            break;
                        case 2:
                            float width = i < 4 ? REW_Func.ReadFloatArrayStr(strFront)[0] : REW_Func.ReadFloatArrayStr(strRear)[0];
                            float height = i < 4 ? REW_Func.ReadFloatArrayStr(strFront)[1] : REW_Func.ReadFloatArrayStr(strRear)[1];
                            float k = Math.Min(width, height) / Math.Max(width, height);
                            if (Math.Max(width, height) > 2f)
                            {
                                cornerTypes[i] = (2f / Math.Max(width, height)) * k;
                            }
                            else
                            {
                                cornerTypes[i] = 1f * k;
                            }
                            break;
                        case 1:
                            cornerTypes[i] = 0.25f;
                            break;
                        case 0:
                            cornerTypes[i] = 0f;
                            break;
                    }
                }
                string valueCornerType = cornerTypes[2] + "," + cornerTypes[1] + "," + cornerTypes[0] + "," + cornerTypes[3] + "," + cornerTypes[6] + "," + cornerTypes[5] + "," + cornerTypes[4] + "," + cornerTypes[7];
                if (type == 2)
                {
                    valueCornerType = 1 + "," + 1 + "," + 1 + "," + 1 + "," + cornerTypes[1] + "," + cornerTypes[2] + "," + cornerTypes[3] + "," + cornerTypes[0]; ;
                }


                //deadWeight
                string strDeadWeight = fuselageEleSP.Element("Fuselage.State").Attribute("deadWeight").Value;
                float deadWeight = Convert.ToSingle(strDeadWeight);
                //fuelPercentage
                string strFuelPercentage = fuselageEleSP.Element("Fuselage.State").Attribute("fuelPercentage").Value;
                float fuelPercentage = Convert.ToSingle(strFuelPercentage);




                XElement fuselageEleSR2 = new XElement("Part",
                    new XAttribute("id", fuselageEleSP.Attribute("id").Value),
                    new XAttribute("partType", strPartType),
                    new XAttribute("position", fuselageEleSP.Attribute("position").Value),
                    new XAttribute("rotation", strRotation),
                    new XAttribute("commandPodId", 1),
                    new XAttribute("materials", arrayMaterial[0] + "," + arrayMaterial[0] + "," + arrayMaterial[0] + "," + arrayMaterial[0] + "," + arrayMaterial[0]),
                    new XAttribute("texture", "Default"),
                    new XElement("Drag",
                        new XAttribute("drag", fuselageEleSP.Attribute("drag").Value),
                        new XAttribute("area", "0,0,0,0,0,0")
                    ),
                    new XElement("Config",
                        new XAttribute("dragScale", strDragScale),
                        new XAttribute("massScale", strMassScale),
                        new XAttribute("partCollisionHandling", strPartCollisionHandling),
                        new XAttribute("partScale", scaleSR2[0] + "," + scaleSR2[1] + "," + scaleSR2[2])
                    ),
                    new XElement("Fuselage",
                        new XAttribute("bottomScale", rear1 + "," + rear2),
                        new XAttribute("cornerRadiuses", valueCornerType),
                        new XAttribute("deadWeight", deadWeight),
                        new XAttribute("fuelPercentage", fuelPercentage),
                        new XAttribute("offset", offset1 + "," + offset3 + "," + offset2),
                        new XAttribute("topScale", front1 + "," + front2)
                    )
                );
                if (strPartType != "Inlet1")
                {
                    fuselageEleSR2.Add(new XElement("FuelTank",
                        new XAttribute("autoFuelType", "false"),
                        new XAttribute("capacity", fuselageEleSP.Element("FuelTank.State").Attribute("capacity").Value),
                        new XAttribute("fuel", fuselageEleSP.Element("FuelTank.State").Attribute("fuel").Value),
                        new XAttribute("fuelType", "Jet")));
                }
                totalFuselageElementsSR2.Add(fuselageEleSR2);
            }
            #endregion

            #region =======机翼=======
            //-----------------------------------------转换机翼------------------------------------------
            List<XElement> totalWingsElementsSP = new List<XElement>();
            totalWingsElementsSP.AddRange(wing1ElementsSP);
            totalWingsElementsSP.AddRange(wing3ElementsSP);
            totalWingsElementsSP.AddRange(wing2ElementsSP);

            List<XElement> totalWingsElementsSR2 = new List<XElement>();
            foreach (XElement wingEleSP in totalWingsElementsSP)
            {
                //partType
                int type; //0-wing3 1-wing2 2-panel 3-wing1
                string strPartType = "";

                if (wingEleSP.Attribute("partType").Value == "Wing-3")
                {
                    strPartType = "Wing1";
                    type = 0;
                }
                else if(wingEleSP.Attribute("partType").Value == "Wing-1")
                {
                    strPartType = "Wing1";
                    type = 3;
                }
                else
                {
                    if (wingEleSP.Element("Wing.State").Attribute("wingPhysicsEnabled").Value == "true")
                    {
                        strPartType = "Wing1";
                        type = 1;
                    }
                    else
                    {
                        strPartType = "StructuralPanel1";
                        type = 2;
                    }
                }
                //Collision
                string strDisableCol = wingEleSP.Attribute("disableAircraftCollisions") != null ? wingEleSP.Attribute("disableAircraftCollisions").Value : "false";
                string strPartCollisionHandling;
                switch (strDisableCol)
                {
                    case "true":
                        strPartCollisionHandling = "Never";
                        break;
                    case "false":
                        strPartCollisionHandling = "Default";
                        break;
                    default:
                        strPartCollisionHandling = "Default";
                        break;
                }
                //materials
                int[] arrayMaterial = REW_Func.ReadIntArrayStr(wingEleSP.Attribute("materials").Value);
                //scale
                string strDragScale = wingEleSP.Attribute("dragScale") != null ? wingEleSP.Attribute("dragScale").Value : "1";
                string strScale = wingEleSP.Attribute("scale") != null ? wingEleSP.Attribute("scale").Value : "1,1,1";
                string strMassScale = wingEleSP.Attribute("massScale") != null ? wingEleSP.Attribute("massScale").Value : "1";
                float[] scaleSP = REW_Func.ReadFloatArrayStr(strScale);
                float[] scaleSR2 = new float[] { scaleSP[0], scaleSP[1], scaleSP[2] }; ;

                //Offset(root-tip)
                string strRootLeadingOffset = wingEleSP.Element("Wing.State").Attribute("rootLeadingOffset").Value;
                string strRootTrailingOffset = wingEleSP.Element("Wing.State").Attribute("rootTrailingOffset").Value;
                string strTipLeadingOffset = wingEleSP.Element("Wing.State").Attribute("tipLeadingOffset").Value;
                string strTipTrailingOffset = wingEleSP.Element("Wing.State").Attribute("tipTrailingOffset").Value;
                string strTipPosition = wingEleSP.Element("Wing.State").Attribute("tipPosition").Value;
                string strHingeDistance = wingEleSP.Element("Wing.State").Attribute("hingeDistance").Value;//=>hingeDistanceFromTrailingEdge
                float[] rootLeadingOffset = REW_Func.ReadFloatArrayStr(strRootLeadingOffset);
                float[] rootTrailingOffset = REW_Func.ReadFloatArrayStr(strRootTrailingOffset);
                float[] tipLeadingOffset = REW_Func.ReadFloatArrayStr(strTipLeadingOffset);
                float[] tipPosition = REW_Func.ReadFloatArrayStr(strTipPosition);
                float[] tipTrailingOffset = REW_Func.ReadFloatArrayStr(strTipTrailingOffset);

                //rotation(same)
                string strRotation = wingEleSP.Attribute("rotation").Value;
                float rotationX = REW_Func.ReadFloatArrayStr(strRotation)[0];
                float rotationY = REW_Func.ReadFloatArrayStr(strRotation)[1];
                float rotationZ = REW_Func.ReadFloatArrayStr(strRotation)[2];
                Matrix4x4 m = REW_Func.EulerToMatix(-rotationX, -rotationY, -rotationZ);
                Vector3 euler = REW_Func.MatrixToEuler(m);
                strRotation = euler.x + "," + euler.y + "," + euler.z;



                XElement wingEleSR2 = new XElement("Part",
                    new XAttribute("id", wingEleSP.Attribute("id").Value),
                    new XAttribute("partType", strPartType),
                    new XAttribute("position", wingEleSP.Attribute("position").Value),
                    new XAttribute("rotation", strRotation),
                    new XAttribute("commandPodId", 1),
                    new XAttribute("materials", arrayMaterial[0] + "," + arrayMaterial[1] + "," + arrayMaterial[0] + "," + arrayMaterial[0] + "," + arrayMaterial[0]),
                    new XElement("Drag",
                        new XAttribute("drag", wingEleSP.Attribute("drag").Value),
                        new XAttribute("area", wingEleSP.Attribute("drag").Value)
                    ),
                    new XElement("Config",
                        new XAttribute("centerOfMass", "0,0,0"),
                        new XAttribute("dragScale", strDragScale),
                        new XAttribute("massScale", strMassScale),
                        new XAttribute("partCollisionHandling", strPartCollisionHandling),
                        new XAttribute("partScale", scaleSR2[0] + "," + scaleSR2[1] + "," + scaleSR2[2])
                    ),
                    new XElement("Wing",
                        new XAttribute("hingeDistanceFromTrailingEdge", strHingeDistance),
                        new XAttribute("rootLeadingOffset", rootLeadingOffset[0]),
                        new XAttribute("rootTrailingOffset", rootTrailingOffset[0]),
                        new XAttribute("tipLeadingOffset", tipLeadingOffset[0]),
                        new XAttribute("tipPosition", tipPosition[0] + "," + tipPosition[1] + "," + tipPosition[2]),
                        new XAttribute("tipTrailingOffset", tipTrailingOffset[0])
                    )
                );
                //ControlSurface
                if (wingEleSP.Element("Wing.State").Elements("ControlSurface").Any())
                {
                    int surfaceCount = wingEleSP.Element("Wing.State").Elements("ControlSurface").Count();
                    for (int i = 0; i < surfaceCount; i++)
                    {
                        string valueEnd = wingEleSP.Element("Wing.State").Elements("ControlSurface").ToArray()[i].Attributes("end").Any() ? wingEleSP.Element("Wing.State").Elements("ControlSurface").ToArray()[i].Attribute("end").Value : "0";
                        string valueStart = wingEleSP.Element("Wing.State").Elements("ControlSurface").ToArray()[i].Attributes("start").Any() ? wingEleSP.Element("Wing.State").Elements("ControlSurface").ToArray()[i].Attribute("start").Value : "0";
                        string valueInput = wingEleSP.Element("Wing.State").Elements("ControlSurface").ToArray()[i].Attribute("inputId").Value;
                        if (valueInput == "VTOL")
                        {
                            valueInput = "Slider2";
                        }
                        else if (valueInput == "Trim")
                        {
                            valueInput = "Slider2";
                        }
                        string valueInvert = wingEleSP.Element("Wing.State").Elements("ControlSurface").ToArray()[i].Attribute("invert").Value;
                        if (type == 3)//wing1偏转方向与wing3不一样
                        {
                            valueInvert = (valueInvert == "true" ? "false" : "true");
                        }

                        XElement ctrlSurfaceEleSR2 = new XElement("ControlSurface",
                            new XAttribute("end", valueEnd),
                            new XAttribute("input", valueInput),
                            new XAttribute("invert", valueInvert),
                            new XAttribute("start", valueStart)
                            );
                        wingEleSR2.Add(ctrlSurfaceEleSR2);
                    }
                }
                totalWingsElementsSR2.Add(wingEleSR2);
            }

            #endregion

            #region =======转轴=======
            //-----------------------------------------转换转轴------------------------------------------
            List<XElement> totalRotatorsElementsSP = new List<XElement>();
            totalRotatorsElementsSP.AddRange(hingeRotatorsElementsSP);
            totalRotatorsElementsSP.AddRange(smallRotatorsElementsSP);
            totalRotatorsElementsSP.AddRange(bigRotatorsElementsSP);

            List<XElement> totalRotatorsElementsSR2 = new List<XElement>();
            foreach (XElement rotatorEleSP in totalRotatorsElementsSP)
            {
                //partType
                int type; //0-hingeRotator 1-small 2-big
                string strPartType = "";

                switch (rotatorEleSP.Attribute("partType").Value)
                {
                    case "HingeRotator-1": type = 0; strPartType = "HingeRotator1"; break;
                    case "SmallRotator-1": type = 1; strPartType = "Rotator1"; break;
                    case "JointRotator-1": type = 2; strPartType = "Rotator1"; break;
                    default: type = 0; strPartType = "HingeRotator1"; break;
                }
                //Collision
                string strDisableCol = rotatorEleSP.Attribute("disableAircraftCollisions") != null ? rotatorEleSP.Attribute("disableAircraftCollisions").Value : "false";
                string strPartCollisionHandling;
                switch (strDisableCol)
                {
                    case "true":
                        strPartCollisionHandling = "Never";
                        break;
                    case "false":
                        strPartCollisionHandling = "Default";
                        break;
                    default:
                        strPartCollisionHandling = "Default";
                        break;
                }
                //materials
                int[] arrayMaterial = REW_Func.ReadIntArrayStr(rotatorEleSP.Attribute("materials").Value);
                //scale
                string strDragScale = rotatorEleSP.Attribute("dragScale") != null ? rotatorEleSP.Attribute("dragScale").Value : "1";
                string strScale = rotatorEleSP.Attribute("scale") != null ? rotatorEleSP.Attribute("scale").Value : "1,1,1";
                string strMassScale = rotatorEleSP.Attribute("massScale") != null ? rotatorEleSP.Attribute("massScale").Value : "1";
                float[] scaleSP = REW_Func.ReadFloatArrayStr(strScale);
                float[] scaleSR2 = new float[] { 1.5f * scaleSP[1], 1f * scaleSP[2], 0.5f * scaleSP[0] };

                //Input
                string strAG = rotatorEleSP.Element("InputController.State").Attribute("activationGroup").Value;
                string strInput = rotatorEleSP.Element("InputController.State").Attribute("input").Value;
                if (strInput == "VTOL")
                {
                    strInput = "Slider2";
                }
                else if (strInput == "Trim")
                {
                    strInput = "Slider2";
                }
                string strInvert = rotatorEleSP.Element("InputController.State").Attribute("invert").Value;
                string strInputId = "Rotator";
                //RotatorRange\Speed
                string strRange = rotatorEleSP.Element("JointRotator.State").Attribute("range").Value;
                string strSpeed = rotatorEleSP.Element("JointRotator.State").Attribute("speed").Value;
                //rotation(same)
                string strRotation = rotatorEleSP.Attribute("rotation").Value;
                float rotationX = REW_Func.ReadFloatArrayStr(strRotation)[0];
                float rotationY = REW_Func.ReadFloatArrayStr(strRotation)[1];
                float rotationZ = REW_Func.ReadFloatArrayStr(strRotation)[2];
                Matrix4x4 m1 = REW_Func.EulerToMatix(-90f, 0, 0);
                Matrix4x4 m2 = REW_Func.EulerToMatix(0, 0, -90f);
                Matrix4x4 m3 = REW_Func.EulerToMatix(-rotationX, -rotationY, -rotationZ);
                Vector3 euler = REW_Func.MatrixToEuler(m3 * m2 * m1);
                if(type == 2)
                {
                    euler = REW_Func.MatrixToEuler(m3); ;
                }
                strRotation = euler.x + "," + euler.y + "," + euler.z;



                XElement rotatorEleSR2 = new XElement("Part",
                    new XAttribute("id", rotatorEleSP.Attribute("id").Value),
                    new XAttribute("partType", strPartType),
                    new XAttribute("position", rotatorEleSP.Attribute("position").Value),
                    new XAttribute("rotation", strRotation),
                    new XAttribute("activationGroup", strAG),
                    new XAttribute("commandPodId", 1),
                    new XAttribute("materials", arrayMaterial[0] + "," + arrayMaterial[0] + "," + arrayMaterial[0] + "," + arrayMaterial[0] + "," + arrayMaterial[0]),
                    new XElement("Drag",
                        new XAttribute("drag", rotatorEleSP.Attribute("drag").Value),
                        new XAttribute("area", rotatorEleSP.Attribute("drag").Value)
                    ),
                    new XElement("Config",
                        new XAttribute("dragScale", strDragScale),
                        new XAttribute("massScale", strMassScale),
                        new XAttribute("partCollisionHandling", strPartCollisionHandling),
                        new XAttribute("partScale", scaleSR2[0] + "," + scaleSR2[1] + "," + scaleSR2[2])
                    ),
                    new XElement("JointRotator",
                        new XAttribute("range", strRange),
                        new XAttribute("speed", strSpeed)
                    ),
                    new XElement("InputController",
                        new XAttribute("input", strInput),
                        new XAttribute("invert", strInvert),
                        new XAttribute("inputId", strInputId)
                    )
                );
                totalRotatorsElementsSR2.Add(rotatorEleSR2);
            }
            #endregion

            #region =======弹簧=======
            //-----------------------------------------转换弹簧------------------------------------------
            List<XElement> totalShockElementsSP = new List<XElement>();
            totalShockElementsSP.AddRange(shockElementsSP);

            List<XElement> totalShockElementsSR2 = new List<XElement>();
            foreach (XElement shockEleSP in totalShockElementsSP)
            {
                //partType
                int type; //0-hingeRotator
                string strPartType = "";

                switch (shockEleSP.Attribute("partType").Value)
                {
                    case "Shock": type = 0; strPartType = "Shock1"; break;
                    default: type = 0; strPartType = "Shock1"; break;
                }
                //Collision
                string strDisableCol = shockEleSP.Attribute("disableAircraftCollisions") != null ? shockEleSP.Attribute("disableAircraftCollisions").Value : "false";
                string strPartCollisionHandling;
                switch (strDisableCol)
                {
                    case "true":
                        strPartCollisionHandling = "Never";
                        break;
                    case "false":
                        strPartCollisionHandling = "Default";
                        break;
                    default:
                        strPartCollisionHandling = "Default";
                        break;
                }
                //materials
                int[] arrayMaterial = REW_Func.ReadIntArrayStr(shockEleSP.Attribute("materials").Value);
                //scale
                string strDragScale = shockEleSP.Attribute("dragScale") != null ? shockEleSP.Attribute("dragScale").Value : "1";
                string strScale = shockEleSP.Attribute("scale") != null ? shockEleSP.Attribute("scale").Value : "1,1,1";
                string strMassScale = shockEleSP.Attribute("massScale") != null ? shockEleSP.Attribute("massScale").Value : "1";
                float[] scaleSP = REW_Func.ReadFloatArrayStr(strScale);
                float[] scaleSR2 = scaleSP;

                //rotation(same)
                string strRotation = shockEleSP.Attribute("rotation").Value;
                float rotationX = REW_Func.ReadFloatArrayStr(strRotation)[0];
                float rotationY = REW_Func.ReadFloatArrayStr(strRotation)[1];
                float rotationZ = REW_Func.ReadFloatArrayStr(strRotation)[2];
                Matrix4x4 m = REW_Func.EulerToMatix(-rotationX, -rotationY, -rotationZ);
                Vector3 euler = REW_Func.MatrixToEuler(m);
                strRotation = euler.x + "," + euler.y + "," + euler.z;
                //Suspension
                string strDamper = shockEleSP.Element("Suspension.State").Attribute("damper").Value;
                string strSpring = shockEleSP.Element("Suspension.State").Attribute("spring").Value;

                XElement shockEleSR2 = new XElement("Part",
                    new XAttribute("id", shockEleSP.Attribute("id").Value),
                    new XAttribute("partType", strPartType),
                    new XAttribute("position", shockEleSP.Attribute("position").Value),
                    new XAttribute("rotation", strRotation),
                    new XAttribute("commandPodId", 1),
                    new XAttribute("materials", arrayMaterial[0] + "," + arrayMaterial[0] + "," + arrayMaterial[0] + "," + arrayMaterial[0] + "," + arrayMaterial[0]),
                    new XElement("Drag",
                        new XAttribute("drag", shockEleSP.Attribute("drag").Value),
                        new XAttribute("area", shockEleSP.Attribute("drag").Value)
                    ),
                    new XElement("Config",
                        new XAttribute("dragScale", strDragScale),
                        new XAttribute("massScale", strMassScale),
                        new XAttribute("partCollisionHandling", strPartCollisionHandling),
                        new XAttribute("partScale", scaleSR2[0] + "," + scaleSR2[1] + "," + scaleSR2[2])
                    ),
                    new XElement("Suspension",
                        new XAttribute("damper", strDamper),
                        new XAttribute("spring", strSpring)
                    )
                );
                totalShockElementsSR2.Add(shockEleSR2);
            }
            #endregion

            #region =======活塞=======
            //-----------------------------------------转换活塞------------------------------------------
            List<XElement> totalPistonElementsSP = new List<XElement>();
            totalPistonElementsSP.AddRange(pistonElementsSP);

            List<XElement> totalPistonElementsSR2 = new List<XElement>();
            foreach (XElement pistonEleSP in totalPistonElementsSP)
            {
                //partType
                int type; //0-hingeRotator
                string strPartType = "";

                switch (pistonEleSP.Attribute("partType").Value)
                {
                    case "Piston": type = 0; strPartType = "Piston1"; break;
                    default: type = 0; strPartType = "Piston1"; break;
                }
                //Collision
                string strDisableCol = pistonEleSP.Attribute("disableAircraftCollisions") != null ? pistonEleSP.Attribute("disableAircraftCollisions").Value : "false";
                string strPartCollisionHandling;
                switch (strDisableCol)
                {
                    case "true":
                        strPartCollisionHandling = "Never";
                        break;
                    case "false":
                        strPartCollisionHandling = "Default";
                        break;
                    default:
                        strPartCollisionHandling = "Default";
                        break;
                }
                //materials
                int[] arrayMaterial = REW_Func.ReadIntArrayStr(pistonEleSP.Attribute("materials").Value);
                //scale
                string strDragScale = pistonEleSP.Attribute("dragScale") != null ? pistonEleSP.Attribute("dragScale").Value : "1";
                string strScale = pistonEleSP.Attribute("scale") != null ? pistonEleSP.Attribute("scale").Value : "1,1,1";
                string strMassScale = pistonEleSP.Attribute("massScale") != null ? pistonEleSP.Attribute("massScale").Value : "1";
                float[] scaleSP = REW_Func.ReadFloatArrayStr(strScale);
                float[] scaleSR2 = scaleSP;

                //rotation(same)
                string strRotation = pistonEleSP.Attribute("rotation").Value;
                float rotationX = REW_Func.ReadFloatArrayStr(strRotation)[0];
                float rotationY = REW_Func.ReadFloatArrayStr(strRotation)[1];
                float rotationZ = REW_Func.ReadFloatArrayStr(strRotation)[2];
                Matrix4x4 m = REW_Func.EulerToMatix(-rotationX, -rotationY, -rotationZ);
                Vector3 euler = REW_Func.MatrixToEuler(m);
                strRotation = euler.x + "," + euler.y + "," + euler.z;
                //Input
                string strAG = pistonEleSP.Element("InputController.State").Attribute("activationGroup").Value;
                string strInput = pistonEleSP.Element("InputController.State").Attribute("input").Value;
                if (strInput == "VTOL")
                {
                    strInput = "Slider2";
                }
                else if (strInput == "Trim")
                {
                    strInput = "Slider2";
                }
                string strInvert = pistonEleSP.Element("InputController.State").Attribute("invert").Value;
                string strInputId = "Piston";

                //Piston
                string strCycle = pistonEleSP.Element("Piston.State").Attribute("cycle").Value;
                string strRange = pistonEleSP.Element("Piston.State").Attribute("range").Value;
                string strSpeed = pistonEleSP.Element("Piston.State").Attribute("speed").Value;
                string strExtend = pistonEleSP.Element("Piston.State").Attribute("extend").Value;

                XElement pistonEleSR2 = new XElement("Part",
                    new XAttribute("id", pistonEleSP.Attribute("id").Value),
                    new XAttribute("partType", strPartType),
                    new XAttribute("position", pistonEleSP.Attribute("position").Value),
                    new XAttribute("rotation", strRotation),
                    new XAttribute("commandPodId", 1),
                    new XAttribute("materials", arrayMaterial[0] + "," + arrayMaterial[0] + "," + arrayMaterial[0] + "," + arrayMaterial[0] + "," + arrayMaterial[0]),
                    new XElement("Drag",
                        new XAttribute("drag", pistonEleSP.Attribute("drag").Value),
                        new XAttribute("area", pistonEleSP.Attribute("drag").Value)
                    ),
                    new XElement("Config",
                        new XAttribute("dragScale", strDragScale),
                        new XAttribute("massScale", strMassScale),
                        new XAttribute("partCollisionHandling", strPartCollisionHandling),
                        new XAttribute("partScale", scaleSR2[0] + "," + scaleSR2[1] + "," + scaleSR2[2])
                    ),
                    new XElement("Piston",
                        new XAttribute("cycle", strCycle),
                        new XAttribute("extend", strExtend),
                        new XAttribute("range", strRange),
                        new XAttribute("speed", strSpeed)
                    ),
                    new XElement("InputController",
                        new XAttribute("input", strInput),
                        new XAttribute("invert", strInvert),
                        new XAttribute("inputId", strInputId)
                    )
                );
                totalPistonElementsSR2.Add(pistonEleSR2);
            }
            #endregion

            #region =======车轮=======
            //-----------------------------------------转换车轮------------------------------------------
            List<XElement> totalWheelsElementsSP = new List<XElement>();
            totalWheelsElementsSP.AddRange(wheelsElementsSP);

            List<XElement> totalWheelsElementsSR2 = new List<XElement>();
            foreach (XElement wheelEleSP in totalWheelsElementsSP)
            {
                //partType
                int type; //0-hingeRotator
                string strPartType = "";

                switch (wheelEleSP.Attribute("partType").Value)
                {
                    case "Wheel-Resizable-1": type = 0; strPartType = "RoverWheel1"; break;
                    default: type = 0; strPartType = "RoverWheel1"; break;
                }
                //Collision
                string strDisableCol = wheelEleSP.Attribute("disableAircraftCollisions") != null ? wheelEleSP.Attribute("disableAircraftCollisions").Value : "false";
                string strPartCollisionHandling;
                switch (strDisableCol)
                {
                    case "true":
                        strPartCollisionHandling = "Never";
                        break;
                    case "false":
                        strPartCollisionHandling = "Default";
                        break;
                    default:
                        strPartCollisionHandling = "Default";
                        break;
                }
                //materials
                int[] arrayMaterial = REW_Func.ReadIntArrayStr(wheelEleSP.Attribute("materials").Value);
                //scale
                string strDragScale = wheelEleSP.Attribute("dragScale") != null ? wheelEleSP.Attribute("dragScale").Value : "1";
                string strScale = wheelEleSP.Attribute("scale") != null ? wheelEleSP.Attribute("scale").Value : "1,1,1";
                string strMassScale = wheelEleSP.Attribute("massScale") != null ? wheelEleSP.Attribute("massScale").Value : "1";
                float[] scaleSP = REW_Func.ReadFloatArrayStr(strScale);
                float scaleAverage = (scaleSP[0] + scaleSP[1] + scaleSP[2]) * 0.3333f;
                float[] scaleSR2 = new float[] { scaleAverage, scaleAverage, scaleAverage }; ; //average

                //Input
                string strAG = wheelEleSP.Element("InputController.State").Attribute("activationGroup").Value;
                string strInput = wheelEleSP.Element("InputController.State").Attribute("input").Value;
                if (strInput == "VTOL")
                {
                    strInput = "Slider2";
                }
                else if (strInput == "Trim")
                {
                    strInput = "Slider2";
                }
                string strInvert = wheelEleSP.Element("InputController.State").Attribute("invert").Value;
                string strInputId = "Turn";
                //rotation(same)
                string strRotation = wheelEleSP.Attribute("rotation").Value;
                float rotationX = REW_Func.ReadFloatArrayStr(strRotation)[0];
                float rotationY = REW_Func.ReadFloatArrayStr(strRotation)[1];
                float rotationZ = REW_Func.ReadFloatArrayStr(strRotation)[2];
                Matrix4x4 m1 = REW_Func.EulerToMatix(0, 90f, 0);
                Matrix4x4 m2 = REW_Func.EulerToMatix(-rotationX, -rotationY, -rotationZ);
                Vector3 euler = REW_Func.MatrixToEuler(m2 * m1);
                strRotation = euler.x + "," + euler.y + "," + euler.z;

                //Wheel
                string strDirection = wheelEleSP.Element("ResizableWheel.State").Attribute("direction").Value;
                string strSize = wheelEleSP.Element("ResizableWheel.State").Attribute("size").Value;
                string strSlipForwardEx = wheelEleSP.Element("ResizableWheel.State").Attribute("slipForwardExtremum").Value;
                string strSlipForwardAsy = wheelEleSP.Element("ResizableWheel.State").Attribute("slipForwardAsymptote").Value;
                string strSlipSidewaysEx = wheelEleSP.Element("ResizableWheel.State").Attribute("slipSidewaysExtremum").Value;
                string strSlipSidewaysdAsy = wheelEleSP.Element("ResizableWheel.State").Attribute("slipSidewaysAsymptote").Value;
                string strTractionForward = wheelEleSP.Element("ResizableWheel.State").Attribute("tractionForward").Value;
                string strTractionSideways = wheelEleSP.Element("ResizableWheel.State").Attribute("tractionSideways").Value;
                string strTurnAngle = wheelEleSP.Element("ResizableWheel.State").Attribute("turningAngle").Value;
                string strWidth = wheelEleSP.Element("ResizableWheel.State").Attribute("width").Value;
                float size = Convert.ToSingle(strSize) * 0.5f;
                float width = Convert.ToSingle(strWidth) * 1f;

                XElement wheelEleSR2 = new XElement("Part",
                    new XAttribute("id", wheelEleSP.Attribute("id").Value),
                    new XAttribute("partType", strPartType),
                    new XAttribute("position", wheelEleSP.Attribute("position").Value),
                    new XAttribute("rotation", strRotation),
                    new XAttribute("activationGroup", strAG),
                    new XAttribute("commandPodId", 1),
                    new XAttribute("materials", arrayMaterial[0] + "," + arrayMaterial[1] + "," + arrayMaterial[2] + "," + arrayMaterial[0] + "," + arrayMaterial[0]),
                    new XAttribute("wheelStyle", "LandingGearRim"),
                    new XAttribute("tireStyle", "RoverTireLandingGear"),
                    new XElement("Drag",
                        new XAttribute("drag", wheelEleSP.Attribute("drag").Value),
                        new XAttribute("area", wheelEleSP.Attribute("drag").Value)
                    ),
                    new XElement("Config",
                        new XAttribute("dragScale", strDragScale),
                        new XAttribute("massScale", strMassScale),
                        new XAttribute("partCollisionHandling", strPartCollisionHandling),
                        new XAttribute("partScale", scaleSR2[0] + "," + scaleSR2[1] + "," + scaleSR2[2])
                    ),
                    new XElement("ResizableWheel",
                        new XAttribute("direction", strDirection),
                        new XAttribute("size", size),
                        new XAttribute("slipForwardExtremum", strSlipForwardEx),
                        new XAttribute("slipForwardAsymptote", strSlipForwardAsy),
                        new XAttribute("slipSidewaysExtremum", strSlipSidewaysEx),
                        new XAttribute("slipSidewaysAsymptote", strSlipSidewaysdAsy),
                        new XAttribute("tractionForward", strTractionForward),
                        new XAttribute("tractionSideways", strTractionSideways),
                        new XAttribute("turningAngle", strTurnAngle),
                        new XAttribute("width", width)
                    ),
                    new XElement("InputController",
                        new XAttribute("input", strInput),
                        new XAttribute("invert", strInvert),
                        new XAttribute("inputId", strInputId)
                    ),
                    new XElement("InputController",
                        new XAttribute("inputId", "Motor")
                    )
                );
                //悬挂
                if(wheelEleSP.Element("ResizableWheel.State").Attribute("enableSuspension").Value == "true")
                {
                    string strSpring = wheelEleSP.Element("ResizableWheel.State").Attribute("spring").Value;
                    string strDamper = wheelEleSP.Element("ResizableWheel.State").Attribute("damper").Value;
                    wheelEleSR2.Element("ResizableWheel").Add(new XAttribute("enableSuspension", "true"));
                    wheelEleSR2.Element("ResizableWheel").Add(new XAttribute("spring", strSpring));
                    wheelEleSR2.Element("ResizableWheel").Add(new XAttribute("damper", strDamper));
                }
                else
                {
                    wheelEleSR2.Element("ResizableWheel").Add(new XAttribute("enableSuspension", "false"));
                }
                totalWheelsElementsSR2.Add(wheelEleSR2);
            }
            #endregion

            #region ======起落架======
            //-----------------------------------------转换车轮------------------------------------------
            List<XElement> totalGearsElementsSP = new List<XElement>();
            totalGearsElementsSP.AddRange(gear1ElementsSP);
            totalGearsElementsSP.AddRange(gear2ElementsSP);
            totalGearsElementsSP.AddRange(gear3ElementsSP);
            totalGearsElementsSP.AddRange(gear5ElementsSP);

            List<XElement> totalGearsElementsSR2 = new List<XElement>();
            foreach (XElement gearEleSP in totalGearsElementsSP)
            {
                //partType
                int type; //1 -- short  2--long 3--side
                string strPartType = "";

                switch (gearEleSP.Attribute("partType").Value)
                {
                    case "Wheel-1": type = 0; strPartType = "LandingGear1"; break;
                    case "Wheel-2": type = 1; strPartType = "LandingGear1"; break; 
                    case "Wheel-3": type = 2; strPartType = "LandingGear1"; break;
                    case "Wheel-5": type = 3; strPartType = "LandingGear1"; break;
                    default: type = 1; strPartType = "LandingGear1"; break;
                }
                //Collision
                string strDisableCol = gearEleSP.Attribute("disableAircraftCollisions") != null ? gearEleSP.Attribute("disableAircraftCollisions").Value : "false";
                string strPartCollisionHandling;
                switch (strDisableCol)
                {
                    case "true":
                        strPartCollisionHandling = "Never";
                        break;
                    case "false":
                        strPartCollisionHandling = "Default";
                        break;
                    default:
                        strPartCollisionHandling = "Default";
                        break;
                }
                //materials
                int[] arrayMaterial = REW_Func.ReadIntArrayStr(gearEleSP.Attribute("materials").Value);
                int[] newArrayMaterial = new int[5];
                if(type == 0)
                {
                    newArrayMaterial[0] = arrayMaterial[0];
                    newArrayMaterial[1] = arrayMaterial[1];
                    newArrayMaterial[2] = arrayMaterial[1];
                    newArrayMaterial[3] = arrayMaterial[0];
                    newArrayMaterial[4] = arrayMaterial[1];
                }
                else
                {
                    newArrayMaterial[0] = arrayMaterial[0];
                    newArrayMaterial[1] = arrayMaterial[2];
                    newArrayMaterial[2] = arrayMaterial[2];
                    newArrayMaterial[3] = arrayMaterial[1];
                    newArrayMaterial[4] = arrayMaterial[0];
                }
                //scale
                string strDragScale = gearEleSP.Attribute("dragScale") != null ? gearEleSP.Attribute("dragScale").Value : "1";
                string strScale = gearEleSP.Attribute("scale") != null ? gearEleSP.Attribute("scale").Value : "1,1,1";
                string strMassScale = gearEleSP.Attribute("massScale") != null ? gearEleSP.Attribute("massScale").Value : "1";
                float[] scaleSP = REW_Func.ReadFloatArrayStr(strScale);
                float scaleAverage = (scaleSP[0] + scaleSP[1] + scaleSP[2]) * 0.333f;
                float[] scaleSR2 = new float[] { 1f, 1f, 1f };//BUG:无法保存起落架缩放
                float size = 0.7f * scaleAverage;

                
                //rotation(same)
                string strRotation = gearEleSP.Attribute("rotation").Value;
                float rotationX = REW_Func.ReadFloatArrayStr(strRotation)[0];
                float rotationY = REW_Func.ReadFloatArrayStr(strRotation)[1];
                float rotationZ = REW_Func.ReadFloatArrayStr(strRotation)[2];
                Matrix4x4 m1 = REW_Func.EulerToMatix(0, 0, 0);
                if (type == 1 || type == 2)
                {
                    m1 = REW_Func.EulerToMatix(0, 180f, 0);
                }
                Matrix4x4 m2 = REW_Func.EulerToMatix(-rotationX, -rotationY, -rotationZ);
                Vector3 euler = REW_Func.MatrixToEuler(m2 * m1);
                strRotation = euler.x + "," + euler.y + "," + euler.z;
                //position
                float[] arrayPosition = REW_Func.ReadFloatArrayStr(gearEleSP.Attribute("position").Value);
                Vector3 position = new Vector3(arrayPosition[0], arrayPosition[1], arrayPosition[2]);
                if (type == 1)
                {
                    Vector4 worldUp = m2 * m1 * new Vector4(0, 0.25f * size, 0, 0);
                    position += new Vector3(worldUp.x, worldUp.y, worldUp.z);
                }
                string strPosition = position.x + "," + position.y + "," + position.z;


                //Offset
                string strForwardOffset;
                string strHeightOffset;
                string strLengthScale;
                string strSideOffset;
                switch (type)
                {
                    case 0:
                        strForwardOffset = "0";
                        strHeightOffset = "1.45";
                        strLengthScale = "0.5";
                        strSideOffset = "0";
                        break;
                    case 1:
                        strForwardOffset = "0";
                        strHeightOffset = "0";
                        strLengthScale = "0.5";
                        strSideOffset = "0";
                        break;
                    case 2:
                        strForwardOffset = "0";
                        strHeightOffset = "0";
                        strLengthScale = "1.25";
                        strSideOffset = "0";
                        break;
                    case 3:
                        strForwardOffset = "0";
                        strHeightOffset = "0";
                        strLengthScale = "1.25";
                        strSideOffset = "0.49999997";
                        break;
                    default:
                        strForwardOffset = "0";
                        strHeightOffset = "0";
                        strLengthScale = "0.5";
                        strSideOffset = "0";
                        break;
                }
                // 对称起落架
                if(type != 0)
                {
                    if (gearEleSP.Element("RetractableLandingGear.State").Attribute("flipped") != null)
                    {
                        if (gearEleSP.Element("RetractableLandingGear.State").Attribute("flipped").Value == "false")
                        {
                            strSideOffset = (-Convert.ToSingle(strSideOffset)).ToString();
                        }
                    }
                }
                


                XElement gearEleSR2 = new XElement("Part",
                    new XAttribute("id", gearEleSP.Attribute("id").Value),
                    new XAttribute("partType", strPartType),
                    new XAttribute("position", strPosition),
                    new XAttribute("rotation", strRotation),
                    new XAttribute("activated", "true"),
                    new XAttribute("activationGroup", "8"),
                    new XAttribute("commandPodId", 1),
                    new XAttribute("materials", newArrayMaterial[0] + "," + newArrayMaterial[1] + "," + newArrayMaterial[2] + "," + newArrayMaterial[3] + "," + newArrayMaterial[4]),
                    new XElement("Drag",
                        new XAttribute("drag", gearEleSP.Attribute("drag").Value),
                        new XAttribute("area", gearEleSP.Attribute("drag").Value)
                    ),
                    new XElement("Config",
                        new XAttribute("dragScale", strDragScale),
                        new XAttribute("massScale", strMassScale),
                        new XAttribute("partCollisionHandling", strPartCollisionHandling),
                        new XAttribute("partScale", scaleSR2[0] + "," + scaleSR2[1] + "," + scaleSR2[2])
                    ),
                    new XElement("LandingGear",
                        new XAttribute("extended", "true"),
                        new XAttribute("forwardOffset", strForwardOffset),
                        new XAttribute("heightOffset", strHeightOffset),
                        new XAttribute("lengthScale", strLengthScale),
                        new XAttribute("sideOffset", strSideOffset),
                        new XAttribute("size", size)
                    ),
                    new XElement("InputController",
                        new XAttribute("inputId", "Turn")
                    ),
                    new XElement("InputController",
                        new XAttribute("inputId", "Motor")
                    )
                );
                //种类
                if (type == 0)
                {
                    gearEleSR2.Add(new XAttribute("WheelStyle", "Wheel-Double"));
                    gearEleSR2.Add(new XAttribute("BayStyle", "Bay-None"));
                    gearEleSR2.Element("LandingGear").Add(new XAttribute("supportArmEnabled", "false"));
                }
                if (type == 1 || type == 2)
                {
                    gearEleSR2.Add(new XAttribute("WheelStyle", "Wheel-Double"));
                }
                if (type == 3)
                {
                    gearEleSR2.Add(new XAttribute("DoorStyle", "Door-Side"));
                }
                totalGearsElementsSR2.Add(gearEleSR2);
            }
            #endregion

            #region =======引擎=======
            List<XElement> totalEnginesElementsSP = new List<XElement>();
            totalEnginesElementsSP.AddRange(jet1ElementsSP);
            totalEnginesElementsSP.AddRange(jet2ElementsSP);
            totalEnginesElementsSP.AddRange(jet4ElementsSP);
            totalEnginesElementsSP.AddRange(jet6ElementsSP);
            totalEnginesElementsSP.AddRange(jet7ElementsSP);

            List<XElement> totalEnginesElementsSR2 = new List<XElement>();
            foreach (XElement engineEleSP in totalEnginesElementsSP)
            {
                //partType
                int type; 
                string strPartType = "JetEngine1";

                switch (engineEleSP.Attribute("partType").Value)
                {
                    case "Engine-Jet-1": type = 0; break;
                    case "Engine-Jet-2": type = 1; break;
                    case "Engine-Jet-4": type = 2; break;
                    case "Engine-Jet-6": type = 3; break;
                    case "Engine-Jet-7": type = 4; break;
                    default: type = 0; break;
                }
                //Collision
                string strDisableCol = engineEleSP.Attribute("disableAircraftCollisions") != null ? engineEleSP.Attribute("disableAircraftCollisions").Value : "false";
                string strPartCollisionHandling;
                switch (strDisableCol)
                {
                    case "true":
                        strPartCollisionHandling = "Never";
                        break;
                    case "false":
                        strPartCollisionHandling = "Default";
                        break;
                    default:
                        strPartCollisionHandling = "Default";
                        break;
                }
                //materials
                int[] arrayMaterial = REW_Func.ReadIntArrayStr(engineEleSP.Attribute("materials").Value);
                //scale
                string strDragScale = engineEleSP.Attribute("dragScale") != null ? engineEleSP.Attribute("dragScale").Value : "1";
                string strScale = engineEleSP.Attribute("scale") != null ? engineEleSP.Attribute("scale").Value : "1,1,1";
                string strMassScale = engineEleSP.Attribute("massScale") != null ? engineEleSP.Attribute("massScale").Value : "1";
                float[] scaleSP = REW_Func.ReadFloatArrayStr(strScale);
                if (type == 3)
                {
                    scaleSP[2] *= 0.5f;
                }
                else if(type == 4)
                {
                    scaleSP[2] *= 1.25f;
                }
                float[] scaleSR2 = new float[] { scaleSP[0], scaleSP[2], scaleSP[1] };
                
                //rotation(same)
                string strRotation = engineEleSP.Attribute("rotation").Value;
                float rotationX = REW_Func.ReadFloatArrayStr(strRotation)[0];
                float rotationY = REW_Func.ReadFloatArrayStr(strRotation)[1];
                float rotationZ = REW_Func.ReadFloatArrayStr(strRotation)[2];
                Matrix4x4 m1 = REW_Func.EulerToMatix(-90f, 0, 0);
                Matrix4x4 m2 = REW_Func.EulerToMatix(-rotationX, -rotationY, -rotationZ);
                Vector3 euler = REW_Func.MatrixToEuler(m2 * m1);
                strRotation = euler.x + "," + euler.y + "," + euler.z;
                //Engines
                string strBottomScale;
                string strOffset;
                string strTopScale;
                string strBypassRatio;
                string strCompressionRatio;
                string strHasAfterBurner;
                string strMass;
                string strPrice;
                string strShroudCurvature;
                string strShroudLength;
                string strSize;
                switch (type)
                {
                    case 0:
                        strBottomScale = "0.25,0.25";
                        strOffset = "0,0.5743403,0";
                        strTopScale = "0.25,0.25";
                        strBypassRatio = "0";
                        strCompressionRatio = "7.5";
                        strHasAfterBurner = "false";
                        strMass = "1.368409";
                        strPrice = "482504";
                        strShroudCurvature = "1";
                        strShroudLength = "1";
                        strSize = "0.5";
                        break;
                    case 1:
                        strBottomScale = "0.25,0.25";
                        strOffset = "0,1.148091,0";
                        strTopScale = "0.25,0.25";
                        strBypassRatio = "0";
                        strCompressionRatio = "30";
                        strHasAfterBurner = "true";
                        strMass = "2.097504";
                        strPrice = "761419";
                        strShroudCurvature = "1";
                        strShroudLength = "1";
                        strSize = "0.5";
                        break;
                    case 2:
                        strBottomScale = "0.3491054,0.3491054";
                        strOffset = "0,0.8516912,0";
                        strTopScale = "0.5,0.5";
                        strBypassRatio = "1.80000007";
                        strCompressionRatio = "10";
                        strHasAfterBurner = "false";
                        strMass = "3.97522783";
                        strPrice = "1020211";
                        strShroudCurvature = "0.75";
                        strShroudLength = "1.07999992";
                        strSize = "1";
                        break;
                    case 3:
                        strBottomScale = "0.5,0.5";
                        strOffset = "0,1.211181,0";
                        strTopScale = "0.5,0.5";
                        strBypassRatio = "0";
                        strCompressionRatio = "10";
                        strHasAfterBurner = "false";
                        strMass = "11.3890581";
                        strPrice = "4056385";
                        strShroudCurvature = "1";
                        strShroudLength = "1";
                        strSize = "1";
                        break;
                    case 4:
                        strBottomScale = "0.5012461,0.5012461";
                        strOffset = "0,0.9743623,0";
                        strTopScale = "0.75,0.75";
                        strBypassRatio = "4";
                        strCompressionRatio = "10";
                        strHasAfterBurner = "false";
                        strMass = "9.472083";
                        strPrice = "1827905";
                        strShroudCurvature = "0.599999964";
                        strShroudLength = "1.03";
                        strSize = "1.5";
                        break;
                    default:
                        strBottomScale = "0.25,0.25";
                        strOffset = "0,0.5743403,0";
                        strTopScale = "0.25,0.25";
                        strBypassRatio = "0";
                        strCompressionRatio = "7.5";
                        strHasAfterBurner = "false";
                        strMass = "1.368409";
                        strPrice = "482504";
                        strShroudCurvature = "1";
                        strShroudLength = "1";
                        strSize = "0.5";
                        break;
                }
                //Input
                string strAG = engineEleSP.Element("InputController.State").Attribute("activationGroup").Value;



                XElement engineEleSR2 = new XElement("Part",
                    new XAttribute("id", engineEleSP.Attribute("id").Value),
                    new XAttribute("partType", strPartType),
                    new XAttribute("position", engineEleSP.Attribute("position").Value),
                    new XAttribute("rotation", strRotation),
                    new XAttribute("activationGroup", strAG),
                    new XAttribute("commandPodId", 1),
                    new XAttribute("materials", arrayMaterial[0] + "," + arrayMaterial[1] + "," + arrayMaterial[2] + "," + arrayMaterial[0] + "," + arrayMaterial[0]),
                    new XAttribute("wheelStyle", "LandingGearRim"),
                    new XAttribute("tireStyle", "RoverTireLandingGear"),
                    new XElement("Drag",
                        new XAttribute("drag", engineEleSP.Attribute("drag").Value),
                        new XAttribute("area", engineEleSP.Attribute("drag").Value)
                    ),
                    new XElement("Config",
                        new XAttribute("dragScale", strDragScale),
                        new XAttribute("massScale", strMassScale),
                        new XAttribute("partCollisionHandling", strPartCollisionHandling),
                        new XAttribute("partScale", scaleSR2[0] + "," + scaleSR2[1] + "," + scaleSR2[2])
                    ),
                    new XElement("Fuselage",
                        new XAttribute("bottomScale", strBottomScale),
                        new XAttribute("offset", strOffset),
                        new XAttribute("topScale", strTopScale)
                    ),
                    new XElement("JetEngine",
                        new XAttribute("bypassRatio", strBypassRatio),
                        new XAttribute("compressionRatio", strCompressionRatio),
                        new XAttribute("hasAfterburner", strHasAfterBurner),
                        new XAttribute("mass", strMass),
                        new XAttribute("price", strPrice),
                        new XAttribute("shroudCurvature", strShroudCurvature),
                        new XAttribute("shroudLength", strShroudLength),
                        new XAttribute("size", strSize)
                    ),
                    new XElement("Inlet"),
                    new XElement("InputController",
                        new XAttribute("inputId", "Thrust Reverse")
                    )
                );
                //引擎样式
                if(type == 0 || type == 1 || type ==2)
                {
                    engineEleSR2.Add(new XAttribute("nozzleStyle", "Basic"));
                }
                else if(type == 4)
                {
                    engineEleSR2.Add(new XAttribute("shroudStyle", "JetEngineShroud-2"));
                    engineEleSR2.Add(new XAttribute("nozzleStyle", "Civilian"));
                }
                totalEnginesElementsSR2.Add(engineEleSR2);
            }
            #endregion

            #region =======连接点=======
            //-----------------------------------------转换Connections------------------------------------
            List<XElement> connElementsSR2 = new List<XElement>();
            foreach (XElement connEleSP in connElementsSP)
            {
                string PartIdA = connEleSP.Attribute("partA").Value;
                string PartIdB = connEleSP.Attribute("partB").Value;
                string partTypeA = partsElementsSP.Find(x => x.Attribute("id").Value == PartIdA).Attribute("partType").Value;
                string partTypeB = partsElementsSP.Find(x => x.Attribute("id").Value == PartIdB).Attribute("partType").Value;
                

                int[] connsA = REW_Func.ReadIntArrayStr(connEleSP.Attribute("attachPointsA").Value);
                int[] connsB = REW_Func.ReadIntArrayStr(connEleSP.Attribute("attachPointsB").Value);
                int[] connsNewA;
                bool isValidA = ChangeConnections(connsA, partTypeA, out connsNewA);
                int[] connsNewB;
                bool isValidB = ChangeConnections(connsB, partTypeB, out connsNewB);
                


                if (!isValidA || !isValidB)
                {
                    continue;
                }
                XElement connEleSR2 = new XElement("Connection",
                    new XAttribute("partA", connEleSP.Attribute("partA").Value),
                    new XAttribute("partB", connEleSP.Attribute("partB").Value),
                    new XAttribute("attachPointsA", REW_Func.ArrayToString(connsNewA)),
                    new XAttribute("attachPointsB", REW_Func.ArrayToString(connsNewB))
                    );
                connElementsSR2.Add(connEleSR2);
            }
            #endregion

            XDocument document = XDocument.Parse(Properties.Resources.Example);
            XElement partsEle = document.Element("Craft").Element("Assembly").Element("Parts");
            XElement connsEle = document.Element("Craft").Element("Assembly").Element("Connections");
            XElement commandPod = partsEle.Elements().ToList().Find(x => x.Attribute("partType").Value == "CommandPod1");
            commandPod.Attribute("id").SetValue("1");
            partsEle.Add(totalBlocksElementsSR2);
            partsEle.Add(totalFuselageElementsSR2);
            partsEle.Add(totalWingsElementsSR2);
            partsEle.Add(totalRotatorsElementsSR2);
            partsEle.Add(totalShockElementsSR2);
            partsEle.Add(totalPistonElementsSR2);
            partsEle.Add(totalWheelsElementsSR2);
            partsEle.Add(totalGearsElementsSR2);
            partsEle.Add(totalEnginesElementsSR2);
            connsEle.Add(connElementsSR2);

            #region ---------------------------材质------------------------------------
            List<XElement> materialsElements = documentSP.Element("Aircraft").Element("Theme").Elements("Material").ToList();
            foreach(XElement material in materialsElements)
            {
                if (material.Attribute("r") != null) material.Attribute("r").Remove();
                document.Element("Craft").Element("DesignerSettings").Element("Theme").Add(material);
                document.Element("Craft").Element("Themes").Element("Theme").Add(material);
            }
            #endregion

            #region ---------------------------名称------------------------------------
            document.Element("Craft").Attribute("name").SetValue("Export");
            #endregion

            document.Save(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Export.xml");
        }

        






        /// <summary>
        ///转换连接点
        /// </summary>
        /// <param name="conns"></param>
        /// <param name="partType"></param>
        /// <param name="newConns"></param>
        /// <returns></returns>
        public bool ChangeConnections(int[] conns, string partType, out int[] newConns)
        {
            newConns = new int[conns.Length];
            bool isValid = true;
            switch (partType)
            {
                case "Fuselage-Body-1":
                    for (int i = 0; i < conns.Length; i++)
                    {
                        switch (conns[i])
                        {
                            case 0: newConns[i] = 2; break;
                            case 1: newConns[i] = 1; break;
                            default: newConns[i] = 0; break;
                        }
                    }
                    break;
                case "Fuselage-Hollow-1":
                    for (int i = 0; i < conns.Length; i++)
                    {
                        switch (conns[i])
                        {
                            case 0: newConns[i] = 1; break;
                            case 1: newConns[i] = 0; break;
                            default: newConns[i] = 0; break;
                        }
                    }
                    break;
                case "Fuselage-Cone-1":
                    for (int i = 0; i < conns.Length; i++)
                    {
                        newConns[i] = 1;
                    }
                    break;
                case "Fuselage-Inlet-1":
                    for (int i = 0; i < conns.Length; i++)
                    {
                        switch (conns[i])
                        {
                            case 0: newConns[i] = 1; break;
                            case 1: newConns[i] = 0; break;
                            default: newConns[i] = 0; break;
                        }
                    }
                    break;
                case "Wing-2":
                    for (int i = 0; i < conns.Length; i++)
                    {
                        switch (conns[i])
                        {
                            case 0: newConns[i] = 1; break;
                            case 1: newConns[i] = 0; break;
                            default: newConns[i] = 0; break;
                        }
                    }
                    break;
                case "Wing-3":
                    for (int i = 0; i < conns.Length; i++)
                    {
                        switch (conns[i])
                        {
                            case 0: newConns[i] = 1; break;
                            case 1: newConns[i] = 0; break;
                            default: newConns[i] = 0; break;
                        }
                    }
                    break;
                case "Wing-1":
                    for (int i = 0; i < conns.Length; i++)
                    {
                        switch (conns[i])
                        {
                            case 0: newConns[i] = 1; break;
                            case 1: newConns[i] = 0; break;
                            default: newConns[i] = 0; break;
                        }
                    }
                    break;
                case "HingeRotator-1":
                    for (int i = 0; i < conns.Length; i++)
                    {
                        newConns[i] = conns[i];
                    }
                    break;
                case "SmallRotator-1":
                    for (int i = 0; i < conns.Length; i++)
                    {
                        newConns[i] = conns[i];
                    }
                    break;
                case "Block-1":
                    for (int i = 0; i < conns.Length; i++)
                    {
                        switch (conns[i])
                        {
                            case 0: newConns[i] = 4; break;
                            case 1: newConns[i] = 5; break;
                            case 2: newConns[i] = 0; break;
                            case 3: newConns[i] = 1; break;
                            case 4: newConns[i] = 2; break;
                            case 5: newConns[i] = 3; break;
                            default: newConns[i] = 0; break;
                        }
                    }
                    break;
                case "Block-2":
                    for (int i = 0; i < conns.Length; i++)
                    {
                        switch (conns[i])
                        {
                            case 0: newConns[i] = 4; break;
                            case 1: newConns[i] = 5; break;
                            case 2: newConns[i] = 0; break;
                            case 3: newConns[i] = 1; break;
                            case 4: newConns[i] = 2; break;
                            case 5: newConns[i] = 3; break;
                            default: newConns[i] = 0; break;
                        }
                    }
                    break;
                case "Shock":
                    for (int i = 0; i < conns.Length; i++)
                    {
                        newConns[i] = conns[i];
                    }
                    break;
                case "Piston":
                    for (int i = 0; i < conns.Length; i++)
                    {
                        newConns[i] = conns[i];
                    }
                    break;
                case "Wheel-Resizable-1":
                    for (int i = 0; i < conns.Length; i++)
                    {
                        newConns[i] = conns[i];
                    }
                    break;
                case "JointRotator-1":
                    for (int i = 0; i < conns.Length; i++)
                    {
                        if (conns[i] == 0)
                        {
                            newConns[i] = 0;
                        }
                        else
                        {
                            newConns[i] = 1;
                        }
                        
                    }
                    break;
                case "Engine-Jet-1":
                    for (int i = 0; i < conns.Length; i++)
                    {
                        newConns[i] = 2;
                    }
                    break;
                case "Engine-Jet-2":
                    for (int i = 0; i < conns.Length; i++)
                    {
                        newConns[i] = 2;
                    }
                    break;
                case "Engine-Jet-4":
                    for (int i = 0; i < conns.Length; i++)
                    {
                        newConns[i] = 2;
                    }
                    break;
                case "Engine-Jet-6":
                    for (int i = 0; i < conns.Length; i++)
                    {
                        newConns[i] = 2;
                    }
                    break;
                case "Engine-Jet-7":
                    for (int i = 0; i < conns.Length; i++)
                    {
                        newConns[i] = 2;
                    }
                    break;
                case "Wheel-1":
                    for (int i = 0; i < conns.Length; i++)
                    {
                        newConns[i] = 0;
                    }
                    break;
                case "Wheel-2":
                    for (int i = 0; i < conns.Length; i++)
                    {
                        newConns[i] = 0;
                    }
                    break;
                case "Wheel-3":
                    for (int i = 0; i < conns.Length; i++)
                    {
                        newConns[i] = 0;
                    }
                    break;
                case "Wheel-5":
                    for (int i = 0; i < conns.Length; i++)
                    {
                        newConns[i] = 0;
                    }
                    break;
                default:
                    isValid = false;
                    break;
            }
            return isValid;
        }

        
    }
}
