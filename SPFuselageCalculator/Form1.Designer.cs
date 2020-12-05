namespace SPFuselageCalculator
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.添加到XML文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导出XMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导出到ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查看ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开程序根目录ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.button_SeperateAdd = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.button_subsection = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_count = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button_Add_LinearLerp = new System.Windows.Forms.Button();
            this.textBox_lerpLinear2 = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.textBox_lerpLinear1 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.button_lerp = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label15 = new System.Windows.Forms.Label();
            this.textBox_lerpBezier2 = new System.Windows.Forms.TextBox();
            this.button_Add_Bezier = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.comboBox_bezierAlignH = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.comboBox_bezierAlignW = new System.Windows.Forms.ComboBox();
            this.richTextBox3 = new System.Windows.Forms.RichTextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox_k1 = new System.Windows.Forms.TextBox();
            this.textBox_k0 = new System.Windows.Forms.TextBox();
            this.textBox_lerpBezier1 = new System.Windows.Forms.TextBox();
            this.button_bezierLerp = new System.Windows.Forms.Button();
            this.textBox_widthL = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label18 = new System.Windows.Forms.Label();
            this.textBoxRotation = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.textBoxPosition = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox_length = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_heightR = new System.Windows.Forms.TextBox();
            this.textBox_widthR = new System.Windows.Forms.TextBox();
            this.textBox_Run = new System.Windows.Forms.TextBox();
            this.textBox_Rise = new System.Windows.Forms.TextBox();
            this.textBox_heightL = new System.Windows.Forms.TextBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.button_Clear = new System.Windows.Forms.Button();
            this.textBoxPath = new System.Windows.Forms.TextBox();
            this.buttonReadPath = new System.Windows.Forms.Button();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.查看ToolStripMenuItem,
            this.帮助ToolStripMenuItem,
            this.关于ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(829, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.添加到XML文件ToolStripMenuItem,
            this.导出XMLToolStripMenuItem,
            this.导出到ToolStripMenuItem});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.文件ToolStripMenuItem.Text = "文件";
            // 
            // 添加到XML文件ToolStripMenuItem
            // 
            this.添加到XML文件ToolStripMenuItem.Name = "添加到XML文件ToolStripMenuItem";
            this.添加到XML文件ToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.添加到XML文件ToolStripMenuItem.Text = "添加到XML文件";
            this.添加到XML文件ToolStripMenuItem.Click += new System.EventHandler(this.添加到XML文件ToolStripMenuItem_Click);
            // 
            // 导出XMLToolStripMenuItem
            // 
            this.导出XMLToolStripMenuItem.Name = "导出XMLToolStripMenuItem";
            this.导出XMLToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.导出XMLToolStripMenuItem.Text = "导出XML到桌面";
            this.导出XMLToolStripMenuItem.Click += new System.EventHandler(this.导出XMLToolStripMenuItem_Click);
            // 
            // 导出到ToolStripMenuItem
            // 
            this.导出到ToolStripMenuItem.Name = "导出到ToolStripMenuItem";
            this.导出到ToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.导出到ToolStripMenuItem.Text = "导出XML到...";
            this.导出到ToolStripMenuItem.Click += new System.EventHandler(this.导出到ToolStripMenuItem_Click);
            // 
            // 查看ToolStripMenuItem
            // 
            this.查看ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打开程序根目录ToolStripMenuItem});
            this.查看ToolStripMenuItem.Name = "查看ToolStripMenuItem";
            this.查看ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.查看ToolStripMenuItem.Text = "查看";
            // 
            // 打开程序根目录ToolStripMenuItem
            // 
            this.打开程序根目录ToolStripMenuItem.Name = "打开程序根目录ToolStripMenuItem";
            this.打开程序根目录ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.打开程序根目录ToolStripMenuItem.Text = "打开程序根目录";
            this.打开程序根目录ToolStripMenuItem.Click += new System.EventHandler(this.打开程序根目录ToolStripMenuItem_Click);
            // 
            // 关于ToolStripMenuItem
            // 
            this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            this.关于ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.关于ToolStripMenuItem.Text = "关于";
            this.关于ToolStripMenuItem.Click += new System.EventHandler(this.关于ToolStripMenuItem_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(240, 40);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(345, 347);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.button_SeperateAdd);
            this.tabPage1.Controls.Add(this.richTextBox1);
            this.tabPage1.Controls.Add(this.button_subsection);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.textBox_count);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(337, 321);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "圆筒分段";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // button_SeperateAdd
            // 
            this.button_SeperateAdd.Location = new System.Drawing.Point(257, 64);
            this.button_SeperateAdd.Name = "button_SeperateAdd";
            this.button_SeperateAdd.Size = new System.Drawing.Size(74, 221);
            this.button_SeperateAdd.TabIndex = 15;
            this.button_SeperateAdd.Text = "添加>>";
            this.button_SeperateAdd.UseVisualStyleBackColor = true;
            this.button_SeperateAdd.Click += new System.EventHandler(this.button_SeperateAdd_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(6, 64);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(244, 221);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "";
            // 
            // button_subsection
            // 
            this.button_subsection.Location = new System.Drawing.Point(257, 27);
            this.button_subsection.Name = "button_subsection";
            this.button_subsection.Size = new System.Drawing.Size(74, 21);
            this.button_subsection.TabIndex = 2;
            this.button_subsection.Text = "分段";
            this.button_subsection.UseVisualStyleBackColor = true;
            this.button_subsection.Click += new System.EventHandler(this.button_subsection_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 30);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 1;
            this.label7.Text = "段数";
            // 
            // textBox_count
            // 
            this.textBox_count.Location = new System.Drawing.Point(41, 27);
            this.textBox_count.Name = "textBox_count";
            this.textBox_count.Size = new System.Drawing.Size(209, 21);
            this.textBox_count.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.button_Add_LinearLerp);
            this.tabPage2.Controls.Add(this.textBox_lerpLinear2);
            this.tabPage2.Controls.Add(this.label16);
            this.tabPage2.Controls.Add(this.richTextBox2);
            this.tabPage2.Controls.Add(this.textBox_lerpLinear1);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.button_lerp);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(337, 321);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "线性插值";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // button_Add_LinearLerp
            // 
            this.button_Add_LinearLerp.Location = new System.Drawing.Point(257, 65);
            this.button_Add_LinearLerp.Name = "button_Add_LinearLerp";
            this.button_Add_LinearLerp.Size = new System.Drawing.Size(74, 220);
            this.button_Add_LinearLerp.TabIndex = 14;
            this.button_Add_LinearLerp.Text = "截取>>";
            this.button_Add_LinearLerp.UseVisualStyleBackColor = true;
            this.button_Add_LinearLerp.Click += new System.EventHandler(this.button_Add_LinearLerp_Click);
            // 
            // textBox_lerpLinear2
            // 
            this.textBox_lerpLinear2.Location = new System.Drawing.Point(183, 27);
            this.textBox_lerpLinear2.Name = "textBox_lerpLinear2";
            this.textBox_lerpLinear2.Size = new System.Drawing.Size(68, 21);
            this.textBox_lerpLinear2.TabIndex = 5;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(136, 30);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(47, 12);
            this.label16.TabIndex = 4;
            this.label16.Text = "t2(0~1)";
            // 
            // richTextBox2
            // 
            this.richTextBox2.Location = new System.Drawing.Point(6, 65);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(245, 220);
            this.richTextBox2.TabIndex = 3;
            this.richTextBox2.Text = "";
            // 
            // textBox_lerpLinear1
            // 
            this.textBox_lerpLinear1.Location = new System.Drawing.Point(51, 27);
            this.textBox_lerpLinear1.Name = "textBox_lerpLinear1";
            this.textBox_lerpLinear1.Size = new System.Drawing.Size(62, 21);
            this.textBox_lerpLinear1.TabIndex = 2;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(4, 30);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 12);
            this.label9.TabIndex = 1;
            this.label9.Text = "t1(0~1)";
            // 
            // button_lerp
            // 
            this.button_lerp.Location = new System.Drawing.Point(257, 27);
            this.button_lerp.Name = "button_lerp";
            this.button_lerp.Size = new System.Drawing.Size(74, 21);
            this.button_lerp.TabIndex = 0;
            this.button_lerp.Text = "插值";
            this.button_lerp.UseVisualStyleBackColor = true;
            this.button_lerp.Click += new System.EventHandler(this.button_lerp_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label15);
            this.tabPage3.Controls.Add(this.textBox_lerpBezier2);
            this.tabPage3.Controls.Add(this.button_Add_Bezier);
            this.tabPage3.Controls.Add(this.label14);
            this.tabPage3.Controls.Add(this.comboBox_bezierAlignH);
            this.tabPage3.Controls.Add(this.label13);
            this.tabPage3.Controls.Add(this.comboBox_bezierAlignW);
            this.tabPage3.Controls.Add(this.richTextBox3);
            this.tabPage3.Controls.Add(this.label12);
            this.tabPage3.Controls.Add(this.label11);
            this.tabPage3.Controls.Add(this.label10);
            this.tabPage3.Controls.Add(this.textBox_k1);
            this.tabPage3.Controls.Add(this.textBox_k0);
            this.tabPage3.Controls.Add(this.textBox_lerpBezier1);
            this.tabPage3.Controls.Add(this.button_bezierLerp);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(337, 321);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Bezier插值";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(139, 101);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(41, 12);
            this.label15.TabIndex = 15;
            this.label15.Text = "t(0~1)";
            // 
            // textBox_lerpBezier2
            // 
            this.textBox_lerpBezier2.Location = new System.Drawing.Point(180, 96);
            this.textBox_lerpBezier2.Name = "textBox_lerpBezier2";
            this.textBox_lerpBezier2.Size = new System.Drawing.Size(87, 21);
            this.textBox_lerpBezier2.TabIndex = 14;
            this.textBox_lerpBezier2.Text = "1";
            // 
            // button_Add_Bezier
            // 
            this.button_Add_Bezier.Location = new System.Drawing.Point(273, 122);
            this.button_Add_Bezier.Name = "button_Add_Bezier";
            this.button_Add_Bezier.Size = new System.Drawing.Size(54, 163);
            this.button_Add_Bezier.TabIndex = 13;
            this.button_Add_Bezier.Text = "截取>>";
            this.button_Add_Bezier.UseVisualStyleBackColor = true;
            this.button_Add_Bezier.Click += new System.EventHandler(this.button_Add_Bezier_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 74);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(41, 12);
            this.label14.TabIndex = 12;
            this.label14.Text = "alignH";
            // 
            // comboBox_bezierAlignH
            // 
            this.comboBox_bezierAlignH.FormattingEnabled = true;
            this.comboBox_bezierAlignH.Items.AddRange(new object[] {
            "+align",
            "-align"});
            this.comboBox_bezierAlignH.Location = new System.Drawing.Point(47, 71);
            this.comboBox_bezierAlignH.Name = "comboBox_bezierAlignH";
            this.comboBox_bezierAlignH.Size = new System.Drawing.Size(127, 20);
            this.comboBox_bezierAlignH.TabIndex = 11;
            this.comboBox_bezierAlignH.Text = "-align";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 51);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(41, 12);
            this.label13.TabIndex = 10;
            this.label13.Text = "alignW";
            // 
            // comboBox_bezierAlignW
            // 
            this.comboBox_bezierAlignW.FormattingEnabled = true;
            this.comboBox_bezierAlignW.Items.AddRange(new object[] {
            "+align",
            "-align"});
            this.comboBox_bezierAlignW.Location = new System.Drawing.Point(47, 48);
            this.comboBox_bezierAlignW.Name = "comboBox_bezierAlignW";
            this.comboBox_bezierAlignW.Size = new System.Drawing.Size(127, 20);
            this.comboBox_bezierAlignW.TabIndex = 9;
            this.comboBox_bezierAlignW.Text = "-align";
            // 
            // richTextBox3
            // 
            this.richTextBox3.Location = new System.Drawing.Point(6, 122);
            this.richTextBox3.Name = "richTextBox3";
            this.richTextBox3.Size = new System.Drawing.Size(261, 163);
            this.richTextBox3.TabIndex = 7;
            this.richTextBox3.Text = "";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(139, 24);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(35, 12);
            this.label12.TabIndex = 6;
            this.label12.Text = "k1(R)";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 24);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 12);
            this.label11.TabIndex = 5;
            this.label11.Text = "k0(L)";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 101);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 12);
            this.label10.TabIndex = 4;
            this.label10.Text = "t(0~1)";
            // 
            // textBox_k1
            // 
            this.textBox_k1.Location = new System.Drawing.Point(180, 21);
            this.textBox_k1.Name = "textBox_k1";
            this.textBox_k1.Size = new System.Drawing.Size(87, 21);
            this.textBox_k1.TabIndex = 3;
            this.textBox_k1.Text = "2";
            // 
            // textBox_k0
            // 
            this.textBox_k0.Location = new System.Drawing.Point(47, 21);
            this.textBox_k0.Name = "textBox_k0";
            this.textBox_k0.Size = new System.Drawing.Size(70, 21);
            this.textBox_k0.TabIndex = 2;
            this.textBox_k0.Text = "0";
            // 
            // textBox_lerpBezier1
            // 
            this.textBox_lerpBezier1.Location = new System.Drawing.Point(47, 96);
            this.textBox_lerpBezier1.Name = "textBox_lerpBezier1";
            this.textBox_lerpBezier1.Size = new System.Drawing.Size(70, 21);
            this.textBox_lerpBezier1.TabIndex = 1;
            this.textBox_lerpBezier1.Text = "0";
            // 
            // button_bezierLerp
            // 
            this.button_bezierLerp.Location = new System.Drawing.Point(273, 13);
            this.button_bezierLerp.Name = "button_bezierLerp";
            this.button_bezierLerp.Size = new System.Drawing.Size(54, 103);
            this.button_bezierLerp.TabIndex = 0;
            this.button_bezierLerp.Text = "插值";
            this.button_bezierLerp.UseVisualStyleBackColor = true;
            this.button_bezierLerp.Click += new System.EventHandler(this.button_bezierLerp_Click);
            // 
            // textBox_widthL
            // 
            this.textBox_widthL.Location = new System.Drawing.Point(111, 20);
            this.textBox_widthL.Name = "textBox_widthL";
            this.textBox_widthL.Size = new System.Drawing.Size(100, 21);
            this.textBox_widthL.TabIndex = 0;
            this.textBox_widthL.Text = "1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.textBoxRotation);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.textBoxPosition);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.textBox_length);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBox_heightR);
            this.groupBox1.Controls.Add(this.textBox_widthR);
            this.groupBox1.Controls.Add(this.textBox_Run);
            this.groupBox1.Controls.Add(this.textBox_Rise);
            this.groupBox1.Controls.Add(this.textBox_heightL);
            this.groupBox1.Controls.Add(this.textBox_widthL);
            this.groupBox1.Location = new System.Drawing.Point(12, 89);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(222, 298);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "原始圆筒信息";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(16, 235);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(53, 12);
            this.label18.TabIndex = 17;
            this.label18.Text = "Rotation";
            // 
            // textBoxRotation
            // 
            this.textBoxRotation.Location = new System.Drawing.Point(111, 230);
            this.textBoxRotation.Name = "textBoxRotation";
            this.textBoxRotation.Size = new System.Drawing.Size(100, 21);
            this.textBoxRotation.TabIndex = 16;
            this.textBoxRotation.Text = "0,0,0";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(16, 262);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(53, 12);
            this.label17.TabIndex = 15;
            this.label17.Text = "Position";
            // 
            // textBoxPosition
            // 
            this.textBoxPosition.Location = new System.Drawing.Point(111, 257);
            this.textBoxPosition.Name = "textBoxPosition";
            this.textBoxPosition.Size = new System.Drawing.Size(100, 21);
            this.textBoxPosition.TabIndex = 14;
            this.textBoxPosition.Text = "0,0,0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 90);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 13;
            this.label8.Text = "Length";
            // 
            // textBox_length
            // 
            this.textBox_length.Location = new System.Drawing.Point(111, 85);
            this.textBox_length.Name = "textBox_length";
            this.textBox_length.Size = new System.Drawing.Size(100, 21);
            this.textBox_length.TabIndex = 12;
            this.textBox_length.Text = "1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 200);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 12);
            this.label5.TabIndex = 11;
            this.label5.Text = "frontHeight(R)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 173);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 12);
            this.label6.TabIndex = 10;
            this.label6.Text = "frontWidth(R)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "Run";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "Rise";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "rearHeight(L)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "rearWidth(L)";
            // 
            // textBox_heightR
            // 
            this.textBox_heightR.Location = new System.Drawing.Point(111, 195);
            this.textBox_heightR.Name = "textBox_heightR";
            this.textBox_heightR.Size = new System.Drawing.Size(100, 21);
            this.textBox_heightR.TabIndex = 5;
            this.textBox_heightR.Text = "1";
            // 
            // textBox_widthR
            // 
            this.textBox_widthR.Location = new System.Drawing.Point(111, 168);
            this.textBox_widthR.Name = "textBox_widthR";
            this.textBox_widthR.Size = new System.Drawing.Size(100, 21);
            this.textBox_widthR.TabIndex = 4;
            this.textBox_widthR.Text = "1";
            // 
            // textBox_Run
            // 
            this.textBox_Run.Location = new System.Drawing.Point(111, 112);
            this.textBox_Run.Name = "textBox_Run";
            this.textBox_Run.Size = new System.Drawing.Size(100, 21);
            this.textBox_Run.TabIndex = 3;
            this.textBox_Run.Text = "0";
            // 
            // textBox_Rise
            // 
            this.textBox_Rise.Location = new System.Drawing.Point(111, 139);
            this.textBox_Rise.Name = "textBox_Rise";
            this.textBox_Rise.Size = new System.Drawing.Size(100, 21);
            this.textBox_Rise.TabIndex = 2;
            this.textBox_Rise.Text = "0";
            // 
            // textBox_heightL
            // 
            this.textBox_heightL.Location = new System.Drawing.Point(111, 47);
            this.textBox_heightL.Name = "textBox_heightL";
            this.textBox_heightL.Size = new System.Drawing.Size(100, 21);
            this.textBox_heightL.TabIndex = 1;
            this.textBox_heightL.Text = "1";
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(600, 62);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(208, 325);
            this.listView1.TabIndex = 13;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "img_fuselage.png");
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.AddExtension = false;
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // button_Clear
            // 
            this.button_Clear.Location = new System.Drawing.Point(600, 28);
            this.button_Clear.Name = "button_Clear";
            this.button_Clear.Size = new System.Drawing.Size(208, 28);
            this.button_Clear.TabIndex = 14;
            this.button_Clear.Text = "清除";
            this.button_Clear.UseVisualStyleBackColor = true;
            this.button_Clear.Click += new System.EventHandler(this.button_Clear_Click);
            // 
            // textBoxPath
            // 
            this.textBoxPath.Location = new System.Drawing.Point(13, 40);
            this.textBoxPath.Name = "textBoxPath";
            this.textBoxPath.Size = new System.Drawing.Size(141, 21);
            this.textBoxPath.TabIndex = 15;
            // 
            // buttonReadPath
            // 
            this.buttonReadPath.Location = new System.Drawing.Point(161, 40);
            this.buttonReadPath.Name = "buttonReadPath";
            this.buttonReadPath.Size = new System.Drawing.Size(51, 20);
            this.buttonReadPath.TabIndex = 16;
            this.buttonReadPath.Text = "读取";
            this.buttonReadPath.UseVisualStyleBackColor = true;
            this.buttonReadPath.Click += new System.EventHandler(this.buttonReadPath_Click);
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.帮助ToolStripMenuItem.Text = "帮助";
            this.帮助ToolStripMenuItem.Click += new System.EventHandler(this.帮助ToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(829, 423);
            this.Controls.Add(this.buttonReadPath);
            this.Controls.Add(this.textBoxPath);
            this.Controls.Add(this.button_Clear);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SP圆筒计算器";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox textBox_widthL;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_heightR;
        private System.Windows.Forms.TextBox textBox_widthR;
        private System.Windows.Forms.TextBox textBox_Run;
        private System.Windows.Forms.TextBox textBox_Rise;
        private System.Windows.Forms.TextBox textBox_heightL;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button button_subsection;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox_count;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox_length;
        private System.Windows.Forms.Button button_lerp;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.TextBox textBox_lerpLinear1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button button_bezierLerp;
        private System.Windows.Forms.TextBox textBox_lerpBezier1;
        private System.Windows.Forms.TextBox textBox_k1;
        private System.Windows.Forms.TextBox textBox_k0;
        private System.Windows.Forms.RichTextBox richTextBox3;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox comboBox_bezierAlignW;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ToolStripMenuItem 导出XMLToolStripMenuItem;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox comboBox_bezierAlignH;
        private System.Windows.Forms.Button button_Add_Bezier;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox textBox_lerpBezier2;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TextBox textBox_lerpLinear2;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button button_Add_LinearLerp;
        private System.Windows.Forms.ToolStripMenuItem 查看ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开程序根目录ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 导出到ToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button button_SeperateAdd;
        private System.Windows.Forms.Button button_Clear;
        private System.Windows.Forms.TextBox textBoxPath;
        private System.Windows.Forms.Button buttonReadPath;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox textBoxPosition;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox textBoxRotation;
        private System.Windows.Forms.ToolStripMenuItem 添加到XML文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
    }
}

