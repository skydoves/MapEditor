using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;

namespace MapEditor
{
    public partial class Form1 : Form
    {
        #region Variables

        public string Version = "1.2";
        private Point RectStartPoint, RectStartPoint2;
        private int TileSize = 32;
        private int LayerMode = 1; // 1 : Layer1 mode  2 : Layer2 mode
        private string MapPath = null; // Layer1에 대한 맵 이름
        private string MapPath2 = null; // Layer2에 대한 맵 이름

        // Tileset & Map Data
        private string TilesetName = null;
        private string[] MapData = null; // Map의 이동가능성 정보를 동적으로 관리한다.
        private string[,] ChipsetData = null; // 칩셋에서 맵을 잘라낸 부분 만큼의 TilesetData
        private string[] TilesetData = null; // 현재 Tile set의 Data 배열

        // Mouse State
        private Point ChipSet_StartMousePoint; // 칩셋을 클릭한 순간의 시작 point
        private Point Layer1_StartMouserPoint; // 레이어를 클릭한 부분의 시작 point
        private int MouseState_ChipSet = 0; // ChipSet : clickdown = 1, clickup = 0
        private int MouseState_Layer = 0; // Layer1 : clickdown = 1, clickup = 0

        // Bitmap
        Bitmap Drawing = null; // 실질적으로 사용자들이 그려지는것을 보여주는 Bitmap
        Bitmap TileSet = null; // Chipset에서 사용자가 선택한 범위를 crropped에 clone해주기 위한 가상 Bitmap
        Bitmap cropped = null; // 현재 사용자가 선택한 범위의 Bitmap
        Graphics g = null; // g는 현재 사용자의 Layer에 띄워주기 위한것이며 Layer1 위에 그려진다.
        Graphics g2 = null; // g2, g3는 지속적으로 저장하는 .png 파일을 위한 g의 복사본과도 같으며 Savebm 위에 그려진다.
        Graphics g3 = null; // g2 : Layer1에 대한 복사본, g3 : Layer2에 대한 복사본
        Bitmap Savebm;
        Bitmap Savebm2;

        // Form variables
        public int Menu_isopen = 0;

        #endregion

        ///<summary>
        /// Form Load 부분
        ///</summary>

        public Form1()
        {
            InitializeComponent();
        }

        // Form Load
        private void Form1_Load(object sender, EventArgs e)
        {
            // Set Version
            Properties.Settings.Default.Version = Version;

            // Start Opacity & Show Title
            this.Opacity = 0;
            this.Location = new Point(Screen.PrimaryScreen.Bounds.Width / 2 - (this.Width) / 2,
            Screen.PrimaryScreen.Bounds.Height / 2 - (this.Height) / 2);
            TitleForm Title = new TitleForm();
            Title.Owner = this;
            Title.Show();
            
            // SplitConainer.panel <- Chipset
            splitContainer1.Panel1.Controls.Add(ChipSet);
            ChipSet.Location = new Point(0, 0);

            // ChipSet <- Selector1  /  Layer1 <- Selector2
            ChipSet.Controls.Add(Selector1);
            Selector1.Location = new Point(-32, -32);
            Layer1.Controls.Add(Selector2);
            Selector2.Location = new Point(-256, -32);

            // Panel_Layer <- Layer1
            Panel_Layer1.Controls.Add(Layer1);
            Layer1.Size = new Size(0, 0);

            // Set TreeView
            ListDirectory(treeView1, @"Maps");

            // Set ToolStrip Set
            ToolStrip_MapName.Text = "";
            ToolStrip_LayerArray.Text = "          ";
            toolStripButton_Layer1.Checked = true;

            // Set Menustrip & Toolstrip border color
            menuStrip1.Renderer = new ToolStripProfessionalRenderer(new TestColorTable());
            toolStrip1.Renderer = new MySR();

            // Event Handler
            this.FormClosed += MainForm_FormClosed; // Map Data auto Save
        }

        ///<summary>
        /// 좌측의 ChipSet을 담당하는 부분이다.
        ///</summary>

        #region ChipSet

        // ChipSet - MouseDown
        private void ChipSet_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (g != null && Menu_isopen == 0)
            {
                int Arr_x, Arr_y;

                MouseState_ChipSet = 1;

                Selector1.Size = new Size(TileSize, TileSize);
                Selector2.Size = new Size(TileSize, TileSize);

                // Determine the initial rectangle coordinates...
                RectStartPoint = e.Location;
                Invalidate();

                Arr_x = RectStartPoint.X / TileSize;
                Arr_y = RectStartPoint.Y / TileSize;

                // Set Mouser Start Point
                ChipSet_StartMousePoint = new Point(Arr_x, Arr_y);

                // Move Selector
                Selector1.Location = new Point(Arr_x * TileSize, Arr_y * TileSize);

                // LayerMode에 따라서 모드를 다르게 해준다.
                if (LayerMode == 1) // Layer1
                    g.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
                else // Layer 2
                {
                    g.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceOver;
                    g3.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceOver;
                }

                if (toolStripButton_Eraser.Checked)
                {
                    toolStripButton_Eraser.Checked = false;

                    MapImageLoad();
                }
            }
        }

