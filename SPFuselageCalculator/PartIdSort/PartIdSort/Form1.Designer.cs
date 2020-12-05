namespace PartIdSort
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
            this.textBoxPath = new System.Windows.Forms.TextBox();
            this.buttonSort = new System.Windows.Forms.Button();
            this.buttonDisableCol = new System.Windows.Forms.Button();
            this.buttonSetMass = new System.Windows.Forms.Button();
            this.textBoxMassScale = new System.Windows.Forms.TextBox();
            this.checkBoxOnlyFuselage = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBoxOnlyMarkedMass = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.buttonCalculateDrags = new System.Windows.Forms.Button();
            this.checkBoxOnlyMarkDrags = new System.Windows.Forms.CheckBox();
            this.textBoxDragScale = new System.Windows.Forms.TextBox();
            this.buttonDragScale = new System.Windows.Forms.Button();
            this.buttonDisableDrags = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxScale = new System.Windows.Forms.TextBox();
            this.buttonScaleChange = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.buttonJoin = new System.Windows.Forms.Button();
            this.textBoxPathJoin = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxJoinMassScale = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxPath
            // 
            this.textBoxPath.Location = new System.Drawing.Point(12, 23);
            this.textBoxPath.Name = "textBoxPath";
            this.textBoxPath.Size = new System.Drawing.Size(605, 21);
            this.textBoxPath.TabIndex = 0;
            // 
            // buttonSort
            // 
            this.buttonSort.Location = new System.Drawing.Point(6, 91);
            this.buttonSort.Name = "buttonSort";
            this.buttonSort.Size = new System.Drawing.Size(121, 55);
            this.buttonSort.TabIndex = 1;
            this.buttonSort.Text = "Sort";
            this.buttonSort.UseVisualStyleBackColor = true;
            this.buttonSort.Click += new System.EventHandler(this.buttonSort_Click);
            // 
            // buttonDisableCol
            // 
            this.buttonDisableCol.Location = new System.Drawing.Point(6, 91);
            this.buttonDisableCol.Name = "buttonDisableCol";
            this.buttonDisableCol.Size = new System.Drawing.Size(121, 55);
            this.buttonDisableCol.TabIndex = 2;
            this.buttonDisableCol.Text = "DisableCollision";
            this.buttonDisableCol.UseVisualStyleBackColor = true;
            this.buttonDisableCol.Click += new System.EventHandler(this.buttonDisableCol_Click);
            // 
            // buttonSetMass
            // 
            this.buttonSetMass.Location = new System.Drawing.Point(6, 91);
            this.buttonSetMass.Name = "buttonSetMass";
            this.buttonSetMass.Size = new System.Drawing.Size(121, 55);
            this.buttonSetMass.TabIndex = 3;
            this.buttonSetMass.Text = "massScale";
            this.buttonSetMass.UseVisualStyleBackColor = true;
            this.buttonSetMass.Click += new System.EventHandler(this.buttonSetMass_Click);
            // 
            // textBoxMassScale
            // 
            this.textBoxMassScale.Location = new System.Drawing.Point(6, 20);
            this.textBoxMassScale.Name = "textBoxMassScale";
            this.textBoxMassScale.Size = new System.Drawing.Size(82, 21);
            this.textBoxMassScale.TabIndex = 4;
            // 
            // checkBoxOnlyFuselage
            // 
            this.checkBoxOnlyFuselage.AutoSize = true;
            this.checkBoxOnlyFuselage.Location = new System.Drawing.Point(6, 47);
            this.checkBoxOnlyFuselage.Name = "checkBoxOnlyFuselage";
            this.checkBoxOnlyFuselage.Size = new System.Drawing.Size(60, 16);
            this.checkBoxOnlyFuselage.TabIndex = 5;
            this.checkBoxOnlyFuselage.Text = "仅圆筒";
            this.checkBoxOnlyFuselage.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBoxOnlyMarkedMass);
            this.groupBox1.Controls.Add(this.textBoxMassScale);
            this.groupBox1.Controls.Add(this.checkBoxOnlyFuselage);
            this.groupBox1.Controls.Add(this.buttonSetMass);
            this.groupBox1.Location = new System.Drawing.Point(12, 61);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(133, 154);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "质量";
            // 
            // checkBoxOnlyMarkedMass
            // 
            this.checkBoxOnlyMarkedMass.AutoSize = true;
            this.checkBoxOnlyMarkedMass.Location = new System.Drawing.Point(6, 69);
            this.checkBoxOnlyMarkedMass.Name = "checkBoxOnlyMarkedMass";
            this.checkBoxOnlyMarkedMass.Size = new System.Drawing.Size(84, 16);
            this.checkBoxOnlyMarkedMass.TabIndex = 6;
            this.checkBoxOnlyMarkedMass.Text = "仅标记零件";
            this.checkBoxOnlyMarkedMass.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonSort);
            this.groupBox2.Location = new System.Drawing.Point(165, 61);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(133, 154);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "排序";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.buttonDisableCol);
            this.groupBox3.Location = new System.Drawing.Point(317, 61);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(133, 154);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "碰撞";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.buttonCalculateDrags);
            this.groupBox4.Controls.Add(this.checkBoxOnlyMarkDrags);
            this.groupBox4.Controls.Add(this.textBoxDragScale);
            this.groupBox4.Controls.Add(this.buttonDragScale);
            this.groupBox4.Controls.Add(this.buttonDisableDrags);
            this.groupBox4.Location = new System.Drawing.Point(484, 61);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(133, 154);
            this.groupBox4.TabIndex = 9;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "阻力";
            // 
            // buttonCalculateDrags
            // 
            this.buttonCalculateDrags.Location = new System.Drawing.Point(6, 120);
            this.buttonCalculateDrags.Name = "buttonCalculateDrags";
            this.buttonCalculateDrags.Size = new System.Drawing.Size(121, 26);
            this.buttonCalculateDrags.TabIndex = 9;
            this.buttonCalculateDrags.Text = "CalculateDrags";
            this.buttonCalculateDrags.UseVisualStyleBackColor = true;
            this.buttonCalculateDrags.Click += new System.EventHandler(this.buttonCalculateDrags_Click);
            // 
            // checkBoxOnlyMarkDrags
            // 
            this.checkBoxOnlyMarkDrags.AutoSize = true;
            this.checkBoxOnlyMarkDrags.Location = new System.Drawing.Point(6, 22);
            this.checkBoxOnlyMarkDrags.Name = "checkBoxOnlyMarkDrags";
            this.checkBoxOnlyMarkDrags.Size = new System.Drawing.Size(60, 16);
            this.checkBoxOnlyMarkDrags.TabIndex = 8;
            this.checkBoxOnlyMarkDrags.Text = "仅标记";
            this.checkBoxOnlyMarkDrags.UseVisualStyleBackColor = true;
            // 
            // textBoxDragScale
            // 
            this.textBoxDragScale.Location = new System.Drawing.Point(6, 64);
            this.textBoxDragScale.Name = "textBoxDragScale";
            this.textBoxDragScale.Size = new System.Drawing.Size(40, 21);
            this.textBoxDragScale.TabIndex = 7;
            // 
            // buttonDragScale
            // 
            this.buttonDragScale.Location = new System.Drawing.Point(52, 64);
            this.buttonDragScale.Name = "buttonDragScale";
            this.buttonDragScale.Size = new System.Drawing.Size(75, 21);
            this.buttonDragScale.TabIndex = 3;
            this.buttonDragScale.Text = "ScaleDrags";
            this.buttonDragScale.UseVisualStyleBackColor = true;
            this.buttonDragScale.Click += new System.EventHandler(this.buttonDragScale_Click);
            // 
            // buttonDisableDrags
            // 
            this.buttonDisableDrags.Location = new System.Drawing.Point(6, 91);
            this.buttonDisableDrags.Name = "buttonDisableDrags";
            this.buttonDisableDrags.Size = new System.Drawing.Size(121, 26);
            this.buttonDisableDrags.TabIndex = 2;
            this.buttonDisableDrags.Text = "DisableDrags";
            this.buttonDisableDrags.UseVisualStyleBackColor = true;
            this.buttonDisableDrags.Click += new System.EventHandler(this.buttonDisableDrags_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Controls.Add(this.label1);
            this.groupBox5.Controls.Add(this.textBoxScale);
            this.groupBox5.Controls.Add(this.buttonScaleChange);
            this.groupBox5.Location = new System.Drawing.Point(12, 233);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(133, 154);
            this.groupBox5.TabIndex = 10;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "圆筒缩放调整";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label2.Location = new System.Drawing.Point(2, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "（仅调整标记圆筒）";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label1.Location = new System.Drawing.Point(2, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "（圆筒大小保持不变）";
            // 
            // textBoxScale
            // 
            this.textBoxScale.Location = new System.Drawing.Point(6, 63);
            this.textBoxScale.Name = "textBoxScale";
            this.textBoxScale.Size = new System.Drawing.Size(121, 21);
            this.textBoxScale.TabIndex = 7;
            // 
            // buttonScaleChange
            // 
            this.buttonScaleChange.Location = new System.Drawing.Point(6, 90);
            this.buttonScaleChange.Name = "buttonScaleChange";
            this.buttonScaleChange.Size = new System.Drawing.Size(121, 58);
            this.buttonScaleChange.TabIndex = 3;
            this.buttonScaleChange.Text = "ScaleChange";
            this.buttonScaleChange.UseVisualStyleBackColor = true;
            this.buttonScaleChange.Click += new System.EventHandler(this.buttonScaleChange_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.textBoxJoinMassScale);
            this.groupBox6.Controls.Add(this.label3);
            this.groupBox6.Controls.Add(this.textBoxPathJoin);
            this.groupBox6.Controls.Add(this.buttonJoin);
            this.groupBox6.Location = new System.Drawing.Point(165, 233);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(452, 154);
            this.groupBox6.TabIndex = 8;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "并入";
            // 
            // buttonJoin
            // 
            this.buttonJoin.Location = new System.Drawing.Point(6, 119);
            this.buttonJoin.Name = "buttonJoin";
            this.buttonJoin.Size = new System.Drawing.Size(440, 27);
            this.buttonJoin.TabIndex = 1;
            this.buttonJoin.Text = "Join";
            this.buttonJoin.UseVisualStyleBackColor = true;
            this.buttonJoin.Click += new System.EventHandler(this.buttonJoin_Click);
            // 
            // textBoxPathJoin
            // 
            this.textBoxPathJoin.Location = new System.Drawing.Point(8, 27);
            this.textBoxPathJoin.Name = "textBoxPathJoin";
            this.textBoxPathJoin.Size = new System.Drawing.Size(425, 21);
            this.textBoxPathJoin.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label3.Location = new System.Drawing.Point(6, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 12);
            this.label3.TabIndex = 10;
            this.label3.Text = "基准零件massScale";
            // 
            // textBoxJoinMassScale
            // 
            this.textBoxJoinMassScale.Location = new System.Drawing.Point(119, 63);
            this.textBoxJoinMassScale.Name = "textBoxJoinMassScale";
            this.textBoxJoinMassScale.Size = new System.Drawing.Size(100, 21);
            this.textBoxJoinMassScale.TabIndex = 12;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 431);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBoxPath);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "PartOperations";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxPath;
        private System.Windows.Forms.Button buttonSort;
        private System.Windows.Forms.Button buttonDisableCol;
        private System.Windows.Forms.Button buttonSetMass;
        private System.Windows.Forms.TextBox textBoxMassScale;
        private System.Windows.Forms.CheckBox checkBoxOnlyFuselage;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox checkBoxOnlyMarkedMass;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button buttonDisableDrags;
        private System.Windows.Forms.TextBox textBoxDragScale;
        private System.Windows.Forms.Button buttonDragScale;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxScale;
        private System.Windows.Forms.Button buttonScaleChange;
        private System.Windows.Forms.Button buttonCalculateDrags;
        private System.Windows.Forms.CheckBox checkBoxOnlyMarkDrags;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox textBoxJoinMassScale;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxPathJoin;
        private System.Windows.Forms.Button buttonJoin;
    }
}

