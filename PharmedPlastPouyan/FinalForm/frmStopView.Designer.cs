namespace PharmedPlastPouyan
{
    partial class frmStopView
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
            Telerik.WinControls.UI.ConditionalFormattingObject conditionalFormattingObject1 = new Telerik.WinControls.UI.ConditionalFormattingObject();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStopView));
            this.radTitleBar1 = new Telerik.WinControls.UI.RadTitleBar();
            this.label4 = new System.Windows.Forms.Label();
            this.comType = new System.Windows.Forms.ComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnExit = new Telerik.WinControls.UI.RadButton();
            this.gridAll = new Telerik.WinControls.UI.RadGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pnlBack = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.radTitleBar1)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridAll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridAll.MasterTemplate)).BeginInit();
            this.panel2.SuspendLayout();
            this.pnlBack.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // radTitleBar1
            // 
            this.radTitleBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radTitleBar1.Font = new System.Drawing.Font("IRANSansWeb(FaNum)", 12F);
            this.radTitleBar1.Location = new System.Drawing.Point(0, 0);
            this.radTitleBar1.Name = "radTitleBar1";
            this.radTitleBar1.Size = new System.Drawing.Size(520, 34);
            this.radTitleBar1.TabIndex = 7;
            this.radTitleBar1.TabStop = false;
            this.radTitleBar1.Text = "نمایش کد های توقف";
            ((Telerik.WinControls.UI.RadTitleBarElement)(this.radTitleBar1.GetChildAt(0))).Text = "نمایش کد های توقف";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.radTitleBar1.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.radTitleBar1.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(0).GetChildAt(1).GetChildAt(1))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label4.Location = new System.Drawing.Point(294, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 24);
            this.label4.TabIndex = 95;
            this.label4.Text = "انتخاب نوع توقف";
            // 
            // comType
            // 
            this.comType.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.comType.BackColor = System.Drawing.SystemColors.Window;
            this.comType.DisplayMember = "Title";
            this.comType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comType.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.comType.FormattingEnabled = true;
            this.comType.Items.AddRange(new object[] {
            "1- روتین",
            "2- آزمایشی",
            "3- راه اندازی"});
            this.comType.Location = new System.Drawing.Point(132, 5);
            this.comType.Margin = new System.Windows.Forms.Padding(2);
            this.comType.MaxDropDownItems = 2;
            this.comType.Name = "comType";
            this.comType.Size = new System.Drawing.Size(159, 32);
            this.comType.TabIndex = 94;
            this.comType.ValueMember = "StopID";
            this.comType.SelectedIndexChanged += new System.EventHandler(this.comType_SelectedIndexChanged);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.comType);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(10, 10);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(498, 43);
            this.panel3.TabIndex = 95;
            // 
            // btnExit
            // 
            this.btnExit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnExit.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnExit.Location = new System.Drawing.Point(201, 8);
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
            this.gridAll.Font = new System.Drawing.Font("B Nazanin", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.gridAll.Location = new System.Drawing.Point(0, 0);
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
            gridViewTextBoxColumn2.FieldName = "Title";
            gridViewTextBoxColumn2.HeaderText = "نوع توقف";
            gridViewTextBoxColumn2.Name = "Title";
            gridViewTextBoxColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            gridViewTextBoxColumn2.Width = 362;
            conditionalFormattingObject1.CellBackColor = System.Drawing.Color.Empty;
            conditionalFormattingObject1.CellFont = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            conditionalFormattingObject1.CellForeColor = System.Drawing.Color.Empty;
            conditionalFormattingObject1.ConditionType = Telerik.WinControls.UI.ConditionTypes.NotEqual;
            conditionalFormattingObject1.Name = "NewCondition";
            conditionalFormattingObject1.RowBackColor = System.Drawing.Color.Empty;
            conditionalFormattingObject1.RowForeColor = System.Drawing.Color.Empty;
            conditionalFormattingObject1.TValue1 = " ";
            gridViewTextBoxColumn3.ConditionalFormattingObjectList.Add(conditionalFormattingObject1);
            gridViewTextBoxColumn3.Expression = "";
            gridViewTextBoxColumn3.FieldName = "StopID";
            gridViewTextBoxColumn3.HeaderText = "کد توقف";
            gridViewTextBoxColumn3.Name = "StopID";
            gridViewTextBoxColumn3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn3.Width = 136;
            gridViewTextBoxColumn4.FieldName = "Tartib";
            gridViewTextBoxColumn4.HeaderText = "Tartib";
            gridViewTextBoxColumn4.IsVisible = false;
            gridViewTextBoxColumn4.Name = "Tartib";
            gridViewTextBoxColumn4.Width = 357;
            gridViewTextBoxColumn5.FieldName = "ParrentID";
            gridViewTextBoxColumn5.HeaderText = "ParrentID";
            gridViewTextBoxColumn5.IsVisible = false;
            gridViewTextBoxColumn5.Name = "ParrentID";
            gridViewTextBoxColumn5.Width = 46;
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
            this.gridAll.Size = new System.Drawing.Size(498, 473);
            this.gridAll.TabIndex = 91;
            this.gridAll.TabStop = false;
            this.gridAll.CellDoubleClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.gridAll_CellDoubleClick);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.gridAll);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(10, 53);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(498, 473);
            this.panel2.TabIndex = 93;
            // 
            // pnlBack
            // 
            this.pnlBack.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBack.Controls.Add(this.panel2);
            this.pnlBack.Controls.Add(this.panel1);
            this.pnlBack.Controls.Add(this.panel3);
            this.pnlBack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBack.Location = new System.Drawing.Point(0, 34);
            this.pnlBack.Name = "pnlBack";
            this.pnlBack.Padding = new System.Windows.Forms.Padding(10);
            this.pnlBack.Size = new System.Drawing.Size(520, 581);
            this.pnlBack.TabIndex = 8;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(10, 526);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(498, 43);
            this.panel1.TabIndex = 91;
            // 
            // frmStopView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(224)))), ((int)(((byte)(231)))));
            this.ClientSize = new System.Drawing.Size(520, 615);
            this.Controls.Add(this.pnlBack);
            this.Controls.Add(this.radTitleBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmStopView";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "نمایش کد های توقف";
            ((System.ComponentModel.ISupportInitialize)(this.radTitleBar1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridAll.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridAll)).EndInit();
            this.panel2.ResumeLayout(false);
            this.pnlBack.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadTitleBar radTitleBar1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comType;
        private System.Windows.Forms.Panel panel3;
        private Telerik.WinControls.UI.RadButton btnExit;
        private Telerik.WinControls.UI.RadGridView gridAll;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel pnlBack;
        private System.Windows.Forms.Panel panel1;
    }
}