namespace PSC_ERPNew
{
    partial class FormTest
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.functionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colFunctionID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFunctionName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNamespaceAndClassName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLocalIdx = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlobalIdx = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colImage = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colShowDialog = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStartPosition = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWindowsState = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsMdiChild = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsMdiContainer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPublicStaticSingletonProperty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPublicInitInstanceMethod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPublicStaticMethod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTest1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMenus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.menuBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.functionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.menuBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1});
            this.gridView2.GridControl = this.gridControl1;
            this.gridView2.Name = "gridView2";
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "gridColumn1";
            this.gridColumn1.CustomizationCaption = "Tên";
            this.gridColumn1.FieldName = "Title";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.functionBindingSource;
            gridLevelNode1.LevelTemplate = this.gridView2;
            gridLevelNode1.RelationName = "Menus";
            this.gridControl1.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.gridControl1.Location = new System.Drawing.Point(51, 28);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(724, 278);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1,
            this.gridView2});
            // 
            // functionBindingSource
            // 
            this.functionBindingSource.DataSource = typeof(PSC_ERP_Business.Main.Model.AppFunction);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colFunctionID,
            this.colFunctionName,
            this.colNamespaceAndClassName,
            this.colDescription,
            this.colLocalIdx,
            this.colGlobalIdx,
            this.colType,
            this.colImage,
            this.colShowDialog,
            this.colStartPosition,
            this.colWindowsState,
            this.colIsMdiChild,
            this.colIsMdiContainer,
            this.colPublicStaticSingletonProperty,
            this.colPublicInitInstanceMethod,
            this.colPublicStaticMethod,
            this.colTest1,
            this.colMenus});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            // 
            // colFunctionID
            // 
            this.colFunctionID.FieldName = "FunctionID";
            this.colFunctionID.Name = "colFunctionID";
            this.colFunctionID.Visible = true;
            this.colFunctionID.VisibleIndex = 0;
            // 
            // colFunctionName
            // 
            this.colFunctionName.FieldName = "FunctionName";
            this.colFunctionName.Name = "colFunctionName";
            this.colFunctionName.Visible = true;
            this.colFunctionName.VisibleIndex = 1;
            // 
            // colNamespaceAndClassName
            // 
            this.colNamespaceAndClassName.FieldName = "NamespaceAndClassName";
            this.colNamespaceAndClassName.Name = "colNamespaceAndClassName";
            this.colNamespaceAndClassName.Visible = true;
            this.colNamespaceAndClassName.VisibleIndex = 2;
            // 
            // colDescription
            // 
            this.colDescription.FieldName = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 3;
            // 
            // colLocalIdx
            // 
            this.colLocalIdx.FieldName = "LocalIdx";
            this.colLocalIdx.Name = "colLocalIdx";
            this.colLocalIdx.Visible = true;
            this.colLocalIdx.VisibleIndex = 4;
            // 
            // colGlobalIdx
            // 
            this.colGlobalIdx.FieldName = "GlobalIdx";
            this.colGlobalIdx.Name = "colGlobalIdx";
            this.colGlobalIdx.Visible = true;
            this.colGlobalIdx.VisibleIndex = 5;
            // 
            // colType
            // 
            this.colType.FieldName = "Type";
            this.colType.Name = "colType";
            this.colType.Visible = true;
            this.colType.VisibleIndex = 6;
            // 
            // colImage
            // 
            this.colImage.FieldName = "Image";
            this.colImage.Name = "colImage";
            this.colImage.Visible = true;
            this.colImage.VisibleIndex = 7;
            // 
            // colShowDialog
            // 
            this.colShowDialog.FieldName = "ShowDialog";
            this.colShowDialog.Name = "colShowDialog";
            this.colShowDialog.Visible = true;
            this.colShowDialog.VisibleIndex = 8;
            // 
            // colStartPosition
            // 
            this.colStartPosition.FieldName = "StartPosition";
            this.colStartPosition.Name = "colStartPosition";
            this.colStartPosition.Visible = true;
            this.colStartPosition.VisibleIndex = 9;
            // 
            // colWindowsState
            // 
            this.colWindowsState.FieldName = "WindowsState";
            this.colWindowsState.Name = "colWindowsState";
            this.colWindowsState.Visible = true;
            this.colWindowsState.VisibleIndex = 10;
            // 
            // colIsMdiChild
            // 
            this.colIsMdiChild.FieldName = "IsMdiChild";
            this.colIsMdiChild.Name = "colIsMdiChild";
            this.colIsMdiChild.Visible = true;
            this.colIsMdiChild.VisibleIndex = 11;
            // 
            // colIsMdiContainer
            // 
            this.colIsMdiContainer.FieldName = "IsMdiContainer";
            this.colIsMdiContainer.Name = "colIsMdiContainer";
            this.colIsMdiContainer.Visible = true;
            this.colIsMdiContainer.VisibleIndex = 12;
            // 
            // colPublicStaticSingletonProperty
            // 
            this.colPublicStaticSingletonProperty.FieldName = "PublicStaticSingletonProperty";
            this.colPublicStaticSingletonProperty.Name = "colPublicStaticSingletonProperty";
            this.colPublicStaticSingletonProperty.Visible = true;
            this.colPublicStaticSingletonProperty.VisibleIndex = 13;
            // 
            // colPublicInitInstanceMethod
            // 
            this.colPublicInitInstanceMethod.FieldName = "PublicInitInstanceMethod";
            this.colPublicInitInstanceMethod.Name = "colPublicInitInstanceMethod";
            this.colPublicInitInstanceMethod.Visible = true;
            this.colPublicInitInstanceMethod.VisibleIndex = 14;
            // 
            // colPublicStaticMethod
            // 
            this.colPublicStaticMethod.FieldName = "PublicStaticMethod";
            this.colPublicStaticMethod.Name = "colPublicStaticMethod";
            this.colPublicStaticMethod.Visible = true;
            this.colPublicStaticMethod.VisibleIndex = 15;
            // 
            // colTest1
            // 
            this.colTest1.FieldName = "Test1";
            this.colTest1.Name = "colTest1";
            this.colTest1.Visible = true;
            this.colTest1.VisibleIndex = 16;
            // 
            // colMenus
            // 
            this.colMenus.FieldName = "Menus";
            this.colMenus.Name = "colMenus";
            this.colMenus.Visible = true;
            this.colMenus.VisibleIndex = 17;
            // 
            // menuBindingSource
            // 
            this.menuBindingSource.DataSource = typeof(PSC_ERP_Business.Main.Model.AppMenu);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(254, 323);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(393, 322);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 23);
            this.btnXoa.TabIndex = 2;
            this.btnXoa.Text = "Xoa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // FormTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(876, 569);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.gridControl1);
            this.Name = "FormTest";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.functionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.menuBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.BindingSource functionBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colFunctionID;
        private DevExpress.XtraGrid.Columns.GridColumn colFunctionName;
        private DevExpress.XtraGrid.Columns.GridColumn colNamespaceAndClassName;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colLocalIdx;
        private DevExpress.XtraGrid.Columns.GridColumn colGlobalIdx;
        private DevExpress.XtraGrid.Columns.GridColumn colType;
        private DevExpress.XtraGrid.Columns.GridColumn colImage;
        private DevExpress.XtraGrid.Columns.GridColumn colShowDialog;
        private DevExpress.XtraGrid.Columns.GridColumn colStartPosition;
        private DevExpress.XtraGrid.Columns.GridColumn colWindowsState;
        private DevExpress.XtraGrid.Columns.GridColumn colIsMdiChild;
        private DevExpress.XtraGrid.Columns.GridColumn colIsMdiContainer;
        private DevExpress.XtraGrid.Columns.GridColumn colPublicStaticSingletonProperty;
        private DevExpress.XtraGrid.Columns.GridColumn colPublicInitInstanceMethod;
        private DevExpress.XtraGrid.Columns.GridColumn colPublicStaticMethod;
        private DevExpress.XtraGrid.Columns.GridColumn colTest1;
        private DevExpress.XtraGrid.Columns.GridColumn colMenus;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private System.Windows.Forms.BindingSource menuBindingSource;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnXoa;
    }
}

