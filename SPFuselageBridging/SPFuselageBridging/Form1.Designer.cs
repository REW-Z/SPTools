namespace SPFuselageBridging
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
            this.label5 = new System.Windows.Forms.Label();
            this.buttonFrame = new System.Windows.Forms.Button();
            this.buttonBridge = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxPath
            // 
            this.textBoxPath.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxPath.Location = new System.Drawing.Point(39, 12);
            this.textBoxPath.Name = "textBoxPath";
            this.textBoxPath.Size = new System.Drawing.Size(524, 21);
            this.textBoxPath.TabIndex = 15;
            this.textBoxPath.Text = "C:\\Users\\*\\AppData\\LocalLow\\Jundroo\\SimplePlanes\\AircraftDesigns\\*.xml";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label5.Location = new System.Drawing.Point(12, 159);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(293, 12);
            this.label5.TabIndex = 17;
            this.label5.Text = "（要桥接的两个框架圆筒需要涂最后一个颜色材质。）";
            // 
            // buttonFrame
            // 
            this.buttonFrame.Location = new System.Drawing.Point(303, 61);
            this.buttonFrame.Name = "buttonFrame";
            this.buttonFrame.Size = new System.Drawing.Size(260, 84);
            this.buttonFrame.TabIndex = 18;
            this.buttonFrame.Text = "机体生成框架";
            this.buttonFrame.UseVisualStyleBackColor = true;
            this.buttonFrame.Click += new System.EventHandler(this.buttonFrame_Click);
            // 
            // buttonBridge
            // 
            this.buttonBridge.Location = new System.Drawing.Point(39, 61);
            this.buttonBridge.Name = "buttonBridge";
            this.buttonBridge.Size = new System.Drawing.Size(238, 84);
            this.buttonBridge.TabIndex = 19;
            this.buttonBridge.Text = "框架生成机体";
            this.buttonBridge.UseVisualStyleBackColor = true;
            this.buttonBridge.Click += new System.EventHandler(this.buttonBridge_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label1.Location = new System.Drawing.Point(307, 159);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(281, 12);
            this.label1.TabIndex = 20;
            this.label1.Text = "（要生成框架的圆筒也需要涂最后一个颜色材质。）";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 233);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonBridge);
            this.Controls.Add(this.buttonFrame);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxPath);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SPFuselageBridge(by REW)";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBoxPath;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonFrame;
        private System.Windows.Forms.Button buttonBridge;
        private System.Windows.Forms.Label label1;
    }
}

