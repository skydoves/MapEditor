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

namespace MapEditor
{
    public partial class MapDataSimulation : Form
    {
        Bitmap TileSet;
        Graphics g;
        string FileDatapath;

        public MapDataSimulation()
        {
            InitializeComponent();
        }

        private void MapDataSimulation_Load(object sender, EventArgs e)
        {
            // Set Mouse Cursor - mouser hover로 조건을 바꿔야할듯.
            Cursor cur = new Cursor(Properties.Resources.mouse_pointer.Handle);
            this.Cursor = cur;

            // Form Event Handler
            FormClosed += MapDataSimulation_FormClosed;
            pictureBox1.MouseMove += pictureBox1_MouseMove;

            // Controls
            panel1.Controls.Add(pictureBox1);
            panel1.BorderStyle = BorderStyle.FixedSingle;
        }

        // Screenshot 폴더에서 맵 이미지를 로딩한다.
        public void TilesetLoad(string FileName)
        {
            int Tilewidth, Tileheight;

            // File path save
            FileDatapath = @"Map Data\" + FileName + ".txt";

            // Tileset Image Load
            Bitmap load = new Bitmap(@"Screenshot\" + FileName + ".png");
            TileSet = new Bitmap(load);
            Tilewidth = TileSet.Width / 32 * 32;  Tileheight = TileSet.Height / 32 * 32;
            pictureBox1.Image = TileSet;
            pictureBox1.Size = new System.Drawing.Size(Tilewidth, Tileheight);
            load.Dispose();

            try
            {
                // Get Map Data char by char
                int count = 0;
                string Data = File.ReadAllText(FileDatapath);

                g = Graphics.FromImage(TileSet);
                Font gfont = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));

                foreach (char c in Data)
                {
                    if (!c.ToString().Contains("U"))
                        g.DrawString(c.ToString(), gfont, new SolidBrush(Color.Black), new Point(count % (Tilewidth/32) * 32 + 6, count / (Tilewidth/32) * 32 + 3));
                    count++;
                }
            }
            catch
            {
                MessageBox.Show("맵 데이터 없음");
            }

            // Label Set
            toolStripStatusLabel2.Text = "Map : " + FileName + " (" + Tilewidth / 32 + " x " + Tileheight / 32 + ")";

            pictureBox1.Controls.Add(pictureBox2);
            pictureBox2.Location = new Point(0, 0);
        }

        // Mouse Move -> picturebox : 좌표 획득
        private void pictureBox1_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            int Arr_x, Arr_y;

            Point RectStartPoint;
            RectStartPoint = e.Location;
            Invalidate();

            Arr_x = RectStartPoint.X / 32;
            Arr_y = RectStartPoint.Y / 32;

            toolStripStatusLabel4.Text = "(" + Arr_x + "," + Arr_y + ")";

            // Selector
            pictureBox2.Location = new Point(Arr_x * 32, Arr_y * 32);
        }

        // Tileset form Closed Event
        private void MapDataSimulation_FormClosed(object sender, EventArgs e)
        {
            Form1 frm1 = (Form1)this.Owner;
            frm1.Menu_isopen = 0;
        }
    }
}
