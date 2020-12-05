using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace SPFuselageCurveGenerator
{
    
    public partial class Form1 : Form
    {
        private Graphics graphics;
        private Pen pen1;
        private Pen pen2;
        private Pen pen3;
        private Pen pen4;

        Point p1;
        Point p2;
        Point p3;
        Point p4;

        private Bezier bezier;
        private bool isDragging;
        private bool showCurve;
        private bool showSegs;
        private bool showArcs;
        private int draggingPoint;

        private List<Fuselage> fuselages;
        private List<Segment2> segments;
        private double scale;


        public Form1()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
           
            pen1 = new Pen(Color.Yellow);
            pen2 = new Pen(Color.White);
            pen3 = new Pen(Color.Blue);
            pen4 = new Pen(Color.Red);
            graphics = panel_curve.CreateGraphics();

            showCurve = true;
            showSegs = false;
            showArcs = false;
            radioButton_curve.Checked = true;
            scale = 0.1;

            p1 = new Point(10, 10);
            p2 = new Point(150, 10);

            p3 = new Point(290, 150);
            p4 = new Point(290, 290);

            fuselages = null;
        }
        
        

        //---------------------------------------------------------事件响应-----------------------------------------------

        private void panel_curve_Paint(object sender, PaintEventArgs e)
        {
            DrawCurve();
        }

        private void panel_curve_MouseDown(object sender, MouseEventArgs e)
        {
            isDragging = true;
            status_label1.Text = "isDragging: true";
            Point point_panel = panel_curve.PointToScreen(new Point(0, 0));
            Point p = new Point(MousePosition.X - point_panel.X, MousePosition.Y - point_panel.Y);
            
            if((p1.ToVector() - p.ToVector()).Magnitude < 10)
            {
                draggingPoint = 1;
            }
            else if ((p2.ToVector() - p.ToVector()).Magnitude < 10)
            {
                draggingPoint = 2;
            }
            else if ((p3.ToVector() - p.ToVector()).Magnitude < 10)
            {
                draggingPoint = 3;
            }
            else if ((p4.ToVector() - p.ToVector()).Magnitude < 10)
            {
                draggingPoint = 4;
            }
            else
            {
                draggingPoint = 0;
            }
            
        }

        private void panel_curve_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
            status_label1.Text = "isDragging: false";

            isDragging = true;
            Point point_panel = panel_curve.PointToScreen(new Point(0, 0));
            Point p = new Point(MousePosition.X - point_panel.X, MousePosition.Y - point_panel.Y);

            switch (draggingPoint)
            {
                case 1:
                    p1.X = p.X;
                    p1.Y = p.Y;
                    break;
                case 2:
                    p2.X = p.X;
                    p2.Y = p.Y;
                    break;
                case 3:
                    p3.X = p.X;
                    p3.Y = p.Y;
                    break;
                case 4:
                    p4.X = p.X;
                    p4.Y = p.Y;
                    break;
                case 0:
                    break;
            }
            DrawCurve();

        }
        

        private void textBox_t0_TextChanged(object sender, EventArgs e)
        {
            DrawCurve();
        }

        private void radioButton_curve_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_curve.Checked)
            {
                showCurve = true;
                showSegs = false;
                showArcs = false;
                DrawCurve();
            }
        }

        private void radioButton_seg_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_seg.Checked)
            {
                showCurve = false;
                showSegs = true;
                showArcs = false;
                DrawCurve();
            }
        }

        private void radioButton_arcs_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_arcs.Checked)
            {
                showCurve = false;
                showSegs = false;
                showArcs = true;
                DrawCurve();
            }
        }

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("曲线圆筒结构生成器\n by REW \n version1.0");
        }
        //---------------------------------------------------------绘图-----------------------------------------------
        private void DrawCurve()
        {
            graphics.Clear(Color.Black);

            graphics.DrawRectangle(pen4, p1.X - 2, p1.Y - 2, 4, 4);
            graphics.DrawLine(pen1, p1, p2);
            graphics.DrawRectangle(pen4, p2.X - 2, p2.Y - 2, 4, 4);
            graphics.DrawRectangle(pen4, p3.X - 2, p3.Y - 2, 4, 4);
            graphics.DrawLine(pen1, p3, p4);
            graphics.DrawRectangle(pen4, p4.X - 2, p4.Y - 2, 4, 4);

            bezier = new Bezier(p1.ToVector(), p2.ToVector(), p3.ToVector(), p4.ToVector());

            List<Segment2> segs = new List<Segment2>();

            if (bezier != null)
            {
                double α0 = new Segment2(p1.ToVector(), p2.ToVector()).Angle;

                double α = 15;
                double i = 1;
                double t0; double.TryParse(textBox_t0.Text, out t0);

                Vector2 subPointPrevious = bezier.Lerp(t0);
                Vector2 subPointCurrent;

                for (double t = t0; t <= 1; t += 0.00001)
                {

                    subPointCurrent = bezier.Lerp(t);
                    Segment2 segCurrent = new Segment2(subPointPrevious, subPointCurrent);

                    if (Math.Abs(segCurrent.Angle - (α * i)) < 0.1 && segCurrent.Magnitude > 1)
                    {
                        i += 1;
                        subPointPrevious = subPointCurrent;
                        segs.Add(segCurrent);
                    }
                }
            }
            segments = null;
            segments = segs;


            if (showCurve)
            {
                graphics.DrawBezier(pen1, p1, p2, p3, p4);
            }
            if (showSegs)
            {
                foreach (Segment2 seg in segments)
                {
                    graphics.DrawLine(pen3, seg.P1.ToPoint(), seg.P2.ToPoint());
                }
            }
            if (showArcs)
            {
                foreach(Segment2 seg in segments)
                {
                    Ellipse24 ellipse = new Ellipse24(seg.Center, seg.Magnitude * 1.5, seg.Magnitude / 5, seg.Angle);
                    List<Segment2> segsEllipse = ellipse.GetSegments();
                    foreach (Segment2 segEllipse in segsEllipse)
                    {
                        graphics.DrawLine(pen3, segEllipse.P1.ToPoint(), segEllipse.P2.ToPoint());
                    }
                }
                fuselages = new List<Fuselage>();
                foreach (Segment2 segment in segments)
                {
                    Fuselage fuselage = new Fuselage();
                    Segment2 scaleSegment = segment.Scale(1.6);
                    fuselage.sectionL = new Vector2(scaleSegment.Magnitude, scaleSegment.Magnitude / 5) * scale;
                    fuselage.sectionR = new Vector2(scaleSegment.Magnitude, scaleSegment.Magnitude / 5) * scale;
                    fuselage.length = 5;
                    fuselage.run = 0;
                    fuselage.rise = 0;
                    fuselage.rotation = new Vector3(0, 0, (segment.Angle > 0 ? segment.Angle : 360 + segment.Angle));
                    fuselage.position = new Vector3(segment.Center.x, segment.Center.y, 0) * 0.5 * scale;

                    fuselages.Add(fuselage);
                }
            }
        }
        //-----------------------------------------------------------------------导出XML------------------------------------------------
        private void textBox_scale_TextChanged(object sender, EventArgs e)
        {
            double.TryParse(textBox_scale.Text, out scale);
        }
        private void button_writeXML_Click(object sender, EventArgs e)
        {
            if (showArcs)
            {
                WriteXML(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/Curve.xml", "Curve");
                MessageBox.Show("已将XML文件保存到桌面");
            }
            else
            {
                MessageBox.Show("请先绘制椭圆！");
            }
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
            foreach (Fuselage fuselage in fuselages)
            {
                i++;
                eleParts.Add(new XElement("Part", new XAttribute("id", (i + 1).ToString()),
                new XAttribute("partType", "Fuselage-Body-1"),
                new XAttribute("position", fuselage.position.x + "," + fuselage.position.y + "," + fuselage.position.z),
                new XAttribute("rotation", fuselage.rotation.x + "," + fuselage.rotation.y + "," + fuselage.rotation.z),
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
                    new XAttribute("cornerTypes", "3,3,3,3,3,3,3,3")
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
