namespace PharmedPlastPouyan
{
    partial class frmChangeYear
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.comYear = new System.Windows.Forms.ComboBox();
            this.btnExit = new Telerik.WinControls.UI.RadButton();
            this.pnlBack = new System.Windows.Forms.Panel();
            this.radTitleBar1 = new Telerik.WinControls.UI.RadTitleBar();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).BeginInit();
            this.pnlBack.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radTitleBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.comYear);
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(10, 10);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(10);
            this.panel1.Size = new System.Drawing.Size(318, 112);
            this.panel1.TabIndex = 91;
            // 
            // comYear
            // 
            this.comYear.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.comYear.DisplayMember = "Title";
            this.comYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comYear.DropDownWidth = 280;
            this.comYear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comYear.Font = new System.Drawing.Font("B Nazanin", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.comYear.FormattingEnabled = true;
            this.comYear.Location = new System.Drawing.Point(12, 12);
            this.comYear.Margin = new System.Windows.Forms.Padding(2);
            this.comYear.Name = "comYear";
            this.comYear.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.comYear.Size = new System.Drawing.Size(294, 37);
            this.comYear.TabIndex = 93;
            this.comYear.ValueMember = "ID";
            // 
            // btnExit
            // 
            this.btnExit.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnExit.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnExit.Location = new System.Drawing.Point(111, 73);
            this.btnExit.Margin = new System.Windows.Forms.Padding(2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(117, 27);
            this.btnExit.TabIndex = 92;
            this.btnExit.TabStop = false;
            this.btnExit.Text = "خروج";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // pnlBack
            // 
            this.pnlBack.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBack.Controls.Add(this.panel1);
            this.pnlBack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBack.Location = new System.Drawing.Point(0, 34);
            this.pnlBack.Name = "pnlBack";
            this.pnlBack.Padding = new System.Windows.Forms.Padding(10);
            this.pnlBack.Size = new System.Drawing.Size(340, 134);
            this.pnlBack.TabIndex = 12;
            // 
            // radTitleBar1
            // 
            this.radTitleBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radTitleBar1.Font = new System.Drawing.Font("IRANSansWeb(FaNum)", 12F);
            this.radTitleBar1.ForeColor = System.Drawing.Color.Black;
            this.radTitleBar1.Location = new System.Drawing.Point(0, 0);
            this.radTitleBar1.Name = "radTitleBar1";
            this.radTitleBar1.Size = new System.Drawing.Size(340, 34);
            this.radTitleBar1.TabIndex = 11;
            this.radTitleBar1.TabStop = false;
            this.radTitleBar1.Text = "تغییر سال پیش فرض";
            ((Telerik.WinControls.UI.RadTitleBarElement)(this.radTitleBar1.GetChildAt(0))).Text = "تغییر سال پیش فرض";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.radTitleBar1.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.radTitleBar1.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(0).GetChildAt(1).GetChildAt(1))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            // 
            // frmChangeYear
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 168);
            this.Controls.Add(this.pnlBack);
            this.Controls.Add(this.radTitleBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmChangeYear";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "تغییر سال پیش فرض";
            this.Load += new System.EventHandler(this.frmChangeYear_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).EndInit();
            this.pnlBack.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radTitleBar1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Telerik.WinControls.UI.RadButton btnExit;
        private System.Windows.Forms.Panel pnlBack;
        private Telerik.WinControls.UI.RadTitleBar radTitleBar1;
        private System.Windows.Forms.ComboBox comYear;
    }
}