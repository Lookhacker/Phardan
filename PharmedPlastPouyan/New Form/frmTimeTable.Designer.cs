namespace PharmedPlastPouyan
{
    partial class frmTimeTable
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTimeTable));
            this.txtEdit = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnSave = new Telerik.WinControls.UI.RadButton();
            this.pnlBack = new System.Windows.Forms.Panel();
            this.pnlBack2 = new System.Windows.Forms.Panel();
            this.chkLimit = new System.Windows.Forms.CheckBox();
            this.txtCreateTime = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDarsad = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExit = new Telerik.WinControls.UI.RadButton();
            this.radTitleBar1 = new Telerik.WinControls.UI.RadTitleBar();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).BeginInit();
            this.pnlBack.SuspendLayout();
            this.pnlBack2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTitleBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtEdit
            // 
            this.txtEdit.BackColor = System.Drawing.SystemColors.Window;
            this.txtEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEdit.Location = new System.Drawing.Point(66, 39);
            this.txtEdit.Margin = new System.Windows.Forms.Padding(2);
            this.txtEdit.MaxLength = 3;
            this.txtEdit.Name = "txtEdit";
            this.txtEdit.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtEdit.Size = new System.Drawing.Size(221, 35);
            this.txtEdit.TabIndex = 202;
            this.txtEdit.TabStop = false;
            this.txtEdit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtEdit.TextChanged += new System.EventHandler(this.txtEdit_TextChanged);
            this.txtEdit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPresss);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(224)))), ((int)(((byte)(231)))));
            this.label6.Font = new System.Drawing.Font("B Nazanin", 18F);
            this.label6.Location = new System.Drawing.Point(291, 39);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(305, 35);
            this.label6.TabIndex = 203;
            this.label6.Text = "مدت زمان ویرایش پس از ثبت اطلاعات";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnSave.Enabled = false;
            this.btnSave.Font = new System.Drawing.Font("B Nazanin", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnSave.Location = new System.Drawing.Point(331, 239);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(157, 35);
            this.btnSave.TabIndex = 201;
            this.btnSave.TabStop = false;
            this.btnSave.Text = "ثبت";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // pnlBack
            // 
            this.pnlBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(194)))), ((int)(((byte)(201)))));
            this.pnlBack.Controls.Add(this.pnlBack2);
            this.pnlBack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBack.Location = new System.Drawing.Point(0, 34);
            this.pnlBack.Name = "pnlBack";
            this.pnlBack.Padding = new System.Windows.Forms.Padding(5, 0, 5, 5);
            this.pnlBack.Size = new System.Drawing.Size(618, 291);
            this.pnlBack.TabIndex = 8;
            // 
            // pnlBack2
            // 
            this.pnlBack2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(224)))), ((int)(((byte)(231)))));
            this.pnlBack2.Controls.Add(this.chkLimit);
            this.pnlBack2.Controls.Add(this.txtCreateTime);
            this.pnlBack2.Controls.Add(this.label7);
            this.pnlBack2.Controls.Add(this.label8);
            this.pnlBack2.Controls.Add(this.txtDarsad);
            this.pnlBack2.Controls.Add(this.txtEdit);
            this.pnlBack2.Controls.Add(this.label5);
            this.pnlBack2.Controls.Add(this.label4);
            this.pnlBack2.Controls.Add(this.label1);
            this.pnlBack2.Controls.Add(this.label6);
            this.pnlBack2.Controls.Add(this.btnExit);
            this.pnlBack2.Controls.Add(this.btnSave);
            this.pnlBack2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBack2.Location = new System.Drawing.Point(5, 0);
            this.pnlBack2.Name = "pnlBack2";
            this.pnlBack2.Padding = new System.Windows.Forms.Padding(10);
            this.pnlBack2.Size = new System.Drawing.Size(608, 286);
            this.pnlBack2.TabIndex = 1;
            // 
            // chkLimit
            // 
            this.chkLimit.AutoSize = true;
            this.chkLimit.Font = new System.Drawing.Font("B Nazanin", 18F);
            this.chkLimit.Location = new System.Drawing.Point(16, 154);
            this.chkLimit.Name = "chkLimit";
            this.chkLimit.Size = new System.Drawing.Size(148, 39);
            this.chkLimit.TabIndex = 207;
            this.chkLimit.Text = "بدون محدودیت";
            this.chkLimit.UseVisualStyleBackColor = true;
            this.chkLimit.CheckedChanged += new System.EventHandler(this.chkLimit_CheckedChanged);
            // 
            // txtCreateTime
            // 
            this.txtCreateTime.BackColor = System.Drawing.SystemColors.Window;
            this.txtCreateTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCreateTime.Location = new System.Drawing.Point(212, 155);
            this.txtCreateTime.Margin = new System.Windows.Forms.Padding(2);
            this.txtCreateTime.MaxLength = 3;
            this.txtCreateTime.Name = "txtCreateTime";
            this.txtCreateTime.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtCreateTime.Size = new System.Drawing.Size(108, 35);
            this.txtCreateTime.TabIndex = 204;
            this.txtCreateTime.TabStop = false;
            this.txtCreateTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCreateTime.TextChanged += new System.EventHandler(this.txtCreateTime_TextChanged);
            this.txtCreateTime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPresss);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(224)))), ((int)(((byte)(231)))));
            this.label7.Font = new System.Drawing.Font("B Nazanin", 18F);
            this.label7.Location = new System.Drawing.Point(169, 155);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 35);
            this.label7.TabIndex = 205;
            this.label7.Text = "روز";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(224)))), ((int)(((byte)(231)))));
            this.label8.Font = new System.Drawing.Font("B Nazanin", 18F);
            this.label8.Location = new System.Drawing.Point(324, 155);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(272, 35);
            this.label8.TabIndex = 206;
            this.label8.Text = "محدودیت زمان ثبت اطلاعات تولید";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtDarsad
            // 
            this.txtDarsad.BackColor = System.Drawing.SystemColors.Window;
            this.txtDarsad.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDarsad.Location = new System.Drawing.Point(66, 97);
            this.txtDarsad.Margin = new System.Windows.Forms.Padding(2);
            this.txtDarsad.MaxLength = 2;
            this.txtDarsad.Name = "txtDarsad";
            this.txtDarsad.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtDarsad.Size = new System.Drawing.Size(303, 35);
            this.txtDarsad.TabIndex = 202;
            this.txtDarsad.TabStop = false;
            this.txtDarsad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDarsad.TextChanged += new System.EventHandler(this.txtRequest_TextChanged);
            this.txtDarsad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPresss);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(224)))), ((int)(((byte)(231)))));
            this.label5.Font = new System.Drawing.Font("B Nazanin", 18F);
            this.label5.Location = new System.Drawing.Point(6, 97);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 35);
            this.label5.TabIndex = 203;
            this.label5.Text = "درصد";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(224)))), ((int)(((byte)(231)))));
            this.label4.Font = new System.Drawing.Font("B Nazanin", 18F);
            this.label4.Location = new System.Drawing.Point(6, 39);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 35);
            this.label4.TabIndex = 203;
            this.label4.Text = "ساعت";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(224)))), ((int)(((byte)(231)))));
            this.label1.Font = new System.Drawing.Font("B Nazanin", 18F);
            this.label1.Location = new System.Drawing.Point(373, 97);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(223, 35);
            this.label1.TabIndex = 203;
            this.label1.Text = "تلرانس برای ثبت آمار مونتاژ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnExit
            // 
            this.btnExit.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Font = new System.Drawing.Font("B Nazanin", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnExit.Location = new System.Drawing.Point(144, 239);
            this.btnExit.Margin = new System.Windows.Forms.Padding(2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(157, 35);
            this.btnExit.TabIndex = 201;
            this.btnExit.TabStop = false;
            this.btnExit.Text = "خروج";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // radTitleBar1
            // 
            this.radTitleBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radTitleBar1.Font = new System.Drawing.Font("IRANSansWeb(FaNum)", 12F);
            this.radTitleBar1.ForeColor = System.Drawing.Color.Black;
            this.radTitleBar1.Location = new System.Drawing.Point(0, 0);
            this.radTitleBar1.Name = "radTitleBar1";
            this.radTitleBar1.Size = new System.Drawing.Size(618, 34);
            this.radTitleBar1.TabIndex = 7;
            this.radTitleBar1.TabStop = false;
            this.radTitleBar1.Text = "جدول ویرایش زمان ها";
            // 
            // frmTimeTable
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(618, 325);
            this.Controls.Add(this.pnlBack);
            this.Controls.Add(this.radTitleBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(618, 325);
            this.Name = "frmTimeTable";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "جدول ویرایش زمان ها";
            this.Load += new System.EventHandler(this.frmTimeTable_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).EndInit();
            this.pnlBack.ResumeLayout(false);
            this.pnlBack2.ResumeLayout(false);
            this.pnlBack2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTitleBar1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtEdit;
        private System.Windows.Forms.Label label6;
        private Telerik.WinControls.UI.RadButton btnSave;
        private System.Windows.Forms.Panel pnlBack;
        private System.Windows.Forms.Panel pnlBack2;
        private Telerik.WinControls.UI.RadTitleBar radTitleBar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDarsad;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private Telerik.WinControls.UI.RadButton btnExit;
        private System.Windows.Forms.TextBox txtCreateTime;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox chkLimit;
    }
}