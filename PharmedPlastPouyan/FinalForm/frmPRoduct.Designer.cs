namespace PharmedPlastPouyan
{
    partial class frmPRoduct
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
            Telerik.WinControls.UI.ConditionalFormattingObject conditionalFormattingObject1 = new Telerik.WinControls.UI.ConditionalFormattingObject();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPRoduct));
            this.btnExit = new Telerik.WinControls.UI.RadButton();
            this.gridAll = new Telerik.WinControls.UI.RadGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnPnlAdd = new Telerik.WinControls.UI.RadButton();
            this.btnAdd = new Telerik.WinControls.UI.RadButton();
            this.btnClosePanel = new Telerik.WinControls.UI.RadButton();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPrName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFastCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPRCode = new System.Windows.Forms.TextBox();
            this.pnlAcept = new System.Windows.Forms.Panel();
            this.comType = new System.Windows.Forms.ComboBox();
            this.pnlBack = new System.Windows.Forms.Panel();
            this.radTitleBar1 = new Telerik.WinControls.UI.RadTitleBar();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridAll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridAll.MasterTemplate)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnPnlAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClosePanel)).BeginInit();
            this.pnlAcept.SuspendLayout();
            this.pnlBack.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radTitleBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnExit.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnExit.Location = new System.Drawing.Point(8, 8);
            this.btnExit.Margin = new System.Windows.Forms.Padding(2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(117, 27);
            this.btnExit.TabIndex = 92;
            this.btnExit.TabStop = false;
            this.btnExit.Text = "خروج";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // gridAll
            // 
            this.gridAll.AllowDrop = true;
            this.gridAll.AutoSizeRows = true;
            this.gridAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridAll.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.gridAll.Location = new System.Drawing.Point(10, 10);
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
            gridViewTextBoxColumn1.Width = 738;
            gridViewTextBoxColumn2.Expression = "";
            gridViewTextBoxColumn2.FieldName = "CodeFast";
            gridViewTextBoxColumn2.HeaderText = "کد انتخاب سریع";
            gridViewTextBoxColumn2.Name = "CodeFast";
            gridViewTextBoxColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn2.Width = 112;
            gridViewTextBoxColumn3.FieldName = "Product_Code";
            gridViewTextBoxColumn3.HeaderText = "کد محصول";
            gridViewTextBoxColumn3.Name = "Product_Code";
            gridViewTextBoxColumn3.Width = 135;
            gridViewTextBoxColumn4.FieldName = "Product_Name";
            gridViewTextBoxColumn4.HeaderText = "نام محصول";
            gridViewTextBoxColumn4.Name = "Product_Name";
            gridViewTextBoxColumn4.Width = 360;
            conditionalFormattingObject1.CellBackColor = System.Drawing.Color.Empty;
            conditionalFormattingObject1.CellFont = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            conditionalFormattingObject1.CellForeColor = System.Drawing.Color.Empty;
            conditionalFormattingObject1.ConditionType = Telerik.WinControls.UI.ConditionTypes.NotEqual;
            conditionalFormattingObject1.Name = "NewCondition";
            conditionalFormattingObject1.RowBackColor = System.Drawing.Color.Empty;
            conditionalFormattingObject1.RowForeColor = System.Drawing.Color.Empty;
            conditionalFormattingObject1.TValue1 = " ";
            gridViewTextBoxColumn5.ConditionalFormattingObjectList.Add(conditionalFormattingObject1);
            gridViewTextBoxColumn5.FieldName = "kind";
            gridViewTextBoxColumn5.HeaderText = "نوع محصول";
            gridViewTextBoxColumn5.Name = "kind";
            gridViewTextBoxColumn5.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn5.Width = 98;
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
            this.gridAll.Size = new System.Drawing.Size(703, 521);
            this.gridAll.TabIndex = 90;
            this.gridAll.TabStop = false;
            this.gridAll.CellDoubleClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.gridAll_CellDoubleClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnPnlAdd);
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(10, 531);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(703, 43);
            this.panel1.TabIndex = 91;
            // 
            // btnPnlAdd
            // 
            this.btnPnlAdd.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnPnlAdd.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnPnlAdd.Location = new System.Drawing.Point(129, 8);
            this.btnPnlAdd.Margin = new System.Windows.Forms.Padding(2);
            this.btnPnlAdd.Name = "btnPnlAdd";
            this.btnPnlAdd.Size = new System.Drawing.Size(207, 27);
            this.btnPnlAdd.TabIndex = 93;
            this.btnPnlAdd.TabStop = false;
            this.btnPnlAdd.Text = "اضافه کردن کالا جدید";
            this.btnPnlAdd.Visible = false;
            this.btnPnlAdd.Click += new System.EventHandler(this.btnPnlAdd_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAdd.Font = new System.Drawing.Font("B Nazanin", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnAdd.Location = new System.Drawing.Point(272, 100);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(117, 27);
            this.btnAdd.TabIndex = 91;
            this.btnAdd.TabStop = false;
            this.btnAdd.Text = "ثبت";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnClosePanel
            // 
            this.btnClosePanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnClosePanel.Font = new System.Drawing.Font("B Nazanin", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnClosePanel.Location = new System.Drawing.Point(133, 100);
            this.btnClosePanel.Margin = new System.Windows.Forms.Padding(2);
            this.btnClosePanel.Name = "btnClosePanel";
            this.btnClosePanel.Size = new System.Drawing.Size(117, 27);
            this.btnClosePanel.TabIndex = 90;
            this.btnClosePanel.TabStop = false;
            this.btnClosePanel.Text = "خروج";
            this.btnClosePanel.Click += new System.EventHandler(this.btnClosePanel_Click);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("B Nazanin", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label3.Location = new System.Drawing.Point(450, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 28);
            this.label3.TabIndex = 81;
            this.label3.Text = "نام محصول";
            // 
            // txtPrName
            // 
            this.txtPrName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtPrName.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.txtPrName.Location = new System.Drawing.Point(17, 57);
            this.txtPrName.Margin = new System.Windows.Forms.Padding(2);
            this.txtPrName.MaxLength = 150;
            this.txtPrName.Name = "txtPrName";
            this.txtPrName.Size = new System.Drawing.Size(427, 26);
            this.txtPrName.TabIndex = 80;
            this.txtPrName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("B Nazanin", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label2.Location = new System.Drawing.Point(206, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 28);
            this.label2.TabIndex = 79;
            this.label2.Text = "کد انتخاب سریع";
            // 
            // txtFastCode
            // 
            this.txtFastCode.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtFastCode.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.txtFastCode.Location = new System.Drawing.Point(133, 17);
            this.txtFastCode.Margin = new System.Windows.Forms.Padding(2);
            this.txtFastCode.MaxLength = 3;
            this.txtFastCode.Name = "txtFastCode";
            this.txtFastCode.Size = new System.Drawing.Size(68, 26);
            this.txtFastCode.TabIndex = 78;
            this.txtFastCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtFastCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFastCode_KeyPress);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("B Nazanin", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.Location = new System.Drawing.Point(449, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 28);
            this.label1.TabIndex = 77;
            this.label1.Text = "کد محصول";
            // 
            // txtPRCode
            // 
            this.txtPRCode.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtPRCode.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.txtPRCode.Location = new System.Drawing.Point(319, 17);
            this.txtPRCode.Margin = new System.Windows.Forms.Padding(2);
            this.txtPRCode.MaxLength = 10;
            this.txtPRCode.Name = "txtPRCode";
            this.txtPRCode.Size = new System.Drawing.Size(125, 26);
            this.txtPRCode.TabIndex = 75;
            this.txtPRCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPRCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFastCode_KeyPress);
            // 
            // pnlAcept
            // 
            this.pnlAcept.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlAcept.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAcept.Controls.Add(this.comType);
            this.pnlAcept.Controls.Add(this.btnAdd);
            this.pnlAcept.Controls.Add(this.btnClosePanel);
            this.pnlAcept.Controls.Add(this.label3);
            this.pnlAcept.Controls.Add(this.txtPrName);
            this.pnlAcept.Controls.Add(this.label2);
            this.pnlAcept.Controls.Add(this.txtFastCode);
            this.pnlAcept.Controls.Add(this.label1);
            this.pnlAcept.Controls.Add(this.txtPRCode);
            this.pnlAcept.Enabled = false;
            this.pnlAcept.Location = new System.Drawing.Point(90, 288);
            this.pnlAcept.Name = "pnlAcept";
            this.pnlAcept.Padding = new System.Windows.Forms.Padding(15);
            this.pnlAcept.Size = new System.Drawing.Size(536, 143);
            this.pnlAcept.TabIndex = 92;
            this.pnlAcept.Visible = false;
            // 
            // comType
            // 
            this.comType.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comType.DisplayMember = "Title";
            this.comType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comType.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.comType.FormattingEnabled = true;
            this.comType.Items.AddRange(new object[] {
            "تولید",
            "گرانول",
            "مونتاژ"});
            this.comType.Location = new System.Drawing.Point(17, 13);
            this.comType.Margin = new System.Windows.Forms.Padding(2);
            this.comType.Name = "comType";
            this.comType.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.comType.Size = new System.Drawing.Size(101, 32);
            this.comType.TabIndex = 92;
            this.comType.ValueMember = "ID";
            // 
            // pnlBack
            // 
            this.pnlBack.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBack.Controls.Add(this.pnlAcept);
            this.pnlBack.Controls.Add(this.gridAll);
            this.pnlBack.Controls.Add(this.panel1);
            this.pnlBack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBack.Location = new System.Drawing.Point(0, 34);
            this.pnlBack.Name = "pnlBack";
            this.pnlBack.Padding = new System.Windows.Forms.Padding(10);
            this.pnlBack.Size = new System.Drawing.Size(725, 586);
            this.pnlBack.TabIndex = 4;
            // 
            // radTitleBar1
            // 
            this.radTitleBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radTitleBar1.Font = new System.Drawing.Font("IRANSansWeb(FaNum)", 12F);
            this.radTitleBar1.Location = new System.Drawing.Point(0, 0);
            this.radTitleBar1.Name = "radTitleBar1";
            this.radTitleBar1.Size = new System.Drawing.Size(725, 34);
            this.radTitleBar1.TabIndex = 3;
            this.radTitleBar1.TabStop = false;
            this.radTitleBar1.Text = "کالا";
            ((Telerik.WinControls.UI.RadTitleBarElement)(this.radTitleBar1.GetChildAt(0))).Text = "کالا";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.radTitleBar1.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.radTitleBar1.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(0).GetChildAt(1).GetChildAt(1))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            // 
            // frmPRoduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(224)))), ((int)(((byte)(231)))));
            this.ClientSize = new System.Drawing.Size(725, 620);
            this.Controls.Add(this.pnlBack);
            this.Controls.Add(this.radTitleBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPRoduct";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "کالا";
            this.Load += new System.EventHandler(this.frmPRoduct_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridAll.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridAll)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnPnlAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClosePanel)).EndInit();
            this.pnlAcept.ResumeLayout(false);
            this.pnlAcept.PerformLayout();
            this.pnlBack.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radTitleBar1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadButton btnExit;
        private Telerik.WinControls.UI.RadGridView gridAll;
        private System.Windows.Forms.Panel panel1;
        private Telerik.WinControls.UI.RadButton btnPnlAdd;
        private Telerik.WinControls.UI.RadButton btnAdd;
        private Telerik.WinControls.UI.RadButton btnClosePanel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPrName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFastCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPRCode;
        private System.Windows.Forms.Panel pnlAcept;
        private System.Windows.Forms.Panel pnlBack;
        private Telerik.WinControls.UI.RadTitleBar radTitleBar1;
        private System.Windows.Forms.ComboBox comType;
    }
}