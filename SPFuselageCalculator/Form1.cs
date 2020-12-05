using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace SPFuselageCalculator
{
    public partial class Form1 : Form
    {
        private string fuselagesType;
        public List<Fuselage> fuselages;
        public Fuselage fuselageCache;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            fuselagesType = "null";
            fuselageCache = null;
            fuselages = new List<Fuselage>();

            textBoxPath.Text = "C:\\Users\\" + Environment.UserName + "\\AppData\\LocalLow\\Jundroo\\SimplePlanes\\AircraftDesigns\\*.xml";

            listView1.View = View.LargeIcon;
            listView1.LargeImageList = imageList1;

            saveFileDialog1.DefaultExt = "xml";
            saveFileDialog1.Filter = "XML文件(*.xml)|*.xml";

            //Test测试Test测试Test测试Test测试Test测试Test测试Test测试Test测试Test测试Test测试Test测试
            //Vector3 right = new Vector3(1, 0, 0).Rotate(0, 45, 45);
            //MessageBox.Show("Right:" + right.x.ToString() + "," + right.y.ToString() + "," + right.z.ToString() + "");
        }

        private void buttonReadPath_Click(object sender, EventArgs e)
        {
            XDocument document = XDocument.Load(textBoxPath.Text.Trim());
            if (document != null)
            {
                List<XElement> parts = document.Element("Aircraft").Element("Assembly").Element("Parts").Elements().ToList();
                List<XElement> partsMark = parts.FindAll(x => REW_Func.ReadIntArrayStr(x.Attribute("materials").Value)[0] == 14);

                fuselagesType = partsMark[0].Attribute("partType").Value;
                if(fuselagesType != "Fuselage-Body-1" && fuselagesType != "Fuselage-Hollow-1")
                {
                    return;
                }

                string strPosition = partsMark[0].Attribute("position").Value;
                string strRotation = partsMark[0].Attribute("rotation").Value;
                string strSection2 = partsMark[0].Element("Fuselage.State").Attribute("frontScale").Value;
                string strSection1 = partsMark[0].Element("Fuselage.State").Attribute("rearScale").Value;

                string strOffset = partsMark[0].Element("Fuselage.State").Attribute("offset").Value; //run rise length
                string strRun = strOffset.Substring(0, strOffset.IndexOf(','));
                string strRise = strOffset.Substring(strOffset.IndexOf(',') + 1, strOffset.LastIndexOf(',') - strOffset.IndexOf(',') - 1);
                string strLength = strOffset.Substring(strOffset.LastIndexOf(',') + 1);

                textBox_widthL.Text = strSection1.Substring(0, strSection1.IndexOf(','));
                textBox_heightL.Text = strSection1.Substring(strSection1.IndexOf(',') + 1);
                textBox_widthR.Text = strSection2.Substring(0, strSection2.IndexOf(','));
                textBox_heightR.Text = strSection2.Substring(strSection2.IndexOf(',') + 1);
                textBox_Run.Text = strRun;
                textBox_Rise.Text = strRise;
                textBox_length.Text = strLength;
                textBoxPosition.Text = strPosition;
                textBoxRotation.Text = strRotation;
                
            }
        }

        private void button_subsection_Click(object sender, EventArgs e)
        {
            int count;
            Int32.TryParse(textBox_count.Text, out count);

            float widthL;
            Single.TryParse(textBox_widthL.Text, out widthL);
            float heightL;
            Single.TryParse(textBox_heightL.Text, out heightL);

            float length;
            Single.TryParse(textBox_length.Text, out length);
            float rise;
            Single.TryParse(textBox_Rise.Text, out rise);
            float run;
            Single.TryParse(textBox_Run.Text, out run);


            float widthR;
            Single.TryParse(textBox_widthR.Text, out widthR);
            float heightR;
            Single.TryParse(textBox_heightR.Text, out heightR);

            richTextBox1.Text = "";
            StringBuilder result = new StringBuilder();
            float rise_frag = rise / count;
            float run_frag = run / count;
            result.AppendLine("-------RESULT------");
            result.Append("Rise: " + rise_frag + " ");
            result.Append("Run: " + run_frag + Environment.NewLine);
            for (int i = 0; i < count - 1; i++)
            {
                float width_current = widthL + ((widthR - widthL) * (i + 1) / count);
                float height_current = heightL + ((heightR - heightL) * (i + 1) / count);

                result.Append("---" + (i + 1).ToString() + "---" + Environment.NewLine);
                
                result.Append("WidthL: " + width_current + " ");
                result.Append("HeightL: " + height_current + Environment.NewLine);
                result.Append(Environment.NewLine);
            }
            richTextBox1.Text = result.ToString();
            
        }

        private void button_SeperateAdd_Click(object sender, EventArgs e)
        {
            int count;
            Int32.TryParse(textBox_count.Text, out count);

            float widthL;
            Single.TryParse(textBox_widthL.Text, out widthL);
            float heightL;
            Single.TryParse(textBox_heightL.Text, out heightL);

            float length;
            Single.TryParse(textBox_length.Text, out length);
            float rise;
            Single.TryParse(textBox_Rise.Text, out rise);
            float run;
            Single.TryParse(textBox_Run.Text, out run);


            float widthR;
            Single.TryParse(textBox_widthR.Text, out widthR);
            float heightR;
            Single.TryParse(textBox_heightR.Text, out heightR);

            Fuselage[] subFuselages = new Fuselage[count];
            
            float rise_frag = rise / count;
            float run_frag = run / count;

            //------位置计算--------
            string rotationStr = textBoxRotation.Text;
            float rotationX; float.TryParse(rotationStr.Substring(0, rotationStr.IndexOf(',')), out rotationX);
            float rotationY; float.TryParse(rotationStr.Substring(rotationStr.IndexOf(',') + 1, rotationStr.LastIndexOf(',') - rotationStr.IndexOf(',') - 1), out rotationY);
            float rotationZ; float.TryParse(rotationStr.Substring(rotationStr.LastIndexOf(',') + 1), out rotationZ);
            //SP旋转方向：视线逆时针
            Vector3 right = new Vector3(1f, 0f, 0f).Rotate(-rotationX, -rotationY, -rotationZ);
            Vector3 up = new Vector3(0f, 1f, 0f).Rotate(-rotationX, -rotationY, -rotationZ);
            Vector3 forward = new Vector3(0f, 0f, 1f).Rotate(-rotationX, -rotationY, -rotationZ);

            string positionStr = textBoxPosition.Text;
            float positionx; float.TryParse(positionStr.Substring(0, positionStr.IndexOf(',')), out positionx);
            float positiony; float.TryParse(positionStr.Substring(positionStr.IndexOf(',') + 1, positionStr.LastIndexOf(',') - positionStr.IndexOf(',') - 1), out positiony);
            float positionz; float.TryParse(positionStr.Substring(positionStr.LastIndexOf(',') + 1), out positionz);
            Vector3 position = new Vector3(positionx, positiony, positionz);
            Vector3 positionL = position + (right * run * 0.25f) + (up * rise * 0.25f) - (forward * length * 0.25f);
            Vector3 positionR = position - (right * run * 0.25f) - (up * rise * 0.25f) + (forward * length * 0.25f);
            
            //------------

            for (int i = 0; i < count; i++)
            {
                float width_current = widthL + ((widthR - widthL) * (i + 1) / count);
                float height_current = heightL + ((heightR - heightL) * (i + 1) / count);

                float width_previous = widthL + ((widthR - widthL) * i / count);
                float height_previous = heightL + ((heightR - heightL) * i / count);

                subFuselages[i] = new Fuselage();
                subFuselages[i].sectionL = new Vector2(width_previous, height_previous);
                subFuselages[i].sectionR = new Vector2(width_current, height_current);
                subFuselages[i].run = run_frag;
                subFuselages[i].rise = rise_frag;
                subFuselages[i].length = length / count;
                subFuselages[i].position = positionL - (right * (run_frag * ((float)i + 0.5f)) * 0.5f) - (up * (rise_frag * ((float)i + 0.5f)) * 0.5f) + (forward * ((length / count) * ((float)i + 0.5f)) * 0.5f);
            }

            fuselageCache = null;
            foreach (Fuselage item in subFuselages)
            {
                fuselageCache = item;
                FuselageAdd();
            }
            fuselageCache = null;
        }

        private void button_lerp_Click(object sender, EventArgs e)
        {
            float t1;
            Single.TryParse(textBox_lerpLinear1.Text, out t1);
            float t2;
            Single.TryParse(textBox_lerpLinear2.Text, out t2);

            float widthL;
            Single.TryParse(textBox_widthL.Text, out widthL);
            float heightL;
            Single.TryParse(textBox_heightL.Text, out heightL);

            float length;
            Single.TryParse(textBox_length.Text, out length);
            float rise;
            Single.TryParse(textBox_Rise.Text, out rise);
            float run;
            Single.TryParse(textBox_Run.Text, out run);


            float widthR;
            Single.TryParse(textBox_widthR.Text, out widthR);
            float heightR;
            Single.TryParse(textBox_heightR.Text, out heightR);


            float width_t1 = (widthR - widthL) * t1 + widthL;
            float height_t1 = (heightR - heightL) * t1 + heightL;
            float rise_t1L = rise * (t1 / 1f);
            float rise_t1R = rise * ((1f - t1) / 1f);
            float run_t1L = run * (t1 / 1f);
            float run_t1R = run * ((1f - t1) / 1f);

            float width_t2 = (widthR - widthL) * t2 + widthL;
            float height_t2 = (heightR - heightL) * t2 + heightL;
            float rise_t2L = rise * (t2 / 1f);
            float rise_t2R = rise * ((1f - t2) / 1f);
            float run_t2L = run * (t2 / 1f);
            float run_t2R = run * ((1f - t2) / 1f);

            float runMid = run_t1R - run_t2R;
            float riseMid = rise_t1R - rise_t2R;

            richTextBox2.Text = "";
            StringBuilder result = new StringBuilder();
            result.AppendLine("-------RESULT------");
            result.AppendLine("section1: " + width_t1.ToString() + "<->" + height_t1.ToString());
            result.AppendLine("      run : " + runMid.ToString());
            result.AppendLine("      rise: " + riseMid.ToString());
            result.AppendLine("section2: " + width_t2.ToString() + "<->" + height_t2.ToString());
            richTextBox2.Text = result.ToString();

            //------位置计算--------
            string rotationStr = textBoxRotation.Text;
            float rotationX; float.TryParse(rotationStr.Substring(0, rotationStr.IndexOf(',')), out rotationX);
            float rotationY; float.TryParse(rotationStr.Substring(rotationStr.IndexOf(',') + 1, rotationStr.LastIndexOf(',') - rotationStr.IndexOf(',') - 1), out rotationY);
            float rotationZ; float.TryParse(rotationStr.Substring(rotationStr.LastIndexOf(',') + 1), out rotationZ);
            //SP旋转方向：视线逆时针
            Vector3 right = new Vector3(1f, 0f, 0f).Rotate(-rotationX, -rotationY, -rotationZ);
            Vector3 up = new Vector3(0f, 1f, 0f).Rotate(-rotationX, -rotationY, -rotationZ);
            Vector3 forward = new Vector3(0f, 0f, 1f).Rotate(-rotationX, -rotationY, -rotationZ);

            string positionStr = textBoxPosition.Text;
            float positionx; float.TryParse(positionStr.Substring(0, positionStr.IndexOf(',')), out positionx);
            float positiony; float.TryParse(positionStr.Substring(positionStr.IndexOf(',') + 1, positionStr.LastIndexOf(',') - positionStr.IndexOf(',') - 1), out positiony);
            float positionz; float.TryParse(positionStr.Substring(positionStr.LastIndexOf(',') + 1), out positionz);
            Vector3 position = new Vector3(positionx, positiony, positionz);
            Vector3 positionL = position + (right * run * 0.25f) + (up * rise * 0.25f) - (forward * length * 0.25f);
            Vector3 positionR = position - (right * run * 0.25f) - (up * rise * 0.25f) + (forward * length * 0.25f);
            
            Vector3 positionCurrent = positionL + (positionR - positionL) * ((t1 + t2) / 2);
            //------------

            Fuselage fuselage = new Fuselage();
            fuselage.sectionL = new Vector2(width_t1, height_t1);
            fuselage.sectionR = new Vector2(width_t2, height_t2);
            fuselage.run = runMid;
            fuselage.rise = riseMid;
            fuselage.length = length * ((t2 - t1) / 1);
            fuselage.position = positionCurrent;
            fuselageCache = null;
            fuselageCache = fuselage;
        }

        private void button_Add_LinearLerp_Click(object sender, EventArgs e)
        {
            FuselageAdd();
        }

        private void button_bezierLerp_Click(object sender, EventArgs e)
        {
            float t1;
            Single.TryParse(textBox_lerpBezier1.Text, out t1);
            float t2;
            Single.TryParse(textBox_lerpBezier2.Text, out t2);

            float widthL;
            Single.TryParse(textBox_widthL.Text, out widthL);
            float heightL;
            Single.TryParse(textBox_heightL.Text, out heightL);

            float length;
            Single.TryParse(textBox_length.Text, out length);
            float rise;
            Single.TryParse(textBox_Rise.Text, out rise);
            float run;
            Single.TryParse(textBox_Run.Text, out run);


            float widthR;
            Single.TryParse(textBox_widthR.Text, out widthR);
            float heightR;
            Single.TryParse(textBox_heightR.Text, out heightR);

            double k0;
            double.TryParse(textBox_k0.Text, out k0);
            double k1;
            double.TryParse(textBox_k1.Text, out k1);
            IFunctionCurve curve = new BezierCurve(new Vector2(0, 0), k0, new Vector2(1, 1), k1);
            if(curve.Value(t1).Length == 0 || curve.Value(t2).Length == 0)
            {
                
            }
            else
            {
                //Down代表负值，Up代表正值；
                double bezier1 = curve.Value(t1)[0];
                double bezier2 = curve.Value(t2)[0];
                double width_t1 = widthL + bezier1 * (widthR - widthL);
                double height_t1 = heightL + bezier1 * (heightR - heightL);
                double width_t2 = widthL + bezier2 * (widthR - widthL);
                double height_t2 = heightL + bezier2 * (heightR - heightL);
                double runL;
                double runR;
                double runMid;
                double riseL;
                double riseR;
                double riseMid;

                if (comboBox_bezierAlignW.Text == "-align")
                {
                    double runDown = run - ((widthR / 2) - (widthL / 2));
                    
                    double runDownL = t1 * runDown;
                    runL = runDownL + ((width_t1 / 2) - (widthL / 2));
                    double runDownR = (1 - t2) * runDown;
                    runR = runDownR + ((widthR / 2) - (width_t2 / 2));
                }
                else if (comboBox_bezierAlignW.Text == "+align")
                {
                    double runUp = run + ((widthR / 2) - (widthL / 2));

                    double runUpL = t1 * runUp;
                    runL = runUpL - ((width_t1 / 2) - (widthL / 2));
                    double runUpR = (1 - t2) * runUp;
                    runR = runUpR - ((widthR / 2) - (width_t2 / 2));
                }
                else
                {
                    runL = 0;
                    runR = 0;
                }

                if (comboBox_bezierAlignH.Text == "-align")
                {
                    double riseDown = rise - ((heightR / 2) - (heightL / 2));

                    double riseDownL = t1 * riseDown;
                    riseL = riseDownL + ((height_t1 / 2) - (heightL / 2));
                    double riseDownR = (1 - t2) * riseDown;
                    riseR = riseDownR + ((heightR / 2) - (height_t2 / 2));
                }
                else if (comboBox_bezierAlignH.Text == "+align")
                {
                    double riseUp = run + ((heightR / 2) - (heightL / 2));

                    double riseUpL = t1 * riseUp;
                    riseL = riseUpL - ((height_t1 / 2) - (heightL / 2));
                    double riseUpR = (1 - t2) * riseUp;
                    riseR = riseUpR - ((heightR / 2) - (height_t2 / 2));
                }
                else
                {
                    riseL = 0;
                    riseR = 0;
                }

                runMid = run - runL - runR;
                riseMid = rise - riseL - riseR;

                //------位置计算--------
                string rotationStr = textBoxRotation.Text;
                float rotationX; float.TryParse(rotationStr.Substring(0, rotationStr.IndexOf(',')), out rotationX);
                float rotationY; float.TryParse(rotationStr.Substring(rotationStr.IndexOf(',') + 1, rotationStr.LastIndexOf(',') - rotationStr.IndexOf(',') - 1), out rotationY);
                float rotationZ; float.TryParse(rotationStr.Substring(rotationStr.LastIndexOf(',') + 1), out rotationZ);
                //SP旋转方向：视线逆时针
                Vector3 right = new Vector3(1f, 0f, 0f).Rotate(-rotationX, -rotationY, -rotationZ);
                Vector3 up = new Vector3(0f, 1f, 0f).Rotate(-rotationX, -rotationY, -rotationZ);
                Vector3 forward = new Vector3(0f, 0f, 1f).Rotate(-rotationX, -rotationY, -rotationZ);

                string positionStr = textBoxPosition.Text;
                float positionx; float.TryParse(positionStr.Substring(0, positionStr.IndexOf(',')), out positionx);
                float positiony; float.TryParse(positionStr.Substring(positionStr.IndexOf(',') + 1, positionStr.LastIndexOf(',') - positionStr.IndexOf(',') - 1), out positiony);
                float positionz; float.TryParse(positionStr.Substring(positionStr.LastIndexOf(',') + 1), out positionz);
                Vector3 position = new Vector3(positionx, positiony, positionz);
                Vector3 positionL = position + (right * run * 0.25f) + (up * rise * 0.25f) - (forward * length * 0.25f);
                Vector3 positionR = position - (right * run * 0.25f) - (up * rise * 0.25f) + (forward * length * 0.25f);

                Vector3 positionSectiont1 = positionL + (right * (float)-runL * 0.5f) + (up * (float)-riseL * 0.5f) + (forward * length * t1 * 0.5f);
                Vector3 positionSectiont2 = positionR - (right * (float)-runR * 0.5f) - (up * (float)-riseR * 0.5f) - (forward * length * (1 - t2) * 0.5f);
                Vector3 positionCurrent = (positionSectiont1 + positionSectiont2) * 0.5f;
                //------------

                richTextBox3.Text = "";
                StringBuilder result = new StringBuilder();
                result.AppendLine("-------RESULT------");
                result.AppendLine("Section1: " + width_t1.ToString() + "<->" + height_t1.ToString());
                result.AppendLine("      Run : " + runMid.ToString());
                result.AppendLine("      Rise: " + riseMid.ToString());
                result.AppendLine("Section2: " + width_t2.ToString() + "<->" + height_t2.ToString());
                richTextBox3.Text = result.ToString();

                Fuselage fuselage = new Fuselage();
                fuselage.sectionL = new Vector2(width_t1, height_t1);
                fuselage.sectionR = new Vector2(width_t2, height_t2);
                fuselage.run = runMid;
                fuselage.rise = riseMid;
                fuselage.length = length * ((t2 - t1) / 1);
                fuselage.position = positionCurrent;
                fuselageCache = null;
                fuselageCache = fuselage;
            }
        }

        private void button_Add_Bezier_Click(object sender, EventArgs e)
        {
            FuselageAdd();
        }


        private void button_Clear_Click(object sender, EventArgs e)
        {
            fuselages = null;
            listView1.Clear();
        }

        private void 添加到XML文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddToXML();
        }

        private void 导出XMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WriteXML(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/Fuselages_Export.xml", "Fuselages_Export");
        }

        private void 导出到ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
            saveFileDialog1.FileName = "Fuselages_Exports";
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            if (saveFileDialog1.CheckPathExists)
            {
                WriteXML(saveFileDialog1.FileName, System.IO.Path.GetFileNameWithoutExtension(saveFileDialog1.FileName));
            }
        }

        private void 打开程序根目录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Application.StartupPath);
        }

        private void 帮助ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FormHelp().ShowDialog();
        }

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Form_Info().ShowDialog();
        }





        private void FuselageAdd()
        {
            if (fuselageCache != null)
            {
                fuselages.Add(fuselageCache);

                ListViewItem item = new ListViewItem();
                item.Name = "Fuselage";
                item.Text = "Fuselage";
                item.ImageIndex = 0;
                listView1.Items.Add(item);
                //listView1.Refresh();
            }
        }

        private void AddToXML()
        {
            XDocument document = XDocument.Load(textBoxPath.Text.Trim());
            XElement eleParts = document.Element("Aircraft").Element("Assembly").Element("Parts");
            int lastIndex; int.TryParse((eleParts.Elements("Part").LastOrDefault().Attribute("id").Value), out lastIndex);

            foreach(Fuselage fuselage in fuselages)
            {
                eleParts.Add(new XElement("Part", new XAttribute("id", (lastIndex + 1)),
                new XAttribute("partType", fuselagesType),
                new XAttribute("position", fuselage.position.x + "," + fuselage.position.y + "," + fuselage.position.z),
                new XAttribute("rotation", textBoxRotation.Text),
                new XAttribute("drag", "0,0,0,0,0,0"),
                new XAttribute("materials", "0"),
                new XAttribute("partCollisionResponse", "Default"),
                new XElement("FuelTank.State", new XAttribute("fuel", "0"), new XAttribute("capacity", "0")),
                new XElement("Fuselage.State", new XAttribute("version", "2"),
                    new XAttribute("frontScale", fuselage.sectionR.x + "," + fuselage.sectionR.y),
                    new XAttribute("rearScale", fuselage.sectionL.x + "," + fuselage.sectionL.y),
                    new XAttribute("offset", fuselage.run + "," + fuselage.rise + "," + fuselage.length),
                    new XAttribute("deadWeight", "0"),
                    new XAttribute("buoyancy", "0"),
                    new XAttribute("fuelPercentage", "0"),
                    new XAttribute("autoSizeOnConnected", "false"),
                    new XAttribute("cornerTypes", "3,3,3,3,3,3,3,3")
                )));
                lastIndex++;
            }
            document.Save(textBoxPath.Text.Trim());
        }

        private void WriteXML(string path, string name)
        {
            XElement eleParts = new XElement("Parts");
            eleParts.Add(new XElement("Part", new XAttribute("id", "1"), 
                new XAttribute("partType", "Cockpit-1"), 
                new XAttribute("position", "0,0,0"),
                new XAttribute("rotation", "0,0,0"),
                new XAttribute("drag", "0,0,0,0,0,0"),
                new XAttribute("materials", "0,0"), 
                new XAttribute("partCollisionResponse", "Default"),
                new XElement("Cockpit.State", new XAttribute("primaryCockpit", "True"), new XAttribute("lookBackTranslation", "0,0"))
                ));
            int i = 0;
            foreach(Fuselage fuselage in fuselages)
            {
                i++;
                eleParts.Add(new XElement("Part", new XAttribute("id", (i + 1).ToString()),
                new XAttribute("partType", fuselagesType),
                new XAttribute("position", "0,0,0"),
                new XAttribute("rotation", "0,0,0"),
                new XAttribute("drag", "0,0,0,0,0,0"),
                new XAttribute("materials", "0"),
                new XAttribute("partCollisionResponse", "Default"),
                new XElement("FuelTank.State", new XAttribute("fuel", "0"), new XAttribute("capacity", "0")),
                new XElement("Fuselage.State", new XAttribute("version", "2"), 
                    new XAttribute("frontScale", fuselage.sectionL.x + "," + fuselage.sectionL.y),
                    new XAttribute("rearScale", fuselage.sectionR.x + "," + fuselage.sectionR.y),
                    new XAttribute("offset", fuselage.run + "," + fuselage.rise + "," + fuselage.length),
                    new XAttribute("deadWeight", "0"),
                    new XAttribute("buoyancy", "0"),
                    new XAttribute("fuelPercentage", "0"),
                    new XAttribute("autoSizeOnConnected", "false"),
                    new XAttribute("cornerTypes", "0,0,0,0,0,0,0,0")
                )));
            }


            XDocument document = new XDocument(
                new XDeclaration("1.0", "utf-8", null),

                new XElement("Aircraft",
                    new XAttribute("name", name),
                    new XAttribute("url", ""),
                    new XAttribute("theme", "Default"),
                    new XAttribute("size", "1,1,1"),
                    new XAttribute("boundsMin", "0,0,0"),
                    new XAttribute("xmlVersion", "6"),
                    new XAttribute("legacyJointIdentification", "false"),

                    new XElement("Assembly",
                        eleParts,
                        new XElement("Connections"),
                        new XElement("Bodies")
                    ),

                    new XElement("Theme",
                        new XAttribute("name", "Custom"),
                        new XElement("Material", new XAttribute("color", "000000"), new XAttribute("r", "0"), new XAttribute("m", "0"), new XAttribute("s", "0")),
                        new XElement("Material", new XAttribute("color", "000000"), new XAttribute("r", "0"), new XAttribute("m", "0"), new XAttribute("s", "0")),
                        new XElement("Material", new XAttribute("color", "000000"), new XAttribute("r", "0"), new XAttribute("m", "0"), new XAttribute("s", "0")),
                        new XElement("Material", new XAttribute("color", "000000"), new XAttribute("r", "0"), new XAttribute("m", "0"), new XAttribute("s", "0")),
                        new XElement("Material", new XAttribute("color", "000000"), new XAttribute("r", "0"), new XAttribute("m", "0"), new XAttribute("s", "0")),
                        new XElement("Material", new XAttribute("color", "000000"), new XAttribute("r", "0"), new XAttribute("m", "0"), new XAttribute("s", "0")),
                        new XElement("Material", new XAttribute("color", "000000"), new XAttribute("r", "0"), new XAttribute("m", "0"), new XAttribute("s", "0")),
                        new XElement("Material", new XAttribute("color", "000000"), new XAttribute("r", "0"), new XAttribute("m", "0"), new XAttribute("s", "0")),
                        new XElement("Material", new XAttribute("color", "000000"), new XAttribute("r", "0"), new XAttribute("m", "0"), new XAttribute("s", "0")),
                        new XElement("Material", new XAttribute("color", "000000"), new XAttribute("r", "0"), new XAttribute("m", "0"), new XAttribute("s", "0")),
                        new XElement("Material", new XAttribute("color", "000000"), new XAttribute("r", "0"), new XAttribute("m", "0"), new XAttribute("s", "0")),
                        new XElement("Material", new XAttribute("color", "000000"), new XAttribute("r", "0"), new XAttribute("m", "0"), new XAttribute("s", "0")),
                        new XElement("Material", new XAttribute("color", "000000"), new XAttribute("r", "0"), new XAttribute("m", "0"), new XAttribute("s", "0")),
                        new XElement("Material", new XAttribute("color", "000000"), new XAttribute("r", "0"), new XAttribute("m", "0"), new XAttribute("s", "0")),
                        new XElement("Material", new XAttribute("color", "000000"), new XAttribute("r", "0"), new XAttribute("m", "0"), new XAttribute("s", "0"))
                    )
                )
                );

            document.Save(path);
            
        }

        
    }
}
