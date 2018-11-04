﻿namespace Rendering
{
  partial class Form1
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose ( bool disposing )
    {
      if ( disposing && ( components != null ) )
      {
        components.Dispose ();
      }
      base.Dispose ( disposing );
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent ()
    {
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
      this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      this.pictureBox1 = new System.Windows.Forms.PictureBox();
      this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
      this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
      this.buttonSave = new System.Windows.Forms.Button();
      this.SavePointCloudButton = new System.Windows.Forms.Button();
      this.AdvancedToolsButton = new System.Windows.Forms.Button();
      this.RayVisualiserButton = new System.Windows.Forms.Button();
      this.RenderClientsButton = new System.Windows.Forms.Button();
      this.ResetButton = new System.Windows.Forms.Button();
      this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
      this.buttonRender = new System.Windows.Forms.Button();
      this.buttonStop = new System.Windows.Forms.Button();
      this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
      this.buttonRes = new System.Windows.Forms.Button();
      this.label2 = new System.Windows.Forms.Label();
      this.numericSupersampling = new System.Windows.Forms.NumericUpDown();
      this.checkJitter = new System.Windows.Forms.CheckBox();
      this.checkShadows = new System.Windows.Forms.CheckBox();
      this.checkReflections = new System.Windows.Forms.CheckBox();
      this.checkRefractions = new System.Windows.Forms.CheckBox();
      this.checkMultithreading = new System.Windows.Forms.CheckBox();
      this.pointCloudCheckBox = new System.Windows.Forms.CheckBox();
      this.panel1 = new System.Windows.Forms.Panel();
      this.textParam = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.comboScene = new System.Windows.Forms.ComboBox();
      this.label1 = new System.Windows.Forms.Label();
      this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
      this.labelElapsed = new System.Windows.Forms.Label();
      this.labelSample = new System.Windows.Forms.Label();
      this.notificationIcon = new System.Windows.Forms.NotifyIcon(this.components);
      this.collectDataCheckBox = new System.Windows.Forms.CheckBox();
      this.tableLayoutPanel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
      this.tableLayoutPanel2.SuspendLayout();
      this.flowLayoutPanel1.SuspendLayout();
      this.flowLayoutPanel3.SuspendLayout();
      this.flowLayoutPanel2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.numericSupersampling)).BeginInit();
      this.panel1.SuspendLayout();
      this.tableLayoutPanel3.SuspendLayout();
      this.SuspendLayout();
      // 
      // tableLayoutPanel1
      // 
      this.tableLayoutPanel1.ColumnCount = 1;
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel1.Controls.Add(this.pictureBox1, 0, 0);
      this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 4);
      this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel2, 0, 2);
      this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
      this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 3);
      this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
      this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 5;
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
      this.tableLayoutPanel1.Size = new System.Drawing.Size(904, 632);
      this.tableLayoutPanel1.TabIndex = 0;
      // 
      // pictureBox1
      // 
      this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
      this.pictureBox1.Location = new System.Drawing.Point(0, 0);
      this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new System.Drawing.Size(904, 519);
      this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
      this.pictureBox1.TabIndex = 51;
      this.pictureBox1.TabStop = false;
      this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
      this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
      this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
      this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
      // 
      // tableLayoutPanel2
      // 
      this.tableLayoutPanel2.ColumnCount = 2;
      this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
      this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
      this.tableLayoutPanel2.Controls.Add(this.flowLayoutPanel1, 1, 0);
      this.tableLayoutPanel2.Controls.Add(this.flowLayoutPanel3, 0, 0);
      this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 603);
      this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
      this.tableLayoutPanel2.Name = "tableLayoutPanel2";
      this.tableLayoutPanel2.RowCount = 1;
      this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel2.Size = new System.Drawing.Size(904, 29);
      this.tableLayoutPanel2.TabIndex = 5;
      // 
      // flowLayoutPanel1
      // 
      this.flowLayoutPanel1.Controls.Add(this.buttonSave);
      this.flowLayoutPanel1.Controls.Add(this.SavePointCloudButton);
      this.flowLayoutPanel1.Controls.Add(this.AdvancedToolsButton);
      this.flowLayoutPanel1.Controls.Add(this.RayVisualiserButton);
      this.flowLayoutPanel1.Controls.Add(this.RenderClientsButton);
      this.flowLayoutPanel1.Controls.Add(this.ResetButton);
      this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
      this.flowLayoutPanel1.Location = new System.Drawing.Point(226, 0);
      this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
      this.flowLayoutPanel1.Name = "flowLayoutPanel1";
      this.flowLayoutPanel1.Size = new System.Drawing.Size(678, 29);
      this.flowLayoutPanel1.TabIndex = 4;
      this.flowLayoutPanel1.WrapContents = false;
      // 
      // buttonSave
      // 
      this.buttonSave.Enabled = false;
      this.buttonSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.buttonSave.Location = new System.Drawing.Point(597, 3);
      this.buttonSave.Name = "buttonSave";
      this.buttonSave.Size = new System.Drawing.Size(78, 23);
      this.buttonSave.TabIndex = 4;
      this.buttonSave.Text = "Save image";
      this.buttonSave.UseVisualStyleBackColor = true;
      this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
      // 
      // SavePointCloudButton
      // 
      this.SavePointCloudButton.Enabled = false;
      this.SavePointCloudButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.SavePointCloudButton.Location = new System.Drawing.Point(495, 3);
      this.SavePointCloudButton.Name = "SavePointCloudButton";
      this.SavePointCloudButton.Size = new System.Drawing.Size(96, 23);
      this.SavePointCloudButton.TabIndex = 8;
      this.SavePointCloudButton.Text = "Save point cloud";
      this.SavePointCloudButton.UseVisualStyleBackColor = true;
      this.SavePointCloudButton.Click += new System.EventHandler(this.SavePointCloudButton_Click);
      // 
      // AdvancedToolsButton
      // 
      this.AdvancedToolsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.AdvancedToolsButton.Location = new System.Drawing.Point(382, 3);
      this.AdvancedToolsButton.Name = "AdvancedToolsButton";
      this.AdvancedToolsButton.Size = new System.Drawing.Size(107, 23);
      this.AdvancedToolsButton.TabIndex = 5;
      this.AdvancedToolsButton.Text = "Advanced Tools";
      this.AdvancedToolsButton.UseVisualStyleBackColor = true;
      this.AdvancedToolsButton.Click += new System.EventHandler(this.AdvancedToolsButton_Click);
      // 
      // RayVisualiserButton
      // 
      this.RayVisualiserButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.RayVisualiserButton.Location = new System.Drawing.Point(284, 3);
      this.RayVisualiserButton.Name = "RayVisualiserButton";
      this.RayVisualiserButton.Size = new System.Drawing.Size(92, 23);
      this.RayVisualiserButton.TabIndex = 6;
      this.RayVisualiserButton.Text = "Ray Visualiser";
      this.RayVisualiserButton.UseVisualStyleBackColor = true;
      this.RayVisualiserButton.Click += new System.EventHandler(this.RayVisualiserButton_Click);
      // 
      // RenderClientsButton
      // 
      this.RenderClientsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.RenderClientsButton.Location = new System.Drawing.Point(179, 3);
      this.RenderClientsButton.Name = "RenderClientsButton";
      this.RenderClientsButton.Size = new System.Drawing.Size(99, 23);
      this.RenderClientsButton.TabIndex = 7;
      this.RenderClientsButton.Text = "Render Clients";
      this.RenderClientsButton.UseVisualStyleBackColor = true;
      this.RenderClientsButton.Click += new System.EventHandler(this.addRenderClientToolStripMenuItem_Click);
      // 
      // ResetButton
      // 
      this.ResetButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.ResetButton.Location = new System.Drawing.Point(130, 3);
      this.ResetButton.Name = "ResetButton";
      this.ResetButton.Size = new System.Drawing.Size(43, 23);
      this.ResetButton.TabIndex = 9;
      this.ResetButton.Text = "Reset";
      this.ResetButton.UseVisualStyleBackColor = true;
      this.ResetButton.Click += new System.EventHandler(this.ResetButton_Click);
      // 
      // flowLayoutPanel3
      // 
      this.flowLayoutPanel3.Controls.Add(this.buttonRender);
      this.flowLayoutPanel3.Controls.Add(this.buttonStop);
      this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
      this.flowLayoutPanel3.Location = new System.Drawing.Point(0, 0);
      this.flowLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
      this.flowLayoutPanel3.Name = "flowLayoutPanel3";
      this.flowLayoutPanel3.Size = new System.Drawing.Size(226, 29);
      this.flowLayoutPanel3.TabIndex = 5;
      this.flowLayoutPanel3.WrapContents = false;
      // 
      // buttonRender
      // 
      this.buttonRender.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.buttonRender.Location = new System.Drawing.Point(3, 3);
      this.buttonRender.Name = "buttonRender";
      this.buttonRender.Size = new System.Drawing.Size(108, 23);
      this.buttonRender.TabIndex = 8;
      this.buttonRender.Text = "Render";
      this.buttonRender.UseVisualStyleBackColor = true;
      this.buttonRender.Click += new System.EventHandler(this.buttonRender_Click);
      // 
      // buttonStop
      // 
      this.buttonStop.Enabled = false;
      this.buttonStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.buttonStop.Location = new System.Drawing.Point(117, 3);
      this.buttonStop.Name = "buttonStop";
      this.buttonStop.Size = new System.Drawing.Size(51, 23);
      this.buttonStop.TabIndex = 9;
      this.buttonStop.Text = "Stop";
      this.buttonStop.UseVisualStyleBackColor = true;
      this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
      // 
      // flowLayoutPanel2
      // 
      this.flowLayoutPanel2.Controls.Add(this.buttonRes);
      this.flowLayoutPanel2.Controls.Add(this.label2);
      this.flowLayoutPanel2.Controls.Add(this.numericSupersampling);
      this.flowLayoutPanel2.Controls.Add(this.checkJitter);
      this.flowLayoutPanel2.Controls.Add(this.checkShadows);
      this.flowLayoutPanel2.Controls.Add(this.checkReflections);
      this.flowLayoutPanel2.Controls.Add(this.checkRefractions);
      this.flowLayoutPanel2.Controls.Add(this.checkMultithreading);
      this.flowLayoutPanel2.Controls.Add(this.pointCloudCheckBox);
      this.flowLayoutPanel2.Controls.Add(this.collectDataCheckBox);
      this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 554);
      this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
      this.flowLayoutPanel2.Name = "flowLayoutPanel2";
      this.flowLayoutPanel2.Size = new System.Drawing.Size(904, 29);
      this.flowLayoutPanel2.TabIndex = 1;
      // 
      // buttonRes
      // 
      this.buttonRes.Anchor = System.Windows.Forms.AnchorStyles.Left;
      this.buttonRes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.buttonRes.Location = new System.Drawing.Point(3, 3);
      this.buttonRes.Name = "buttonRes";
      this.buttonRes.Size = new System.Drawing.Size(83, 23);
      this.buttonRes.TabIndex = 43;
      this.buttonRes.Text = "Resolution";
      this.buttonRes.UseVisualStyleBackColor = true;
      this.buttonRes.Click += new System.EventHandler(this.buttonRes_Click);
      // 
      // label2
      // 
      this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(92, 8);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(79, 13);
      this.label2.TabIndex = 44;
      this.label2.Text = "Supersampling:";
      // 
      // numericSupersampling
      // 
      this.numericSupersampling.Anchor = System.Windows.Forms.AnchorStyles.Left;
      this.numericSupersampling.Location = new System.Drawing.Point(177, 4);
      this.numericSupersampling.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
      this.numericSupersampling.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.numericSupersampling.Name = "numericSupersampling";
      this.numericSupersampling.Size = new System.Drawing.Size(52, 20);
      this.numericSupersampling.TabIndex = 45;
      this.numericSupersampling.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
      // 
      // checkJitter
      // 
      this.checkJitter.Anchor = System.Windows.Forms.AnchorStyles.Left;
      this.checkJitter.AutoSize = true;
      this.checkJitter.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.checkJitter.Checked = true;
      this.checkJitter.CheckState = System.Windows.Forms.CheckState.Checked;
      this.checkJitter.Location = new System.Drawing.Point(235, 6);
      this.checkJitter.Name = "checkJitter";
      this.checkJitter.Size = new System.Drawing.Size(59, 17);
      this.checkJitter.TabIndex = 49;
      this.checkJitter.Text = "jittering";
      this.checkJitter.UseVisualStyleBackColor = true;
      // 
      // checkShadows
      // 
      this.checkShadows.Anchor = System.Windows.Forms.AnchorStyles.Left;
      this.checkShadows.AutoSize = true;
      this.checkShadows.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.checkShadows.Checked = true;
      this.checkShadows.CheckState = System.Windows.Forms.CheckState.Checked;
      this.checkShadows.Location = new System.Drawing.Point(300, 6);
      this.checkShadows.Name = "checkShadows";
      this.checkShadows.Size = new System.Drawing.Size(68, 17);
      this.checkShadows.TabIndex = 46;
      this.checkShadows.Text = "shadows";
      this.checkShadows.UseVisualStyleBackColor = true;
      // 
      // checkReflections
      // 
      this.checkReflections.Anchor = System.Windows.Forms.AnchorStyles.Left;
      this.checkReflections.AutoSize = true;
      this.checkReflections.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.checkReflections.Checked = true;
      this.checkReflections.CheckState = System.Windows.Forms.CheckState.Checked;
      this.checkReflections.Location = new System.Drawing.Point(374, 6);
      this.checkReflections.Name = "checkReflections";
      this.checkReflections.Size = new System.Drawing.Size(74, 17);
      this.checkReflections.TabIndex = 47;
      this.checkReflections.Text = "reflections";
      this.checkReflections.UseVisualStyleBackColor = true;
      // 
      // checkRefractions
      // 
      this.checkRefractions.Anchor = System.Windows.Forms.AnchorStyles.Left;
      this.checkRefractions.AutoSize = true;
      this.checkRefractions.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.checkRefractions.Checked = true;
      this.checkRefractions.CheckState = System.Windows.Forms.CheckState.Checked;
      this.checkRefractions.Location = new System.Drawing.Point(454, 6);
      this.checkRefractions.Name = "checkRefractions";
      this.checkRefractions.Size = new System.Drawing.Size(75, 17);
      this.checkRefractions.TabIndex = 48;
      this.checkRefractions.Text = "refractions";
      this.checkRefractions.UseVisualStyleBackColor = true;
      // 
      // checkMultithreading
      // 
      this.checkMultithreading.Anchor = System.Windows.Forms.AnchorStyles.Left;
      this.checkMultithreading.AutoSize = true;
      this.checkMultithreading.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.checkMultithreading.Location = new System.Drawing.Point(535, 6);
      this.checkMultithreading.Name = "checkMultithreading";
      this.checkMultithreading.Size = new System.Drawing.Size(94, 17);
      this.checkMultithreading.TabIndex = 50;
      this.checkMultithreading.Text = "multi-threading";
      this.checkMultithreading.UseVisualStyleBackColor = true;
      // 
      // pointCloudCheckBox
      // 
      this.pointCloudCheckBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
      this.pointCloudCheckBox.AutoSize = true;
      this.pointCloudCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.pointCloudCheckBox.Location = new System.Drawing.Point(635, 6);
      this.pointCloudCheckBox.Name = "pointCloudCheckBox";
      this.pointCloudCheckBox.Size = new System.Drawing.Size(78, 17);
      this.pointCloudCheckBox.TabIndex = 51;
      this.pointCloudCheckBox.Text = "point cloud";
      this.pointCloudCheckBox.UseVisualStyleBackColor = true;
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.textParam);
      this.panel1.Controls.Add(this.label3);
      this.panel1.Controls.Add(this.comboScene);
      this.panel1.Controls.Add(this.label1);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panel1.Location = new System.Drawing.Point(3, 522);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(898, 29);
      this.panel1.TabIndex = 3;
      // 
      // textParam
      // 
      this.textParam.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.textParam.Location = new System.Drawing.Point(272, 5);
      this.textParam.Name = "textParam";
      this.textParam.Size = new System.Drawing.Size(623, 20);
      this.textParam.TabIndex = 49;
      // 
      // label3
      // 
      this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(211, 9);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(63, 13);
      this.label3.TabIndex = 48;
      this.label3.Text = "Parameters:";
      // 
      // comboScene
      // 
      this.comboScene.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.comboScene.FormattingEnabled = true;
      this.comboScene.Location = new System.Drawing.Point(50, 5);
      this.comboScene.Name = "comboScene";
      this.comboScene.Size = new System.Drawing.Size(155, 21);
      this.comboScene.TabIndex = 47;
      this.comboScene.SelectedIndexChanged += new System.EventHandler(this.comboScene_SelectedIndexChanged);
      // 
      // label1
      // 
      this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(3, 9);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(41, 13);
      this.label1.TabIndex = 46;
      this.label1.Text = "Scene:";
      // 
      // tableLayoutPanel3
      // 
      this.tableLayoutPanel3.ColumnCount = 2;
      this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.66666F));
      this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
      this.tableLayoutPanel3.Controls.Add(this.labelElapsed, 0, 0);
      this.tableLayoutPanel3.Controls.Add(this.labelSample, 1, 0);
      this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 583);
      this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
      this.tableLayoutPanel3.Name = "tableLayoutPanel3";
      this.tableLayoutPanel3.RowCount = 1;
      this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel3.Size = new System.Drawing.Size(904, 20);
      this.tableLayoutPanel3.TabIndex = 4;
      // 
      // labelElapsed
      // 
      this.labelElapsed.Anchor = System.Windows.Forms.AnchorStyles.Left;
      this.labelElapsed.AutoSize = true;
      this.labelElapsed.Location = new System.Drawing.Point(3, 3);
      this.labelElapsed.Name = "labelElapsed";
      this.labelElapsed.Size = new System.Drawing.Size(48, 13);
      this.labelElapsed.TabIndex = 24;
      this.labelElapsed.Text = "Elapsed:";
      // 
      // labelSample
      // 
      this.labelSample.Anchor = System.Windows.Forms.AnchorStyles.Left;
      this.labelSample.AutoSize = true;
      this.labelSample.Location = new System.Drawing.Point(605, 3);
      this.labelSample.Name = "labelSample";
      this.labelSample.Size = new System.Drawing.Size(45, 13);
      this.labelSample.TabIndex = 23;
      this.labelSample.Text = "Sample:";
      // 
      // notificationIcon
      // 
      this.notificationIcon.Text = "048 Monte Carlo RT script";
      this.notificationIcon.Visible = true;
      // 
      // collectDataCheckBox
      // 
      this.collectDataCheckBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
      this.collectDataCheckBox.AutoSize = true;
      this.collectDataCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.collectDataCheckBox.Location = new System.Drawing.Point(719, 6);
      this.collectDataCheckBox.Name = "collectDataCheckBox";
      this.collectDataCheckBox.Size = new System.Drawing.Size(129, 17);
      this.collectDataCheckBox.TabIndex = 52;
      this.collectDataCheckBox.Text = "collect additional data";
      this.collectDataCheckBox.UseVisualStyleBackColor = true;
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(904, 632);
      this.Controls.Add(this.tableLayoutPanel1);
      this.MinimumSize = new System.Drawing.Size(680, 300);
      this.Name = "Form1";
      this.Text = "048 Monte Carlo RT script";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
      this.Load += new System.EventHandler(this.Form2_Load);
      this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form2_KeyDown);
      this.tableLayoutPanel1.ResumeLayout(false);
      this.tableLayoutPanel1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
      this.tableLayoutPanel2.ResumeLayout(false);
      this.flowLayoutPanel1.ResumeLayout(false);
      this.flowLayoutPanel3.ResumeLayout(false);
      this.flowLayoutPanel2.ResumeLayout(false);
      this.flowLayoutPanel2.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.numericSupersampling)).EndInit();
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.tableLayoutPanel3.ResumeLayout(false);
      this.tableLayoutPanel3.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
    private System.Windows.Forms.Button buttonRes;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.NumericUpDown numericSupersampling;
    private System.Windows.Forms.CheckBox checkJitter;
    private System.Windows.Forms.CheckBox checkShadows;
    private System.Windows.Forms.CheckBox checkReflections;
    private System.Windows.Forms.CheckBox checkRefractions;
    private System.Windows.Forms.CheckBox checkMultithreading;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.TextBox textParam;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.ComboBox comboScene;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
    private System.Windows.Forms.Label labelSample;
    private System.Windows.Forms.Label labelElapsed;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    private System.Windows.Forms.Button buttonSave;
    private System.Windows.Forms.Button RenderClientsButton;
    private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
    private System.Windows.Forms.Button buttonRender;
    private System.Windows.Forms.Button buttonStop;
    private System.Windows.Forms.PictureBox pictureBox1;
    private System.Windows.Forms.Button AdvancedToolsButton;
    public System.Windows.Forms.CheckBox pointCloudCheckBox;
    private System.Windows.Forms.Button SavePointCloudButton;
    private System.Windows.Forms.NotifyIcon notificationIcon;
    public System.Windows.Forms.Button RayVisualiserButton;
    private System.Windows.Forms.Button ResetButton;
    public System.Windows.Forms.CheckBox collectDataCheckBox;
  }
}
