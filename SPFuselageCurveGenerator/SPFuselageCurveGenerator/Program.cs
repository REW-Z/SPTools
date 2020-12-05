using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SPFuselageCurveGenerator
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }

    public class Fuselage
    {
        public Vector2 sectionL;
        public Vector2 sectionR;

        public double length;
        public double run;
        public double rise;

        public Vector3 position;
        public Vector3 rotation;
    }

    public class Ellipse24
    {
        private Vector2 center;
        private Vector2[] points;

        public Ellipse24(Vector2 center, double width, double height, double eulerAngle = 0)
        {
            this.center = center;
            points = new Vector2[24];

            Vector2[] initPoints = new Vector2[24];
            double a = width / 2;
            double b = height / 2;

            for (int i = 0; i < 24; i++)
            {
                initPoints[i] = new Vector2(a * Math.Cos(2 * Math.PI * i / 24) + center.x, b * Math.Sin(2 * Math.PI * i / 24) + center.y);
            }
            if(eulerAngle == 0)
            {
                for (int i = 0; i < 24; i++)
                {
                    points[i] = initPoints[i];
                }
            }
            else
            {
                for (int i = 0; i < 24; i++)
                {
                    points[i] = initPoints[i].RotateAround(center, eulerAngle);
                }
            }
            
        }

        public List<Segment2> GetSegments()
        {
            List<Segment2> segments = new List<Segment2>();
            for (int i = 0; i < 24; i++)
            {
                if(i != 23)
                {
                    segments.Add(new Segment2(points[i], points[i + 1]));
                }
                else
                {
                    segments.Add(new Segment2(points[i], points[0]));
                }
            }
            return segments;
        }
    }

    public class Vector2
    {
        public double x;
        public double y;

        public Vector2(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public double Magnitude
        {
            get
            {
                return Math.Sqrt(x * x + y * y);
            }
        }

        public Vector2 RotateAround(Vector2 center, double angle)
        {
            double mag = (this - center).Magnitude;
            double initAngle = new Segment2(center, this).Angle;
            double newAngle = initAngle + angle;
            if(newAngle > 180)
            {
                newAngle -= 360;
            }
            else if (newAngle < -180)
            {
                newAngle += 360;
            }
            double x_nor = Math.Cos(newAngle * Math.PI / 180);
            double y_nor = Math.Sin(newAngle * Math.PI / 180);
            
            return new Vector2(center.x + x_nor * mag, center.y + y_nor * mag);
        }

        public static Vector2 operator -(Vector2 v1, Vector2 v2)
        {
            return new Vector2(v1.x - v2.x, v1.y - v2.y);
        }
        public static Vector2 operator +(Vector2 v1, Vector2 v2)
        {
            return new Vector2(v1.x + v2.x, v1.y + v2.y);
        }
        public static Vector2 operator *(Vector2 v1, double t)
        {
            return new Vector2(v1.x * t, v1.y * t);
        }

        public Point ToPoint()
        {
            int x_int = System.Convert.ToInt32(System.Math.Round(x));
            int y_int = System.Convert.ToInt32(System.Math.Round(y));
            return new Point(x_int, y_int);
        }
    }

    public class Vector3
    {
        public double x;
        public double y;
        public double z;

        public Vector3(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public double Magnitude
        {
            get
            {
                return Math.Sqrt(x * x + y * y + z * z);
            }
        }

        public static Vector3 operator -(Vector3 v1, Vector3 v2)
        {
            return new Vector3(v1.x - v2.x, v1.y - v2.y, v1.z - v2.z);
        }
        public static Vector3 operator +(Vector3 v1, Vector3 v2)
        {
            return new Vector3(v1.x + v2.x, v1.y + v2.y, v1.z + v2.z);
        }
        public static Vector3 operator *(Vector3 v1, double t)
        {
            return new Vector3(v1.x * t, v1.y * t, v1.z * t);
        }
        
    }

    public class Segment2
    {
        private Vector2 p1;
        private Vector2 p2;

        public Vector2 P1 { get { return p1; } }
        public Vector2 P2 { get { return p2; } }

        public Segment2(Vector2 p1, Vector2 p2)
        {
            this.p1 = p1;
            this.p2 = p2;
        }

        public double K
        {
            get { return ((p2 - p1).y / (p2 - p1).x); }
        }

        public Vector2 Center
        {
            get { return new Vector2((p1.x + p2.x) / 2, (p1.y + p2.y) / 2); }
        }

        public double Angle
        {
            get
            {
                Vector2 p3 = new Vector2(p1.x, p2.y);
                double deltaX = p2.x - p1.x;
                double deltaY = p2.y - p1.y;
                double mag = Math.Sqrt((deltaX * deltaX) + (deltaY * deltaY));

                double angleCos = Math.Acos(deltaX / mag) * 180 / Math.PI;
                double angle;

                if(deltaY >= 0)
                {
                    angle = angleCos;
                }
                else
                {
                    angle = -angleCos;
                }
                return angle;
                
            }
        }

        public double Magnitude
        {
            get
            {
                double x2 = (p2.x - p1.x) * (p2.x - p1.x);
                double y2 = (p2.y - p1.y) * (p2.y - p1.y);
                return Math.Sqrt(x2 + y2);
            }
        }

        public Vector2 Lerp(double t)
        {
            return p1 + ((p2 - p1) * t);
        }

        public Segment2 Scale(double scale)
        {
            Vector2 centerPoint = new Vector2((p1.x + p2.x) / 2, (p1.y + p2.y) / 2);
            Vector2 centerToP1 = p1 - centerPoint;
            Vector2 centerToP2 = p2 - centerPoint;

            Vector2 newP1 = centerPoint + (centerToP1 * scale);
            Vector2 newP2 = centerPoint + (centerToP2 * scale);
            return new Segment2(newP1, newP2);
        }
        
    }

    public static class CustomGraphics
    {
        
        public static Vector2 ToVector(this Point p)
        {
            return new Vector2(p.X, p.Y);
        }
    }

    public class Bezier
    {
        private Vector2 p1;
        private Vector2 p2;
        private Vector2 p3;
        private Vector2 p4;

        public Bezier(Vector2 p1, Vector2 p2, Vector2 p3, Vector2 p4)
        {
            this.p1 = p1;
            this.p2 = p2;
            this.p3 = p3;
            this.p4 = p4;
        }

        public Vector2 Lerp(double t)
        {
            Segment2 seg1 = new Segment2(p1, p2);
            Segment2 seg2 = new Segment2(p2, p3);
            Segment2 seg3 = new Segment2(p3, p4);
            Vector2 v1 = seg1.Lerp(t);
            Vector2 v2 = seg2.Lerp(t);
            Vector2 v3 = seg3.Lerp(t);

            Segment2 seg4 = new Segment2(v1, v2);
            Segment2 seg5 = new Segment2(v2, v3);
            Vector2 v4 = seg4.Lerp(t);
            Vector2 v5 = seg5.Lerp(t);

            Segment2 seg6 = new Segment2(v4, v5);
            Vector2 v = seg6.Lerp(t);
            return v;
        }
    }
}
