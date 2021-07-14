namespace PharmedPlastPouyan
{
    partial class PersonalForm
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.ConditionalFormattingObject conditionalFormattingObject1 = new Telerik.WinControls.UI.ConditionalFormattingObject();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.ConditionalFormattingObject conditionalFormattingObject2 = new Telerik.WinControls.UI.ConditionalFormattingObject();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PersonalForm));
            this.radTitleBar1 = new Telerik.WinControls.UI.RadTitleBar();
            this.pnlBack = new System.Windows.Forms.Panel();
            this.pnlEditNew = new System.Windows.Forms.Panel();
            this.btnClose = new Telerik.WinControls.UI.RadButton();
            this.btnAccept = new Telerik.WinControls.UI.RadButton();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPnameEN = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPnameFA = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPcode = new System.Windows.Forms.TextBox();
            this.gridAll = new Telerik.WinControls.UI.RadGridView();
            this.RightClickMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.btnNew = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label42 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnexit = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.radTitleBar1)).BeginInit();
            this.pnlBack.SuspendLayout();
            this.pnlEditNew.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAccept)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridAll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridAll.MasterTemplate)).BeginInit();
            this.RightClickMenu.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnexit)).BeginInit();
            this.SuspendLayout();
            // 
            // radTitleBar1
            // 
            this.radTitleBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radTitleBar1.Font = new System.Drawing.Font("IRANSansWeb(FaNum)", 12F);
            this.radTitleBar1.ForeColor = System.Drawing.Color.Black;
            this.radTitleBar1.Location = new System.Drawing.Point(0, 0);
            this.radTitleBar1.Name = "radTitleBar1";
            this.radTitleBar1.Size = new System.Drawing.Size(670, 34);
            this.radTitleBar1.TabIndex = 2;
            this.radTitleBar1.TabStop = false;
            this.radTitleBar1.Text = "لیست پرسنل";
            // 
            // pnlBack
            // 
            this.pnlBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(194)))), ((int)(((byte)(201)))));
            this.pnlBack.Controls.Add(this.pnlEditNew);
            this.pnlBack.Controls.Add(this.gridAll);
            this.pnlBack.Controls.Add(this.panel2);
            this.pnlBack.Controls.Add(this.panel1);
            this.pnlBack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBack.Location = new System.Drawing.Point(0, 34);
            this.pnlBack.Name = "pnlBack";
            this.pnlBack.Padding = new System.Windows.Forms.Padding(7, 0, 7, 7);
            this.pnlBack.Size = new System.Drawing.Size(670, 773);
            this.pnlBack.TabIndex = 3;
            // 
            // pnlEditNew
            // 
            this.pnlEditNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(224)))), ((int)(((byte)(231)))));
            this.pnlEditNew.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlEditNew.Controls.Add(this.btnClose);
            this.pnlEditNew.Controls.Add(this.btnAccept);
            this.pnlEditNew.Controls.Add(this.label3);
            this.pnlEditNew.Controls.Add(this.txtPnameEN);
            this.pnlEditNew.Controls.Add(this.label2);
            this.pnlEditNew.Controls.Add(this.txtPnameFA);
            this.pnlEditNew.Controls.Add(this.label1);
            this.pnlEditNew.Controls.Add(this.txtPcode);
            this.pnlEditNew.Location = new System.Drawing.Point(58, 271);
            this.pnlEditNew.Name = "pnlEditNew";
            this.pnlEditNew.Padding = new System.Windows.Forms.Padding(10);
            this.pnlEditNew.Size = new System.Drawing.Size(502, 190);
            this.pnlEditNew.TabIndex = 97;
            this.pnlEditNew.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnClose.Font = new System.Drawing.Font("B Nazanin", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnClose.Location = new System.Drawing.Point(144, 141);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(103, 36);
            this.btnClose.TabIndex = 144;
            this.btnClose.TabStop = false;
            this.btnClose.Text = "بستن";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnAccept
            // 
            this.btnAccept.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAccept.Font = new System.Drawing.Font("B Nazanin", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnAccept.Location = new System.Drawing.Point(266, 141);
            this.btnAccept.Margin = new System.Windows.Forms.Padding(2);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(103, 36);
            this.btnAccept.TabIndex = 144;
            this.btnAccept.TabStop = false;
            this.btnAccept.Text = "ثبت";
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(224)))), ((int)(((byte)(231)))));
            this.label3.Font = new System.Drawing.Font("B Nazanin", 18F);
            this.label3.Location = new System.Drawing.Point(363, 98);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 35);
            this.label3.TabIndex = 143;
            this.label3.Text = "نام انگلیسی";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtPnameEN
            // 
            this.txtPnameEN.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtPnameEN.Font = new System.Drawing.Font("IRANSansWeb(FaNum)", 12F);
            this.txtPnameEN.Location = new System.Drawing.Point(18, 98);
            this.txtPnameEN.Margin = new System.Windows.Forms.Padding(2);
            this.txtPnameEN.MaxLength = 32565;
            this.txtPnameEN.Name = "txtPnameEN";
            this.txtPnameEN.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtPnameEN.Size = new System.Drawing.Size(341, 34);
            this.txtPnameEN.TabIndex = 142;
            this.txtPnameEN.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(224)))), ((int)(((byte)(231)))));
            this.label2.Font = new System.Drawing.Font("B Nazanin", 18F);
            this.label2.Location = new System.Drawing.Point(363, 53);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 35);
            this.label2.TabIndex = 141;
            this.label2.Text = "نام فارسی";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtPnameFA
            // 
            this.txtPnameFA.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtPnameFA.Font = new System.Drawing.Font("IRANSansWeb(FaNum)", 12F);
            this.txtPnameFA.Location = new System.Drawing.Point(18, 53);
            this.txtPnameFA.Margin = new System.Windows.Forms.Padding(2);
            this.txtPnameFA.MaxLength = 32565;
            this.txtPnameFA.Name = "txtPnameFA";
            this.txtPnameFA.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPnameFA.Size = new System.Drawing.Size(341, 34);
            this.txtPnameFA.TabIndex = 140;
            this.txtPnameFA.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(224)))), ((int)(((byte)(231)))));
            this.label1.Font = new System.Drawing.Font("B Nazanin", 18F);
            this.label1.Location = new System.Drawing.Point(363, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 35);
            this.label1.TabIndex = 139;
            this.label1.Text = "شماره پرسنلی";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtPcode
            // 
            this.txtPcode.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtPcode.BackColor = System.Drawing.SystemColors.Window;
            this.txtPcode.Font = new System.Drawing.Font("IRANSansWeb(FaNum)", 12F);
            this.txtPcode.Location = new System.Drawing.Point(18, 7);
            this.txtPcode.Margin = new System.Windows.Forms.Padding(2);
            this.txtPcode.MaxLength = 32565;
            this.txtPcode.Name = "txtPcode";
            this.txtPcode.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtPcode.Size = new System.Drawing.Size(341, 34);
            this.txtPcode.TabIndex = 138;
            this.txtPcode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // gridAll
            // 
            this.gridAll.AllowDrop = true;
            this.gridAll.AutoSizeRows = true;
            this.gridAll.CausesValidation = false;
            this.gridAll.ContextMenuStrip = this.RightClickMenu;
            this.gridAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridAll.Font = new System.Drawing.Font("B Nazanin", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.gridAll.Location = new System.Drawing.Point(7, 55);
            // 
            // 
            // 
            this.gridAll.MasterTemplate.AddNewRowPosition = Telerik.WinControls.UI.SystemRowPosition.Bottom;
            this.gridAll.MasterTemplate.AllowAddNewRow = false;
            this.gridAll.MasterTemplate.AllowCellContextMenu = false;
            this.gridAll.MasterTemplate.AllowColumnChooser = false;
            this.gridAll.MasterTemplate.AllowColumnHeaderContextMenu = false;
            this.gridAll.MasterTemplate.AllowColumnReorder = false;
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
            gridViewTextBoxColumn1.Width = 235;
            conditionalFormattingObject1.CellBackColor = System.Drawing.Color.Empty;
            conditionalFormattingObject1.CellFont = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            conditionalFormattingObject1.CellForeColor = System.Drawing.Color.Empty;
            conditionalFormattingObject1.ConditionType = Telerik.WinControls.UI.ConditionTypes.NotEqual;
            conditionalFormattingObject1.Name = "NewCondition";
            conditionalFormattingObject1.RowBackColor = System.Drawing.Color.Empty;
            conditionalFormattingObject1.RowForeColor = System.Drawing.Color.Empty;
            conditionalFormattingObject1.TValue1 = "A";
            gridViewTextBoxColumn2.ConditionalFormattingObjectList.Add(conditionalFormattingObject1);
            gridViewTextBoxColumn2.FieldName = "PersonalCode";
            gridViewTextBoxColumn2.HeaderText = "شماره پرسنلی";
            gridViewTextBoxColumn2.Name = "PersonalCode";
            gridViewTextBoxColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn2.Width = 113;
            gridViewTextBoxColumn3.FieldName = "PersonalName";
            gridViewTextBoxColumn3.HeaderText = "نام فارسی کاربر";
            gridViewTextBoxColumn3.Name = "PersonalName";
            gridViewTextBoxColumn3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn3.Width = 205;
            conditionalFormattingObject2.CellBackColor = System.Drawing.Color.Empty;
            conditionalFormattingObject2.CellFont = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            conditionalFormattingObject2.CellForeColor = System.Drawing.Color.Empty;
            conditionalFormattingObject2.ConditionType = Telerik.WinControls.UI.ConditionTypes.NotEqual;
            conditionalFormattingObject2.Name = "NewCondition";
            conditionalFormattingObject2.RowBackColor = System.Drawing.Color.Empty;
            conditionalFormattingObject2.RowForeColor = System.Drawing.Color.Empty;
            conditionalFormattingObject2.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            conditionalFormattingObject2.TValue1 = "1";
            gridViewTextBoxColumn4.ConditionalFormattingObjectList.Add(conditionalFormattingObject2);
            gridViewTextBoxColumn4.FieldName = "EnglishName";
            gridViewTextBoxColumn4.HeaderText = "نام انگلیسی کاربر";
            gridViewTextBoxColumn4.Name = "EnglishName";
            gridViewTextBoxColumn4.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn4.Width = 339;
            this.gridAll.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4});
            this.gridAll.MasterTemplate.ShowFilteringRow = false;
            this.gridAll.MasterTemplate.ShowRowHeaderColumn = false;
            this.gridAll.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.gridAll.Name = "gridAll";
            this.gridAll.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.gridAll.ShowGroupPanel = false;
            this.gridAll.ShowGroupPanelScrollbars = false;
            this.gridAll.ShowItemToolTips = false;
            this.gridAll.ShowRowErrors = false;
            this.gridAll.Size = new System.Drawing.Size(656, 662);
            this.gridAll.TabIndex = 96;
            this.gridAll.TabStop = false;
            // 
            // RightClickMenu
            // 
            this.RightClickMenu.Font = new System.Drawing.Font("IRANSansWeb(FaNum)", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.RightClickMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.RightClickMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnEdit,
            this.btnDelete,
            this.btnNew});
            this.RightClickMenu.Name = "RightClickMenu";
            this.RightClickMenu.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightClickMenu.Size = new System.Drawing.Size(136, 100);
            // 
            // btnEdit
            // 
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(135, 32);
            this.btnEdit.Text = "ویرایش";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(135, 32);
            this.btnDelete.Text = "حذف";
            this.btnDelete.Visible = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnNew
            // 
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(135, 32);
            this.btnNew.Text = "جدید";
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(224)))), ((int)(((byte)(231)))));
            this.panel2.Controls.Add(this.txtSearch);
            this.panel2.Controls.Add(this.label42);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(7, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(5);
            this.panel2.Size = new System.Drawing.Size(656, 55);
            this.panel2.TabIndex = 13;
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtSearch.Font = new System.Drawing.Font("IRANSansWeb(FaNum)", 12F);
            this.txtSearch.Location = new System.Drawing.Point(51, 10);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(2);
            this.txtSearch.MaxLength = 32565;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtSearch.Size = new System.Drawing.Size(476, 34);
            this.txtSearch.TabIndex = 137;
            this.txtSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // label42
            // 
            this.label42.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label42.AutoSize = true;
            this.label42.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(224)))), ((int)(((byte)(231)))));
            this.label42.Font = new System.Drawing.Font("B Nazanin", 18F);
            this.label42.Location = new System.Drawing.Point(531, 10);
            this.label42.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(74, 35);
            this.label42.TabIndex = 138;
            this.label42.Text = "جستجو:";
            this.label42.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label42.Click += new System.EventHandler(this.label42_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(224)))), ((int)(((byte)(231)))));
            this.panel1.Controls.Add(this.btnexit);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(7, 717);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(656, 49);
            this.panel1.TabIndex = 12;
            // 
            // btnexit
            // 
            this.btnexit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnexit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnexit.Font = new System.Drawing.Font("B Nazanin", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnexit.Location = new System.Drawing.Point(277, 6);
            this.btnexit.Margin = new System.Windows.Forms.Padding(2);
            this.btnexit.Name = "btnexit";
            this.btnexit.Size = new System.Drawing.Size(103, 36);
            this.btnexit.TabIndex = 21;
            this.btnexit.TabStop = false;
            this.btnexit.Text = "خروج";
            this.btnexit.Click += new System.EventHandler(this.btnexit_Click);
            // 
            // PersonalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(224)))), ((int)(((byte)(231)))));
            this.CancelButton = this.btnexit;
            this.ClientSize = new System.Drawing.Size(670, 807);
            this.Controls.Add(this.pnlBack);
            this.Controls.Add(this.radTitleBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PersonalForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "لیست پرسنل";
            this.Load += new System.EventHandler(this.PersonalForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radTitleBar1)).EndInit();
            this.pnlBack.ResumeLayout(false);
            this.pnlEditNew.ResumeLayout(false);
            this.pnlEditNew.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAccept)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridAll.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridAll)).EndInit();
            this.RightClickMenu.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnexit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadTitleBar radTitleBar1;
        private System.Windows.Forms.Panel pnlBack;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private Telerik.WinControls.UI.RadButton btnexit;
        private Telerik.WinControls.UI.RadGridView gridAll;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.ContextMenuStrip RightClickMenu;
        private System.Windows.Forms.ToolStripMenuItem btnEdit;
        private System.Windows.Forms.ToolStripMenuItem btnDelete;
        private System.Windows.Forms.ToolStripMenuItem btnNew;
        private System.Windows.Forms.Panel pnlEditNew;
        private Telerik.WinControls.UI.RadButton btnClose;
        private Telerik.WinControls.UI.RadButton btnAccept;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPnameEN;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPnameFA;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPcode;
    }
}