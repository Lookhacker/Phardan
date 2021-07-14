namespace PharmedPlastPouyan
{
    partial class frmConvert
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
            this.radTitleBar1 = new Telerik.WinControls.UI.RadTitleBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnExit = new Telerik.WinControls.UI.RadButton();
            this.pnlData = new System.Windows.Forms.Panel();
            this.lblShift = new System.Windows.Forms.TextBox();
            this.lblDay = new System.Windows.Forms.TextBox();
            this.lblMonth = new System.Windows.Forms.TextBox();
            this.lblYear = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtLot = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.pnlDate = new System.Windows.Forms.Panel();
            this.lblBatch = new System.Windows.Forms.Label();
            this.lblWeek = new System.Windows.Forms.Label();
            this.lblLot = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.chkShiftStatus = new Telerik.WinControls.UI.RadToggleSwitch();
            this.txtDay = new System.Windows.Forms.TextBox();
            this.txtMonth = new System.Windows.Forms.TextBox();
            this.txtYear = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.radTitleBar1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).BeginInit();
            this.pnlData.SuspendLayout();
            this.pnlDate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkShiftStatus)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // radTitleBar1
            // 
            this.radTitleBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radTitleBar1.Font = new System.Drawing.Font("IRANSansWeb(FaNum)", 12F);
            this.radTitleBar1.ForeColor = System.Drawing.Color.Black;
            this.radTitleBar1.Location = new System.Drawing.Point(0, 0);
            this.radTitleBar1.Name = "radTitleBar1";
            this.radTitleBar1.Size = new System.Drawing.Size(770, 34);
            this.radTitleBar1.TabIndex = 120;
            this.radTitleBar1.TabStop = false;
            this.radTitleBar1.Text = "frmConvert";
            ((Telerik.WinControls.UI.RadTitleBarElement)(this.radTitleBar1.GetChildAt(0))).Text = "frmConvert";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.radTitleBar1.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.radTitleBar1.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(0).GetChildAt(1).GetChildAt(1))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 34);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(10);
            this.panel1.Size = new System.Drawing.Size(770, 474);
            this.panel1.TabIndex = 119;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pnlData);
            this.panel2.Controls.Add(this.pnlDate);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(10, 10);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(750, 454);
            this.panel2.TabIndex = 0;
            // 
            // btnExit
            // 
            this.btnExit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Font = new System.Drawing.Font("B Nazanin", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnExit.Location = new System.Drawing.Point(247, 8);
            this.btnExit.Margin = new System.Windows.Forms.Padding(2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(259, 35);
            this.btnExit.TabIndex = 0;
            this.btnExit.Text = "خروج";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // pnlData
            // 
            this.pnlData.BackgroundImage = global::PharmedPlastPouyan.Properties.Resources.panelbackGround;
            this.pnlData.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlData.Controls.Add(this.lblShift);
            this.pnlData.Controls.Add(this.lblDay);
            this.pnlData.Controls.Add(this.lblMonth);
            this.pnlData.Controls.Add(this.lblYear);
            this.pnlData.Controls.Add(this.label10);
            this.pnlData.Controls.Add(this.label12);
            this.pnlData.Controls.Add(this.label13);
            this.pnlData.Controls.Add(this.label14);
            this.pnlData.Controls.Add(this.label4);
            this.pnlData.Controls.Add(this.txtLot);
            this.pnlData.Controls.Add(this.label9);
            this.pnlData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlData.Font = new System.Drawing.Font("B Nazanin", 18F);
            this.pnlData.Location = new System.Drawing.Point(0, 0);
            this.pnlData.Margin = new System.Windows.Forms.Padding(2);
            this.pnlData.Name = "pnlData";
            this.pnlData.Size = new System.Drawing.Size(375, 396);
            this.pnlData.TabIndex = 3;
            // 
            // lblShift
            // 
            this.lblShift.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblShift.BackColor = System.Drawing.SystemColors.Window;
            this.lblShift.Font = new System.Drawing.Font("B Nazanin", 15F, System.Drawing.FontStyle.Bold);
            this.lblShift.Location = new System.Drawing.Point(35, 242);
            this.lblShift.Margin = new System.Windows.Forms.Padding(2);
            this.lblShift.MaxLength = 2;
            this.lblShift.Name = "lblShift";
            this.lblShift.ReadOnly = true;
            this.lblShift.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblShift.Size = new System.Drawing.Size(75, 39);
            this.lblShift.TabIndex = 75;
            this.lblShift.TabStop = false;
            this.lblShift.Text = "-----";
            this.lblShift.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblDay
            // 
            this.lblDay.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblDay.BackColor = System.Drawing.SystemColors.Window;
            this.lblDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.lblDay.Location = new System.Drawing.Point(284, 243);
            this.lblDay.Margin = new System.Windows.Forms.Padding(2);
            this.lblDay.MaxLength = 2;
            this.lblDay.Name = "lblDay";
            this.lblDay.ReadOnly = true;
            this.lblDay.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblDay.Size = new System.Drawing.Size(75, 35);
            this.lblDay.TabIndex = 75;
            this.lblDay.TabStop = false;
            this.lblDay.Text = "-----";
            this.lblDay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblMonth
            // 
            this.lblMonth.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblMonth.BackColor = System.Drawing.SystemColors.Window;
            this.lblMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.lblMonth.Location = new System.Drawing.Point(201, 243);
            this.lblMonth.Margin = new System.Windows.Forms.Padding(2);
            this.lblMonth.MaxLength = 2;
            this.lblMonth.Name = "lblMonth";
            this.lblMonth.ReadOnly = true;
            this.lblMonth.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblMonth.Size = new System.Drawing.Size(75, 35);
            this.lblMonth.TabIndex = 76;
            this.lblMonth.TabStop = false;
            this.lblMonth.Text = "-----";
            this.lblMonth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblYear
            // 
            this.lblYear.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblYear.BackColor = System.Drawing.SystemColors.Window;
            this.lblYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.lblYear.Location = new System.Drawing.Point(118, 243);
            this.lblYear.Margin = new System.Windows.Forms.Padding(2);
            this.lblYear.MaxLength = 4;
            this.lblYear.Name = "lblYear";
            this.lblYear.ReadOnly = true;
            this.lblYear.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblYear.Size = new System.Drawing.Size(75, 35);
            this.lblYear.TabIndex = 77;
            this.lblYear.TabStop = false;
            this.lblYear.Text = "-----";
            this.lblYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(224)))), ((int)(((byte)(231)))));
            this.label10.Font = new System.Drawing.Font("B Nazanin", 18F);
            this.label10.Location = new System.Drawing.Point(302, 194);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(39, 35);
            this.label10.TabIndex = 78;
            this.label10.Text = "روز";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(224)))), ((int)(((byte)(231)))));
            this.label12.Font = new System.Drawing.Font("B Nazanin", 18F);
            this.label12.Location = new System.Drawing.Point(42, 194);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(60, 35);
            this.label12.TabIndex = 80;
            this.label12.Text = "شیفت";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(224)))), ((int)(((byte)(231)))));
            this.label13.Font = new System.Drawing.Font("B Nazanin", 18F);
            this.label13.Location = new System.Drawing.Point(132, 194);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(46, 35);
            this.label13.TabIndex = 81;
            this.label13.Text = "سال";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            this.label14.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(224)))), ((int)(((byte)(231)))));
            this.label14.Font = new System.Drawing.Font("B Nazanin", 18F);
            this.label14.Location = new System.Drawing.Point(220, 194);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(37, 35);
            this.label14.TabIndex = 79;
            this.label14.Text = "ماه";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(224)))), ((int)(((byte)(231)))));
            this.label4.Font = new System.Drawing.Font("B Nazanin", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label4.Location = new System.Drawing.Point(71, 8);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(215, 38);
            this.label4.TabIndex = 68;
            this.label4.Text = "تبدیل لات نامبر به تاریخ";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtLot
            // 
            this.txtLot.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtLot.BackColor = System.Drawing.SystemColors.Window;
            this.txtLot.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.txtLot.Location = new System.Drawing.Point(99, 78);
            this.txtLot.Margin = new System.Windows.Forms.Padding(2);
            this.txtLot.MaxLength = 5;
            this.txtLot.Name = "txtLot";
            this.txtLot.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtLot.Size = new System.Drawing.Size(131, 35);
            this.txtLot.TabIndex = 0;
            this.txtLot.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtLot.TextChanged += new System.EventHandler(this.txtLot_TextChanged);
            this.txtLot.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IsNumberic);
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(224)))), ((int)(((byte)(231)))));
            this.label9.Font = new System.Drawing.Font("B Nazanin", 18F);
            this.label9.Location = new System.Drawing.Point(234, 78);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(83, 35);
            this.label9.TabIndex = 72;
            this.label9.Text = "لات نامبر";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlDate
            // 
            this.pnlDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(224)))), ((int)(((byte)(231)))));
            this.pnlDate.BackgroundImage = global::PharmedPlastPouyan.Properties.Resources.panelbackGround;
            this.pnlDate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlDate.Controls.Add(this.lblBatch);
            this.pnlDate.Controls.Add(this.lblWeek);
            this.pnlDate.Controls.Add(this.lblLot);
            this.pnlDate.Controls.Add(this.label6);
            this.pnlDate.Controls.Add(this.label7);
            this.pnlDate.Controls.Add(this.label8);
            this.pnlDate.Controls.Add(this.chkShiftStatus);
            this.pnlDate.Controls.Add(this.txtDay);
            this.pnlDate.Controls.Add(this.txtMonth);
            this.pnlDate.Controls.Add(this.txtYear);
            this.pnlDate.Controls.Add(this.label1);
            this.pnlDate.Controls.Add(this.label5);
            this.pnlDate.Controls.Add(this.label3);
            this.pnlDate.Controls.Add(this.label2);
            this.pnlDate.Controls.Add(this.label11);
            this.pnlDate.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlDate.Location = new System.Drawing.Point(375, 0);
            this.pnlDate.Margin = new System.Windows.Forms.Padding(2);
            this.pnlDate.Name = "pnlDate";
            this.pnlDate.Size = new System.Drawing.Size(375, 396);
            this.pnlDate.TabIndex = 2;
            // 
            // lblBatch
            // 
            this.lblBatch.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblBatch.BackColor = System.Drawing.Color.White;
            this.lblBatch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBatch.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.lblBatch.Location = new System.Drawing.Point(157, 230);
            this.lblBatch.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBatch.Name = "lblBatch";
            this.lblBatch.Size = new System.Drawing.Size(175, 31);
            this.lblBatch.TabIndex = 80;
            this.lblBatch.Text = "-----";
            this.lblBatch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblWeek
            // 
            this.lblWeek.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblWeek.BackColor = System.Drawing.Color.White;
            this.lblWeek.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblWeek.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.lblWeek.Location = new System.Drawing.Point(157, 179);
            this.lblWeek.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblWeek.Name = "lblWeek";
            this.lblWeek.Size = new System.Drawing.Size(175, 31);
            this.lblWeek.TabIndex = 79;
            this.lblWeek.Text = "-----";
            this.lblWeek.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLot
            // 
            this.lblLot.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblLot.BackColor = System.Drawing.Color.White;
            this.lblLot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblLot.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.lblLot.Location = new System.Drawing.Point(157, 281);
            this.lblLot.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblLot.Name = "lblLot";
            this.lblLot.Size = new System.Drawing.Size(175, 31);
            this.lblLot.TabIndex = 78;
            this.lblLot.Text = "-----";
            this.lblLot.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(224)))), ((int)(((byte)(231)))));
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label6.Location = new System.Drawing.Point(45, 233);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label6.Size = new System.Drawing.Size(108, 24);
            this.label6.TabIndex = 77;
            this.label6.Text = "Batch Num.";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(224)))), ((int)(((byte)(231)))));
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label7.Location = new System.Drawing.Point(43, 182);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label7.Size = new System.Drawing.Size(110, 24);
            this.label7.TabIndex = 76;
            this.label7.Text = "Week Num.";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(224)))), ((int)(((byte)(231)))));
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label8.Location = new System.Drawing.Point(62, 284);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label8.Size = new System.Drawing.Size(91, 24);
            this.label8.TabIndex = 75;
            this.label8.Text = "Lot. Num.";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkShiftStatus
            // 
            this.chkShiftStatus.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkShiftStatus.Location = new System.Drawing.Point(13, 115);
            this.chkShiftStatus.Name = "chkShiftStatus";
            this.chkShiftStatus.OffText = "شیفت شب";
            this.chkShiftStatus.OnText = "شیفت روز";
            this.chkShiftStatus.Size = new System.Drawing.Size(106, 32);
            this.chkShiftStatus.TabIndex = 3;
            this.chkShiftStatus.ToggleStateMode = Telerik.WinControls.UI.ToggleStateMode.Click;
            this.chkShiftStatus.ValueChanged += new System.EventHandler(this.chkShiftStatus_ValueChanged);
            ((Telerik.WinControls.UI.RadToggleSwitchElement)(this.chkShiftStatus.GetChildAt(0))).ThumbOffset = 86;
            ((Telerik.WinControls.UI.ToggleSwitchPartElement)(this.chkShiftStatus.GetChildAt(0).GetChildAt(0))).Text = "شیفت روز";
            ((Telerik.WinControls.UI.ToggleSwitchPartElement)(this.chkShiftStatus.GetChildAt(0).GetChildAt(0))).Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold);
            ((Telerik.WinControls.UI.ToggleSwitchPartElement)(this.chkShiftStatus.GetChildAt(0).GetChildAt(1))).Text = "شیفت شب";
            ((Telerik.WinControls.UI.ToggleSwitchPartElement)(this.chkShiftStatus.GetChildAt(0).GetChildAt(1))).ForeColor = System.Drawing.Color.Black;
            ((Telerik.WinControls.UI.ToggleSwitchPartElement)(this.chkShiftStatus.GetChildAt(0).GetChildAt(1))).Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold);
            // 
            // txtDay
            // 
            this.txtDay.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtDay.BackColor = System.Drawing.SystemColors.Window;
            this.txtDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.txtDay.Location = new System.Drawing.Point(286, 112);
            this.txtDay.Margin = new System.Windows.Forms.Padding(2);
            this.txtDay.MaxLength = 2;
            this.txtDay.Name = "txtDay";
            this.txtDay.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtDay.Size = new System.Drawing.Size(75, 35);
            this.txtDay.TabIndex = 0;
            this.txtDay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDay.TextChanged += new System.EventHandler(this.txtDay_TextChanged);
            this.txtDay.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IsNumberic);
            // 
            // txtMonth
            // 
            this.txtMonth.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtMonth.BackColor = System.Drawing.SystemColors.Window;
            this.txtMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.txtMonth.Location = new System.Drawing.Point(205, 112);
            this.txtMonth.Margin = new System.Windows.Forms.Padding(2);
            this.txtMonth.MaxLength = 2;
            this.txtMonth.Name = "txtMonth";
            this.txtMonth.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtMonth.Size = new System.Drawing.Size(75, 35);
            this.txtMonth.TabIndex = 1;
            this.txtMonth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMonth.TextChanged += new System.EventHandler(this.txtMonth_TextChanged);
            this.txtMonth.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IsNumberic);
            // 
            // txtYear
            // 
            this.txtYear.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtYear.BackColor = System.Drawing.SystemColors.Window;
            this.txtYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.txtYear.Location = new System.Drawing.Point(124, 112);
            this.txtYear.Margin = new System.Windows.Forms.Padding(2);
            this.txtYear.MaxLength = 4;
            this.txtYear.Name = "txtYear";
            this.txtYear.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtYear.Size = new System.Drawing.Size(75, 35);
            this.txtYear.TabIndex = 2;
            this.txtYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtYear.TextChanged += new System.EventHandler(this.txtYear_TextChanged);
            this.txtYear.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IsNumberic);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(224)))), ((int)(((byte)(231)))));
            this.label1.Font = new System.Drawing.Font("B Nazanin", 18F);
            this.label1.Location = new System.Drawing.Point(303, 64);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 35);
            this.label1.TabIndex = 71;
            this.label1.Text = "روز";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(224)))), ((int)(((byte)(231)))));
            this.label5.Font = new System.Drawing.Font("B Nazanin", 18F);
            this.label5.Location = new System.Drawing.Point(36, 64);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 35);
            this.label5.TabIndex = 73;
            this.label5.Text = "شیفت";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(224)))), ((int)(((byte)(231)))));
            this.label3.Font = new System.Drawing.Font("B Nazanin", 18F);
            this.label3.Location = new System.Drawing.Point(138, 64);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 35);
            this.label3.TabIndex = 73;
            this.label3.Text = "سال";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(224)))), ((int)(((byte)(231)))));
            this.label2.Font = new System.Drawing.Font("B Nazanin", 18F);
            this.label2.Location = new System.Drawing.Point(224, 64);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 35);
            this.label2.TabIndex = 72;
            this.label2.Text = "ماه";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(224)))), ((int)(((byte)(231)))));
            this.label11.Font = new System.Drawing.Font("B Nazanin", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label11.Location = new System.Drawing.Point(92, 8);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(215, 38);
            this.label11.TabIndex = 67;
            this.label11.Text = "تبدیل تاریخ به لات نامبر";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.BackgroundImage = global::PharmedPlastPouyan.Properties.Resources.panelbackGWide;
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel3.Controls.Add(this.btnExit);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 396);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(750, 58);
            this.panel3.TabIndex = 4;
            // 
            // frmConvert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(224)))), ((int)(((byte)(231)))));
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(770, 508);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.radTitleBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(770, 508);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(770, 508);
            this.Name = "frmConvert";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmConvert";
            this.Load += new System.EventHandler(this.frmConvert_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radTitleBar1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).EndInit();
            this.pnlData.ResumeLayout(false);
            this.pnlData.PerformLayout();
            this.pnlDate.ResumeLayout(false);
            this.pnlDate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkShiftStatus)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadTitleBar radTitleBar1;
        private System.Windows.Forms.Panel pnlDate;
        private System.Windows.Forms.TextBox txtDay;
        private System.Windows.Forms.TextBox txtMonth;
        private System.Windows.Forms.TextBox txtYear;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel pnlData;
        private System.Windows.Forms.Label label4;
        private Telerik.WinControls.UI.RadToggleSwitch chkShiftStatus;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblBatch;
        private System.Windows.Forms.Label lblWeek;
        private System.Windows.Forms.Label lblLot;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox lblDay;
        private System.Windows.Forms.TextBox lblMonth;
        private System.Windows.Forms.TextBox lblYear;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtLot;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel3;
        private Telerik.WinControls.UI.RadButton btnExit;
        private System.Windows.Forms.TextBox lblShift;
    }
}