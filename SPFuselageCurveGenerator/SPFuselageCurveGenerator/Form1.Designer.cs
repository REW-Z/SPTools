namespace SPFuselageCurveGenerator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel_curve = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.status_label1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.textBox_t0 = new System.Windows.Forms.TextBox();
            this.radioButton_curve = new System.Windows.Forms.RadioButton();
            this.radioButton_seg = new System.Windows.Forms.RadioButton();
            this.textBox_scale = new System.Windows.Forms.TextBox();
            this.button_writeXML = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.radioButton_arcs = new System.Windows.Forms.RadioButton();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_curve
            // 
            this.panel_curve.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_curve.Location = new System.Drawing.Point(32, 66);
            this.panel_curve.Name = "panel_curve";
            this.panel_curve.Size = new System.Drawing.Size(300, 300);
            this.panel_curve.TabIndex = 0;
            this.panel_curve.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_curve_Paint);
            this.panel_curve.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_curve_MouseDown);
            this.panel_curve.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel_curve_MouseUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "线段起始点(0~1)：";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.status_label1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 378);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(480, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // status_label1
            // 
            this.status_label1.Name = "status_label1";
            this.status_label1.Size = new System.Drawing.Size(0, 17);
            // 
            // textBox_t0
            // 
            this.textBox_t0.Location = new System.Drawing.Point(143, 44);
            this.textBox_t0.Name = "textBox_t0";
            this.textBox_t0.Size = new System.Drawing.Size(189, 21);
            this.textBox_t0.TabIndex = 3;
            this.textBox_t0.Text = "0.05";
            this.textBox_t0.TextChanged += new System.EventHandler(this.textBox_t0_TextChanged);
            // 
            // radioButton_curve
            // 
            this.radioButton_curve.AutoSize = true;
            this.radioButton_curve.Location = new System.Drawing.Point(349, 66);
            this.radioButton_curve.Name = "radioButton_curve";
            this.radioButton_curve.Size = new System.Drawing.Size(71, 16);
            this.radioButton_curve.TabIndex = 4;
            this.radioButton_curve.TabStop = true;
            this.radioButton_curve.Text = "绘制曲线";
            this.radioButton_curve.UseVisualStyleBackColor = true;
            this.radioButton_curve.CheckedChanged += new System.EventHandler(this.radioButton_curve_CheckedChanged);
            // 
            // radioButton_seg
            // 
            this.radioButton_seg.AutoSize = true;
            this.radioButton_seg.Location = new System.Drawing.Point(349, 88);
            this.radioButton_seg.Name = "radioButton_seg";
            this.radioButton_seg.Size = new System.Drawing.Size(71, 16);
            this.radioButton_seg.TabIndex = 5;
            this.radioButton_seg.TabStop = true;
            this.radioButton_seg.Text = "绘制线段";
            this.radioButton_seg.UseVisualStyleBackColor = true;
            this.radioButton_seg.CheckedChanged += new System.EventHandler(this.radioButton_seg_CheckedChanged);
            // 
            // textBox_scale
            // 
            this.textBox_scale.Location = new System.Drawing.Point(382, 232);
            this.textBox_scale.Name = "textBox_scale";
            this.textBox_scale.Size = new System.Drawing.Size(67, 21);
            this.textBox_scale.TabIndex = 6;
            this.textBox_scale.Text = "0.1";
            this.textBox_scale.TextChanged += new System.EventHandler(this.textBox_scale_TextChanged);
            // 
            // button_writeXML
            // 
            this.button_writeXML.Location = new System.Drawing.Point(349, 270);
            this.button_writeXML.Name = "button_writeXML";
            this.button_writeXML.Size = new System.Drawing.Size(100, 96);
            this.button_writeXML.TabIndex = 7;
            this.button_writeXML.Text = "导出XML";
            this.button_writeXML.UseVisualStyleBackColor = true;
            this.button_writeXML.Click += new System.EventHandler(this.button_writeXML_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(347, 235);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "缩放";
            // 
            // radioButton_arcs
            // 
            this.radioButton_arcs.AutoSize = true;
            this.radioButton_arcs.Location = new System.Drawing.Point(349, 110);
            this.radioButton_arcs.Name = "radioButton_arcs";
            this.radioButton_arcs.Size = new System.Drawing.Size(71, 16);
            this.radioButton_arcs.TabIndex = 9;
            this.radioButton_arcs.TabStop = true;
            this.radioButton_arcs.Text = "绘制椭圆";
            this.radioButton_arcs.UseVisualStyleBackColor = true;
            this.radioButton_arcs.CheckedChanged += new System.EventHandler(this.radioButton_arcs_CheckedChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.关于ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(480, 25);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.文件ToolStripMenuItem.Text = "文件";
            // 
            // 关于ToolStripMenuItem
            // 
            this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            this.关于ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.关于ToolStripMenuItem.Text = "关于";
            this.关于ToolStripMenuItem.Click += new System.EventHandler(this.关于ToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 400);
            this.Controls.Add(this.radioButton_arcs);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button_writeXML);
            this.Controls.Add(this.textBox_scale);
            this.Controls.Add(this.radioButton_seg);
            this.Controls.Add(this.radioButton_curve);
            this.Controls.Add(this.textBox_t0);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel_curve);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "曲线圆筒结构生成器(by REW)";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel_curve;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel status_label1;
        private System.Windows.Forms.TextBox textBox_t0;
        private System.Windows.Forms.RadioButton radioButton_curve;
        private System.Windows.Forms.RadioButton radioButton_seg;
        private System.Windows.Forms.TextBox textBox_scale;
        private System.Windows.Forms.Button button_writeXML;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton radioButton_arcs;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
    }
}

