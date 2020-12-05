using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;


namespace PartIdSort
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBoxPath.Text = "C:\\Users\\" + Environment.UserName + "\\AppData\\LocalLow\\Jundroo\\SimplePlanes\\AircraftDesigns\\*.xml";
            textBoxPathJoin.Text = "C:\\Users\\" + Environment.UserName + "\\AppData\\LocalLow\\Jundroo\\SimplePlanes\\AircraftDesigns\\*.xml";
        }

        private void buttonSort_Click(object sender, EventArgs e)
        {
            XDocument document = XDocument.Load(textBoxPath.Text);
            List<XElement> partElemets = document.Element("Aircraft").Element("Assembly").Element("Parts").Elements("Part").ToList();
            List<XElement> connectionsElemets = document.Element("Aircraft").Element("Assembly").Element("Connections").Elements("Connection").ToList();
            
            int count = partElemets.Count;
            for(int i = 0; i < count; i++)
            {
                string previousId = partElemets[i].Attribute("id").Value;
                partElemets[i].Attribute("id").SetValue(i + 1);
                foreach(XElement connEle in connectionsElemets)
                {
                    if(connEle.Attribute("partA").Value == previousId)
                    {
                        connEle.Attribute("partA").SetValue(i + 1);
                    }
                    else if (connEle.Attribute("partB").Value == previousId)
                    {
                        connEle.Attribute("partB").SetValue(i + 1);
                    }
                }
                
            }
            document.Save(textBoxPath.Text);
        }

        private void buttonDisableCol_Click(object sender, EventArgs e)
        {
            XDocument document = XDocument.Load(textBoxPath.Text);
            List<XElement> partElemets = document.Element("Aircraft").Element("Assembly").Element("Parts").Elements("Part").ToList();
            foreach(XElement part in partElemets)
            {
                if(true)
                {
                    part.SetAttributeValue("disableAircraftCollisions", true);
                }
            }

            document.Save(textBoxPath.Text);
        }

        private void buttonSetMass_Click(object sender, EventArgs e)
        {
            XDocument document = XDocument.Load(textBoxPath.Text);
            List<XElement> partElemets = document.Element("Aircraft").Element("Assembly").Element("Parts").Elements("Part").ToList();
            float massScale = Convert.ToSingle(textBoxMassScale.Text);
            foreach (XElement part in partElemets)
            {
                if (checkBoxOnlyFuselage.Checked)//仅圆筒
                {
                    if (checkBoxOnlyMarkedMass.Checked)
                    {
                        int mat = PartIdSort.Program.ReadIntArrayStr(part.Attribute("materials").Value)[0];
                        if (part.Attribute("partType").Value == "Fuselage-Body-1" && mat == 14)
                        {
                            part.SetAttributeValue("massScale", massScale);
                        }
                    }
                    else
                    {
                        if (part.Attribute("partType").Value == "Fuselage-Body-1")
                        {
                            part.SetAttributeValue("massScale", massScale);
                        }
                    }
                }
                else//不仅圆筒
                {
                    if (checkBoxOnlyMarkedMass.Checked)
                    {
                        int mat = PartIdSort.Program.ReadIntArrayStr(part.Attribute("materials").Value)[0];
                        if (mat == 14)
                        {
                            part.SetAttributeValue("massScale", massScale);
                        }
                    }
                    else
                    {
                        part.SetAttributeValue("massScale", massScale);
                    }
                }
            }

            document.Save(textBoxPath.Text);
        }
        //calculateDrag="false" dragScale="0.33"
        private void buttonDisableDrags_Click(object sender, EventArgs e)
        {
            XDocument document = XDocument.Load(textBoxPath.Text);
            List<XElement> partElemets = document.Element("Aircraft").Element("Assembly").Element("Parts").Elements("Part").ToList();
            foreach (XElement part in partElemets)
            {
                if (checkBoxOnlyMarkDrags.Checked) 
                {
                    if(Program.ReadIntArrayStr(part.Attribute("materials").Value)[0] == 14)
                    {
                        part.SetAttributeValue("calculateDrag", "false");
                    }
                }
                else
                {
                    part.SetAttributeValue("calculateDrag", "false");
                }
            }

            document.Save(textBoxPath.Text);
        }

        private void buttonCalculateDrags_Click(object sender, EventArgs e)
        {
            XDocument document = XDocument.Load(textBoxPath.Text);
            List<XElement> partElemets = document.Element("Aircraft").Element("Assembly").Element("Parts").Elements("Part").ToList();
            foreach (XElement part in partElemets)
            {
                if (checkBoxOnlyMarkDrags.Checked)
                {
                    if (Program.ReadIntArrayStr(part.Attribute("materials").Value)[0] == 14)
                    {
                        part.SetAttributeValue("calculateDrag", "true");
                    }
                }
                else
                {
                    part.SetAttributeValue("calculateDrag", "true");
                }
            }

            document.Save(textBoxPath.Text);
        }

        private void buttonDragScale_Click(object sender, EventArgs e)
        {
            XDocument document = XDocument.Load(textBoxPath.Text);
            List<XElement> partElemets = document.Element("Aircraft").Element("Assembly").Element("Parts").Elements("Part").ToList();
            foreach (XElement part in partElemets)
            {
                if (checkBoxOnlyMarkDrags.Checked)
                {
                    if (Program.ReadIntArrayStr(part.Attribute("materials").Value)[0] == 14)
                    {
                        part.SetAttributeValue("dragScale", Convert.ToSingle(textBoxDragScale.Text));
                    }
                }
                else
                {
                    part.SetAttributeValue("dragScale", Convert.ToSingle(textBoxDragScale.Text));
                }
            }

            document.Save(textBoxPath.Text);
        }

        private void buttonScaleChange_Click(object sender, EventArgs e)
        {
            XDocument document = XDocument.Load(textBoxPath.Text);
            List<XElement> partElemets = document.Element("Aircraft").Element("Assembly").Element("Parts").Elements("Part").ToList();
            foreach (XElement part in partElemets)
            {
                if (part.Attribute("partType").Value == "Fuselage-Body-1")
                {
                    int mat = PartIdSort.Program.ReadIntArrayStr(part.Attribute("materials").Value)[0];
                    if (mat == 14)
                    {
                        float[] rearScale = Program.ReadFloatArrayStr(part.Element("Fuselage.State").Attribute("rearScale").Value);
                        float[] frontScale = Program.ReadFloatArrayStr(part.Element("Fuselage.State").Attribute("frontScale").Value);
                        float[] offset = Program.ReadFloatArrayStr(part.Element("Fuselage.State").Attribute("offset").Value);
                        float scale = Convert.ToSingle(textBoxScale.Text);
                        rearScale[0] *= (1f / scale);
                        rearScale[1] *= (1f / scale);
                        frontScale[0] *= (1f / scale);
                        frontScale[1] *= (1f / scale);
                        offset[0] *= (1f / scale);
                        offset[1] *= (1f / scale);
                        offset[2] *= (1f / scale);
                        part.Element("Fuselage.State").SetAttributeValue("rearScale", Program.ArrayToString(rearScale));
                        part.Element("Fuselage.State").SetAttributeValue("frontScale", Program.ArrayToString(frontScale));
                        part.Element("Fuselage.State").SetAttributeValue("offset", Program.ArrayToString(offset));
                        part.SetAttributeValue("scale", scale + "," + scale + "," + scale);
                    }
                }
            }

            document.Save(textBoxPath.Text);
        }

        private void buttonJoin_Click(object sender, EventArgs e)
        {
            XDocument document = XDocument.Load(textBoxPath.Text);
            XDocument documentJoin = XDocument.Load(textBoxPathJoin.Text);
            List<XElement> partElemets = document.Element("Aircraft").Element("Assembly").Element("Parts").Elements("Part").ToList();
            List<XElement> partElemetsJoin = documentJoin.Element("Aircraft").Element("Assembly").Element("Parts").Elements("Part").ToList();
            List<XElement> connElemetsJoin = documentJoin.Element("Aircraft").Element("Assembly").Element("Connections").Elements("Connection").ToList();
            List<XElement> bodyElemetsJoin = documentJoin.Element("Aircraft").Element("Assembly").Element("Bodies").Elements("Body").ToList();

            //massScale标记匹配
            XElement partMarkMain = partElemets.FindAll(x => x.Attribute("massScale") != null).Find(x => x.Attribute("massScale").Value == textBoxJoinMassScale.Text);
            XElement partMarkJoin = partElemetsJoin.FindAll(x => x.Attribute("massScale") != null).Find(x => x.Attribute("massScale").Value == textBoxJoinMassScale.Text);
            if(partMarkMain != null && partMarkJoin != null)
            {
                //位移
                float[] positionArrMarkMain = Program.ReadFloatArrayStr(partMarkMain.Attribute("position").Value);
                float[] positionArrMarkJoin = Program.ReadFloatArrayStr(partMarkJoin.Attribute("position").Value);

                Vector3 positionMarkMain = new Vector3(positionArrMarkMain[0], positionArrMarkMain[1], positionArrMarkMain[2]);
                Vector3 positionMarkJoin = new Vector3(positionArrMarkJoin[0], positionArrMarkJoin[1], positionArrMarkJoin[2]);

                Vector3 joinToMainVector = positionMarkMain - positionMarkJoin;

                foreach(XElement partJoin in partElemetsJoin)
                {
                    float[] position = Program.ReadFloatArrayStr(partJoin.Attribute("position").Value);
                    position[0] += joinToMainVector.x;
                    position[1] += joinToMainVector.y;
                    position[2] += joinToMainVector.z;
                    partJoin.SetAttributeValue("position", position[0] + "," + position[1] + "," + position[2]);
                    
                    if(partJoin.Element("Cockpit.State") != null)
                    {
                        partJoin.Element("Cockpit.State").SetAttributeValue("primaryCockpit", "False");
                    }
                }

                //重新排序
                int maxIndex = 0;
                foreach (XElement part in partElemets)
                {
                    if (Convert.ToInt32(part.Attribute("id").Value) > maxIndex)
                    {
                        maxIndex = Convert.ToInt32(part.Attribute("id").Value);
                    }
                }

                Hashtable table = new Hashtable();
                foreach (XElement partJoin in partElemetsJoin)
                {
                    table.Add(partJoin.Attribute("id").Value, ++maxIndex);
                }


                foreach (XElement partJoin in partElemetsJoin)
                {
                    partJoin.SetAttributeValue("id", table[partJoin.Attribute("id").Value]);
                }
                foreach (XElement connJoin in connElemetsJoin)
                {
                    connJoin.SetAttributeValue("partA", table[connJoin.Attribute("partA").Value]);
                    connJoin.SetAttributeValue("partB", table[connJoin.Attribute("partB").Value]);
                }
                foreach (XElement bodyJoin in bodyElemetsJoin)
                {
                    int[] ids = Program.ReadIntArrayStr(bodyJoin.Attribute("partIds").Value);
                    StringBuilder strb = new StringBuilder();
                    for (int i = 0; i < ids.Length; i++)
                    {
                        ids[i] = Convert.ToInt32(table[ids[i]]);
                        strb.Append(ids[i]);
                        if (i != ids.Length - 1)
                        {
                            strb.Append(",");
                        }
                    }
                    bodyJoin.SetAttributeValue("partIds", strb.ToString());

                    float[] bodyPositionArr = Program.ReadFloatArrayStr(bodyJoin.Attribute("position").Value);
                    bodyPositionArr[0] += joinToMainVector.x;
                    bodyPositionArr[1] += joinToMainVector.y;
                    bodyPositionArr[2] += joinToMainVector.z;
                    bodyJoin.SetAttributeValue("position", bodyPositionArr[0] + "," + bodyPositionArr[1] + "," + bodyPositionArr[2]);
                }



                //合并
                document.Element("Aircraft").Element("Assembly").Element("Parts").Add(
                    documentJoin.Element("Aircraft").Element("Assembly").Element("Parts").Elements("Part"));
                document.Element("Aircraft").Element("Assembly").Element("Connections").Add(
                    documentJoin.Element("Aircraft").Element("Assembly").Element("Connections").Elements("Connection"));
                document.Element("Aircraft").Element("Assembly").Element("Bodies").Add(
                    documentJoin.Element("Aircraft").Element("Assembly").Element("Bodies").Elements("Body"));

                document.Save(textBoxPath.Text);
            }
            
        }
    }
}
