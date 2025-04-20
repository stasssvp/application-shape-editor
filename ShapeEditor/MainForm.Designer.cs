namespace GraphicShapesCoursework
{
    partial class MainForm
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
            this.comboBoxShapes = new System.Windows.Forms.ComboBox();
            this.btnAddShape = new System.Windows.Forms.Button();
            this.btnUndo = new System.Windows.Forms.Button();
            this.btnRedo = new System.Windows.Forms.Button();
            this.btnChangeFillColor = new System.Windows.Forms.Button();
            this.btnChangleOutlineColor = new System.Windows.Forms.Button();
            this.btnDeleteShape = new System.Windows.Forms.Button();
            this.btnCalculateArea = new System.Windows.Forms.Button();
            this.lblParameters = new System.Windows.Forms.Label();
            this.txtRadius = new System.Windows.Forms.TextBox();
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.txtWidth = new System.Windows.Forms.TextBox();
            this.lblRadius = new System.Windows.Forms.Label();
            this.lblWidth = new System.Windows.Forms.Label();
            this.lblHeight = new System.Windows.Forms.Label();
            this.txtSideLength = new System.Windows.Forms.TextBox();
            this.lblSideLength = new System.Windows.Forms.Label();
            this.lblSideAB = new System.Windows.Forms.Label();
            this.lblSideBC = new System.Windows.Forms.Label();
            this.lblSideAC = new System.Windows.Forms.Label();
            this.txtSideAB = new System.Windows.Forms.TextBox();
            this.txtSideBC = new System.Windows.Forms.TextBox();
            this.txtSideAC = new System.Windows.Forms.TextBox();
            this.btnUpdateDimensions = new System.Windows.Forms.Button();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.txtRadiusY = new System.Windows.Forms.TextBox();
            this.lblRadiusY = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.cmbOperations = new System.Windows.Forms.ComboBox();
            this.lblResult = new System.Windows.Forms.Label();
            this.lblShapeCriteria = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxShapes
            // 
            this.comboBoxShapes.BackColor = System.Drawing.Color.White;
            this.comboBoxShapes.CausesValidation = false;
            this.comboBoxShapes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboBoxShapes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxShapes.Font = new System.Drawing.Font("Segoe UI", 13.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxShapes.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.comboBoxShapes.FormattingEnabled = true;
            this.comboBoxShapes.ItemHeight = 47;
            this.comboBoxShapes.Items.AddRange(new object[] {
            "Circle",
            "Rectangle",
            "Square",
            "Triangle",
            "Ellipse"});
            this.comboBoxShapes.Location = new System.Drawing.Point(38, 48);
            this.comboBoxShapes.Margin = new System.Windows.Forms.Padding(10);
            this.comboBoxShapes.Name = "comboBoxShapes";
            this.comboBoxShapes.Size = new System.Drawing.Size(223, 55);
            this.comboBoxShapes.TabIndex = 0;
            // 
            // btnAddShape
            // 
            this.btnAddShape.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddShape.Font = new System.Drawing.Font("Segoe UI", 13.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddShape.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnAddShape.Location = new System.Drawing.Point(38, 119);
            this.btnAddShape.Margin = new System.Windows.Forms.Padding(10);
            this.btnAddShape.Name = "btnAddShape";
            this.btnAddShape.Padding = new System.Windows.Forms.Padding(3);
            this.btnAddShape.Size = new System.Drawing.Size(223, 74);
            this.btnAddShape.TabIndex = 1;
            this.btnAddShape.Text = "Add shape";
            this.btnAddShape.UseVisualStyleBackColor = true;
            this.btnAddShape.Click += new System.EventHandler(this.btnAddShape_Click);
            // 
            // btnUndo
            // 
            this.btnUndo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUndo.Font = new System.Drawing.Font("Segoe UI", 13.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUndo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnUndo.Location = new System.Drawing.Point(38, 211);
            this.btnUndo.Margin = new System.Windows.Forms.Padding(10);
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Padding = new System.Windows.Forms.Padding(3);
            this.btnUndo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnUndo.Size = new System.Drawing.Size(102, 66);
            this.btnUndo.TabIndex = 2;
            this.btnUndo.Text = "↩\r\n\r\n";
            this.btnUndo.UseVisualStyleBackColor = true;
            this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);
            // 
            // btnRedo
            // 
            this.btnRedo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRedo.Font = new System.Drawing.Font("Segoe UI", 13.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRedo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnRedo.Location = new System.Drawing.Point(159, 211);
            this.btnRedo.Margin = new System.Windows.Forms.Padding(10);
            this.btnRedo.Name = "btnRedo";
            this.btnRedo.Padding = new System.Windows.Forms.Padding(3);
            this.btnRedo.Size = new System.Drawing.Size(102, 66);
            this.btnRedo.TabIndex = 3;
            this.btnRedo.Text = "↪";
            this.btnRedo.UseVisualStyleBackColor = true;
            this.btnRedo.Click += new System.EventHandler(this.btnRedo_Click);
            // 
            // btnChangeFillColor
            // 
            this.btnChangeFillColor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChangeFillColor.Font = new System.Drawing.Font("Segoe UI", 13.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChangeFillColor.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnChangeFillColor.Location = new System.Drawing.Point(38, 525);
            this.btnChangeFillColor.Margin = new System.Windows.Forms.Padding(10);
            this.btnChangeFillColor.Name = "btnChangeFillColor";
            this.btnChangeFillColor.Padding = new System.Windows.Forms.Padding(3);
            this.btnChangeFillColor.Size = new System.Drawing.Size(223, 74);
            this.btnChangeFillColor.TabIndex = 4;
            this.btnChangeFillColor.Text = "Fill Color";
            this.btnChangeFillColor.UseVisualStyleBackColor = true;
            this.btnChangeFillColor.Click += new System.EventHandler(this.btnChangeFillColor_Click);
            // 
            // btnChangleOutlineColor
            // 
            this.btnChangleOutlineColor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChangleOutlineColor.Font = new System.Drawing.Font("Segoe UI", 13.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChangleOutlineColor.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnChangleOutlineColor.Location = new System.Drawing.Point(38, 435);
            this.btnChangleOutlineColor.Margin = new System.Windows.Forms.Padding(10);
            this.btnChangleOutlineColor.Name = "btnChangleOutlineColor";
            this.btnChangleOutlineColor.Padding = new System.Windows.Forms.Padding(3);
            this.btnChangleOutlineColor.Size = new System.Drawing.Size(223, 74);
            this.btnChangleOutlineColor.TabIndex = 5;
            this.btnChangleOutlineColor.Text = "Outline Color";
            this.btnChangleOutlineColor.UseVisualStyleBackColor = true;
            this.btnChangleOutlineColor.Click += new System.EventHandler(this.btnChangleOutlineColor_Click);
            // 
            // btnDeleteShape
            // 
            this.btnDeleteShape.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeleteShape.Font = new System.Drawing.Font("Segoe UI", 13.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteShape.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnDeleteShape.Location = new System.Drawing.Point(349, 230);
            this.btnDeleteShape.Margin = new System.Windows.Forms.Padding(10);
            this.btnDeleteShape.Name = "btnDeleteShape";
            this.btnDeleteShape.Padding = new System.Windows.Forms.Padding(3);
            this.btnDeleteShape.Size = new System.Drawing.Size(223, 74);
            this.btnDeleteShape.TabIndex = 6;
            this.btnDeleteShape.Text = "Delete";
            this.btnDeleteShape.UseVisualStyleBackColor = true;
            this.btnDeleteShape.Click += new System.EventHandler(this.btnDeleteShape_Click);
            // 
            // btnCalculateArea
            // 
            this.btnCalculateArea.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCalculateArea.Font = new System.Drawing.Font("Segoe UI", 13.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCalculateArea.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnCalculateArea.Location = new System.Drawing.Point(349, 48);
            this.btnCalculateArea.Margin = new System.Windows.Forms.Padding(10);
            this.btnCalculateArea.Name = "btnCalculateArea";
            this.btnCalculateArea.Padding = new System.Windows.Forms.Padding(3);
            this.btnCalculateArea.Size = new System.Drawing.Size(223, 74);
            this.btnCalculateArea.TabIndex = 7;
            this.btnCalculateArea.Text = "Calculate";
            this.btnCalculateArea.UseVisualStyleBackColor = true;
            this.btnCalculateArea.Click += new System.EventHandler(this.btnCalculateArea_Click);
            // 
            // lblParameters
            // 
            this.lblParameters.AutoSize = true;
            this.lblParameters.BackColor = System.Drawing.Color.Transparent;
            this.lblParameters.Font = new System.Drawing.Font("Segoe UI Semibold", 13.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblParameters.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblParameters.Location = new System.Drawing.Point(643, 51);
            this.lblParameters.Name = "lblParameters";
            this.lblParameters.Size = new System.Drawing.Size(305, 47);
            this.lblParameters.TabIndex = 15;
            this.lblParameters.Text = "Shape Parameters";
            // 
            // txtRadius
            // 
            this.txtRadius.BackColor = System.Drawing.Color.White;
            this.txtRadius.Font = new System.Drawing.Font("Segoe UI", 13.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRadius.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtRadius.Location = new System.Drawing.Point(875, 119);
            this.txtRadius.Name = "txtRadius";
            this.txtRadius.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtRadius.Size = new System.Drawing.Size(111, 54);
            this.txtRadius.TabIndex = 10;
            // 
            // txtHeight
            // 
            this.txtHeight.BackColor = System.Drawing.Color.White;
            this.txtHeight.Font = new System.Drawing.Font("Segoe UI", 13.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHeight.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtHeight.Location = new System.Drawing.Point(875, 184);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtHeight.Size = new System.Drawing.Size(111, 54);
            this.txtHeight.TabIndex = 9;
            // 
            // txtWidth
            // 
            this.txtWidth.BackColor = System.Drawing.Color.White;
            this.txtWidth.Font = new System.Drawing.Font("Segoe UI", 13.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWidth.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtWidth.Location = new System.Drawing.Point(875, 118);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtWidth.Size = new System.Drawing.Size(111, 54);
            this.txtWidth.TabIndex = 8;
            // 
            // lblRadius
            // 
            this.lblRadius.AutoSize = true;
            this.lblRadius.BackColor = System.Drawing.Color.Transparent;
            this.lblRadius.Font = new System.Drawing.Font("Segoe UI", 13.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRadius.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblRadius.Location = new System.Drawing.Point(647, 120);
            this.lblRadius.Name = "lblRadius";
            this.lblRadius.Size = new System.Drawing.Size(131, 47);
            this.lblRadius.TabIndex = 12;
            this.lblRadius.Text = "Radius:";
            // 
            // lblWidth
            // 
            this.lblWidth.AutoSize = true;
            this.lblWidth.BackColor = System.Drawing.Color.Transparent;
            this.lblWidth.Font = new System.Drawing.Font("Segoe UI", 13.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWidth.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblWidth.Location = new System.Drawing.Point(647, 125);
            this.lblWidth.Name = "lblWidth";
            this.lblWidth.Size = new System.Drawing.Size(122, 47);
            this.lblWidth.TabIndex = 11;
            this.lblWidth.Text = "Width:";
            // 
            // lblHeight
            // 
            this.lblHeight.AutoSize = true;
            this.lblHeight.BackColor = System.Drawing.Color.Transparent;
            this.lblHeight.Font = new System.Drawing.Font("Segoe UI", 13.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeight.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblHeight.Location = new System.Drawing.Point(648, 186);
            this.lblHeight.Name = "lblHeight";
            this.lblHeight.Size = new System.Drawing.Size(135, 47);
            this.lblHeight.TabIndex = 13;
            this.lblHeight.Text = "Length:";
            // 
            // txtSideLength
            // 
            this.txtSideLength.BackColor = System.Drawing.Color.White;
            this.txtSideLength.Font = new System.Drawing.Font("Segoe UI", 13.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSideLength.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtSideLength.Location = new System.Drawing.Point(875, 119);
            this.txtSideLength.Name = "txtSideLength";
            this.txtSideLength.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtSideLength.Size = new System.Drawing.Size(111, 54);
            this.txtSideLength.TabIndex = 14;
            // 
            // lblSideLength
            // 
            this.lblSideLength.AutoSize = true;
            this.lblSideLength.BackColor = System.Drawing.Color.Transparent;
            this.lblSideLength.Font = new System.Drawing.Font("Segoe UI", 13.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSideLength.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblSideLength.Location = new System.Drawing.Point(648, 118);
            this.lblSideLength.Name = "lblSideLength";
            this.lblSideLength.Size = new System.Drawing.Size(211, 47);
            this.lblSideLength.TabIndex = 15;
            this.lblSideLength.Text = "Side Length:";
            // 
            // lblSideAB
            // 
            this.lblSideAB.AutoSize = true;
            this.lblSideAB.BackColor = System.Drawing.Color.Transparent;
            this.lblSideAB.Font = new System.Drawing.Font("Segoe UI", 13.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSideAB.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblSideAB.Location = new System.Drawing.Point(649, 119);
            this.lblSideAB.Name = "lblSideAB";
            this.lblSideAB.Size = new System.Drawing.Size(188, 47);
            this.lblSideAB.TabIndex = 16;
            this.lblSideAB.Text = "Length AB:";
            // 
            // lblSideBC
            // 
            this.lblSideBC.AutoSize = true;
            this.lblSideBC.BackColor = System.Drawing.Color.Transparent;
            this.lblSideBC.Font = new System.Drawing.Font("Segoe UI", 13.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSideBC.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblSideBC.Location = new System.Drawing.Point(648, 186);
            this.lblSideBC.Name = "lblSideBC";
            this.lblSideBC.Size = new System.Drawing.Size(187, 47);
            this.lblSideBC.TabIndex = 17;
            this.lblSideBC.Text = "Length BC:";
            // 
            // lblSideAC
            // 
            this.lblSideAC.AutoSize = true;
            this.lblSideAC.BackColor = System.Drawing.Color.Transparent;
            this.lblSideAC.Font = new System.Drawing.Font("Segoe UI", 13.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSideAC.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblSideAC.Location = new System.Drawing.Point(648, 254);
            this.lblSideAC.Name = "lblSideAC";
            this.lblSideAC.Size = new System.Drawing.Size(190, 47);
            this.lblSideAC.TabIndex = 18;
            this.lblSideAC.Text = "Length CA:";
            // 
            // txtSideAB
            // 
            this.txtSideAB.BackColor = System.Drawing.Color.White;
            this.txtSideAB.Font = new System.Drawing.Font("Segoe UI", 13.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSideAB.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtSideAB.Location = new System.Drawing.Point(875, 119);
            this.txtSideAB.Name = "txtSideAB";
            this.txtSideAB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtSideAB.Size = new System.Drawing.Size(111, 54);
            this.txtSideAB.TabIndex = 19;
            // 
            // txtSideBC
            // 
            this.txtSideBC.BackColor = System.Drawing.Color.White;
            this.txtSideBC.Font = new System.Drawing.Font("Segoe UI", 13.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSideBC.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtSideBC.Location = new System.Drawing.Point(875, 184);
            this.txtSideBC.Name = "txtSideBC";
            this.txtSideBC.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtSideBC.Size = new System.Drawing.Size(111, 54);
            this.txtSideBC.TabIndex = 20;
            // 
            // txtSideAC
            // 
            this.txtSideAC.BackColor = System.Drawing.Color.White;
            this.txtSideAC.Font = new System.Drawing.Font("Segoe UI", 13.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSideAC.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtSideAC.Location = new System.Drawing.Point(875, 249);
            this.txtSideAC.Name = "txtSideAC";
            this.txtSideAC.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtSideAC.Size = new System.Drawing.Size(111, 54);
            this.txtSideAC.TabIndex = 21;
            // 
            // btnUpdateDimensions
            // 
            this.btnUpdateDimensions.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdateDimensions.Font = new System.Drawing.Font("Segoe UI", 13.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateDimensions.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnUpdateDimensions.Location = new System.Drawing.Point(349, 138);
            this.btnUpdateDimensions.Margin = new System.Windows.Forms.Padding(10);
            this.btnUpdateDimensions.Name = "btnUpdateDimensions";
            this.btnUpdateDimensions.Padding = new System.Windows.Forms.Padding(3);
            this.btnUpdateDimensions.Size = new System.Drawing.Size(223, 74);
            this.btnUpdateDimensions.TabIndex = 22;
            this.btnUpdateDimensions.Text = "Update";
            this.btnUpdateDimensions.UseVisualStyleBackColor = true;
            this.btnUpdateDimensions.Click += new System.EventHandler(this.btnUpdateDimensions_Click);
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // txtRadiusY
            // 
            this.txtRadiusY.BackColor = System.Drawing.Color.White;
            this.txtRadiusY.Font = new System.Drawing.Font("Segoe UI", 13.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRadiusY.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtRadiusY.Location = new System.Drawing.Point(875, 186);
            this.txtRadiusY.Name = "txtRadiusY";
            this.txtRadiusY.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtRadiusY.Size = new System.Drawing.Size(111, 54);
            this.txtRadiusY.TabIndex = 23;
            // 
            // lblRadiusY
            // 
            this.lblRadiusY.AutoSize = true;
            this.lblRadiusY.BackColor = System.Drawing.Color.Transparent;
            this.lblRadiusY.Font = new System.Drawing.Font("Segoe UI", 13.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRadiusY.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblRadiusY.Location = new System.Drawing.Point(649, 187);
            this.lblRadiusY.Name = "lblRadiusY";
            this.lblRadiusY.Size = new System.Drawing.Size(160, 47);
            this.lblRadiusY.TabIndex = 24;
            this.lblRadiusY.Text = "Radius Y:";
            // 
            // btnLoad
            // 
            this.btnLoad.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLoad.Font = new System.Drawing.Font("Segoe UI", 13.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoad.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnLoad.Location = new System.Drawing.Point(349, 525);
            this.btnLoad.Margin = new System.Windows.Forms.Padding(10);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Padding = new System.Windows.Forms.Padding(3);
            this.btnLoad.Size = new System.Drawing.Size(223, 74);
            this.btnLoad.TabIndex = 26;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnSave
            // 
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 13.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSave.Location = new System.Drawing.Point(349, 435);
            this.btnSave.Margin = new System.Windows.Forms.Padding(10);
            this.btnSave.Name = "btnSave";
            this.btnSave.Padding = new System.Windows.Forms.Padding(3);
            this.btnSave.Size = new System.Drawing.Size(223, 74);
            this.btnSave.TabIndex = 27;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cmbOperations
            // 
            this.cmbOperations.BackColor = System.Drawing.Color.White;
            this.cmbOperations.CausesValidation = false;
            this.cmbOperations.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbOperations.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOperations.Font = new System.Drawing.Font("Segoe UI", 13.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbOperations.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cmbOperations.FormattingEnabled = true;
            this.cmbOperations.ItemHeight = 47;
            this.cmbOperations.Items.AddRange(new object[] {
            "Най-голяма фигура",
            "Най-малка фигура",
            "Групирай по тип",
            "Средна площ"});
            this.cmbOperations.Location = new System.Drawing.Point(651, 433);
            this.cmbOperations.Margin = new System.Windows.Forms.Padding(10);
            this.cmbOperations.Name = "cmbOperations";
            this.cmbOperations.Size = new System.Drawing.Size(363, 55);
            this.cmbOperations.TabIndex = 28;
            this.cmbOperations.SelectedIndexChanged += new System.EventHandler(this.cmbOperations_SelectedIndexChanged);
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.BackColor = System.Drawing.Color.Transparent;
            this.lblResult.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResult.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblResult.Location = new System.Drawing.Point(648, 504);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(0, 45);
            this.lblResult.TabIndex = 32;
            // 
            // lblShapeCriteria
            // 
            this.lblShapeCriteria.AutoSize = true;
            this.lblShapeCriteria.BackColor = System.Drawing.Color.Transparent;
            this.lblShapeCriteria.Font = new System.Drawing.Font("Segoe UI Semibold", 13.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShapeCriteria.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblShapeCriteria.Location = new System.Drawing.Point(643, 357);
            this.lblShapeCriteria.Name = "lblShapeCriteria";
            this.lblShapeCriteria.Size = new System.Drawing.Size(263, 47);
            this.lblShapeCriteria.TabIndex = 33;
            this.lblShapeCriteria.Text = "Shape statistics";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1186, 765);
            this.Controls.Add(this.lblShapeCriteria);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.cmbOperations);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.lblRadiusY);
            this.Controls.Add(this.txtRadiusY);
            this.Controls.Add(this.btnUpdateDimensions);
            this.Controls.Add(this.txtSideAC);
            this.Controls.Add(this.txtSideBC);
            this.Controls.Add(this.txtSideAB);
            this.Controls.Add(this.lblSideAC);
            this.Controls.Add(this.lblSideBC);
            this.Controls.Add(this.lblSideAB);
            this.Controls.Add(this.lblSideLength);
            this.Controls.Add(this.lblParameters);
            this.Controls.Add(this.txtSideLength);
            this.Controls.Add(this.btnCalculateArea);
            this.Controls.Add(this.lblHeight);
            this.Controls.Add(this.lblWidth);
            this.Controls.Add(this.btnDeleteShape);
            this.Controls.Add(this.lblRadius);
            this.Controls.Add(this.btnChangleOutlineColor);
            this.Controls.Add(this.txtWidth);
            this.Controls.Add(this.btnChangeFillColor);
            this.Controls.Add(this.txtHeight);
            this.Controls.Add(this.btnRedo);
            this.Controls.Add(this.txtRadius);
            this.Controls.Add(this.btnUndo);
            this.Controls.Add(this.btnAddShape);
            this.Controls.Add(this.comboBoxShapes);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "Shape Editor";
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnAddShape;
        private System.Windows.Forms.Button btnUndo;
        private System.Windows.Forms.Button btnRedo;
        private System.Windows.Forms.Button btnChangeFillColor;
        private System.Windows.Forms.Button btnChangleOutlineColor;
        private System.Windows.Forms.Button btnDeleteShape;
        public System.Windows.Forms.ComboBox comboBoxShapes;
        private System.Windows.Forms.Button btnCalculateArea;
        private System.Windows.Forms.Label lblParameters;
        private System.Windows.Forms.TextBox txtRadius;
        private System.Windows.Forms.TextBox txtHeight;
        private System.Windows.Forms.TextBox txtWidth;
        private System.Windows.Forms.Label lblRadius;
        private System.Windows.Forms.Label lblWidth;
        private System.Windows.Forms.Label lblHeight;
        private System.Windows.Forms.TextBox txtSideLength;
        private System.Windows.Forms.Label lblSideLength;
        private System.Windows.Forms.Label lblSideAB;
        private System.Windows.Forms.Label lblSideBC;
        private System.Windows.Forms.Label lblSideAC;
        private System.Windows.Forms.TextBox txtSideAB;
        private System.Windows.Forms.TextBox txtSideBC;
        private System.Windows.Forms.TextBox txtSideAC;
        private System.Windows.Forms.Button btnUpdateDimensions;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.TextBox txtRadiusY;
        private System.Windows.Forms.Label lblRadiusY;
        private System.Windows.Forms.Button btnLoad;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button btnSave;
        public System.Windows.Forms.ComboBox cmbOperations;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Label lblShapeCriteria;
    }
}

