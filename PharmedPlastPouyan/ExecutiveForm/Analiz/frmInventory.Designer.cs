namespace PharmedPlastPouyan
{
    partial class frmInventory
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
            Telerik.WinControls.UI.ConditionalFormattingObject conditionalFormattingObject1 = new Telerik.WinControls.UI.ConditionalFormattingObject();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn8 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn9 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.Data.SortDescriptor sortDescriptor1 = new Telerik.WinControls.Data.SortDescriptor();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInventory));
            this.pnlBack = new System.Windows.Forms.Panel();
            this.panla = new System.Windows.Forms.Panel();
            this.gridAll = new Telerik.WinControls.UI.RadGridView();
            this.pnlWait = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.radWaitingBar1 = new Telerik.WinControls.UI.RadWaitingBar();
            this.rotatingRingsWaitingBarIndicatorElement1 = new Telerik.WinControls.UI.RotatingRingsWaitingBarIndicatorElement();
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.combGhaleb = new System.Windows.Forms.ComboBox();
            this.txtLotEnd = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblProdectName = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lblProdectCode = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtLotStart = new System.Windows.Forms.TextBox();
            this.chkLot = new System.Windows.Forms.CheckBox();
            this.chkMold = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtPRSalon = new System.Windows.Forms.Label();
            this.txtPRControl = new System.Windows.Forms.Label();
            this.txtStoreControl = new System.Windows.Forms.Label();
            this.txtStoreSalon = new System.Windows.Forms.Label();
            this.txtSell = new System.Windows.Forms.Label();
            this.txtWastage = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.radButton1 = new Telerik.WinControls.UI.RadButton();
            this.radTitleBar1 = new Telerik.WinControls.UI.RadTitleBar();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.FetchAllData = new System.ComponentModel.BackgroundWorker();
            this.pnlBack.SuspendLayout();
            this.panla.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridAll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridAll.MasterTemplate)).BeginInit();
            this.gridAll.SuspendLayout();
            this.pnlWait.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radWaitingBar1)).BeginInit();
            this.pnlFilter.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTitleBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBack
            // 
            this.pnlBack.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBack.Controls.Add(this.panla);
            this.pnlBack.Controls.Add(this.panel2);
            this.pnlBack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBack.Location = new System.Drawing.Point(0, 34);
            this.pnlBack.Name = "pnlBack";
            this.pnlBack.Padding = new System.Windows.Forms.Padding(10);
            this.pnlBack.Size = new System.Drawing.Size(1291, 867);
            this.pnlBack.TabIndex = 14;
            // 
            // panla
            // 
            this.panla.Controls.Add(this.gridAll);
            this.panla.Controls.Add(this.pnlFilter);
            this.panla.Controls.Add(this.panel1);
            this.panla.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panla.Location = new System.Drawing.Point(10, 10);
            this.panla.Name = "panla";
            this.panla.Size = new System.Drawing.Size(1269, 802);
            this.panla.TabIndex = 107;
            // 
            // gridAll
            // 
            this.gridAll.AllowDrop = true;
            this.gridAll.AutoSizeRows = true;
            this.gridAll.CausesValidation = false;
            this.gridAll.Controls.Add(this.pnlWait);
            this.gridAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridAll.Font = new System.Drawing.Font("B Nazanin", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.gridAll.Location = new System.Drawing.Point(0, 126);
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
            conditionalFormattingObject1.ApplyToRow = true;
            conditionalFormattingObject1.CellBackColor = System.Drawing.Color.Empty;
            conditionalFormattingObject1.CellForeColor = System.Drawing.Color.Empty;
            conditionalFormattingObject1.ConditionType = Telerik.WinControls.UI.ConditionTypes.NotEqual;
            conditionalFormattingObject1.Name = "NewCondition";
            conditionalFormattingObject1.RowBackColor = System.Drawing.Color.Empty;
            conditionalFormattingObject1.RowFont = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            conditionalFormattingObject1.RowForeColor = System.Drawing.Color.Empty;
            conditionalFormattingObject1.TValue1 = " ";
            gridViewTextBoxColumn1.ConditionalFormattingObjectList.Add(conditionalFormattingObject1);
            gridViewTextBoxColumn1.FieldName = "LotNum";
            gridViewTextBoxColumn1.HeaderText = "LotNum";
            gridViewTextBoxColumn1.Name = "LotNum";
            gridViewTextBoxColumn1.SortOrder = Telerik.WinControls.UI.RadSortOrder.Ascending;
            gridViewTextBoxColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn1.Width = 166;
            gridViewTextBoxColumn2.FieldName = "TemplateNum";
            gridViewTextBoxColumn2.HeaderText = "شماره قالب";
            gridViewTextBoxColumn2.Name = "TemplateNum";
            gridViewTextBoxColumn2.Width = 91;
            gridViewTextBoxColumn3.FieldName = "PRSalon";
            gridViewTextBoxColumn3.HeaderText = "موجودی سالم سالن";
            gridViewTextBoxColumn3.Name = "PRSalon";
            gridViewTextBoxColumn3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn3.Width = 135;
            gridViewTextBoxColumn4.FieldName = "PRControl";
            gridViewTextBoxColumn4.HeaderText = "موجودی تحت کنترل سالن";
            gridViewTextBoxColumn4.Name = "PRControl";
            gridViewTextBoxColumn4.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn4.Width = 180;
            gridViewTextBoxColumn5.FieldName = "StoreSalon";
            gridViewTextBoxColumn5.HeaderText = "موجودی سالم انبار";
            gridViewTextBoxColumn5.Name = "StoreSalon";
            gridViewTextBoxColumn5.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn5.Width = 140;
            gridViewTextBoxColumn6.FieldName = "StoreControl";
            gridViewTextBoxColumn6.HeaderText = "موجودی تحت کنترل انبار";
            gridViewTextBoxColumn6.Name = "StoreControl";
            gridViewTextBoxColumn6.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn6.Width = 190;
            gridViewTextBoxColumn7.FieldName = "DHR";
            gridViewTextBoxColumn7.HeaderText = "ترخیص";
            gridViewTextBoxColumn7.Name = "DHR";
            gridViewTextBoxColumn7.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn7.Width = 139;
            gridViewTextBoxColumn8.FieldName = "Sell";
            gridViewTextBoxColumn8.HeaderText = "فروش";
            gridViewTextBoxColumn8.Name = "Sell";
            gridViewTextBoxColumn8.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn8.Width = 142;
            gridViewTextBoxColumn9.FieldName = "Wastage";
            gridViewTextBoxColumn9.HeaderText = "ضایعات";
            gridViewTextBoxColumn9.Name = "Wastage";
            gridViewTextBoxColumn9.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn9.Width = 93;
            this.gridAll.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7,
            gridViewTextBoxColumn8,
            gridViewTextBoxColumn9});
            this.gridAll.MasterTemplate.ShowRowHeaderColumn = false;
            sortDescriptor1.PropertyName = "LotNum";
            this.gridAll.MasterTemplate.SortDescriptors.AddRange(new Telerik.WinControls.Data.SortDescriptor[] {
            sortDescriptor1});
            this.gridAll.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.gridAll.Name = "gridAll";
            this.gridAll.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.gridAll.ShowItemToolTips = false;
            this.gridAll.Size = new System.Drawing.Size(1269, 633);
            this.gridAll.TabIndex = 95;
            this.gridAll.TabStop = false;
            this.gridAll.CellDoubleClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.gridAll_CellDoubleClick);
            // 
            // pnlWait
            // 
            this.pnlWait.BackColor = System.Drawing.Color.White;
            this.pnlWait.Controls.Add(this.label1);
            this.pnlWait.Controls.Add(this.radWaitingBar1);
            this.pnlWait.Location = new System.Drawing.Point(507, 242);
            this.pnlWait.Name = "pnlWait";
            this.pnlWait.Padding = new System.Windows.Forms.Padding(2);
            this.pnlWait.Size = new System.Drawing.Size(258, 139);
            this.pnlWait.TabIndex = 109;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("IRANSansWeb(FaNum)", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.Location = new System.Drawing.Point(5, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(248, 47);
            this.label1.TabIndex = 1;
            this.label1.Text = "در حال محاسبه موجودی";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // radWaitingBar1
            // 
            this.radWaitingBar1.Location = new System.Drawing.Point(94, 4);
            this.radWaitingBar1.Name = "radWaitingBar1";
            this.radWaitingBar1.Size = new System.Drawing.Size(70, 70);
            this.radWaitingBar1.TabIndex = 0;
            this.radWaitingBar1.Text = "radWaitingBar1";
            this.radWaitingBar1.WaitingIndicators.Add(this.rotatingRingsWaitingBarIndicatorElement1);
            this.radWaitingBar1.WaitingStep = 7;
            this.radWaitingBar1.WaitingStyle = Telerik.WinControls.Enumerations.WaitingBarStyles.RotatingRings;
            ((Telerik.WinControls.UI.RadWaitingBarElement)(this.radWaitingBar1.GetChildAt(0))).WaitingStep = 7;
            ((Telerik.WinControls.UI.WaitingBarContentElement)(this.radWaitingBar1.GetChildAt(0).GetChildAt(0))).WaitingStyle = Telerik.WinControls.Enumerations.WaitingBarStyles.RotatingRings;
            ((Telerik.WinControls.UI.WaitingBarSeparatorElement)(this.radWaitingBar1.GetChildAt(0).GetChildAt(0).GetChildAt(0))).Dash = false;
            // 
            // rotatingRingsWaitingBarIndicatorElement1
            // 
            this.rotatingRingsWaitingBarIndicatorElement1.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.rotatingRingsWaitingBarIndicatorElement1.Name = "rotatingRingsWaitingBarIndicatorElement1";
            this.rotatingRingsWaitingBarIndicatorElement1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.rotatingRingsWaitingBarIndicatorElement1.UseCompatibleTextRendering = false;
            // 
            // pnlFilter
            // 
            this.pnlFilter.Controls.Add(this.combGhaleb);
            this.pnlFilter.Controls.Add(this.txtLotEnd);
            this.pnlFilter.Controls.Add(this.label3);
            this.pnlFilter.Controls.Add(this.lblProdectName);
            this.pnlFilter.Controls.Add(this.label16);
            this.pnlFilter.Controls.Add(this.lblProdectCode);
            this.pnlFilter.Controls.Add(this.label14);
            this.pnlFilter.Controls.Add(this.txtLotStart);
            this.pnlFilter.Controls.Add(this.chkLot);
            this.pnlFilter.Controls.Add(this.chkMold);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Location = new System.Drawing.Point(0, 0);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Padding = new System.Windows.Forms.Padding(10);
            this.pnlFilter.Size = new System.Drawing.Size(1269, 126);
            this.pnlFilter.TabIndex = 93;
            // 
            // combGhaleb
            // 
            this.combGhaleb.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.combGhaleb.DisplayMember = "TemplateNum";
            this.combGhaleb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combGhaleb.Enabled = false;
            this.combGhaleb.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.combGhaleb.FormattingEnabled = true;
            this.combGhaleb.Location = new System.Drawing.Point(951, 70);
            this.combGhaleb.Margin = new System.Windows.Forms.Padding(2);
            this.combGhaleb.Name = "combGhaleb";
            this.combGhaleb.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.combGhaleb.Size = new System.Drawing.Size(82, 33);
            this.combGhaleb.TabIndex = 133;
            this.combGhaleb.ValueMember = "TemplateNum";
            this.combGhaleb.SelectedIndexChanged += new System.EventHandler(this.combGhaleb_SelectedIndexChanged);
            // 
            // txtLotEnd
            // 
            this.txtLotEnd.Enabled = false;
            this.txtLotEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.txtLotEnd.Location = new System.Drawing.Point(595, 69);
            this.txtLotEnd.Margin = new System.Windows.Forms.Padding(2);
            this.txtLotEnd.MaxLength = 5;
            this.txtLotEnd.Name = "txtLotEnd";
            this.txtLotEnd.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtLotEnd.Size = new System.Drawing.Size(112, 35);
            this.txtLotEnd.TabIndex = 132;
            this.txtLotEnd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtLotEnd.TextChanged += new System.EventHandler(this.txtLotEnd_TextChanged);
            this.txtLotEnd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtKeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(224)))), ((int)(((byte)(231)))));
            this.label3.Font = new System.Drawing.Font("B Nazanin", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label3.Location = new System.Drawing.Point(706, 72);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(23, 28);
            this.label3.TabIndex = 131;
            this.label3.Text = "تا:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblProdectName
            // 
            this.lblProdectName.BackColor = System.Drawing.Color.White;
            this.lblProdectName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblProdectName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProdectName.Location = new System.Drawing.Point(12, 10);
            this.lblProdectName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblProdectName.Name = "lblProdectName";
            this.lblProdectName.Size = new System.Drawing.Size(651, 37);
            this.lblProdectName.TabIndex = 126;
            this.lblProdectName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(224)))), ((int)(((byte)(231)))));
            this.label16.Font = new System.Drawing.Font("B Nazanin", 18F);
            this.label16.Location = new System.Drawing.Point(667, 12);
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
            this.lblProdectCode.BackColor = System.Drawing.Color.White;
            this.lblProdectCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblProdectCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProdectCode.Location = new System.Drawing.Point(749, 12);
            this.lblProdectCode.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblProdectCode.Name = "lblProdectCode";
            this.lblProdectCode.Size = new System.Drawing.Size(301, 37);
            this.lblProdectCode.TabIndex = 125;
            this.lblProdectCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(224)))), ((int)(((byte)(231)))));
            this.label14.Font = new System.Drawing.Font("B Nazanin", 18F);
            this.label14.Location = new System.Drawing.Point(1054, 12);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label14.Size = new System.Drawing.Size(78, 35);
            this.label14.TabIndex = 127;
            this.label14.Text = "کد کالا :";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtLotStart
            // 
            this.txtLotStart.Enabled = false;
            this.txtLotStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.txtLotStart.Location = new System.Drawing.Point(731, 69);
            this.txtLotStart.Margin = new System.Windows.Forms.Padding(2);
            this.txtLotStart.MaxLength = 5;
            this.txtLotStart.Name = "txtLotStart";
            this.txtLotStart.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtLotStart.Size = new System.Drawing.Size(112, 35);
            this.txtLotStart.TabIndex = 124;
            this.txtLotStart.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtLotStart.TextChanged += new System.EventHandler(this.txtLotStart_TextChanged);
            this.txtLotStart.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtKeyPress);
            // 
            // chkLot
            // 
            this.chkLot.AutoSize = true;
            this.chkLot.Font = new System.Drawing.Font("B Nazanin", 11.25F, System.Drawing.FontStyle.Bold);
            this.chkLot.Location = new System.Drawing.Point(841, 72);
            this.chkLot.Name = "chkLot";
            this.chkLot.Size = new System.Drawing.Size(98, 28);
            this.chkLot.TabIndex = 122;
            this.chkLot.Text = "شماره لات از:";
            this.chkLot.UseVisualStyleBackColor = true;
            this.chkLot.CheckedChanged += new System.EventHandler(this.chkLot_CheckedChanged);
            // 
            // chkMold
            // 
            this.chkMold.AutoSize = true;
            this.chkMold.Font = new System.Drawing.Font("B Nazanin", 11.25F, System.Drawing.FontStyle.Bold);
            this.chkMold.Location = new System.Drawing.Point(1038, 72);
            this.chkMold.Name = "chkMold";
            this.chkMold.Size = new System.Drawing.Size(88, 28);
            this.chkMold.TabIndex = 120;
            this.chkMold.Text = "شماره قالب";
            this.chkMold.UseVisualStyleBackColor = true;
            this.chkMold.CheckedChanged += new System.EventHandler(this.chkMold_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtPRSalon);
            this.panel1.Controls.Add(this.txtPRControl);
            this.panel1.Controls.Add(this.txtStoreControl);
            this.panel1.Controls.Add(this.txtStoreSalon);
            this.panel1.Controls.Add(this.txtSell);
            this.panel1.Controls.Add(this.txtWastage);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 759);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1269, 43);
            this.panel1.TabIndex = 92;
            // 
            // txtPRSalon
            // 
            this.txtPRSalon.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtPRSalon.BackColor = System.Drawing.Color.White;
            this.txtPRSalon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPRSalon.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPRSalon.Location = new System.Drawing.Point(359, 3);
            this.txtPRSalon.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.txtPRSalon.Name = "txtPRSalon";
            this.txtPRSalon.Size = new System.Drawing.Size(141, 37);
            this.txtPRSalon.TabIndex = 131;
            this.txtPRSalon.Text = "0";
            this.txtPRSalon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtPRControl
            // 
            this.txtPRControl.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtPRControl.BackColor = System.Drawing.Color.White;
            this.txtPRControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPRControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPRControl.Location = new System.Drawing.Point(510, 3);
            this.txtPRControl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.txtPRControl.Name = "txtPRControl";
            this.txtPRControl.Size = new System.Drawing.Size(141, 37);
            this.txtPRControl.TabIndex = 130;
            this.txtPRControl.Text = "0";
            this.txtPRControl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtStoreControl
            // 
            this.txtStoreControl.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtStoreControl.BackColor = System.Drawing.Color.White;
            this.txtStoreControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtStoreControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStoreControl.Location = new System.Drawing.Point(812, 3);
            this.txtStoreControl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.txtStoreControl.Name = "txtStoreControl";
            this.txtStoreControl.Size = new System.Drawing.Size(141, 37);
            this.txtStoreControl.TabIndex = 131;
            this.txtStoreControl.Text = "0";
            this.txtStoreControl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtStoreSalon
            // 
            this.txtStoreSalon.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtStoreSalon.BackColor = System.Drawing.Color.White;
            this.txtStoreSalon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtStoreSalon.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStoreSalon.Location = new System.Drawing.Point(661, 3);
            this.txtStoreSalon.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.txtStoreSalon.Name = "txtStoreSalon";
            this.txtStoreSalon.Size = new System.Drawing.Size(141, 37);
            this.txtStoreSalon.TabIndex = 129;
            this.txtStoreSalon.Text = "0";
            this.txtStoreSalon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtSell
            // 
            this.txtSell.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtSell.BackColor = System.Drawing.Color.White;
            this.txtSell.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSell.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSell.Location = new System.Drawing.Point(963, 3);
            this.txtSell.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.txtSell.Name = "txtSell";
            this.txtSell.Size = new System.Drawing.Size(141, 37);
            this.txtSell.TabIndex = 130;
            this.txtSell.Text = "0";
            this.txtSell.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtWastage
            // 
            this.txtWastage.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtWastage.BackColor = System.Drawing.Color.White;
            this.txtWastage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtWastage.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWastage.Location = new System.Drawing.Point(1114, 3);
            this.txtWastage.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.txtWastage.Name = "txtWastage";
            this.txtWastage.Size = new System.Drawing.Size(141, 37);
            this.txtWastage.TabIndex = 129;
            this.txtWastage.Text = "0";
            this.txtWastage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.radButton1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(10, 812);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1269, 43);
            this.panel2.TabIndex = 108;
            // 
            // radButton1
            // 
            this.radButton1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.radButton1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.radButton1.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.radButton1.Location = new System.Drawing.Point(576, 8);
            this.radButton1.Margin = new System.Windows.Forms.Padding(2);
            this.radButton1.Name = "radButton1";
            this.radButton1.Size = new System.Drawing.Size(117, 27);
            this.radButton1.TabIndex = 92;
            this.radButton1.TabStop = false;
            this.radButton1.Text = "خروج";
            // 
            // radTitleBar1
            // 
            this.radTitleBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radTitleBar1.Font = new System.Drawing.Font("IRANSansWeb(FaNum)", 12F);
            this.radTitleBar1.Location = new System.Drawing.Point(0, 0);
            this.radTitleBar1.Name = "radTitleBar1";
            this.radTitleBar1.Size = new System.Drawing.Size(1291, 34);
            this.radTitleBar1.TabIndex = 13;
            this.radTitleBar1.TabStop = false;
            this.radTitleBar1.Text = "موجودی سالن";
            ((Telerik.WinControls.UI.RadTitleBarElement)(this.radTitleBar1.GetChildAt(0))).Text = "موجودی سالن";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.radTitleBar1.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.radTitleBar1.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(0).GetChildAt(1).GetChildAt(1))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // FetchAllData
            // 
            this.FetchAllData.DoWork += new System.ComponentModel.DoWorkEventHandler(this.FetchAllData_DoWork);
            this.FetchAllData.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.FetchAllData_RunWorkerCompleted);
            // 
            // frmInventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(224)))), ((int)(((byte)(231)))));
            this.CancelButton = this.radButton1;
            this.ClientSize = new System.Drawing.Size(1291, 901);
            this.Controls.Add(this.pnlBack);
            this.Controls.Add(this.radTitleBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmInventory";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "موجودی سالن";
            this.Load += new System.EventHandler(this.frmInventory_Load);
            this.pnlBack.ResumeLayout(false);
            this.panla.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridAll.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridAll)).EndInit();
            this.gridAll.ResumeLayout(false);
            this.gridAll.PerformLayout();
            this.pnlWait.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radWaitingBar1)).EndInit();
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTitleBar1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlBack;
        private System.Windows.Forms.Panel panla;
        private Telerik.WinControls.UI.RadTitleBar radTitleBar1;
        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox chkMold;
        private System.Windows.Forms.CheckBox chkLot;
        private System.Windows.Forms.TextBox txtLotStart;
        private System.Windows.Forms.Label lblProdectName;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lblProdectCode;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label txtWastage;
        private System.Windows.Forms.TextBox txtLotEnd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private Telerik.WinControls.UI.RadButton radButton1;
        private System.Windows.Forms.Label txtStoreControl;
        private System.Windows.Forms.Label txtSell;
        private System.Windows.Forms.Panel pnlWait;
        private System.Windows.Forms.Label label1;
        private Telerik.WinControls.UI.RadWaitingBar radWaitingBar1;
        private Telerik.WinControls.UI.RotatingRingsWaitingBarIndicatorElement rotatingRingsWaitingBarIndicatorElement1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.ComponentModel.BackgroundWorker FetchAllData;
        private System.Windows.Forms.ComboBox combGhaleb;
        private Telerik.WinControls.UI.RadGridView gridAll;
        private System.Windows.Forms.Label txtPRSalon;
        private System.Windows.Forms.Label txtPRControl;
        private System.Windows.Forms.Label txtStoreSalon;
    }
}