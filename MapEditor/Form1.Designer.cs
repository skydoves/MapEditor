namespace MapEditor
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;


        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Panel_Layer1 = new System.Windows.Forms.Panel();
            this.Selector2 = new System.Windows.Forms.PictureBox();
            this.Layer1 = new System.Windows.Forms.PictureBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.Selector1 = new System.Windows.Forms.PictureBox();
            this.ChipSet = new System.Windows.Forms.PictureBox();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.ToolStrip_MapName = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.ToolStrip_LayerArray = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ToolStrip_File = new System.Windows.Forms.ToolStripMenuItem();
            this.새로운맵ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.타일셋ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.데이터ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.타일셋데이터셋팅ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.맵데이터저장ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.도움ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Tile = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_pamorama = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_Eraser = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_Paint = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_Layer1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Layer2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.Panel_Layer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Selector2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Layer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Selector1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChipSet)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Panel_Layer1
            // 
            this.Panel_Layer1.AutoScroll = true;
            this.Panel_Layer1.BackColor = System.Drawing.Color.LightGray;
            this.Panel_Layer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Panel_Layer1.Controls.Add(this.Selector2);
            this.Panel_Layer1.Controls.Add(this.Layer1);
            this.Panel_Layer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel_Layer1.Location = new System.Drawing.Point(290, 52);
            this.Panel_Layer1.Name = "Panel_Layer1";
            this.Panel_Layer1.Size = new System.Drawing.Size(644, 586);
            this.Panel_Layer1.TabIndex = 15;
            // 
            // Selector2
            // 
            this.Selector2.BackColor = System.Drawing.Color.Transparent;
            this.Selector2.BackgroundImage = global::MapEditor.Properties.Resources.SelectPointer;
            this.Selector2.Enabled = false;
            this.Selector2.Location = new System.Drawing.Point(-1, 0);
            this.Selector2.Name = "Selector2";
            this.Selector2.Size = new System.Drawing.Size(32, 32);
            this.Selector2.TabIndex = 16;
            this.Selector2.TabStop = false;
            // 
            // Layer1
            // 
            this.Layer1.BackColor = System.Drawing.Color.White;
            this.Layer1.Location = new System.Drawing.Point(-1, -1);
            this.Layer1.Name = "Layer1";
            this.Layer1.Size = new System.Drawing.Size(400, 471);
            this.Layer1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.Layer1.TabIndex = 7;
            this.Layer1.TabStop = false;
            this.Layer1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Layer1_MouseDown);
            this.Layer1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Layer1_MouseMove);
            this.Layer1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Layer1_MouseUp);
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Left;
            this.splitContainer1.Location = new System.Drawing.Point(5, 52);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel1.Controls.Add(this.Selector1);
            this.splitContainer1.Panel1.Controls.Add(this.ChipSet);
            this.splitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Panel2.Controls.Add(this.treeView1);
            this.splitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer1.Size = new System.Drawing.Size(280, 586);
            this.splitContainer1.SplitterDistance = 449;
            this.splitContainer1.TabIndex = 14;
            // 
            // Selector1
            // 
            this.Selector1.BackColor = System.Drawing.Color.Transparent;
            this.Selector1.BackgroundImage = global::MapEditor.Properties.Resources.SelectPointer;
            this.Selector1.Enabled = false;
            this.Selector1.Location = new System.Drawing.Point(-1, -1);
            this.Selector1.Name = "Selector1";
            this.Selector1.Size = new System.Drawing.Size(32, 32);
            this.Selector1.TabIndex = 15;
            this.Selector1.TabStop = false;
            // 
            // ChipSet
            // 
            this.ChipSet.BackColor = System.Drawing.SystemColors.Control;
            this.ChipSet.Location = new System.Drawing.Point(-1, 0);
            this.ChipSet.Name = "ChipSet";
            this.ChipSet.Size = new System.Drawing.Size(256, 64);
            this.ChipSet.TabIndex = 0;
            this.ChipSet.TabStop = false;
            this.ChipSet.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ChipSet_MouseDown);
            this.ChipSet.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ChipSet_MouseMove);
            this.ChipSet.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ChipSet_MouseUp);
            // 
            // treeView1
            // 
            this.treeView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.treeView1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(278, 131);
            this.treeView1.TabIndex = 8;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.ToolStrip_MapName,
            this.toolStripStatusLabel4,
            this.ToolStrip_LayerArray});
            this.statusStrip1.Location = new System.Drawing.Point(0, 648);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(939, 24);
            this.statusStrip1.TabIndex = 16;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(128, 19);
            this.toolStripStatusLabel1.Text = "Copyright ⓒ skydoves";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(439, 19);
            this.toolStripStatusLabel2.Text = "                                                                                 " +
    "                           ";
            // 
            // ToolStrip_MapName
            // 
            this.ToolStrip_MapName.Name = "ToolStrip_MapName";
            this.ToolStrip_MapName.Size = new System.Drawing.Size(63, 19);
            this.ToolStrip_MapName.Text = "MapName";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(87, 19);
            this.toolStripStatusLabel4.Text = "                    ";
            // 
            // ToolStrip_LayerArray
            // 
            this.ToolStrip_LayerArray.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)));
            this.ToolStrip_LayerArray.Name = "ToolStrip_LayerArray";
            this.ToolStrip_LayerArray.Size = new System.Drawing.Size(39, 19);
            this.ToolStrip_LayerArray.Text = "Array";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStrip_File,
            this.데이터ToolStripMenuItem,
            this.도움ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip1.Size = new System.Drawing.Size(939, 24);
            this.menuStrip1.TabIndex = 18;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ToolStrip_File
            // 
            this.ToolStrip_File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.새로운맵ToolStripMenuItem,
            this.타일셋ToolStripMenuItem,
            this.toolStripMenuItem1});
            this.ToolStrip_File.Name = "ToolStrip_File";
            this.ToolStrip_File.Size = new System.Drawing.Size(53, 20);
            this.ToolStrip_File.Text = "File(A)";
            // 
            // 새로운맵ToolStripMenuItem
            // 
            this.새로운맵ToolStripMenuItem.Image = global::MapEditor.Properties.Resources.Icon_file2;
            this.새로운맵ToolStripMenuItem.Name = "새로운맵ToolStripMenuItem";
            this.새로운맵ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.새로운맵ToolStripMenuItem.Text = "New Map";
            this.새로운맵ToolStripMenuItem.Click += new System.EventHandler(this.새로운맵ToolStripMenuItem_Click);
            // 
            // 타일셋ToolStripMenuItem
            // 
            this.타일셋ToolStripMenuItem.Image = global::MapEditor.Properties.Resources.Icon_Tile;
            this.타일셋ToolStripMenuItem.Name = "타일셋ToolStripMenuItem";
            this.타일셋ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.타일셋ToolStripMenuItem.Text = "Tileset";
            this.타일셋ToolStripMenuItem.Click += new System.EventHandler(this.타일셋ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Image = global::MapEditor.Properties.Resources.Icon_panorama;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem1.Text = "Parnorama";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // 데이터ToolStripMenuItem
            // 
            this.데이터ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.타일셋데이터셋팅ToolStripMenuItem,
            this.맵데이터저장ToolStripMenuItem});
            this.데이터ToolStripMenuItem.Name = "데이터ToolStripMenuItem";
            this.데이터ToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.데이터ToolStripMenuItem.Text = "Data(D)";
            // 
            // 타일셋데이터셋팅ToolStripMenuItem
            // 
            this.타일셋데이터셋팅ToolStripMenuItem.Image = global::MapEditor.Properties.Resources.IconTileSetting;
            this.타일셋데이터셋팅ToolStripMenuItem.Name = "타일셋데이터셋팅ToolStripMenuItem";
            this.타일셋데이터셋팅ToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.타일셋데이터셋팅ToolStripMenuItem.Text = "Setting Tileset";
            this.타일셋데이터셋팅ToolStripMenuItem.Click += new System.EventHandler(this.타일셋데이터셋팅ToolStripMenuItem_Click);
            // 
            // 맵데이터저장ToolStripMenuItem
            // 
            this.맵데이터저장ToolStripMenuItem.Image = global::MapEditor.Properties.Resources.Icon_save;
            this.맵데이터저장ToolStripMenuItem.Name = "맵데이터저장ToolStripMenuItem";
            this.맵데이터저장ToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.맵데이터저장ToolStripMenuItem.Text = "Save Map Data";
            this.맵데이터저장ToolStripMenuItem.Click += new System.EventHandler(this.맵데이터저장ToolStripMenuItem_Click);
            // 
            // 도움ToolStripMenuItem
            // 
            this.도움ToolStripMenuItem.Name = "도움ToolStripMenuItem";
            this.도움ToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.도움ToolStripMenuItem.Text = "Help(E)";
            this.도움ToolStripMenuItem.Click += new System.EventHandler(this.도움ToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton_Tile,
            this.toolStripButton3,
            this.toolStripButton_pamorama,
            this.toolStripButton4,
            this.toolStripLabel1,
            this.toolStripSeparator5,
            this.toolStripButton_Eraser,
            this.toolStripLabel4,
            this.toolStripSeparator3,
            this.toolStripButton_Paint,
            this.toolStripLabel2,
            this.toolStripSeparator1,
            this.toolStripButton_Layer1,
            this.toolStripButton_Layer2,
            this.toolStripSeparator2,
            this.toolStripLabel3,
            this.toolStripButton5,
            this.toolStripSeparator4,
            this.toolStripButton2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(939, 25);
            this.toolStrip1.TabIndex = 19;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::MapEditor.Properties.Resources.Icon_file2;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "New Map";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton_Tile
            // 
            this.toolStripButton_Tile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_Tile.Image = global::MapEditor.Properties.Resources.Icon_Tile;
            this.toolStripButton_Tile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Tile.Name = "toolStripButton_Tile";
            this.toolStripButton_Tile.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_Tile.Text = "Tileset";
            this.toolStripButton_Tile.Click += new System.EventHandler(this.toolStripButton_Tile_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = global::MapEditor.Properties.Resources.IconTileSetting;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton3.Text = "Tileset Data";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // toolStripButton_pamorama
            // 
            this.toolStripButton_pamorama.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_pamorama.Image = global::MapEditor.Properties.Resources.Icon_panorama;
            this.toolStripButton_pamorama.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_pamorama.Name = "toolStripButton_pamorama";
            this.toolStripButton_pamorama.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_pamorama.Text = "Panorama";
            this.toolStripButton_pamorama.Click += new System.EventHandler(this.toolStripButton_pamorama_Click);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = global::MapEditor.Properties.Resources.Icon_save;
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton4.Text = "Map Data Save";
            this.toolStripButton4.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(167, 22);
            this.toolStripLabel1.Text = "                                        ";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton_Eraser
            // 
            this.toolStripButton_Eraser.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_Eraser.Image = global::MapEditor.Properties.Resources.Icon_eraser;
            this.toolStripButton_Eraser.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Eraser.Name = "toolStripButton_Eraser";
            this.toolStripButton_Eraser.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_Eraser.Text = "Eraser";
            this.toolStripButton_Eraser.Click += new System.EventHandler(this.toolStripButton_Eraser_Click);
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(95, 22);
            this.toolStripLabel4.Text = "                      ";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton_Paint
            // 
            this.toolStripButton_Paint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_Paint.Image = global::MapEditor.Properties.Resources.Icon_paint;
            this.toolStripButton_Paint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Paint.Name = "toolStripButton_Paint";
            this.toolStripButton_Paint.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_Paint.Text = "Paint";
            this.toolStripButton_Paint.Click += new System.EventHandler(this.toolStripButton_Paint_Click);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(83, 22);
            this.toolStripLabel2.Text = "                   ";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton_Layer1
            // 
            this.toolStripButton_Layer1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_Layer1.Image = global::MapEditor.Properties.Resources.Icon_layer1;
            this.toolStripButton_Layer1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Layer1.Name = "toolStripButton_Layer1";
            this.toolStripButton_Layer1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_Layer1.Text = "Layer1";
            this.toolStripButton_Layer1.Click += new System.EventHandler(this.toolStripButton_Layer1_Click);
            // 
            // toolStripButton_Layer2
            // 
            this.toolStripButton_Layer2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_Layer2.Image = global::MapEditor.Properties.Resources.Icon_layer2;
            this.toolStripButton_Layer2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Layer2.Name = "toolStripButton_Layer2";
            this.toolStripButton_Layer2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_Layer2.Text = "Layer2";
            this.toolStripButton_Layer2.Click += new System.EventHandler(this.toolStripButton_Layer2_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(91, 22);
            this.toolStripLabel3.Text = "                     ";
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton5.Image = global::MapEditor.Properties.Resources.Icon_play;
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton5.Text = "Map Data Simulation";
            this.toolStripButton5.Click += new System.EventHandler(this.toolStripButton5_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = global::MapEditor.Properties.Resources.Icon_refresh;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "Refresh";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 638);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(939, 10);
            this.panel1.TabIndex = 20;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 49);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(5, 589);
            this.panel2.TabIndex = 21;
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(5, 49);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(934, 3);
            this.panel3.TabIndex = 22;
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(285, 52);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(5, 586);
            this.panel4.TabIndex = 22;
            // 
            // panel5
            // 
            this.panel5.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel5.Location = new System.Drawing.Point(934, 52);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(5, 586);
            this.panel5.TabIndex = 22;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(939, 672);
            this.Controls.Add(this.Panel_Layer1);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(955, 711);
            this.Name = "Form1";
            this.Text = "Map Editor v1.2";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Panel_Layer1.ResumeLayout(false);
            this.Panel_Layer1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Selector2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Layer1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Selector1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChipSet)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox ChipSet;
        private System.Windows.Forms.PictureBox Layer1;
        private System.Windows.Forms.PictureBox Selector1;
        private System.Windows.Forms.Panel Panel_Layer1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel ToolStrip_MapName;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel ToolStrip_LayerArray;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ToolStrip_File;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripMenuItem 새로운맵ToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButton_Tile;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton toolStripButton_Layer1;
        private System.Windows.Forms.ToolStripButton toolStripButton_Layer2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButton_Paint;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem 도움ToolStripMenuItem;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem 타일셋ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton toolStripButton_Eraser;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.PictureBox Selector2;
        private System.Windows.Forms.ToolStripButton toolStripButton_pamorama;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 데이터ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 타일셋데이터셋팅ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 맵데이터저장ToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;

    }
}

