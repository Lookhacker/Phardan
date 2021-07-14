namespace PharmedPlastPouyan
{
    partial class frmInventoryDetails
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInventoryDetails));
            this.radTitleBar1 = new Telerik.WinControls.UI.RadTitleBar();
            this.pnlBack = new System.Windows.Forms.Panel();
            this.panla = new System.Windows.Forms.Panel();
            this.gridAll = new Telerik.WinControls.UI.RadGridView();
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.comType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TotalView = new System.Windows.Forms.Label();
            this.lblLot = new System.Windows.Forms.Label();
            this.lblShift = new System.Windows.Forms.Label();
            this.lblMold = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblProdectName = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lblProdectCode = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnExit = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.radTitleBar1)).BeginInit();
            this.pnlBack.SuspendLayout();
            this.panla.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridAll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridAll.MasterTemplate)).BeginInit();
            this.pnlFilter.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).BeginInit();
            this.SuspendLayout();
            // 
            // radTitleBar1
            // 
            this.radTitleBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radTitleBar1.Font = new System.Drawing.Font("IRANSansWeb(FaNum)", 12F);
            this.radTitleBar1.Location = new System.Drawing.Point(0, 0);
            this.radTitleBar1.Name = "radTitleBar1";
            this.radTitleBar1.Size = new System.Drawing.Size(847, 34);
            this.radTitleBar1.TabIndex = 14;
            this.radTitleBar1.TabStop = false;
            this.radTitleBar1.Text = "ریز موجودی سالن";
            ((Telerik.WinControls.UI.RadTitleBarElement)(this.radTitleBar1.GetChildAt(0))).Text = "ریز موجودی سالن";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.radTitleBar1.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.radTitleBar1.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(0).GetChildAt(1).GetChildAt(1))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            // 
            // pnlBack
            // 
            this.pnlBack.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBack.Controls.Add(this.panla);
            this.pnlBack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBack.Location = new System.Drawing.Point(0, 34);
            this.pnlBack.Name = "pnlBack";
            this.pnlBack.Padding = new System.Windows.Forms.Padding(10);
            this.pnlBack.Size = new System.Drawing.Size(847, 769);
            this.pnlBack.TabIndex = 15;
            // 
            // panla
            // 
            this.panla.Controls.Add(this.gridAll);
            this.panla.Controls.Add(this.pnlFilter);
            this.panla.Controls.Add(this.panel1);
            this.panla.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panla.Location = new System.Drawing.Point(10, 10);
            this.panla.Name = "panla";
            this.panla.Size = new System.Drawing.Size(825, 747);
            this.panla.TabIndex = 107;
            // 
            // gridAll
            // 
            this.gridAll.AllowDrop = true;
            this.gridAll.AutoSizeRows = true;
            this.gridAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridAll.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.gridAll.Location = new System.Drawing.Point(0, 149);
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
            gridViewTextBoxColumn1.FieldName = "ID";
            gridViewTextBoxColumn1.HeaderText = "ID";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "ID";
            gridViewTextBoxColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn1.Width = 49;
            gridViewTextBoxColumn2.FieldName = "Increase";
            gridViewTextBoxColumn2.HeaderText = "افزایش";
            gridViewTextBoxColumn2.Name = "Increase";
            gridViewTextBoxColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn2.Width = 207;
            gridViewTextBoxColumn3.FieldName = "Decrease";
            gridViewTextBoxColumn3.HeaderText = "کاهش";
            gridViewTextBoxColumn3.Name = "Decrease";
            gridViewTextBoxColumn3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn3.Width = 207;
            gridViewTextBoxColumn4.FieldName = "Location";
            gridViewTextBoxColumn4.HeaderText = "محل";
            gridViewTextBoxColumn4.Name = "Location";
            gridViewTextBoxColumn4.Width = 206;
            gridViewTextBoxColumn5.FieldName = "LocationID";
            gridViewTextBoxColumn5.HeaderText = "ردیابی";
            gridViewTextBoxColumn5.Name = "LocationID";
            gridViewTextBoxColumn5.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn5.Width = 207;
            this.gridAll.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5});
            this.gridAll.MasterTemplate.ShowRowHeaderColumn = false;
            this.gridAll.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.gridAll.Name = "gridAll";
            this.gridAll.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.gridAll.ShowItemToolTips = false;
            this.gridAll.Size = new System.Drawing.Size(825, 555);
            this.gridAll.TabIndex = 94;
            this.gridAll.TabStop = false;
            this.gridAll.CellDoubleClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.gridAll_CellDoubleClick);
            // 
            // pnlFilter
            // 
            this.pnlFilter.Controls.Add(this.comType);
            this.pnlFilter.Controls.Add(this.label4);
            this.pnlFilter.Controls.Add(this.TotalView);
            this.pnlFilter.Controls.Add(this.lblLot);
            this.pnlFilter.Controls.Add(this.lblShift);
            this.pnlFilter.Controls.Add(this.lblMold);
            this.pnlFilter.Controls.Add(this.label3);
            this.pnlFilter.Controls.Add(this.label2);
            this.pnlFilter.Controls.Add(this.label5);
            this.pnlFilter.Controls.Add(this.label1);
            this.pnlFilter.Controls.Add(this.lblProdectName);
            this.pnlFilter.Controls.Add(this.label16);
            this.pnlFilter.Controls.Add(this.lblProdectCode);
            this.pnlFilter.Controls.Add(this.label14);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Location = new System.Drawing.Point(0, 0);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Padding = new System.Windows.Forms.Padding(10);
            this.pnlFilter.Size = new System.Drawing.Size(825, 149);
            this.pnlFilter.TabIndex = 93;
            // 
            // comType
            // 
            this.comType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comType.Font = new System.Drawing.Font("B Nazanin", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.comType.FormattingEnabled = true;
            this.comType.Items.AddRange(new object[] {
            "موجودی سالم سالن",
            "موجودی تحت کنترل سالن",
            "موجودی سالم انبار",
            "موجودی تحت کنترل انبار",
            "ترخیص",
            "فروش",
            "ضایعات"});
            this.comType.Location = new System.Drawing.Point(462, 100);
            this.comType.Margin = new System.Windows.Forms.Padding(2);
            this.comType.Name = "comType";
            this.comType.Size = new System.Drawing.Size(258, 36);
            this.comType.TabIndex = 142;
            this.comType.SelectedIndexChanged += new System.EventHandler(this.comTemplate_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(224)))), ((int)(((byte)(231)))));
            this.label4.Font = new System.Drawing.Font("B Nazanin", 18F);
            this.label4.Location = new System.Drawing.Point(194, 101);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label4.Size = new System.Drawing.Size(78, 35);
            this.label4.TabIndex = 141;
            this.label4.Text = "باقیمانده";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TotalView
            // 
            this.TotalView.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.TotalView.BackColor = System.Drawing.Color.White;
            this.TotalView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TotalView.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalView.Location = new System.Drawing.Point(12, 100);
            this.TotalView.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.TotalView.Name = "TotalView";
            this.TotalView.Size = new System.Drawing.Size(178, 37);
            this.TotalView.TabIndex = 140;
            this.TotalView.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLot
            // 
            this.lblLot.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblLot.BackColor = System.Drawing.Color.White;
            this.lblLot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblLot.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLot.Location = new System.Drawing.Point(12, 53);
            this.lblLot.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblLot.Name = "lblLot";
            this.lblLot.Size = new System.Drawing.Size(130, 37);
            this.lblLot.TabIndex = 134;
            this.lblLot.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblShift
            // 
            this.lblShift.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblShift.BackColor = System.Drawing.Color.White;
            this.lblShift.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblShift.Font = new System.Drawing.Font("B Nazanin", 18F);
            this.lblShift.Location = new System.Drawing.Point(327, 53);
            this.lblShift.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblShift.Name = "lblShift";
            this.lblShift.Size = new System.Drawing.Size(100, 37);
            this.lblShift.TabIndex = 133;
            this.lblShift.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMold
            // 
            this.lblMold.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblMold.BackColor = System.Drawing.Color.White;
            this.lblMold.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMold.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMold.Location = new System.Drawing.Point(567, 53);
            this.lblMold.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMold.Name = "lblMold";
            this.lblMold.Size = new System.Drawing.Size(100, 37);
            this.lblMold.TabIndex = 132;
            this.lblMold.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(224)))), ((int)(((byte)(231)))));
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label3.Location = new System.Drawing.Point(177, 57);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(115, 29);
            this.label3.TabIndex = 131;
            this.label3.Text = ".LotNum :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(224)))), ((int)(((byte)(231)))));
            this.label2.Font = new System.Drawing.Font("B Nazanin", 18F);
            this.label2.Location = new System.Drawing.Point(462, 54);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(70, 35);
            this.label2.TabIndex = 130;
            this.label2.Text = "شیفت :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(224)))), ((int)(((byte)(231)))));
            this.label5.Font = new System.Drawing.Font("B Nazanin", 18F);
            this.label5.Location = new System.Drawing.Point(724, 101);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label5.Size = new System.Drawing.Size(88, 35);
            this.label5.TabIndex = 129;
            this.label5.Text = "موجودی :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(224)))), ((int)(((byte)(231)))));
            this.label1.Font = new System.Drawing.Font("B Nazanin", 18F);
            this.label1.Location = new System.Drawing.Point(702, 54);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(110, 35);
            this.label1.TabIndex = 129;
            this.label1.Text = "شماره قالب :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblProdectName
            // 
            this.lblProdectName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblProdectName.BackColor = System.Drawing.Color.White;
            this.lblProdectName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblProdectName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProdectName.Location = new System.Drawing.Point(12, 10);
            this.lblProdectName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblProdectName.Name = "lblProdectName";
            this.lblProdectName.Size = new System.Drawing.Size(398, 37);
            this.lblProdectName.TabIndex = 126;
            this.lblProdectName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label16
            // 
            this.label16.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(224)))), ((int)(((byte)(231)))));
            this.label16.Font = new System.Drawing.Font("B Nazanin", 18F);
            this.label16.Location = new System.Drawing.Point(431, 11);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label16.Size = new System.Drawing.Size(78, 35);
            this.label16.TabIndex = 128;
            this.label16.Text = "نام کالا :";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblProdectCode
            // 
            this.lblProdectCode.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblProdectCode.BackColor = System.Drawing.Color.White;
            this.lblProdectCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblProdectCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProdectCode.Location = new System.Drawing.Point(513, 10);
            this.lblProdectCode.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblProdectCode.Name = "lblProdectCode";
            this.lblProdectCode.Size = new System.Drawing.Size(203, 37);
            this.lblProdectCode.TabIndex = 125;
            this.lblProdectCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            this.label14.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(224)))), ((int)(((byte)(231)))));
            this.label14.Font = new System.Drawing.Font("B Nazanin", 18F);
            this.label14.Location = new System.Drawing.Point(734, 11);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label14.Size = new System.Drawing.Size(78, 35);
            this.label14.TabIndex = 127;
            this.label14.Text = "کد کالا :";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 704);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(825, 43);
            this.panel1.TabIndex = 92;
            // 
            // btnExit
            // 
            this.btnExit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnExit.Location = new System.Drawing.Point(354, 8);
            this.btnExit.Margin = new System.Windows.Forms.Padding(2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(117, 27);
            this.btnExit.TabIndex = 92;
            this.btnExit.TabStop = false;
            this.btnExit.Text = "خروج";
            // 
            // frmInventoryDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(224)))), ((int)(((byte)(231)))));
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(847, 803);
            this.Controls.Add(this.pnlBack);
            this.Controls.Add(this.radTitleBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmInventoryDetails";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ریز موجودی سالن";
            this.Load += new System.EventHandler(this.frmInventoryDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radTitleBar1)).EndInit();
            this.pnlBack.ResumeLayout(false);
            this.panla.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridAll.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridAll)).EndInit();
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadTitleBar radTitleBar1;
        private System.Windows.Forms.Panel pnlBack;
        private System.Windows.Forms.Panel panla;
        private Telerik.WinControls.UI.RadGridView gridAll;
        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.Label lblLot;
        private System.Windows.Forms.Label lblShift;
        private System.Windows.Forms.Label lblMold;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblProdectName;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lblProdectCode;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Panel panel1;
        private Telerik.WinControls.UI.RadButton btnExit;
        private System.Windows.Forms.Label TotalView;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comType;
        private System.Windows.Forms.Label label5;
    }
}