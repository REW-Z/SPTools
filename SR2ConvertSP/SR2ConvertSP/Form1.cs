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

namespace SR2ConvertSP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            //MessageBox.Show(REW_Func.ArrayToString(new int[] { 2,4,6 }));
            textBoxPathSR2.Text = "C:\\Users\\" + Environment.UserName + "\\AppData\\LocalLow\\Jundroo\\SimpleRockets 2\\UserData\\CraftDesigns\\*.xml";
        }


        private void button1_Click(object sender, EventArgs e)
        {
            XDocument documentSR2 = XDocument.Load(textBoxPathSR2.Text);
            List<XElement> partsElementsSR2 = documentSR2.Element("Craft").Element("Assembly").Element("Parts").Elements("Part").ToList();

            //List<XElement> block1ElementsSP = partsElementsSP.FindAll(x => x.Attribute("partType").Value == "Block-1");
            //List<XElement> block2ElementsSP = partsElementsSP.FindAll(x => x.Attribute("partType").Value == "Block-2");

            List<XElement> fuselageElementsSR2 = partsElementsSR2.FindAll(x => x.Attribute("partType").Value == "Fuselage1");
            List<XElement> inletFuselageElementsSR2 = partsElementsSR2.FindAll(x => x.Attribute("partType").Value == "Inlet1");
            List<XElement> structFuselageElementsSR2 = partsElementsSR2.FindAll(x => x.Attribute("partType").Value == "Strut1");


            #region =======圆筒=======
            //--------------------------------------转换FuselageBody\FuselageCone--------------------------------------------
            List<XElement> totalFuselageElementsSR2 = new List<XElement>();
            totalFuselageElementsSR2.AddRange(fuselageElementsSR2);
            totalFuselageElementsSR2.AddRange(inletFuselageElementsSR2);
            totalFuselageElementsSR2.AddRange(structFuselageElementsSR2);


            List<XElement> totalFuselageElementsSP = new List<XElement>();
            foreach (XElement fuselageEleSR2 in totalFuselageElementsSR2)
            {
                //partType
                int type; //0-fuselage 1-hollowFuselage 2-cone
                string strPartType = "";
                switch (fuselageEleSR2.Attribute("partType").Value)
                {
                    case "Fuselage1": strPartType = "Fuselage-Body-1"; type = 1; break;
                    case "Inlet1": strPartType = "Fuselage-Hollow-1"; type = 2; break;
                    case "Struct1": strPartType = "Fuselage-Body-1"; type = 3; break;
                    default: strPartType = "Fuselage-Body-1"; type = 0; break;
                }

                ////Collision
                //string strDisableCol = fuselageEleSR2.Attribute("disableAircraftCollisions") != null ? fuselageEleSR2.Attribute("disableAircraftCollisions").Value : "false";
                //string strPartCollisionHandling;
                //switch (strDisableCol)
                //{
                //    case "true":
                //        strPartCollisionHandling = "Never";
                //        break;
                //    case "false":
                //        strPartCollisionHandling = "Default";
                //        break;
                //    default:
                //        strPartCollisionHandling = "Default";
                //        break;
                //}

                //materials
                int[] arrayMaterial = REW_Func.ReadIntArrayStr(fuselageEleSR2.Attribute("materials").Value);
                //scale
                string strPartScale = fuselageEleSR2.Element("Config").Attribute("partScale") != null ? fuselageEleSR2.Element("Config").Attribute("partScale").Value : "1,1,1";
                float[] scaleSR2 = REW_Func.ReadFloatArrayStr(strPartScale);
                float[] scaleSP = new float[] { scaleSR2[0], scaleSR2[2], scaleSR2[1] }; ; //SP2SR:1-3-2  SR2SP: 1-3-2

                //sectionScale
                string strBottom = fuselageEleSR2.Element("Fuselage").Attribute("bottomScale").Value;
                string strTop = fuselageEleSR2.Element("Fuselage").Attribute("topScale").Value;
                float bottom1 = REW_Func.ReadFloatArrayStr(strBottom)[0] * 4f; //SP2SR : 0.25f
                float bottom2 = REW_Func.ReadFloatArrayStr(strBottom)[1] * 4f;
                float top1 = REW_Func.ReadFloatArrayStr(strTop)[0] * 4f;
                float top2 = REW_Func.ReadFloatArrayStr(strTop)[1] * 4f;

                //offset
                string strOffset = fuselageEleSR2.Element("Fuselage").Attribute("offset").Value;
                float offset1 = REW_Func.ReadFloatArrayStr(strOffset)[0] * 4f;
                float offset2 = REW_Func.ReadFloatArrayStr(strOffset)[1] * 4f;
                float offset3 = REW_Func.ReadFloatArrayStr(strOffset)[2] * 4f;
                if (true)
                {
                    offset1 = -offset1;
                    //offset3 = -offset3;
                }

                //rotation
                string strRotation = fuselageEleSR2.Attribute("rotation").Value;
                float rotationX = REW_Func.ReadFloatArrayStr(strRotation)[0];
                float rotationY = REW_Func.ReadFloatArrayStr(strRotation)[1];
                float rotationZ = REW_Func.ReadFloatArrayStr(strRotation)[2];
                Matrix4x4 m1 = REW_Func.EulerToMatix(90f, 0, 0);
                Matrix4x4 m2 = REW_Func.EulerToMatix(-rotationX, -rotationY, -rotationZ);
                Vector3 euler = REW_Func.MatrixToEuler(m2 * m1);
                strRotation = euler.x + "," + euler.y + "," + euler.z;

                //cornertype
                string strCornerRads;
                if (fuselageEleSR2.Element("Fuselage").Attribute("cornerRadiuses") != null)
                {
                    strCornerRads = fuselageEleSR2.Element("Fuselage").Attribute("cornerRadiuses").Value;
                }
                else
                {
                    strCornerRads = "1,1,1,1,1,1,1,1";
                }
                float[] cornerRads = REW_Func.ReadFloatArrayStr(strCornerRads);
                int[] cornerTypes = new int[8];

                cornerTypes[0] = (int)Math.Ceiling(cornerRads[2] * 3);
                cornerTypes[1] = (int)Math.Ceiling(cornerRads[1] * 3);
                cornerTypes[2] = (int)Math.Ceiling(cornerRads[0] * 3);
                cornerTypes[3] = (int)Math.Ceiling(cornerRads[3] * 3);
                cornerTypes[4] = (int)Math.Ceiling(cornerRads[6] * 3);
                cornerTypes[5] = (int)Math.Ceiling(cornerRads[5] * 3);
                cornerTypes[6] = (int)Math.Ceiling(cornerRads[4] * 3);
                cornerTypes[7] = (int)Math.Ceiling(cornerRads[7] * 3);



                //???


                ////deadWeight
                //string strDeadWeight = fuselageEleSR2.Element("Fuselage.State").Attribute("deadWeight").Value;
                //float deadWeight = Convert.ToSingle(strDeadWeight);
                ////fuelPercentage
                //string strFuelPercentage = fuselageEleSR2.Element("Fuselage.State").Attribute("fuelPercentage").Value;
                //float fuelPercentage = Convert.ToSingle(strFuelPercentage);




                XElement fuselageEleSPnew = new XElement("Part",
                    new XAttribute("id", fuselageEleSR2.Attribute("id").Value),
                    new XAttribute("partType", strPartType),
                    new XAttribute("position", fuselageEleSR2.Attribute("position").Value),
                    new XAttribute("rotation", strRotation),
                    new XAttribute("materials", arrayMaterial[0] + "," + arrayMaterial[1] + "," + arrayMaterial[2]),
                    new XAttribute("drag", "0,0,0,0,0,0"),
                    new XAttribute("scale", scaleSP[0] + "," + scaleSP[1] + "," + scaleSP[2]),

                    new XElement("FuelTank.State",
                        new XAttribute("fuel", "0"),
                        new XAttribute("capacity", "0")//fuel="0" capacity="0" 
                    ),
                    new XElement("Fuselage.State",
                        new XAttribute("version", "2"),
                        new XAttribute("rearScale", bottom1 + "," + bottom2),
                        new XAttribute("cornerTypes", REW_Func.ArrayToString(cornerTypes)),
                        new XAttribute("deadWeight", "0"),
                        new XAttribute("buoyancy", "0"),
                        new XAttribute("fuelPercentage", "0"),
                        new XAttribute("offset", offset1 + "," + offset3 + "," + offset2),
                        new XAttribute("frontScale", top1 + "," + top2)
                    )
                );
                totalFuselageElementsSP.Add(fuselageEleSPnew);
                
            }
            #endregion


            XDocument document = XDocument.Parse(Properties.Resources.ExportTemplateSP);
            XElement partsEle = document.Element("Aircraft").Element("Assembly").Element("Parts");
            //XElement connsEle = document.Element("Craft").Element("Assembly").Element("Connections");
            XElement cockpit = partsEle.Elements().ToList().Find(x => x.Attribute("partType").Value == "Cockpit-1");
            cockpit.Attribute("id").SetValue("1");
            partsEle.Add(totalFuselageElementsSP);
            //connsEle.Add(connElementsSR2);


            #region ---------------------------材质------------------------------------
            List<XElement> materialsElements = documentSR2.Element("Craft").Element("DesignerSettings").Element("Theme").Elements("Material").ToList();
            foreach (XElement material in materialsElements)
            {
                material.Add(new XAttribute("r", "0"));
                document.Element("Aircraft").Element("Theme").Add(material);
            }
            #endregion

            #region ---------------------------名称------------------------------------
            document.Element("Aircraft").Attribute("name").SetValue("Export");
            #endregion

            document.Save(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Export.xml");
        }
    }
}
