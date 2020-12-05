namespace UnitTrans
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
            this.textBoxSpeed = new System.Windows.Forms.TextBox();
            this.comboBoxSpeedUnit = new System.Windows.Forms.ComboBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // textBoxSpeed
            // 
            this.textBoxSpeed.Location = new System.Drawing.Point(22, 23);
            this.textBoxSpeed.Name = "textBoxSpeed";
            this.textBoxSpeed.Size = new System.Drawing.Size(255, 21);
            this.textBoxSpeed.TabIndex = 0;
            this.textBoxSpeed.TextChanged += new System.EventHandler(this.textBoxSpeed_TextChanged);
            // 
            // comboBoxSpeedUnit
            // 
            this.comboBoxSpeedUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSpeedUnit.FormattingEnabled = true;
            this.comboBoxSpeedUnit.Items.AddRange(new object[] {
            "knots",
            "km/h",
            "m/s"});
            this.comboBoxSpeedUnit.Location = new System.Drawing.Point(326, 23);
            this.comboBoxSpeedUnit.Name = "comboBoxSpeedUnit";
            this.comboBoxSpeedUnit.Size = new System.Drawing.Size(121, 20);
            this.comboBoxSpeedUnit.TabIndex = 1;
            this.comboBoxSpeedUnit.SelectedIndexChanged += new System.EventHandler(this.comboBoxSpeedUnit_SelectedIndexChanged);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(22, 64);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(425, 172);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 260);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.comboBoxSpeedUnit);
            this.Controls.Add(this.textBoxSpeed);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxSpeed;
        private System.Windows.Forms.ComboBox comboBoxSpeedUnit;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}

