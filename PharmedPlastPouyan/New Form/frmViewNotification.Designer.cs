namespace PharmedPlastPouyan
{
    partial class frmViewNotification
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmViewNotification));
            this.radTitleBar1 = new Telerik.WinControls.UI.RadTitleBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.chkAccept = new System.Windows.Forms.CheckBox();
            this.btnExit = new Telerik.WinControls.UI.RadButton();
            this.lblMessege = new System.Windows.Forms.Label();
            this.label46 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.radTitleBar1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).BeginInit();
            this.SuspendLayout();
            // 
            // radTitleBar1
            // 
            this.radTitleBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radTitleBar1.Font = new System.Drawing.Font("IRANSansWeb(FaNum)", 12F);
            this.radTitleBar1.Location = new System.Drawing.Point(0, 0);
            this.radTitleBar1.Name = "radTitleBar1";
            this.radTitleBar1.Size = new System.Drawing.Size(754, 34);
            this.radTitleBar1.TabIndex = 1;
            this.radTitleBar1.TabStop = false;
            this.radTitleBar1.Text = "اطلاعات";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 34);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(10);
            this.panel1.Size = new System.Drawing.Size(754, 533);
            this.panel1.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.BackgroundImage = global::PharmedPlastPouyan.Properties.Resources.panelbackGround;
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel3.Controls.Add(this.chkAccept);
            this.panel3.Controls.Add(this.btnExit);
            this.panel3.Controls.Add(this.lblMessege);
            this.panel3.Controls.Add(this.label46);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(10, 10);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.panel3.Size = new System.Drawing.Size(734, 513);
            this.panel3.TabIndex = 9;
            // 
            // chkAccept
            // 
            this.chkAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkAccept.AutoSize = true;
            this.chkAccept.Font = new System.Drawing.Font("B Nazanin", 15.75F, System.Drawing.FontStyle.Bold);
            this.chkAccept.Location = new System.Drawing.Point(15, 411);
            this.chkAccept.Name = "chkAccept";
            this.chkAccept.Size = new System.Drawing.Size(201, 37);
            this.chkAccept.TabIndex = 76;
            this.chkAccept.Text = "قبول دارم/ متوجه شدم";
            this.chkAccept.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("B Nazanin", 15.75F, System.Drawing.FontStyle.Bold);
            this.btnExit.Location = new System.Drawing.Point(220, 463);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(314, 35);
            this.btnExit.TabIndex = 74;
            this.btnExit.Text = "خروج";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblMessege
            // 
            this.lblMessege.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblMessege.AutoEllipsis = true;
            this.lblMessege.Font = new System.Drawing.Font("B Nazanin", 15.75F, System.Drawing.FontStyle.Bold);
            this.lblMessege.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.lblMessege.Location = new System.Drawing.Point(15, 64);
            this.lblMessege.Name = "lblMessege";
            this.lblMessege.Size = new System.Drawing.Size(706, 384);
            this.lblMessege.TabIndex = 70;
            this.lblMessege.Text = "محمد محمودی پیام";
            // 
            // label46
            // 
            this.label46.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label46.AutoSize = true;
            this.label46.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(224)))), ((int)(((byte)(231)))));
            this.label46.Font = new System.Drawing.Font("B Nazanin", 20.25F, System.Drawing.FontStyle.Bold);
            this.label46.Location = new System.Drawing.Point(330, 12);
            this.label46.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(94, 43);
            this.label46.TabIndex = 69;
            this.label46.Text = "اطلاعات";
            this.label46.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmViewNotification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(224)))), ((int)(((byte)(231)))));
            this.ClientSize = new System.Drawing.Size(754, 567);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.radTitleBar1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmViewNotification";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "اطلاعات";
            this.Load += new System.EventHandler(this.PRNoMandP_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radTitleBar1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadTitleBar radTitleBar1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private Telerik.WinControls.UI.RadButton btnExit;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.Label lblMessege;
        private System.Windows.Forms.CheckBox chkAccept;
    }
}