        // ChipSet - MouseUp
        private void ChipSet_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (g != null && Menu_isopen == 0)
            {
                int Arr_x, Arr_y;

                MouseState_ChipSet = 0;

                // Determine the initial rectangle coordinates...
                RectStartPoint = e.Location;
                Invalidate();

                Arr_x = RectStartPoint.X / TileSize;
                Arr_y = RectStartPoint.Y / TileSize;

                // Outer SIze
                if (Arr_x >= ChipSet.Width / TileSize)
                    Arr_x = ChipSet.Width / TileSize - 1;

                if (Arr_x < 0)
                    Arr_x = 0;

                if (Arr_y >= ChipSet.Height / TileSize)
                    Arr_y = ChipSet.Width / TileSize - 1;

                if (Arr_y < 0)
                    Arr_y = 0;

                // Select Tile
                int div_x = 0, div_y = 0;
                int di_x = 0, di_y;

                if (Arr_x - ChipSet_StartMousePoint.X >= 0)
                {
                    div_x = Arr_x - ChipSet_StartMousePoint.X + 1;
                    di_x = 0;
                }
                else
                {
                    div_x = ChipSet_StartMousePoint.X - Arr_x + 1;
                    di_x = 1;
                }

                if (Arr_y - ChipSet_StartMousePoint.Y >= 0)
                {
                    div_y = Arr_y - ChipSet_StartMousePoint.Y + 1;
                    di_y = 0;
                }
                else
                {
                    div_y = ChipSet_StartMousePoint.Y - Arr_y + 1;
                    di_y = 1;
                }

                // Chipset Data
                ChipsetData = new string[div_y, div_x];
                Point startP = new Point(0, 0);

                Rectangle srcRect = new Rectangle(ChipSet_StartMousePoint.X * TileSize, ChipSet_StartMousePoint.Y * TileSize,
                    div_x * TileSize, div_y * TileSize);

                if (di_x == 0 && di_y == 0) // 오른쪽 아래로 드래그
                {
                    Selector1.Size = new Size(div_x * TileSize, div_y * TileSize);

                    srcRect = new Rectangle(ChipSet_StartMousePoint.X * TileSize, ChipSet_StartMousePoint.Y * TileSize,
                    div_x * TileSize, div_y * TileSize);

                    startP = new Point(ChipSet_StartMousePoint.X, ChipSet_StartMousePoint.Y);
                }

                if (di_x == 1 && di_y == 0) // 왼쪽 아래로 드래그
                {
                    Selector1.Location = new Point(Arr_x * TileSize, ChipSet_StartMousePoint.Y * TileSize);
                    Selector1.Size = new Size(div_x * TileSize, div_y * TileSize);

                    srcRect = new Rectangle(Arr_x * TileSize, ChipSet_StartMousePoint.Y * TileSize,
                    div_x * TileSize, div_y * TileSize);

                    startP = new Point(Arr_x, ChipSet_StartMousePoint.Y);
                }

                if (di_x == 0 && di_y == 1) // 오른쪽 위로 드래그
                {
                    Selector1.Location = new Point(ChipSet_StartMousePoint.X * TileSize, Arr_y * TileSize);
                    Selector1.Size = new Size(div_x * TileSize, div_y * TileSize);

                    srcRect = new Rectangle(ChipSet_StartMousePoint.X * TileSize, Arr_y * TileSize,
                    div_x * TileSize, div_y * TileSize);

                    startP = new Point(ChipSet_StartMousePoint.X, Arr_y);
                }

                if (di_x == 1 && di_y == 1) // 왼쪽 위로 드래그
                {
                    Selector1.Location = new Point(Arr_x * TileSize, Arr_y * TileSize);
                    Selector1.Size = new Size(div_x * TileSize, div_y * TileSize);

                    srcRect = new Rectangle(Arr_x * TileSize, Arr_y * TileSize,
                    div_x * TileSize, div_y * TileSize);

                    startP = new Point(Arr_x, Arr_y);
                }

                cropped = (Bitmap)TileSet.Clone(srcRect, TileSet.PixelFormat);

                // 선택된 영역의 TilessetData를 ChipsetData 배열에 저장한다.
                if (TilesetData != null)
                {
                    for (int i = 0; i < div_y; i++)
                    {
                        for (int k = 0; k < div_x; k++)
                            ChipsetData[i, k] = TilesetData[(startP.Y + i) * 8 + startP.X + k];
                    }
                }
            }
        }

        // ChipSet - MouseMove
        private void ChipSet_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (g != null && Menu_isopen == 0)
            {
                Selector2.Location = new Point(-256, 0);

                if (MouseState_ChipSet == 1 && e.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    int Arr_x, Arr_y;

                    // Determine the initial rectangle coordinates...
                    RectStartPoint = e.Location;
                    Invalidate();

                    Arr_x = RectStartPoint.X / TileSize;
                    Arr_y = RectStartPoint.Y / TileSize;

                    // Select Tile
                    int div_x = Arr_x - ChipSet_StartMousePoint.X + 1;
                    int div_y = Arr_y - ChipSet_StartMousePoint.Y + 1;

                    // Select Tile
                    int di_x = 0;
                    int di_y = 0;

                    if (Arr_x - ChipSet_StartMousePoint.X >= 0)
                    {
                        div_x = Arr_x - ChipSet_StartMousePoint.X + 1;
                        di_x = 0;
                    }
                    else
                    {
                        div_x = ChipSet_StartMousePoint.X - Arr_x + 1;
                        di_x = 1;
                    }

                    if (Arr_y - ChipSet_StartMousePoint.Y >= 0)
                    {
                        div_y = Arr_y - ChipSet_StartMousePoint.Y + 1;
                        di_y = 0;
                    }
                    else
                    {
                        div_y = ChipSet_StartMousePoint.Y - Arr_y + 1;
                        di_y = 1;
                    }

                    if (di_x == 0 && di_y == 0) // 오른쪽 아래로 드래그
                    {
                        Selector1.Size = new Size(div_x * TileSize, div_y * TileSize);
                        Selector2.Size = new Size(div_x * TileSize, div_y * TileSize);
                    }

                    if (di_x == 1 && di_y == 0) // 왼쪽 아래로 드래그
                    {
                        Selector1.Location = new Point(Arr_x * TileSize, ChipSet_StartMousePoint.Y * TileSize);
                        Selector1.Size = new Size(div_x * TileSize, div_y * TileSize);
                        Selector2.Size = new Size(div_x * TileSize, div_y * TileSize);
                    }

                    if (di_x == 0 && di_y == 1) // 오른쪽 위로 드래그
                    {
                        Selector1.Location = new Point(ChipSet_StartMousePoint.X * TileSize, Arr_y * TileSize);
                        Selector1.Size = new Size(div_x * TileSize, div_y * TileSize);
                        Selector2.Size = new Size(div_x * TileSize, div_y * TileSize);
                    }

                    if (di_x == 1 && di_y == 1) // 왼쪽 위로 드래그
                    {
                        Selector1.Location = new Point(Arr_x * TileSize, Arr_y * TileSize);
                        Selector1.Size = new Size(div_x * TileSize, div_y * TileSize);
                        Selector2.Size = new Size(div_x * TileSize, div_y * TileSize);
                    }
                }
            }
        }

        #endregion


        ///<summary>
        /// 우측의 Layer를 담당하는 부분이다.
        ///</summary>

        #region Layer

        // Layer - MouseDown
        private void Layer1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (Menu_isopen == 0)
            {
                int Arr_x, Arr_y;

                // Change Mouse state         
                Panel_Layer1.Focus();
                MouseState_Layer = 1;

                // Get Map Tile
                if (e.Button == System.Windows.Forms.MouseButtons.Right && MapPath!=null)
                {
                    RectStartPoint2 = e.Location;
                    Invalidate();

                    Arr_x = RectStartPoint2.X / TileSize;
                    Arr_y = RectStartPoint2.Y / TileSize;

                    if (LayerMode == 1)
                    {
                        Rectangle srcRect = new Rectangle(Arr_x * TileSize, Arr_y * TileSize, TileSize, TileSize);
                        cropped = (Bitmap)Savebm.Clone(srcRect, Savebm.PixelFormat);
                        Selector2.Size = new Size(32, 32);
                        ShowMessage("         타일 복사");
                        toolStripButton_Eraser.Checked = false;
                    }
                }

                if (e.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    RectStartPoint2 = e.Location;
                    Invalidate();

                    Arr_x = RectStartPoint2.X / TileSize;
                    Arr_y = RectStartPoint2.Y / TileSize;

                    // Set Mouser Start Point
                    Layer1_StartMouserPoint = new Point(Arr_x, Arr_y);

                    Point pt = new Point();
                    pt.X = Arr_x * TileSize;
                    pt.Y = Arr_y * TileSize;

                    // Draw Selected Tile
                    if (cropped != null)
                    {
                        if (LayerMode == 1) // Layer1
                        {
                            cropped = Transparent2Color(cropped, Color.White);
                            g2.DrawImage(cropped, pt);
                        }
                        else // Layer2
                        {
                            g3.DrawImage(cropped, pt);
                        }

                        if (toolStripButton_Eraser.Checked == false)
                            g.DrawImage(cropped, pt);
                        else
                        {
                            Bitmap black = Properties.Resources.black;
                            g.DrawImage(black, pt);
                            black.Dispose();
                        }
                        Layer1.Refresh();

                        // Map 데이터를 배열에만 저장 시켜준다. - .dat 파일은 저장 버튼을 누를시
                        if (toolStripButton_Layer2.Checked == true)
                        {
                            if (toolStripButton_Eraser.Checked == false && TilesetData != null)  // 지우개 모드가 아닌 경우
                            {
                                for (int i = 0; i < cropped.Height / 32; i++)
                                {
                                    for (int k = 0; k < cropped.Width / 32; k++)
                                        if (Layer1_StartMouserPoint.X >= 0 && Layer1_StartMouserPoint.Y >= 0)
                                            if (Layer1_StartMouserPoint.Y + i < Layer1.Height / 32 && Layer1_StartMouserPoint.X + k < Layer1.Width / 32 && ChipsetData[i, k].Contains("X"))
                                                MapData[(Layer1_StartMouserPoint.Y + i) * Layer1.Width / 32 + Layer1_StartMouserPoint.X + k] = ChipsetData[i, k];
                                }
                            }
                            else  // 지우개 모드인 경우
                            {
                                for (int i = 0; i < cropped.Height / 32; i++)
                                {
                                    for (int k = 0; k < cropped.Width / 32; k++)
                                        MapData[(Layer1_StartMouserPoint.Y + i) * Layer1.Width / 32 + Layer1_StartMouserPoint.X + k] = "U";
                                }
                            }
                        }
                    }
                }
            }
        }

        // Layer - MouseUp
        private void Layer1_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (Menu_isopen == 0 && e.Button == System.Windows.Forms.MouseButtons.Left && MapPath != null)
            {
                // Change Mouse state            
                MouseState_Layer = 0;

                // Layer1에 저장
                if (LayerMode == 1)
                {
                    Bitmap bmpp = new Bitmap(Savebm);
                    bmpp.Save(@"Maps\" + MapPath, ImageFormat.Png);
                    bmpp.Dispose();
                }
                else if (LayerMode == 2)
                {
                    // Layer2에 저장
                    Bitmap bmpp2 = new Bitmap(Savebm2);
                    bmpp2.Save(@"Maps\" + MapPath2, ImageFormat.Png);
                    bmpp2.Dispose();
                }

                if (toolStripButton_Eraser.Checked == true)
                {
                    Bitmap Load3 = new Bitmap(@"Maps\" + MapPath2);
                    Drawing = new Bitmap(Load3);
                    Layer1.Image = Drawing;
                    g = Graphics.FromImage(Drawing);
                    Load3.Dispose();
                }
            }
        }

        // Layer - MouseMove
        private void Layer1_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (Menu_isopen == 0 && MapPath != null)
            {
                int Arr_x, Arr_y;

                // Determine the initial rectangle coordinates...
                RectStartPoint = e.Location;
                Invalidate();

                Arr_x = RectStartPoint.X / TileSize;
                Arr_y = RectStartPoint.Y / TileSize;

                ToolStrip_LayerArray.Text = "(" + Arr_x + "," + Arr_y + ")";
                Selector2.Location = new Point(Arr_x * TileSize, Arr_y*TileSize);

                // If Left Mouse is Pushed?
                if (MouseState_Layer == 1)
                {
                    if (e.Button == System.Windows.Forms.MouseButtons.Left)
                    {
                        if (cropped != null)
                        {
                            Point pt = new Point(Arr_x * TileSize, Arr_y * TileSize);

                            if (LayerMode == 1)
                                g2.DrawImage(cropped, pt);
                            else
                                g3.DrawImage(cropped, pt);

                            if (toolStripButton_Eraser.Checked == false)                            
                                g.DrawImage(cropped, pt);
                            else
                            {
                                Bitmap black = Properties.Resources.black;
                                g.DrawImage(black, pt);
                                black.Dispose();
                            }
                            Layer1.Refresh();
                        }
                    }

                    // Map 데이터를 배열에만 저장 시켜준다. - .txt 파일은 저장 버튼을 누를시
                    if (cropped != null && toolStripButton_Layer2.Checked == true)
                    {
                        if (toolStripButton_Eraser.Checked == false && TilesetData != null) // 지우개 모드가 아닌 경우
                        {
                            for (int i = 0; i < cropped.Height / 32; i++)
                            {
                                for (int k = 0; k < cropped.Width / 32; k++)
                                    if (Arr_y >= 0 && Arr_x >= 0)
                                        if (Arr_y + i < Layer1.Height / 32 && Arr_x + k < Layer1.Width / 32 && ChipsetData[i, k].Contains("X"))
                                            MapData[(Arr_y + i) * Layer1.Width / 32 + Arr_x + k] = ChipsetData[i, k];
                            }
                        }
                        else  // 지우개 모드인 경우
                        {
                            try
                            {
                                for (int i = 0; i < cropped.Height / 32; i++)
                                {
                                    for (int k = 0; k < cropped.Width / 32; k++)
                                        if (Arr_y + i < Layer1.Height / 32 && Arr_x + k < Layer1.Width / 32)
                                            MapData[(Arr_y + i) * Layer1.Width / 32 + Arr_x + k] = "U";
                                }
                            }
                            catch { }
                        }
                    }
                }
            }
        }

        #endregion


        // Map Data를 Loading한다.
        private void MapImageLoad()
        {
            if (g != null)
            {
                // 맵 로딩에 오류 생길 경우
                Bitmap Load = new Bitmap(@"Maps\" + MapPath);
                // Set Toolstriplabel
                if (Load.Width != Layer1.Width || Load.Height != Layer1.Height)
                {
                    Layer1.Image = null;
                    string[] spear = { ".png" };
                    string[] words = MapPath.Split(spear, StringSplitOptions.RemoveEmptyEntries);

                    ToolStrip_MapName.Text = "Map : " + words[0] + "  (" + Load.Width / TileSize + " x " + Load.Height / TileSize + ")";
                    Layer1.Size = new Size(Load.Width, Load.Height);
                }
                Load.Dispose();

                ScreenShotSave();

                // Load Layer1
                if (LayerMode == 1)
                {
                    Bitmap Load3 = new Bitmap(@"Maps\" + MapPath);
                    Drawing = new Bitmap(Load3);
                    Layer1.Image = Drawing;
                    g = Graphics.FromImage(Drawing);
                    Load3.Dispose();
                }

                // Load Layer2
                else
                {
                    // 지우개를 클릭 할경우 Layer2만 띄워준다.
                    if (toolStripButton_Eraser.Checked == true)
                    {
                        Bitmap Load3 = new Bitmap(@"Maps\" + MapPath2);
                        Drawing = new Bitmap(Load3);
                        Layer1.Image = Drawing;
                        g = Graphics.FromImage(Drawing);
                        Load3.Dispose();

                        //using (FileStream fs = new FileStream(@"Maps\" + MapPath2, FileMode.Open, FileAccess.Read))
                        //{
                        //    using (Image original = Image.FromStream(fs))
                        //    {
                        //        Layer1.Image = new Bitmap(original);
                        //    }
                        //}
                    }

                    // 지우개 모드가 아닌경우 Layer1 + Layer2를 화면에 띄워준다.
                    else
                    {
                        Bitmap Load3 = new Bitmap(@"Screenshot\" + MapPath);
                        Drawing = new Bitmap(Load3);
                        Layer1.Image = Drawing;
                        g = Graphics.FromImage(Drawing);
                        Load3.Dispose();
                    }
                }
            }
        }

        // Set Tile background 
        Bitmap Transparent2Color(Bitmap bmp1, Color target)
        {
            Bitmap bmp2 = new Bitmap(bmp1.Width, bmp1.Height);
            Rectangle rect = new Rectangle(Point.Empty, bmp1.Size);
            using (Graphics G = Graphics.FromImage(bmp2))
            {
                G.Clear(target);
                G.DrawImageUnscaledAndClipped(bmp1, rect);
            }
            return bmp2;
        }

        // Treeview에 특정 Directory의 리스트를 가져온다.
        #region Treeview Directory List

        // Get Directory File Lists
        private void ListDirectory(TreeView treeView, string path)
        {
            treeView.Nodes.Clear();
            var rootDirectoryInfo = new DirectoryInfo(path);
            treeView.Nodes.Add(CreateDirectoryNode(rootDirectoryInfo));
       
        }

        private TreeNode CreateDirectoryNode(DirectoryInfo directoryInfo)
        {
            var directoryNode = new TreeNode(directoryInfo.Name);

            ImageList imgList = new ImageList();
            Bitmap Icon1 = new Bitmap(Properties.Resources.Icon_folder);
            Bitmap Icon2 = new Bitmap(Properties.Resources.Icon_file2);
            Bitmap Icon3 = new Bitmap(Properties.Resources.Icon_file2_se);
            imgList.Images.Add(Icon1);
            imgList.Images.Add(Icon2);
            imgList.Images.Add(Icon3);
            treeView1.ImageList = imgList;

            foreach (var directory in directoryInfo.GetDirectories())
                directoryNode.Nodes.Add(CreateDirectoryNode(directory));
            foreach (var file in directoryInfo.GetFiles())
            {
                if (file.Name.Contains(".png") && !file.Name.Contains("layer2"))
                {
                    string[] spear = {".png"};
                    string[] words = file.Name.Split(spear, StringSplitOptions.RemoveEmptyEntries);
                    directoryNode.Nodes.Add(words[0], words[0], 1, 2);
                    directoryNode.ExpandAll();
                }
            }
            return directoryNode;
        }

        #endregion


        // Map의 선택 파일 변경
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            ScreenShotSave();
            MapDataSave();

            string Select_file = treeView1.SelectedNode.ToString();
            
            if (!Select_file.Equals("TreeNode: Maps"))
            {
                string[] spear = { "TreeNode: " };
                string[] words = Select_file.Split(spear, StringSplitOptions.RemoveEmptyEntries);

                // Set MapPath
                MapPath = words[0] + ".png";
                MapPath2 = words[0] + "_layer2.png";

                // Map Load
                try
                {
                    // Layer1 Size
                    Layer1.Image = null; // 이거 안해주면, 큰 Layer1에 작은 Bitmap을 new로 생성해주면 그 안에 새로 생성이됨..
                    Bitmap Load = new Bitmap(@"Maps\" + words[0] + ".png");
                    Layer1.Size = new Size(Load.Width, Load.Height);
                    Load.Dispose();

                    MapLoad();

                    // Set Toolstriplabel
                    ToolStrip_MapName.Text = "Map : " + words[0] + "  (" + Layer1.Width / TileSize + " x " + Layer1.Height / TileSize + ")";
                    toolStripButton_Layer1.Checked = false;
                    toolStripButton_Layer2.Checked = true;
                    LayerMode = 2;
                    toolStripButton_Eraser.Checked = false;

                    // Map Data Load
                    MapDataLoad(words[0]);
                }
                catch
                {
                    MessageBox.Show("삭제된 파일 입니다.");
                    ListDirectory(treeView1, @"Maps");
                }
            }
        }

        // Map Load
        private void MapLoad()
        {
            // Layer1에 대한 로드
            Bitmap Load = new Bitmap(@"Maps\" + MapPath);
            Savebm = new Bitmap(Load);
            g2 = Graphics.FromImage(Savebm);
            Load.Dispose();

            // Layer2에 대한 로드
            Bitmap Load2 = new Bitmap(@"Maps\" + MapPath2);
            Savebm2 = new Bitmap(Load2);
            g3 = Graphics.FromImage(Savebm2);
            Load2.Dispose();

            try // Screenshot 폴더에 파일이 제대로 있는 경우
            {
                Bitmap Load3 = new Bitmap(@"Screenshot\" + MapPath);
                Drawing = new Bitmap(Load3);
                Layer1.Image = Drawing;
                g = Graphics.FromImage(Drawing);
                Load3.Dispose();
            }

            catch // Screenshot 폴더에 파일이 사라진 경우
            {          
                // Layer1 + Layer2 => Screenshot에 저장
                ScreenShotSave();

                // Layer1 + Layer2 (Screenshot) 파일 Layer에 로딩
                Drawing = new Bitmap(@"Screenshot\" + MapPath);
                Layer1.Image = Drawing;
                g = Graphics.FromImage(Drawing);
            }
        }

        // ScreenShot .png file Save
        private void ScreenShotSave()
        {
            if (Savebm != null && Savebm2 != null)
            {
                try
                {
                    // Layer1 + Layer2 => Screenshot에 저장
                    Bitmap Image2 = new Bitmap(Layer1.Width, Layer1.Height);
                    Graphics gh = Graphics.FromImage(Image2);

                    gh.DrawImage(Savebm, new Point(0, 0));
                    gh.DrawImage(Savebm2, new Point(0, 0));

                    Image2.Save(@"Screenshot\" + MapPath);
                    Image2.Dispose();
                }
                catch
                {
                   // ShowMessage(" 스샷 저장 실패");
                }
            }
        }

        // Map Data Load
        private void MapDataLoad(string FileName)
        {
            // 마지막 세미콜론을 붙여주기 때문에 배열크기를 하나 더 늘린다
            MapData = new string[Layer1.Width / 32 * Layer1.Height / 32 + 1];

            try
            {
                // Get Tileset Data char by char
                int count = 0;
                string path = @"Map Data\" + FileName + ".txt";
                string Data = File.ReadAllText(path);

                foreach (char c in Data)
                {
                    MapData[count] = c.ToString();
                    count++;
                }
            }
            catch
            {
                for (int i = 0; i < Layer1.Width / 32 * Layer1.Height / 32; i++)
                    MapData[i] = "U";
            }
        }


        ///<summary>
        /// 상위 첫 번째 라인 메뉴들
        ///</summary>
        ///

        #region Menu Strip Buttons


        private void 새로운맵ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Menu_isopen == 0)
            {
                NewMap Form = new NewMap();
                Form.StartPosition = FormStartPosition.Manual;
                Form.Location = new Point(this.Left + this.ClientSize.Width / 2 - 120, this.Top + this.ClientSize.Height / 2 - 120);
                Form.Owner = this;
                Form.Show();
                Menu_isopen = 1;
            }
        }

        private void 타일셋ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Menu_isopen == 0)
            {
                TilesetSelect Form = new TilesetSelect();
                Form.StartPosition = FormStartPosition.Manual;
                Form.Location = new Point(this.Left + this.ClientSize.Width / 2 - 60, this.Top + this.ClientSize.Height / 2 - 60);
                Form.Show();
                Form.Owner = this;
                Menu_isopen = 1;
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (Menu_isopen == 0 && g != null && g2 != null && MapPath != null)
            {
                Panorama Form = new Panorama();
                Form.StartPosition = FormStartPosition.Manual;
                Form.Location = new Point(this.Left + this.ClientSize.Width / 2 - 60, this.Top + this.ClientSize.Height / 2 - 60);
                Form.Show();
                Form.Owner = this;
                Menu_isopen = 1;
            }
        }

        private void 타일셋데이터셋팅ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Menu_isopen == 0)
            {
                if (TilesetName != null)
                {
                    TilesetSetting Form = new TilesetSetting();
                    Form.StartPosition = FormStartPosition.Manual;
                    Form.Location = new Point(this.Left + this.ClientSize.Width / 2 - 130, this.Top + this.ClientSize.Height / 2 - 290);
                    Form.Show();
                    Form.Owner = this;
                    Form.TilesetLoad(TilesetName);
                    Menu_isopen = 1;
                }
                else
                    MessageBox.Show("타일셋을 먼저 선택해 주세요.");
            }
        }

        private void 맵데이터저장ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MapDataSave();

            ShowMessage("         맵정보 저장");
        }

        private void 도움ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Menu_isopen == 0)
            {
                Help Form = new Help();
                Form.StartPosition = FormStartPosition.Manual;
                Form.Location = new Point(this.Left + this.ClientSize.Width / 2 - 120, this.Top + this.ClientSize.Height / 2 - 120);
                Form.Owner = this;
                Form.Show();
                Menu_isopen = 1;
            }
        }


        #endregion


        ///<summary>
        /// 상위 두 번째 라인 메뉴 버튼 아이콘
        ///</summary>
        ///

        #region Tool Strip Buttons

        // ToolStripButton - New Map
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (Menu_isopen == 0)
            {
                NewMap Form = new NewMap();
                Form.StartPosition = FormStartPosition.Manual;
                Form.Location = new Point(this.Left + this.ClientSize.Width / 2 - 120, this.Top + this.ClientSize.Height / 2 - 120);
                Form.Owner = this;
                Form.Show();
                Menu_isopen = 1;
            }
        }

        // Tool Strip Button - Tileset Select
        private void toolStripButton_Tile_Click(object sender, EventArgs e)
        {
            if (Menu_isopen == 0)
            {
                TilesetSelect Form = new TilesetSelect();
                Form.StartPosition = FormStartPosition.Manual;
                Form.Location = new Point(this.Left + this.ClientSize.Width / 2 - 60, this.Top + this.ClientSize.Height / 2 - 60);
                Form.Show();
                Form.Owner = this;
                Menu_isopen = 1;
            }
        }

        // Tool Strip Button - Tileset Setting
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (Menu_isopen == 0)
            {
                if (TilesetName != null)
                {
                    TilesetSetting Form = new TilesetSetting();
                    Form.StartPosition = FormStartPosition.Manual;
                    Form.Location = new Point(this.Left + this.ClientSize.Width / 2 - 130, this.Top + this.ClientSize.Height / 2 - 290);
                    Form.Show();
                    Form.Owner = this;
                    Form.TilesetLoad(TilesetName);
                    Menu_isopen = 1;
                }
                else
                    MessageBox.Show("타일셋을 먼저 선택해 주세요.");
            }
        }

        // Tool Strip Button - Select Pamorama
        private void toolStripButton_pamorama_Click(object sender, EventArgs e)
        {
            if (Menu_isopen == 0 && g != null && g2 != null && MapPath != null)
            {
                Panorama Form = new Panorama();
                Form.StartPosition = FormStartPosition.Manual;
                Form.Location = new Point(this.Left + this.ClientSize.Width / 2 - 60, this.Top + this.ClientSize.Height / 2 - 60);
                Form.Show();
                Form.Owner = this;
                Menu_isopen = 1;
            }
        }

        // Tool Strip Button - Map Data Save
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            MapDataSave();

            ShowMessage("         맵정보 저장");
        }
        private void MapDataSave()
        {
            if (MapPath != null)
            {
                string[] spear = { ".png" };
                string[] words = MapPath.Split(spear, StringSplitOptions.RemoveEmptyEntries);
                string FileDatapath = @"Map Data\" + words[0] + ".txt";

                // Text FIie - Tileset Data Save
                string Datastring = "";

                for (int i = 0; i < Layer1.Height / 32 * Layer1.Width / 32; i++)
                    Datastring += MapData[i];
                Datastring += ";";

                System.IO.File.WriteAllText(FileDatapath, Datastring);
            }
        }

        // Tool Strip Button - Eraser
        private void toolStripButton_Eraser_Click(object sender, EventArgs e)
        {
            if (g != null)
            {
                Bitmap Eraser = new Bitmap(TileSize, TileSize);
                Rectangle srcRect = new Rectangle(0, 0, TileSize, TileSize);

                cropped = (Bitmap)Eraser.Clone(srcRect, Eraser.PixelFormat);

                g.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
                g3.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;

                Selector1.Size = new Size(32, 32);
                Selector2.Size = new Size(32, 32);
                Selector1.Location = new Point(-32, -32);

                toolStripButton_Eraser.Checked = true;
                Eraser.Dispose();

                MapImageLoad();

                if(ChipsetData == null)
                    ChipsetData = new string[1, 1];

                ShowMessage("         지우개 모드");
            }
        }

        // Click Menu Button - Paint
        private void toolStripButton_Paint_Click(object sender, EventArgs e)
        {
            if (cropped != null && g != null)
            {
                for (int i = 0; i < Layer1.Height / TileSize; i++)
                {
                    for (int k = 0; k < Layer1.Width / TileSize; k++)
                    {
                        Point pt = new Point(k * cropped.Width, i * cropped.Height);
                        g.DrawImage(cropped, pt);

                        if(LayerMode == 1) // Layer1
                            g2.DrawImage(cropped, pt);
                        else // Layer2
                            g3.DrawImage(cropped, pt);

                        // Map 데이터를 배열에만 저장 시켜준다. - .dat 파일은 저장 버튼을 누를시
                        if (toolStripButton_Eraser.Checked == false && TilesetData != null) // 지우개 모드가 아닌 경우
                        {
                            for (int p = 0; p < cropped.Height / 32; p++)
                            {
                                for (int t = 0; t < cropped.Width / 32; t++)
                                  if (pt.Y / 32 >= 0 && pt.X / 32 >= 0)
                                   if (pt.Y / 32 + p < Layer1.Height / 32 && pt.X / 32 + t < Layer1.Width / 32 && ChipsetData[p, t].Contains("X"))
                                    MapData[(pt.Y/32 + p) * Layer1.Width / 32 + pt.X/32 + t] = ChipsetData[p, t];
                            }
                        }
                        else
                        {
                            for (int p = 0; p < cropped.Height / 32; p++)
                            {
                                for (int t = 0; t < cropped.Width / 32; t++)
                                    MapData[(pt.Y / 32 + p) * Layer1.Width / 32 + pt.X / 32 + t] = "U";
                            }
                        }
                    }
                }

                // Layer1 저장
                Bitmap bmpp = new Bitmap(Savebm);
                bmpp.Save(@"Maps\" + MapPath, ImageFormat.Png);
                bmpp.Dispose();

                // Layer2에 저장
                Bitmap bmpp2 = new Bitmap(Savebm2);
                bmpp2.Save(@"Maps\" + MapPath2, ImageFormat.Png);
                bmpp2.Dispose();

                // Layer1 + Layer2 : screentshot
                ScreenShotSave();

                if(toolStripButton_Eraser.Checked == false)
                     ShowMessage("            페인트");
                else 
                {
                    toolStripButton_Eraser.Checked = false;
                    ShowMessage("          맵 클리어");
                    cropped = null;
                }

                // 맵을 재 로딩한다.
                MapImageLoad();
            }
        }

        // ToolStripButton - Layer1
        private void toolStripButton_Layer1_Click(object sender, EventArgs e)
        {
            if (g != null)
            {
                LayerMode = 1;
                g.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
                cropped = null;
                Selector1.Size = new Size(TileSize, TileSize);
                Selector1.Location = new Point(-32, -32);

                toolStripButton_Layer1.Checked = true;
                toolStripButton_Layer2.Checked = false;
                toolStripButton_Eraser.Checked = false;

                MapImageLoad();
            }
        }

        // ToolStripButton - Layer2
        private void toolStripButton_Layer2_Click(object sender, EventArgs e)
        {
            if (g != null)
            {
                LayerMode = 2;
                g.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceOver;
                cropped = null;
                Selector1.Size = new Size(TileSize, TileSize);
                Selector1.Location = new Point(-32, -32);

                toolStripButton_Layer1.Checked = false;
                toolStripButton_Layer2.Checked = true;
                toolStripButton_Eraser.Checked = false;

                Layer1.Image = null;

                MapImageLoad();
            }
        }

        // Map Data Simulation
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            if (Menu_isopen == 0 && MapPath != null)
            {
                MapDataSave();
                ScreenShotSave();

                ShowMessage("         맵정보 저장");

                string[] spear = { ".png" };
                string[] words = MapPath.Split(spear, StringSplitOptions.RemoveEmptyEntries);

                MapDataSimulation Form = new MapDataSimulation();
                Form.StartPosition = FormStartPosition.Manual;
                Form.Location = new Point(this.Left + this.ClientSize.Width / 2 - 290, this.Top + this.ClientSize.Height / 2 - 240);
                Form.Show();
                Form.Owner = this;
                Form.TilesetLoad(words[0]);
                Menu_isopen = 1;
            }
        }

        // Menu Button - Refresh
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (g != null && g2 != null)
            {
                MapImageLoad();
                ShowMessage("           Refresh");
            }
        }

        #endregion


        ///<summary>
        /// 다른 Sub Form으로 부터 호출되는 함수
        ///</summary>
        ///

        #region Called by Other Forms

        // Title이 먼저 뜬 후 MapEditor를 띄워준다 : Called by TitleForm
        public void EditorShow()
        {
            this.Opacity = 1;
        }

        // 새 맵을 작성 후, FileList를 Refresh 해준다 : Called by NewMap Form
        public void RefreshFileList()
        {
            ListDirectory(treeView1, @"Maps");
            ShowMessage("          새 맵 작성");
        }

        // Tileset Changed : Called by TilesetSelect Form
        public void TilesetChanged(string FileName)
        {
            cropped = null;
            Selector1.Size = new Size(32, 32);
            Selector1.Location = new Point(-32, -32);

            TileSet = new Bitmap(@"Tilesets\" + FileName + ".png");
            TilesetName = FileName;
            ChipSet.Image = TileSet;
            ChipSet.Size = new System.Drawing.Size(256, TileSet.Height / TileSize * TileSize);

            // TIleset Data Load
            try
            {
                // Get Tileset Data char by char
                int count = 0;
                string path = @"Tilesets\Tileset Data\" + TilesetName + ".txt";
                string Data = File.ReadAllText(path);
                TilesetData = new string[TileSet.Height / 32 * 8];

                foreach (char c in Data)
                {
                    TilesetData[count] = c.ToString();
                    count++;
                }
            }
            catch
            {
                TilesetData = null;
            }
        }

        // 타일셋 데이터가 바뀐경우 타일셋이 변경된것과 똑같게 현재 타일셋을 리로드 해준다.
        public void TilesetDataChanged()
        {
            cropped = null;
            Selector1.Size = new Size(32, 32);
            Selector1.Location = new Point(-32, -32);

            TileSet = new Bitmap(@"Tilesets\" + TilesetName + ".png");
            ChipSet.Image = TileSet;
            ChipSet.Size = new System.Drawing.Size(256, TileSet.Height / TileSize * TileSize);

            // TIleset Data Load
            try
            {
                // Get Tileset Data char by char
                int count = 0;
                string path = @"Tilesets\Tileset Data\" + TilesetName + ".txt";
                string Data = File.ReadAllText(path);
                TilesetData = new string[TileSet.Height / 32 * 8];

                foreach (char c in Data)
                {
                    TilesetData[count] = c.ToString();
                    count++;
                }
            }
            catch
            {
                TilesetData = null;
            }
        }

        // 파노라마를 선택한 경우
        public void PanoramaFile(string FileName)
        {
            // 파노라마 이미지 그리기
            Bitmap panoramaImg = new Bitmap(@"Panorama\" + FileName);
            g2.DrawImage(panoramaImg, new Point(0, 0));
            MapImageLoad();
            panoramaImg.Dispose();

            // Layer1 이미지 데이터 저장
            Bitmap bmpp = new Bitmap(Savebm);
            bmpp.Save(@"Maps\" + MapPath, ImageFormat.Png);
            bmpp.Dispose();

            Layer1.Refresh();
        }

        #endregion


        ///<summary>
        /// Form1의 부가적인 시스템들
        ///</summary>
        ///

        #region System

        // Show Message : MessageForm
        private void ShowMessage(string text)
        {
            MessageForm mf = new MessageForm();
            mf.MinimumSize = new Size(150, 25);
            mf.Size = new Size(150, 25);
            mf.MakeMessage(text);
            mf.Show();
            mf.Location = new Point(this.Left + this.ClientSize.Width / 2 + 70, this.Top + this.ClientSize.Height / 2 - 220);

            Panel_Layer1.Focus();
        }

        // Auto MessageBox Close 사용 예시 : AutoClosingMessageBox.Show("Loading...", "MapEditor", 10);
        public class AutoClosingMessageBox
        {
            System.Threading.Timer _timeoutTimer;
            string _caption;
            AutoClosingMessageBox(string text, string caption, int timeout)
            {
                _caption = caption;
                _timeoutTimer = new System.Threading.Timer(OnTimerElapsed,
                    null, timeout, System.Threading.Timeout.Infinite);
                MessageBox.Show(text, caption);
            }
            public static void Show(string text, string caption, int timeout)
            {
                new AutoClosingMessageBox(text, caption, timeout);
            }
            void OnTimerElapsed(object state)
            {
                IntPtr mbWnd = FindWindow("#32770", _caption); // lpClassName is #32770 for MessageBox
                if (mbWnd != IntPtr.Zero)
                    SendMessage(mbWnd, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
                _timeoutTimer.Dispose();
            }
            const int WM_CLOSE = 0x0010;
            [System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true)]
            static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
            [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
            static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);
        }

        // MainForm Closed?
        public void MainForm_FormClosed(object sender, EventArgs e)
        {
            MapDataSave();
            ScreenShotSave();
        }

        #endregion


        #region 안쓰지만 필요한 System

        // Override  ToolStrip & MenuStrip Border Color : 툴 스트립, 메뉴 스트립의 unerline border 흰색을 지워준다.
        public class MySR : ToolStripSystemRenderer
        {
            public MySR() { }

            protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
            {

            }
        }

        public class TestColorTable : ProfessionalColorTable
        {
            public override Color MenuBorder  //added for changing the menu border
            {
                get { return Color.White; }
            }
        }

        private void Layer1_Load(object sender, PaintEventArgs e)
        {

        }

        private void ChipSet_Load(object sender, PaintEventArgs e)
        {

        }

        #endregion

    }
}
