namespace PharmedPlastPouyan
{
    partial class frmMoldPress
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMoldPress));
            this.pnlBack = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAdd = new Telerik.WinControls.UI.RadButton();
            this.label3 = new System.Windows.Forms.Label();
            this.txtYear = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEnd = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtStart = new System.Windows.Forms.TextBox();
            this.gridAll = new Telerik.WinControls.UI.RadGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblPerssData = new System.Windows.Forms.Label();
            this.lblMoldName = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.radTitleBar1 = new Telerik.WinControls.UI.RadTitleBar();
            this.linearGaugeNeedleIndicator1 = new Telerik.WinControls.UI.Gauges.LinearGaugeNeedleIndicator();
            this.linearGaugeLine4 = new Telerik.WinControls.UI.Gauges.LinearGaugeLine();
            this.linearGaugeLine6 = new Telerik.WinControls.UI.Gauges.LinearGaugeLine();
            this.linearGaugeLine1 = new Telerik.WinControls.UI.Gauges.LinearGaugeLine();
            this.linearGaugeBar3 = new Telerik.WinControls.UI.Gauges.LinearGaugeBar();
            this.linearGaugeTicks1 = new Telerik.WinControls.UI.Gauges.LinearGaugeTicks();
            this.pnlBack.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridAll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridAll.MasterTemplate)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTitleBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBack
            // 
            this.pnlBack.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBack.Controls.Add(this.panel1);
            this.pnlBack.Controls.Add(this.panel2);
            this.pnlBack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBack.Location = new System.Drawing.Point(0, 34);
            this.pnlBack.Name = "pnlBack";
            this.pnlBack.Padding = new System.Windows.Forms.Padding(10);
            this.pnlBack.Size = new System.Drawing.Size(1508, 556);
            this.pnlBack.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtYear);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtEnd);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtStart);
            this.panel1.Controls.Add(this.gridAll);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(10, 10);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(20);
            this.panel1.Size = new System.Drawing.Size(707, 534);
            this.panel1.TabIndex = 0;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnAdd.Font = new System.Drawing.Font("B Nazanin", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnAdd.Location = new System.Drawing.Point(22, 12);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(117, 27);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.TabStop = false;
            this.btnAdd.Text = "اعمال تاریخ";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("B Nazanin", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label3.Location = new System.Drawing.Point(662, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 28);
            this.label3.TabIndex = 112;
            this.label3.Text = "سال";
            // 
            // txtYear
            // 
            this.txtYear.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtYear.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.txtYear.Location = new System.Drawing.Point(590, 12);
            this.txtYear.Margin = new System.Windows.Forms.Padding(2);
            this.txtYear.MaxLength = 4;
            this.txtYear.Name = "txtYear";
            this.txtYear.Size = new System.Drawing.Size(68, 26);
            this.txtYear.TabIndex = 0;
            this.txtYear.Text = "1399";
            this.txtYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtYear.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtYear_KeyPress);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("B Nazanin", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.Location = new System.Drawing.Point(298, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 28);
            this.label1.TabIndex = 110;
            this.label1.Text = "تا تاریخ";
            // 
            // txtEnd
            // 
            this.txtEnd.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtEnd.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.txtEnd.Location = new System.Drawing.Point(167, 12);
            this.txtEnd.Margin = new System.Windows.Forms.Padding(2);
            this.txtEnd.MaxLength = 5;
            this.txtEnd.Name = "txtEnd";
            this.txtEnd.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtEnd.Size = new System.Drawing.Size(126, 26);
            this.txtEnd.TabIndex = 2;
            this.txtEnd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtEnd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtStart_KeyPress);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("B Nazanin", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label2.Location = new System.Drawing.Point(510, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 28);
            this.label2.TabIndex = 106;
            this.label2.Text = " از تاریخ";
            // 
            // txtStart
            // 
            this.txtStart.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtStart.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.txtStart.Location = new System.Drawing.Point(379, 12);
            this.txtStart.Margin = new System.Windows.Forms.Padding(2);
            this.txtStart.MaxLength = 5;
            this.txtStart.Name = "txtStart";
            this.txtStart.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtStart.Size = new System.Drawing.Size(126, 26);
            this.txtStart.TabIndex = 1;
            this.txtStart.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtStart.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtStart_KeyPress);
            // 
            // gridAll
            // 
            this.gridAll.AllowDrop = true;
            this.gridAll.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.gridAll.AutoSizeRows = true;
            this.gridAll.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.gridAll.Location = new System.Drawing.Point(20, 55);
            // 
            // 
            // 
            this.gridAll.MasterTemplate.AddNewRowPosition = Telerik.WinControls.UI.SystemRowPosition.Bottom;
            this.gridAll.MasterTemplate.AllowAddNewRow = false;
            this.gridAll.MasterTemplate.AllowCellContextMenu = false;
            this.gridAll.MasterTemplate.AllowColumnChooser = false;
            this.gridAll.MasterTemplate.AllowColumnHeaderContextMenu = false;
            this.gridAll.MasterTemplate.AllowColumnReorder = false;
            this.gridAll.MasterTemplate.AllowDeleteRow = false;
            this.gridAll.MasterTemplate.AllowDragToGroup = false;
            this.gridAll.MasterTemplate.AllowEditRow = false;
            this.gridAll.MasterTemplate.AllowRowHeaderContextMenu = false;
            this.gridAll.MasterTemplate.AllowRowReorder = true;
            this.gridAll.MasterTemplate.AllowRowResize = false;
            this.gridAll.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn1.FieldName = "MoldCode";
            gridViewTextBoxColumn1.HeaderText = "کد قالب";
            gridViewTextBoxColumn1.Name = "MoldCode";
            gridViewTextBoxColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn1.Width = 168;
            gridViewTextBoxColumn2.FieldName = "MoldNum";
            gridViewTextBoxColumn2.HeaderText = "شماره قالب";
            gridViewTextBoxColumn2.Name = "MoldNum";
            gridViewTextBoxColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn2.Width = 85;
            gridViewTextBoxColumn3.FieldName = "Product_Code";
            gridViewTextBoxColumn3.HeaderText = "کد محصول";
            gridViewTextBoxColumn3.Name = "Product_Code";
            gridViewTextBoxColumn3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn3.Width = 106;
            gridViewTextBoxColumn4.FieldName = "Product_Name";
            gridViewTextBoxColumn4.HeaderText = "نام محصول";
            gridViewTextBoxColumn4.Name = "Product_Name";
            gridViewTextBoxColumn4.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            gridViewTextBoxColumn4.Width = 324;
            this.gridAll.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4});
            this.gridAll.MasterTemplate.ShowRowHeaderColumn = false;
            this.gridAll.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.gridAll.Name = "gridAll";
            this.gridAll.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.gridAll.ShowItemToolTips = false;
            this.gridAll.Size = new System.Drawing.Size(681, 459);
            this.gridAll.TabIndex = 104;
            this.gridAll.TabStop = false;
            this.gridAll.SelectionChanged += new System.EventHandler(this.gridAll_SelectionChanged);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lblPerssData);
            this.panel2.Controls.Add(this.lblMoldName);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(717, 10);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(5);
            this.panel2.Size = new System.Drawing.Size(779, 534);
            this.panel2.TabIndex = 1;
            // 
            // lblPerssData
            // 
            this.lblPerssData.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblPerssData.BackColor = System.Drawing.Color.Black;
            this.lblPerssData.Font = new System.Drawing.Font("Bahnschrift Condensed", 65F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPerssData.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblPerssData.Location = new System.Drawing.Point(47, 241);
            this.lblPerssData.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPerssData.Name = "lblPerssData";
            this.lblPerssData.Size = new System.Drawing.Size(421, 110);
            this.lblPerssData.TabIndex = 112;
            this.lblPerssData.Text = "98765554321";
            this.lblPerssData.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMoldName
            // 
            this.lblMoldName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblMoldName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(181)))), ((int)(((byte)(141)))));
            this.lblMoldName.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMoldName.Location = new System.Drawing.Point(47, 361);
            this.lblMoldName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMoldName.Name = "lblMoldName";
            this.lblMoldName.Size = new System.Drawing.Size(242, 42);
            this.lblMoldName.TabIndex = 111;
            this.lblMoldName.Text = "M010506";
            this.lblMoldName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::PharmedPlastPouyan.Properties.Resources.MoldPress;
            this.pictureBox1.Location = new System.Drawing.Point(8, 11);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(760, 513);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // radTitleBar1
            // 
            this.radTitleBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radTitleBar1.Font = new System.Drawing.Font("IRANSansWeb(FaNum)", 12F);
            this.radTitleBar1.Location = new System.Drawing.Point(0, 0);
            this.radTitleBar1.Name = "radTitleBar1";
            this.radTitleBar1.Size = new System.Drawing.Size(1508, 34);
            this.radTitleBar1.TabIndex = 3;
            this.radTitleBar1.TabStop = false;
            this.radTitleBar1.Text = "ضرب قالب";
            ((Telerik.WinControls.UI.RadTitleBarElement)(this.radTitleBar1.GetChildAt(0))).Text = "ضرب قالب";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.radTitleBar1.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.radTitleBar1.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(0).GetChildAt(1).GetChildAt(1))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            // 
            // linearGaugeNeedleIndicator1
            // 
            this.linearGaugeNeedleIndicator1.AutoSize = false;
            this.linearGaugeNeedleIndicator1.BackColor = System.Drawing.Color.Red;
            this.linearGaugeNeedleIndicator1.Bounds = new System.Drawing.Rectangle(0, 0, 63, 270);
            this.linearGaugeNeedleIndicator1.CircleTicks = true;
            this.linearGaugeNeedleIndicator1.Direction = Telerik.WinControls.UI.Gauges.Direction.Left;
            this.linearGaugeNeedleIndicator1.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.linearGaugeNeedleIndicator1.DrawValue = true;
            this.linearGaugeNeedleIndicator1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.linearGaugeNeedleIndicator1.InnerPointRadiusPercentage = 10F;
            this.linearGaugeNeedleIndicator1.IsFilled = false;
            this.linearGaugeNeedleIndicator1.LenghtPercentage = 6F;
            this.linearGaugeNeedleIndicator1.LineLenght = 40F;
            this.linearGaugeNeedleIndicator1.LocationPercentage = 70F;
            this.linearGaugeNeedleIndicator1.Name = "linearGaugeNeedleIndicator1";
            this.linearGaugeNeedleIndicator1.Padding = new System.Windows.Forms.Padding(0);
            this.linearGaugeNeedleIndicator1.PointRadiusPercentage = 10F;
            this.linearGaugeNeedleIndicator1.TextOffsetFromIndicator = new System.Drawing.SizeF(2F, -5F);
            this.linearGaugeNeedleIndicator1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.linearGaugeNeedleIndicator1.UseCompatibleTextRendering = false;
            this.linearGaugeNeedleIndicator1.Value = 66F;
            // 
            // linearGaugeLine4
            // 
            this.linearGaugeLine4.AutoSize = false;
            this.linearGaugeLine4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.linearGaugeLine4.Bounds = new System.Drawing.Rectangle(0, 0, 60, 270);
            this.linearGaugeLine4.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.linearGaugeLine4.Name = "linearGaugeLine4";
            this.linearGaugeLine4.Offset = 35F;
            this.linearGaugeLine4.Padding = new System.Windows.Forms.Padding(0);
            this.linearGaugeLine4.RangeEnd = 80F;
            this.linearGaugeLine4.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.linearGaugeLine4.UseCompatibleTextRendering = false;
            this.linearGaugeLine4.Width = 2F;
            // 
            // linearGaugeLine6
            // 
            this.linearGaugeLine6.AutoSize = false;
            this.linearGaugeLine6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.linearGaugeLine6.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.linearGaugeLine6.Bounds = new System.Drawing.Rectangle(0, 0, 59, 270);
            this.linearGaugeLine6.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.linearGaugeLine6.Name = "linearGaugeLine6";
            this.linearGaugeLine6.Offset = 35F;
            this.linearGaugeLine6.Padding = new System.Windows.Forms.Padding(0);
            this.linearGaugeLine6.RangeEnd = 120F;
            this.linearGaugeLine6.RangeStart = 80F;
            this.linearGaugeLine6.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.linearGaugeLine6.UseCompatibleTextRendering = false;
            this.linearGaugeLine6.Width = 2F;
            // 
            // linearGaugeLine1
            // 
            this.linearGaugeLine1.AutoSize = false;
            this.linearGaugeLine1.Bounds = new System.Drawing.Rectangle(0, 0, 15, 285);
            this.linearGaugeLine1.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.linearGaugeLine1.Name = "linearGaugeLine1";
            this.linearGaugeLine1.Offset = 28F;
            this.linearGaugeLine1.Padding = new System.Windows.Forms.Padding(0);
            this.linearGaugeLine1.RangeEnd = 120F;
            this.linearGaugeLine1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.linearGaugeLine1.UseCompatibleTextRendering = false;
            this.linearGaugeLine1.Width = 1.5F;
            // 
            // linearGaugeBar3
            // 
            this.linearGaugeBar3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(88)))), ((int)(((byte)(88)))));
            this.linearGaugeBar3.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(88)))), ((int)(((byte)(88)))));
            this.linearGaugeBar3.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.linearGaugeBar3.Name = "linearGaugeBar3";
            this.linearGaugeBar3.Offset = 20F;
            this.linearGaugeBar3.Padding = new System.Windows.Forms.Padding(0);
            this.linearGaugeBar3.RangeEnd = 81F;
            this.linearGaugeBar3.RangeStart = 120F;
            this.linearGaugeBar3.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.linearGaugeBar3.UseCompatibleTextRendering = false;
            this.linearGaugeBar3.Width = 50F;
            this.linearGaugeBar3.Width2 = 35F;
            // 
            // linearGaugeTicks1
            // 
            this.linearGaugeTicks1.AutoSize = false;
            this.linearGaugeTicks1.Bounds = new System.Drawing.Rectangle(0, 0, 15, 261);
            this.linearGaugeTicks1.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.linearGaugeTicks1.Name = "linearGaugeTicks1";
            this.linearGaugeTicks1.Padding = new System.Windows.Forms.Padding(0);
            this.linearGaugeTicks1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.linearGaugeTicks1.TicksCount = 12;
            this.linearGaugeTicks1.TicksLenghtPercentage = 5F;
            this.linearGaugeTicks1.TicksLocationPercentage = 28F;
            this.linearGaugeTicks1.TickThickness = 0.5F;
            this.linearGaugeTicks1.UseCompatibleTextRendering = false;
            // 
            // frmMoldPress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(224)))), ((int)(((byte)(231)))));
            this.ClientSize = new System.Drawing.Size(1508, 590);
            this.Controls.Add(this.pnlBack);
            this.Controls.Add(this.radTitleBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1508, 590);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1508, 590);
            this.Name = "frmMoldPress";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ضرب قالب";
            this.Load += new System.EventHandler(this.frmMoldPress_Load);
            this.pnlBack.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridAll.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridAll)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTitleBar1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlBack;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private Telerik.WinControls.UI.RadTitleBar radTitleBar1;
        private Telerik.WinControls.UI.Gauges.LinearGaugeNeedleIndicator linearGaugeNeedleIndicator1;
        private Telerik.WinControls.UI.Gauges.LinearGaugeLine linearGaugeLine4;
        private Telerik.WinControls.UI.Gauges.LinearGaugeLine linearGaugeLine6;
        private Telerik.WinControls.UI.RadGridView gridAll;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtYear;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEnd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtStart;
        private Telerik.WinControls.UI.RadButton btnAdd;
        private Telerik.WinControls.UI.Gauges.LinearGaugeLine linearGaugeLine1;
        private Telerik.WinControls.UI.Gauges.LinearGaugeBar linearGaugeBar3;
        private Telerik.WinControls.UI.Gauges.LinearGaugeTicks linearGaugeTicks1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblMoldName;
        private System.Windows.Forms.Label lblPerssData;
    }
}