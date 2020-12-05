﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PartIdSort
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


        //数组读取
        public static float[] ReadFloatArrayStr(string str)
        {
            List<float> arrayList = new List<float>();
            string strCurrent = str;
            while (strCurrent.Contains(","))
            {
                arrayList.Add(Convert.ToSingle(strCurrent.Substring(0, strCurrent.IndexOf(','))));
                strCurrent = strCurrent.Substring(strCurrent.IndexOf(',') + 1);
            }
            arrayList.Add(Convert.ToSingle(strCurrent));
            return arrayList.ToArray();
        }
        public static int[] ReadIntArrayStr(string str)
        {
            List<int> arrayList = new List<int>();
            string strCurrent = str;
            while (strCurrent.Contains(","))
            {
                arrayList.Add(Convert.ToInt32(strCurrent.Substring(0, strCurrent.IndexOf(','))));
                strCurrent = strCurrent.Substring(strCurrent.IndexOf(',') + 1);
            }
            arrayList.Add(Convert.ToInt32(strCurrent));
            return arrayList.ToArray();
        }
        //数组转换字符串
        public static string ArrayToString(int[] array)
        {
            StringBuilder strb = new StringBuilder();
            for (int i = 0; i < array.Length; i++)
            {
                strb.Append(array[i]);
                strb.Append(",");
            }
            strb.Remove(strb.Length - 1, 1);
            return strb.ToString();
        }
        //数组转换字符串
        public static string ArrayToString(float[] array)
        {
            StringBuilder strb = new StringBuilder();
            for (int i = 0; i < array.Length; i++)
            {
                strb.Append(array[i]);
                strb.Append(",");
            }
            strb.Remove(strb.Length - 1, 1);
            return strb.ToString();
        }
    }



    #region Geometry


    public class Vector2
    {
        public double x;
        public double y;
        public Vector2(double newx, double newy)
        {
            x = newx;
            y = newy;
        }
        public Vector2(string str)
        {
            float newx = Convert.ToSingle(str.Substring(0, str.IndexOf(',')));
            float newy = Convert.ToSingle(str.Substring(str.LastIndexOf(',') + 1));
            x = newx;
            y = newy;
        }
        public double magnitude
        {
            get
            {
                return Math.Sqrt(x * x + y * y);
            }
        }
        public Vector2 normalized
        {
            get
            {
                double k = (1 / Math.Sqrt(x * x + y * y));
                Vector2 normalizedVec = new Vector2(x * k, y * k);
                return normalizedVec;
            }
        }
        public static Vector2 operator *(double t, Vector2 vec)
        {
            Vector2 result = new Vector2(t * vec.x, t * vec.y);
            return result;
        }
        public static Vector2 operator +(Vector2 vec1, Vector2 vec2)
        {
            Vector2 result = new Vector2(vec1.x + vec2.x, vec1.y + vec2.y);
            return result;
        }
        public static Vector2 operator -(Vector2 vec1, Vector2 vec2)
        {
            Vector2 result = new Vector2(vec1.x - vec2.x, vec1.y - vec2.y);
            return result;
        }

        public override string ToString()
        {
            return (this.x.ToString() + "," + this.y.ToString());
        }
    }

    public class Vector3
    {
        public float x;
        public float y;
        public float z;

        public Vector3()
        {
            this.x = 0;
            this.y = 0;
            this.z = 0;
        }
        public Vector3(string str)
        {
            float newx = Convert.ToSingle(str.Substring(0, str.IndexOf(',')));
            float newy = Convert.ToSingle(str.Substring(0, str.LastIndexOf(',')).Substring(str.IndexOf(',') + 1));
            float newz = Convert.ToSingle(str.Substring(str.LastIndexOf(',') + 1));
            this.x = newx;
            this.y = newy;
            this.z = newz;
        }

        public Vector3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public float Magnitude
        {
            get { return Convert.ToSingle(Math.Sqrt(x * x + y * y + z * z)); }
        }

        public Vector3 Normalized
        {
            get { return this * (1f / this.Magnitude); }
        }

        public static Vector3 operator +(Vector3 vec1, Vector3 vec2)
        {
            return new Vector3(vec1.x + vec2.x, vec1.y + vec2.y, vec1.z + vec2.z);
        }

        public static Vector3 operator -(Vector3 vec1, Vector3 vec2)
        {
            return new Vector3(vec1.x - vec2.x, vec1.y - vec2.y, vec1.z - vec2.z);
        }

        public static Vector3 operator *(Vector3 vec1, float t)
        {
            return new Vector3(vec1.x * t, vec1.y * t, vec1.z * t);
        }

        public static float Dot(Vector3 a, Vector3 b)
        {

            return a.x * b.x + a.y * b.y + a.z * b.z;
        }

        public static Vector3 Cross(Vector3 a, Vector3 b)
        {
            Vector3 c = new Vector3(
                a.y * b.z - b.y * a.z,
                a.z * b.x - b.z * a.x,
                a.x * b.y - b.x * a.y
            );
            return c;
        }

        public static float Angle(Vector3 a, Vector3 b, bool inDegrees = false)
        {
            double result;
            if (inDegrees)
            {
                result = Math.Acos((Vector3.Dot(a, b)) / (a.Magnitude * b.Magnitude)) * 180d / Math.PI;
            }
            else
            {
                result = Math.Acos((Vector3.Dot(a, b)) / (a.Magnitude * b.Magnitude));
            }
            return Convert.ToSingle(result);
        }

        public Vector4 ToVector4(float w)
        {
            return new Vector4(this.x, this.y, this.z, w);
        }

        public Vector3 Rotate(float x, float y, float z)
        {
            //order-zxy
            Matrix4x4 mRotateX = new Matrix4x4(
                1, 0, 0, 0,
                0, Convert.ToSingle(Math.Cos(x * Math.PI / 180d)), Convert.ToSingle(Math.Sin(x * Math.PI / 180d)), 0,
                0, Convert.ToSingle(-Math.Sin(x * Math.PI / 180d)), Convert.ToSingle(Math.Cos(x * Math.PI / 180d)), 0,
                0, 0, 0, 1
            );
            Matrix4x4 mRotateY = new Matrix4x4(
                Convert.ToSingle(Math.Cos(y * Math.PI / 180d)), 0, Convert.ToSingle(-Math.Sin(y * Math.PI / 180d)), 0,
                0, 1, 0, 0,
                Convert.ToSingle(Math.Sin(y * Math.PI / 180d)), 0, Convert.ToSingle(Math.Cos(y * Math.PI / 180d)), 0,
                0, 0, 0, 1
            );
            Matrix4x4 mRotateZ = new Matrix4x4(
                Convert.ToSingle(Math.Cos(z * Math.PI / 180d)), Convert.ToSingle(Math.Sin(z * Math.PI / 180d)), 0, 0,
                Convert.ToSingle(-Math.Sin(z * Math.PI / 180d)), Convert.ToSingle(Math.Cos(z * Math.PI / 180d)), 0, 0,
                0, 0, 1, 0,
                0, 0, 0, 1
            );
            Vector4 newVec = mRotateY * (mRotateX * (mRotateZ * this.ToVector4(0)));
            return new Vector3(newVec.x, newVec.y, newVec.z);
        }

        public override string ToString()
        {
            return (this.x.ToString() + "," + this.y.ToString() + "," + this.z.ToString());
        }
    }

    public class Vector4
    {
        public float x;
        public float y;
        public float z;
        public float w;

        public Vector4()
        {
            this.x = 0;
            this.y = 0;
            this.z = 0;
            this.w = 0;
        }

        public Vector4(float x, float y, float z, float w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }

        public float Magnitude
        {
            get { return Convert.ToSingle(Math.Sqrt(x * x + y * y + z * z + w * w)); }
        }

        public static Vector4 operator +(Vector4 vec1, Vector4 vec2)
        {
            return new Vector4(vec1.x + vec2.x, vec1.y + vec2.y, vec1.z + vec2.z, vec1.w + vec2.w);
        }

        public static Vector4 operator -(Vector4 vec1, Vector4 vec2)
        {
            return new Vector4(vec1.x - vec2.x, vec1.y - vec2.y, vec1.z - vec2.z, vec1.w - vec2.w);
        }

        public static Vector4 operator *(Vector4 vec1, float t)
        {
            return new Vector4(vec1.x * t, vec1.y * t, vec1.z * t, vec1.w * t);
        }

        public override string ToString()
        {
            return (this.x.ToString() + "," + this.y.ToString() + "," + this.z.ToString() + "," + this.w.ToString());
        }
    }

    public class Matrix3x3
    {
        private float[,] matrix;

        public Matrix3x3()
        {
            this.matrix = new float[3, 3];
        }

        public Matrix3x3(float a11, float a12, float a13, float a21, float a22, float a23, float a31, float a32, float a33)
        {
            matrix = new float[3, 3];
            matrix[0, 0] = a11;
            matrix[0, 1] = a12;
            matrix[0, 2] = a13;
            matrix[1, 0] = a21;
            matrix[1, 1] = a22;
            matrix[1, 2] = a23;
            matrix[2, 0] = a31;
            matrix[2, 1] = a32;
            matrix[2, 2] = a33;
        }

        public float this[int i, int j] //二维索引器
        {
            get { return matrix[i, j]; }
            set { matrix[i, j] = value; }
        }

        public static Vector3 operator *(Matrix3x3 m, Vector3 v)
        {
            float _x = v.x * m[0, 0] + v.y * m[0, 1] + v.z * m[0, 2];
            float _y = v.x * m[1, 0] + v.y * m[1, 1] + v.z * m[1, 2];
            float _z = v.x * m[2, 0] + v.y * m[2, 1] + v.z * m[2, 2];
            return new Vector3(_x, _y, _z);
        }

        public static Matrix3x3 operator *(Matrix3x3 m1, Matrix3x3 m2)
        {
            Matrix3x3 newM = new Matrix3x3();

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    newM[i, j] = m1[i, 0] * m2[0, j] + m1[i, 1] * m2[1, j] + m1[i, 2] * m2[2, j];
                }
            }

            return newM;
        }
    }

    public class Matrix4x4
    {
        private float[,] matrix;

        public Matrix4x4()
        {
            this.matrix = new float[4, 4];
        }

        public Matrix4x4(float a11, float a12, float a13, float a14, float a21, float a22, float a23, float a24, float a31, float a32, float a33, float a34, float a41, float a42, float a43, float a44)
        {
            matrix = new float[4, 4];
            matrix[0, 0] = a11;
            matrix[0, 1] = a12;
            matrix[0, 2] = a13;
            matrix[0, 3] = a14;
            matrix[1, 0] = a21;
            matrix[1, 1] = a22;
            matrix[1, 2] = a23;
            matrix[1, 3] = a24;
            matrix[2, 0] = a31;
            matrix[2, 1] = a32;
            matrix[2, 2] = a33;
            matrix[2, 3] = a34;
            matrix[3, 0] = a41;
            matrix[3, 1] = a42;
            matrix[3, 2] = a43;
            matrix[3, 3] = a44;
        }

        public float this[int i, int j] //三维索引器
        {
            get { return matrix[i, j]; }
            set { matrix[i, j] = value; }
        }

        public static Vector4 operator *(Matrix4x4 m, Vector4 v)
        {
            float _x = v.x * m[0, 0] + v.y * m[0, 1] + v.z * m[0, 2] + v.w * m[0, 3];
            float _y = v.x * m[1, 0] + v.y * m[1, 1] + v.z * m[1, 2] + v.w * m[1, 3];
            float _z = v.x * m[2, 0] + v.y * m[2, 1] + v.z * m[2, 2] + v.w * m[2, 3];
            float _w = v.x * m[3, 0] + v.y * m[3, 1] + v.z * m[3, 2] + v.w * m[3, 3];
            return new Vector4(_x, _y, _z, _w);
        }

        public static Matrix4x4 operator *(Matrix4x4 m1, Matrix4x4 m2)
        {
            Matrix4x4 newM = new Matrix4x4();

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    newM[i, j] = m1[i, 0] * m2[0, j] + m1[i, 1] * m2[1, j] + m1[i, 2] * m2[2, j] + m1[i, 3] * m2[3, j];
                }
            }

            return newM;
        }

        public override string ToString()
        {
            string str = this[0, 0] + ", " + this[0, 1] + ", " + this[0, 2] + ", " + this[0, 3] + "\n" +
                this[1, 0] + ", " + this[1, 1] + ", " + this[1, 2] + ", " + this[1, 3] + "\n" +
                this[2, 0] + ", " + this[2, 1] + ", " + this[2, 2] + ", " + this[2, 3] + "\n" +
                this[3, 0] + ", " + this[3, 1] + ", " + this[3, 2] + ", " + this[3, 3];
            return str;
        }
    }

    public interface IFunctionCurve
    {
        string Name { get; set; }
        double[] GetDefineDomain();
        double[] Value(double x);
    }

    
    #endregion


    public class Fuselage
    {
        public Vector2 sectionL;
        public Vector2 sectionR;

        public double length;
        public double run;
        public double rise;

        public Vector3 position;
        public Vector3 rotationEuler;

        public int[] cornerTypes;


        public Vector3 Right()
        {
            Vector3 rightVec = (new Vector3(1, 0, 0)).Rotate(-this.rotationEuler.x, -this.rotationEuler.y, -this.rotationEuler.z).Normalized;
            return rightVec;
        }
        public Vector3 Up()
        {
            Vector3 upVec = (new Vector3(0, 1, 0)).Rotate(-this.rotationEuler.x, -this.rotationEuler.y, -this.rotationEuler.z).Normalized;
            return upVec;
        }
        public Vector3 Forward()
        {
            Vector3 forwardVec = (new Vector3(0, 0, -1)).Rotate(-this.rotationEuler.x, -this.rotationEuler.y, -this.rotationEuler.z).Normalized;
            return forwardVec;
        }
        public Vector3 PosL()
        {
            Vector3 posL = position - (Right() * (float)run + Up() * (float)rise + Forward() * (float)length) * 0.5f * 0.5f;
            return posL;
        }
        public Vector3 PosR()
        {
            Vector3 posR = position + (Right() * (float)run + Up() * (float)rise + Forward() * (float)length) * 0.5f * 0.5f;
            return posR;
        }
    }
}
