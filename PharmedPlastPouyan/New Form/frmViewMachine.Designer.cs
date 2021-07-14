namespace PharmedPlastPouyan
{
    partial class frmViewMachine
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.radTitleBar1 = new Telerik.WinControls.UI.RadTitleBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.led1 = new PharmedPlastPouyan.LEDSize1();
            this.led2 = new PharmedPlastPouyan.LEDSize2();
            this.led3 = new PharmedPlastPouyan.LEDSize3();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtInstallationPosition = new System.Windows.Forms.Label();
            this.txtManufacturingYear = new System.Windows.Forms.Label();
            this.txtOrigin = new System.Windows.Forms.Label();
            this.txtSerial = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtModel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMachineName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMachineNumber = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnExit = new Telerik.WinControls.UI.RadButton();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.radTitleBar1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.led1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.led2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.led3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).BeginInit();
            this.SuspendLayout();
            // 
            // radTitleBar1
            // 
            this.radTitleBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radTitleBar1.Font = new System.Drawing.Font("IRANSansWeb(FaNum)", 12F);
            this.radTitleBar1.ForeColor = System.Drawing.Color.Black;
            this.radTitleBar1.Location = new System.Drawing.Point(0, 0);
            this.radTitleBar1.Name = "radTitleBar1";
            this.radTitleBar1.Size = new System.Drawing.Size(1239, 34);
            this.radTitleBar1.TabIndex = 3;
            this.radTitleBar1.TabStop = false;
            this.radTitleBar1.Text = "نمایش مشخصات ماشین";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 34);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(10);
            this.panel1.Size = new System.Drawing.Size(1239, 807);
            this.panel1.TabIndex = 4;
            // 
            // panel3
            // 
            this.panel3.BackgroundImage = global::PharmedPlastPouyan.Properties.Resources.panelbackGround2;
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel3.Controls.Add(this.led1);
            this.panel3.Controls.Add(this.led2);
            this.panel3.Controls.Add(this.led3);
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(10, 127);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(9);
            this.panel3.Size = new System.Drawing.Size(1219, 620);
            this.panel3.TabIndex = 1;
            // 
            // led1
            // 
            this.led1.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.led1.Enabled = false;
            this.led1.Location = new System.Drawing.Point(424, 182);
            this.led1.Name = "led1";
            this.led1.Size = new System.Drawing.Size(90, 150);
            this.led1.TabIndex = 3;
            this.led1.TabStop = false;
            this.led1.Visible = false;
            // 
            // led2
            // 
            this.led2.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.led2.Enabled = false;
            this.led2.Location = new System.Drawing.Point(553, 172);
            this.led2.Name = "led2";
            this.led2.Size = new System.Drawing.Size(90, 200);
            this.led2.TabIndex = 2;
            this.led2.TabStop = false;
            this.led2.Visible = false;
            // 
            // led3
            // 
            this.led3.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.led3.Enabled = false;
            this.led3.Location = new System.Drawing.Point(686, 172);
            this.led3.Name = "led3";
            this.led3.Size = new System.Drawing.Size(140, 200);
            this.led3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.led3.TabIndex = 1;
            this.led3.TabStop = false;
            this.led3.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::PharmedPlastPouyan.Properties.Resources.Salon_3;
            this.pictureBox1.Location = new System.Drawing.Point(9, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1201, 602);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = global::PharmedPlastPouyan.Properties.Resources.panelbackGWide;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Controls.Add(this.txtInstallationPosition);
            this.panel2.Controls.Add(this.txtManufacturingYear);
            this.panel2.Controls.Add(this.txtOrigin);
            this.panel2.Controls.Add(this.txtSerial);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.txtModel);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtMachineName);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.txtMachineNumber);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(10, 10);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(10);
            this.panel2.Size = new System.Drawing.Size(1219, 117);
            this.panel2.TabIndex = 2;
            // 
            // txtInstallationPosition
            // 
            this.txtInstallationPosition.BackColor = System.Drawing.Color.White;
            this.txtInstallationPosition.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInstallationPosition.Font = new System.Drawing.Font("B Nazanin", 18F);
            this.txtInstallationPosition.Location = new System.Drawing.Point(29, 64);
            this.txtInstallationPosition.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.txtInstallationPosition.Name = "txtInstallationPosition";
            this.txtInstallationPosition.Size = new System.Drawing.Size(381, 37);
            this.txtInstallationPosition.TabIndex = 77;
            this.txtInstallationPosition.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtManufacturingYear
            // 
            this.txtManufacturingYear.BackColor = System.Drawing.Color.White;
            this.txtManufacturingYear.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtManufacturingYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtManufacturingYear.Location = new System.Drawing.Point(553, 64);
            this.txtManufacturingYear.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.txtManufacturingYear.Name = "txtManufacturingYear";
            this.txtManufacturingYear.Size = new System.Drawing.Size(148, 37);
            this.txtManufacturingYear.TabIndex = 77;
            this.txtManufacturingYear.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtOrigin
            // 
            this.txtOrigin.BackColor = System.Drawing.Color.White;
            this.txtOrigin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOrigin.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOrigin.Location = new System.Drawing.Point(850, 64);
            this.txtOrigin.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.txtOrigin.Name = "txtOrigin";
            this.txtOrigin.Size = new System.Drawing.Size(231, 37);
            this.txtOrigin.TabIndex = 77;
            this.txtOrigin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtSerial
            // 
            this.txtSerial.BackColor = System.Drawing.Color.White;
            this.txtSerial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSerial.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSerial.Location = new System.Drawing.Point(29, 9);
            this.txtSerial.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.txtSerial.Name = "txtSerial";
            this.txtSerial.Size = new System.Drawing.Size(147, 37);
            this.txtSerial.TabIndex = 77;
            this.txtSerial.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(194)))), ((int)(((byte)(201)))));
            this.label11.Font = new System.Drawing.Font("B Nazanin", 18F);
            this.label11.Location = new System.Drawing.Point(424, 65);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label11.Size = new System.Drawing.Size(92, 35);
            this.label11.TabIndex = 78;
            this.label11.Text = "محل نصب";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(194)))), ((int)(((byte)(201)))));
            this.label9.Font = new System.Drawing.Font("B Nazanin", 18F);
            this.label9.Location = new System.Drawing.Point(705, 65);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label9.Size = new System.Drawing.Size(100, 35);
            this.label9.TabIndex = 78;
            this.label9.Text = "سال ساخت";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(194)))), ((int)(((byte)(201)))));
            this.label7.Font = new System.Drawing.Font("B Nazanin", 18F);
            this.label7.Location = new System.Drawing.Point(1089, 65);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label7.Size = new System.Drawing.Size(110, 35);
            this.label7.TabIndex = 78;
            this.label7.Text = "کشور سازنده";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(194)))), ((int)(((byte)(201)))));
            this.label5.Font = new System.Drawing.Font("B Nazanin", 18F);
            this.label5.Location = new System.Drawing.Point(180, 10);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label5.Size = new System.Drawing.Size(60, 35);
            this.label5.TabIndex = 78;
            this.label5.Text = "سریال";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtModel
            // 
            this.txtModel.BackColor = System.Drawing.Color.White;
            this.txtModel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtModel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtModel.Location = new System.Drawing.Point(278, 9);
            this.txtModel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.txtModel.Name = "txtModel";
            this.txtModel.Size = new System.Drawing.Size(192, 37);
            this.txtModel.TabIndex = 77;
            this.txtModel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(194)))), ((int)(((byte)(201)))));
            this.label3.Font = new System.Drawing.Font("B Nazanin", 18F);
            this.label3.Location = new System.Drawing.Point(474, 10);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(101, 35);
            this.label3.TabIndex = 78;
            this.label3.Text = "مدل ماشین";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtMachineName
            // 
            this.txtMachineName.BackColor = System.Drawing.Color.White;
            this.txtMachineName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMachineName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMachineName.Location = new System.Drawing.Point(613, 9);
            this.txtMachineName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.txtMachineName.Name = "txtMachineName";
            this.txtMachineName.Size = new System.Drawing.Size(269, 37);
            this.txtMachineName.TabIndex = 77;
            this.txtMachineName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(194)))), ((int)(((byte)(201)))));
            this.label1.Font = new System.Drawing.Font("B Nazanin", 18F);
            this.label1.Location = new System.Drawing.Point(886, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(89, 35);
            this.label1.TabIndex = 78;
            this.label1.Text = "نام ماشین";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtMachineNumber
            // 
            this.txtMachineNumber.BackColor = System.Drawing.Color.White;
            this.txtMachineNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMachineNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMachineNumber.Location = new System.Drawing.Point(1018, 9);
            this.txtMachineNumber.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.txtMachineNumber.Name = "txtMachineNumber";
            this.txtMachineNumber.Size = new System.Drawing.Size(63, 37);
            this.txtMachineNumber.TabIndex = 77;
            this.txtMachineNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(194)))), ((int)(((byte)(201)))));
            this.label14.Font = new System.Drawing.Font("B Nazanin", 18F);
            this.label14.Location = new System.Drawing.Point(1085, 10);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label14.Size = new System.Drawing.Size(114, 35);
            this.label14.TabIndex = 78;
            this.label14.Text = "شماره ماشین";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel4
            // 
            this.panel4.BackgroundImage = global::PharmedPlastPouyan.Properties.Resources.panelbackGWide;
            this.panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel4.Controls.Add(this.btnExit);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(10, 747);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(10);
            this.panel4.Size = new System.Drawing.Size(1219, 50);
            this.panel4.TabIndex = 3;
            // 
            // btnExit
            // 
            this.btnExit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnExit.Font = new System.Drawing.Font("B Nazanin", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnExit.Location = new System.Drawing.Point(552, 8);
            this.btnExit.Margin = new System.Windows.Forms.Padding(2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(114, 35);
            this.btnExit.TabIndex = 36;
            this.btnExit.TabStop = false;
            this.btnExit.Text = "بستن";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 300;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 300;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // timer3
            // 
            this.timer3.Interval = 300;
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // frmViewMachine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(194)))), ((int)(((byte)(201)))));
            this.ClientSize = new System.Drawing.Size(1239, 841);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.radTitleBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1239, 841);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1239, 841);
            this.Name = "frmViewMachine";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "نمایش مشخصات ماشین";
            this.Load += new System.EventHandler(this.frmViewMachine_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radTitleBar1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.led1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.led2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.led3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadTitleBar radTitleBar1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private LEDSize3 led3;
        private System.Windows.Forms.Timer timer1;
        private LEDSize2 led2;
        private LEDSize1 led1;
        private System.Windows.Forms.Label txtMachineNumber;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label txtInstallationPosition;
        private System.Windows.Forms.Label txtManufacturingYear;
        private System.Windows.Forms.Label txtOrigin;
        private System.Windows.Forms.Label txtSerial;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label txtModel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label txtMachineName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.Panel panel4;
        private Telerik.WinControls.UI.RadButton btnExit;
    }
}