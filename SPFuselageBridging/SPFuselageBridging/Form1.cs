using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SPFuselageBridging
{
    public partial class Form1 : Form
    {
        private List<Fuselage> fuselages;
        private List<Bridge> bridges;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBoxPath.Text = "C:\\Users\\" + Environment.UserName + "\\AppData\\LocalLow\\Jundroo\\SimplePlanes\\AircraftDesigns\\*.xml";
        }
        
        /// <summary>
        /// 框架生成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonFrame_Click(object sender, EventArgs e)
        {
            XDocument document = XDocument.Load(textBoxPath.Text);
            XElement partsEle = document.Element("Aircraft").Element("Assembly").Element("Parts");
            List<XElement> partsElements = document.Element("Aircraft").Element("Assembly").Element("Parts").Elements("Part").ToList();

            fuselages = new List<Fuselage>();

            foreach (XElement part in partsElements)
            {
                if (part.Attribute("partType").Value == "Fuselage-Body-1")
                {
                    if (part.Attribute("materials").Value == "14")
                    {
                        Fuselage fuselage = new Fuselage();
                        float[] pos = REW_Func.ReadFloatArrayStr(part.Attribute("position").Value);
                        fuselage.position = new Vector3(pos[0], pos[1], pos[2]);
                        float[] rot = REW_Func.ReadFloatArrayStr(part.Attribute("rotation").Value);
                        fuselage.rotationEuler = new Vector3(rot[0], rot[1], rot[2]);
                        float[] frontScale = REW_Func.ReadFloatArrayStr(part.Element("Fuselage.State").Attribute("frontScale").Value);
                        float[] rearScale = REW_Func.ReadFloatArrayStr(part.Element("Fuselage.State").Attribute("rearScale").Value);
                        float[] offset = REW_Func.ReadFloatArrayStr(part.Element("Fuselage.State").Attribute("offset").Value);
                        fuselage.sectionL = new Vector2(frontScale[0], frontScale[1]);
                        fuselage.sectionR = new Vector2(rearScale[0], rearScale[1]);
                        fuselage.run = offset[0];
                        fuselage.rise = offset[1];
                        fuselage.length = offset[2];
                        fuselage.cornerTypes = REW_Func.ReadIntArrayStr(part.Element("Fuselage.State").Attribute("cornerTypes").Value);

                        fuselages.Add(fuselage);
                    }
                }
            }

            foreach (Fuselage fuselage in fuselages)
            {
                int[] cornersL = new int[] { fuselage.cornerTypes[0], fuselage.cornerTypes[1], fuselage.cornerTypes[2], fuselage.cornerTypes[3], fuselage.cornerTypes[0], fuselage.cornerTypes[1], fuselage.cornerTypes[2], fuselage.cornerTypes[3] };
                int[] cornersR = new int[] { fuselage.cornerTypes[4], fuselage.cornerTypes[5], fuselage.cornerTypes[6], fuselage.cornerTypes[7], fuselage.cornerTypes[4], fuselage.cornerTypes[5], fuselage.cornerTypes[6], fuselage.cornerTypes[7] };


                int lastIndex; int.TryParse((partsEle.Elements("Part").LastOrDefault().Attribute("id").Value), out lastIndex);
                partsEle.Add(new XElement("Part", new XAttribute("id", (lastIndex + 1)),
                new XAttribute("partType", "Fuselage-Body-1"),
                new XAttribute("position", fuselage.PosL().ToString()),
                new XAttribute("rotation", fuselage.rotationEuler.ToString()),
                new XAttribute("drag", "0,0,0,0,0,0"),
                new XAttribute("materials", "0"),
                new XAttribute("partCollisionResponse", "Default"),
                new XElement("FuelTank.State", new XAttribute("fuel", "0"), new XAttribute("capacity", "0")),
                new XElement("Fuselage.State", new XAttribute("version", "2"),
                    new XAttribute("frontScale", fuselage.sectionL.ToString()),
                    new XAttribute("rearScale", fuselage.sectionL.ToString()),
                    new XAttribute("offset", 0f + "," + 0f + "," + 0.05f),
                    new XAttribute("deadWeight", "0"),
                    new XAttribute("buoyancy", "0"),
                    new XAttribute("fuelPercentage", "0"),
                    new XAttribute("autoSizeOnConnected", "false"),
                    new XAttribute("cornerTypes", REW_Func.ArrayToString(cornersL))
                )));

                int.TryParse((partsEle.Elements("Part").LastOrDefault().Attribute("id").Value), out lastIndex);
                partsEle.Add(new XElement("Part", new XAttribute("id", (lastIndex + 1)),
                new XAttribute("partType", "Fuselage-Body-1"),
                new XAttribute("position", fuselage.PosR().ToString()),
                new XAttribute("rotation", fuselage.rotationEuler.ToString()),
                new XAttribute("drag", "0,0,0,0,0,0"),
                new XAttribute("materials", "1"),
                new XAttribute("partCollisionResponse", "Default"),
                new XElement("FuelTank.State", new XAttribute("fuel", "0"), new XAttribute("capacity", "0")),
                new XElement("Fuselage.State", new XAttribute("version", "2"),
                    new XAttribute("frontScale", fuselage.sectionR.ToString()),
                    new XAttribute("rearScale", fuselage.sectionR.ToString()),
                    new XAttribute("offset", 0f + "," + 0f + "," + 0.05f),
                    new XAttribute("deadWeight", "0"),
                    new XAttribute("buoyancy", "0"),
                    new XAttribute("fuelPercentage", "0"),
                    new XAttribute("autoSizeOnConnected", "false"),
                    new XAttribute("cornerTypes", REW_Func.ArrayToString(cornersR))
                )));

            }
            document.Save(textBoxPath.Text.Trim());
        }

        /// <summary>
        /// 桥接生成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonBridge_Click(object sender, EventArgs e)
        {
            XDocument document = XDocument.Load(textBoxPath.Text);
            XElement partsEle = document.Element("Aircraft").Element("Assembly").Element("Parts");
            List<XElement> partsElements = document.Element("Aircraft").Element("Assembly").Element("Parts").Elements("Part").ToList();

            List<Fuselage> frameFuselages = new List<Fuselage>();
            bridges = new List<Bridge>();

            foreach (XElement part in partsElements)
            {
                if (part.Attribute("partType").Value == "Fuselage-Body-1")
                {
                    if (part.Attribute("materials").Value == "14")
                    {
                        Fuselage frameFuselage = new Fuselage();
                        float[] pos = REW_Func.ReadFloatArrayStr(part.Attribute("position").Value);
                        frameFuselage.position = new Vector3(pos[0], pos[1], pos[2]);
                        float[] rot = REW_Func.ReadFloatArrayStr(part.Attribute("rotation").Value);
                        frameFuselage.rotationEuler = new Vector3(rot[0], rot[1], rot[2]);
                        float[] frontScale = REW_Func.ReadFloatArrayStr(part.Element("Fuselage.State").Attribute("frontScale").Value);
                        float[] rearScale = REW_Func.ReadFloatArrayStr(part.Element("Fuselage.State").Attribute("rearScale").Value);
                        float[] offset = REW_Func.ReadFloatArrayStr(part.Element("Fuselage.State").Attribute("offset").Value);
                        frameFuselage.sectionL = new Vector2(frontScale[0], frontScale[1]);
                        frameFuselage.sectionR = new Vector2(rearScale[0], rearScale[1]);
                        frameFuselage.run = offset[0];
                        frameFuselage.rise = offset[1];
                        frameFuselage.length = offset[2];
                        frameFuselage.cornerTypes = REW_Func.ReadIntArrayStr(part.Element("Fuselage.State").Attribute("cornerTypes").Value);

                        frameFuselages.Add(frameFuselage);
                    }
                }
            }

            foreach(Fuselage frameFuselage in frameFuselages)
            {
                bool isNew = true;
                foreach(Bridge bridge in bridges)
                {
                    float error = (bridge.fuselageL.rotationEuler - frameFuselage.rotationEuler).Magnitude;
                    if(error <= 1.0f)
                    {
                        isNew = false;
                        bridge.fuselageR = frameFuselage;
                    }
                }

                if (isNew)
                {
                    Bridge bridgeNew = new Bridge();
                    bridgeNew.fuselageL = frameFuselage;
                    bridgeNew.fuselageR = null;
                    bridges.Add(bridgeNew);
                }
                
            }

            foreach(Bridge bridge in bridges)
            {
                if(bridge.fuselageL != null && bridge.fuselageR != null)
                {
                    Vector3 startEndVector = bridge.fuselageR.position - bridge.fuselageL.position;

                    Vector3 rightVec = bridge.fuselageL.Right();
                    Vector3 upVec = bridge.fuselageL.Up();
                    Vector3 forwardVec = bridge.fuselageL.Forward();

                    float run = Vector3.Dot(startEndVector, rightVec) * 2f;
                    float rise = Vector3.Dot(startEndVector, upVec) * 2f;
                    float length = Vector3.Dot(startEndVector, forwardVec) * 2f;

                    Fuselage result = new Fuselage();
                    result.sectionL = bridge.fuselageL.sectionL;
                    result.sectionR = bridge.fuselageR.sectionR;
                    result.run = run;
                    result.rise = rise;
                    result.length = length;
                    result.rotationEuler = bridge.fuselageL.rotationEuler;
                    result.position = (bridge.fuselageL.position + bridge.fuselageR.position) * 0.5f;
                    //拐角处理
                    int[] cornersL = bridge.fuselageL.cornerTypes;
                    int[] cornersR = bridge.fuselageR.cornerTypes;
                    result.cornerTypes = new int[8] { cornersL[0], cornersL[1], cornersL[2], cornersL[3], cornersR[0], cornersR[1], cornersR[2], cornersR[3] };

                    //反向圆筒处理
                    if (result.length < 0)
                    {
                        result.length *= -1f;
                        result.run *= -1f;
                        result.rise *= -1f;

                        Vector2 temp = result.sectionL;
                        result.sectionL = result.sectionR;
                        result.sectionR = temp;

                        int[] newCorners = new int[8] { result.cornerTypes[4], result.cornerTypes[5], result.cornerTypes[6], result.cornerTypes[7], result.cornerTypes[0], result.cornerTypes[1], result.cornerTypes[2], result.cornerTypes[3] };
                        result.cornerTypes = newCorners;
                    }


                    int lastIndex; int.TryParse((partsEle.Elements("Part").LastOrDefault().Attribute("id").Value), out lastIndex);
                    partsEle.Add(new XElement("Part", new XAttribute("id", (lastIndex + 1)),
                        new XAttribute("partType", "Fuselage-Body-1"),
                        new XAttribute("position", result.position.ToString()),
                        new XAttribute("rotation", result.rotationEuler.ToString()),
                        new XAttribute("drag", "0,0,0,0,0,0"),
                        new XAttribute("materials", "0"),
                        new XAttribute("partCollisionResponse", "Default"),
                        new XElement("FuelTank.State", new XAttribute("fuel", "0"), new XAttribute("capacity", "0")),
                        new XElement("Fuselage.State", new XAttribute("version", "2"),
                            new XAttribute("frontScale", result.sectionL.ToString()),
                            new XAttribute("rearScale", result.sectionR.ToString()),
                            new XAttribute("offset", result.run + "," + result.rise + "," + result.length),
                            new XAttribute("deadWeight", "0"),
                            new XAttribute("buoyancy", "0"),
                            new XAttribute("fuelPercentage", "0"),
                            new XAttribute("autoSizeOnConnected", "false"),
                            new XAttribute("cornerTypes", REW_Func.ArrayToString(result.cornerTypes))
                        )));
                }//if
            }//foreachBridges

            document.Save(textBoxPath.Text.Trim());
        }
    }
}
