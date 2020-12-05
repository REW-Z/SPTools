using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UnitTrans
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ShowResult()
        {
            double speed = 0d; Double.TryParse(textBoxSpeed.Text, out speed);
            string result = "";
            switch (comboBoxSpeedUnit.Text)
            {
                case "knots":
                    string str = "";
                    str += (speed * 1.852d + "km/h" + "\n");
                    str += (speed * 0.5144444d + "m/s" + "\n");
                    result = str;
                    break;
                case "km/h":
                    string str2 = "";
                    str2 += (speed * 0.54d + "knots" + "\n");
                    str2 += (speed * 0.2777778d + "m/s" + "\n");
                    result = str2;
                    break;
                case "m/s":
                    string str3 = "";
                    str3 += (speed * 1.944d + "knots" + "\n");
                    str3 += (speed * 3.6d + "km/h" + "\n");
                    result = str3;
                    break;
                default:
                    result = "error";
                    break;
            }
            richTextBox1.Text = result;
        }

        private void textBoxSpeed_TextChanged(object sender, EventArgs e)
        {
            ShowResult();
        }

        private void comboBoxSpeedUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowResult();
        }
    }
}
