namespace PharmedPlastPouyan
{
    partial class frmView
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
            Telerik.WinControls.UI.ConditionalFormattingObject conditionalFormattingObject1 = new Telerik.WinControls.UI.ConditionalFormattingObject();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmView));
            this.panel1 = new System.Windows.Forms.Panel();
            this.radButton1 = new Telerik.WinControls.UI.RadButton();
            this.gridAll = new Telerik.WinControls.UI.RadGridView();
            this.radTitleBar1 = new Telerik.WinControls.UI.RadTitleBar();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label42 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridAll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridAll.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTitleBar1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radButton1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(10, 710);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(680, 46);
            this.panel1.TabIndex = 1;
            // 
            // radButton1
            // 
            this.radButton1.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.radButton1.Location = new System.Drawing.Point(273, 6);
            this.radButton1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radButton1.Name = "radButton1";
            this.radButton1.Size = new System.Drawing.Size(135, 32);
            this.radButton1.TabIndex = 3;
            this.radButton1.Text = "خروج";
            this.radButton1.Click += new System.EventHandler(this.radButton1_Click);
            // 
            // gridAll
            // 
            this.gridAll.AllowDrop = true;
            this.gridAll.AutoSizeRows = true;
            this.gridAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridAll.Font = new System.Drawing.Font("B Nazanin", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.gridAll.Location = new System.Drawing.Point(10, 56);
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
            gridViewTextBoxColumn1.Width = 49;
            gridViewTextBoxColumn2.FieldName = "Product_Name";
            gridViewTextBoxColumn2.HeaderText = "نام کالا";
            gridViewTextBoxColumn2.Name = "Product_Name";
            gridViewTextBoxColumn2.Width = 450;
            gridViewTextBoxColumn3.FieldName = "Product_Code";
            gridViewTextBoxColumn3.HeaderText = "کد کالا";
            gridViewTextBoxColumn3.Name = "Product_Code";
            gridViewTextBoxColumn3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn3.Width = 100;
            conditionalFormattingObject1.ApplyToRow = true;
            conditionalFormattingObject1.CellBackColor = System.Drawing.Color.Empty;
            conditionalFormattingObject1.CellForeColor = System.Drawing.Color.Empty;
            conditionalFormattingObject1.ConditionType = Telerik.WinControls.UI.ConditionTypes.NotEqual;
            conditionalFormattingObject1.Name = "NewCondition";
            conditionalFormattingObject1.RowBackColor = System.Drawing.Color.Empty;
            conditionalFormattingObject1.RowFont = new System.Drawing.Font("Times New Roman", 15F);
            conditionalFormattingObject1.RowForeColor = System.Drawing.Color.Empty;
            conditionalFormattingObject1.TValue1 = "0";
            gridViewTextBoxColumn4.ConditionalFormattingObjectList.Add(conditionalFormattingObject1);
            gridViewTextBoxColumn4.FieldName = "CodeFast";
            gridViewTextBoxColumn4.HeaderText = "کد انتخاب سریع";
            gridViewTextBoxColumn4.Name = "CodeFast";
            gridViewTextBoxColumn4.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn4.Width = 131;
            gridViewTextBoxColumn5.FieldName = "kind";
            gridViewTextBoxColumn5.HeaderText = "kind";
            gridViewTextBoxColumn5.IsVisible = false;
            gridViewTextBoxColumn5.Name = "kind";
            gridViewTextBoxColumn5.Width = 47;
            this.gridAll.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5});
            this.gridAll.MasterTemplate.ShowRowHeaderColumn = false;
            this.gridAll.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.gridAll.Name = "gridAll";
            this.gridAll.ShowCellErrors = false;
            this.gridAll.ShowGroupPanel = false;
            this.gridAll.ShowGroupPanelScrollbars = false;
            this.gridAll.ShowItemToolTips = false;
            this.gridAll.ShowNoDataText = false;
            this.gridAll.ShowRowErrors = false;
            this.gridAll.Size = new System.Drawing.Size(680, 654);
            this.gridAll.TabIndex = 95;
            this.gridAll.TabStop = false;
            this.gridAll.CellDoubleClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.gridAll_CellDoubleClick);
            // 
            // radTitleBar1
            // 
            this.radTitleBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radTitleBar1.Font = new System.Drawing.Font("IRANSansWeb(FaNum)", 12F);
            this.radTitleBar1.Location = new System.Drawing.Point(0, 0);
            this.radTitleBar1.Name = "radTitleBar1";
            this.radTitleBar1.Size = new System.Drawing.Size(700, 34);
            this.radTitleBar1.TabIndex = 110;
            this.radTitleBar1.TabStop = false;
            this.radTitleBar1.Text = "جدول انتخاب کالا";
            ((Telerik.WinControls.UI.RadTitleBarElement)(this.radTitleBar1.GetChildAt(0))).Text = "جدول انتخاب کالا";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.radTitleBar1.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.radTitleBar1.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(0).GetChildAt(1).GetChildAt(1))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.gridAll);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 34);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(10);
            this.panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.panel2.Size = new System.Drawing.Size(700, 766);
            this.panel2.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txtSearch);
            this.panel3.Controls.Add(this.label42);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(10, 10);
            this.panel3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(680, 46);
            this.panel3.TabIndex = 0;
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtSearch.Font = new System.Drawing.Font("IRANSansWeb(FaNum)", 12F);
            this.txtSearch.Location = new System.Drawing.Point(63, 6);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(2);
            this.txtSearch.MaxLength = 32565;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtSearch.Size = new System.Drawing.Size(476, 34);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // label42
            // 
            this.label42.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label42.AutoSize = true;
            this.label42.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(214)))), ((int)(((byte)(221)))));
            this.label42.Font = new System.Drawing.Font("B Nazanin", 18F);
            this.label42.Location = new System.Drawing.Point(543, 6);
            this.label42.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(74, 35);
            this.label42.TabIndex = 140;
            this.label42.Text = "جستجو:";
            this.label42.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(214)))), ((int)(((byte)(221)))));
            this.ClientSize = new System.Drawing.Size(700, 800);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.radTitleBar1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(700, 800);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(700, 800);
            this.Name = "frmView";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "جدول انتخاب کالا";
            this.Load += new System.EventHandler(this.frmView_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridAll.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridAll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTitleBar1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private Telerik.WinControls.UI.RadButton radButton1;
        private Telerik.WinControls.UI.RadGridView gridAll;
        private Telerik.WinControls.UI.RadTitleBar radTitleBar1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label42;
    }
}