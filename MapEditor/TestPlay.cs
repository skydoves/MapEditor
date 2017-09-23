using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace MapEditor
{
    public partial class TestPlay : Form
    {
        string FileName = null;
        PictureBox Char;
        TransImage Layer2;
        int CharDirection = 0;

        public TestPlay()
        {
            InitializeComponent();
        }

        private void TestPlay_Load(object sender, EventArgs e)
        {
            // Set Mouse Cursor - mouser hover로 조건을 바꿔야할듯.
            Cursor cur = new Cursor(Properties.Resources.mouse_pointer.Handle);
            this.Cursor = cur;

            // Event Handler
            FormClosed += TilesetSelect_FormClosed;
            KeyDown += FormKeyDown;
            KeyUp += FormKeyUp;

            // Controls
            panel1.Controls.Add(Layer1);

        }

        // Map Load
        public void LoadMap(string MapPath)
        {
            string[] spear = { ".png" };
            string[] words = MapPath.Split(spear, StringSplitOptions.RemoveEmptyEntries);

            FileName = words[0];

            // Layer1 Load
            Bitmap Bitmap_Layer1 = new Bitmap(@"Maps\" + MapPath);
            Layer1.Size = new Size(Bitmap_Layer1.Width, Bitmap_Layer1.Height);
            Layer1.Image = new Bitmap(Bitmap_Layer1);
            Bitmap_Layer1.Dispose();

            // Layer2 Load
            Bitmap layer2bm = new Bitmap(@"Maps\" + FileName + "_layer2.png");
            Layer2 = new TransImage(@"Maps\" + FileName + "_layer2.png");
            Layer2.Size = new Size(layer2bm.Width, layer2bm.Height);
            Layer1.Controls.Add(Layer2);
            layer2bm.Dispose();

            // Character Load
            Char = new PictureBox();
            Layer1.Controls.Add(Char);
           // UI.Controls.Add(label1);
            Char.Location = new Point(50, 50);
            Char.Size = new Size(300, 300);
            Char.BackColor = Color.Transparent;

            // UI Background
           // Layer1.Controls.Add(UI);
           // UI.Size = new Size(panel1.Width, panel1.Height);

            // Init
            SetCharImage(0, 0);
            label1.Text = "x :" + Char.Location.X/32 + "\ny :" + Char.Location.Y/32;
        }

        private void FormKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
                SetCharImage(0, 0);
            else if (e.KeyCode == Keys.Up)
                SetCharImage(3, 0);
            else if (e.KeyCode == Keys.Right)
                SetCharImage(2, 0);
            else if (e.KeyCode == Keys.Left)
                SetCharImage(1, 0);
            Layer2.Refresh();
        }

        // Key Down
        private void FormKeyDown(object sender, KeyEventArgs e)
        {
            #region 캐릭터 움직이는 부분
            int direction = 0;
            int move_di = 4;

            if (Char.Location.X > 0 && Char.Location.Y > 0 && Char.Location.X < Layer1.Width - 54 && Char.Location.Y < Layer1.Height - 54)
            {
                if (e.KeyCode == Keys.Down)
                {
                    Char.Location = new Point(Char.Location.X, Char.Location.Y + move_di);
                    direction = 0;
                }

                else if (e.KeyCode == Keys.Up)
                {
                    Char.Location = new Point(Char.Location.X, Char.Location.Y - move_di);
                    direction = 3;
                }

                else if (e.KeyCode == Keys.Right)
                {
                    Char.Location = new Point(Char.Location.X + move_di, Char.Location.Y);
                    direction = 2;
                }

                else if (e.KeyCode == Keys.Left)
                {
                    Char.Location = new Point(Char.Location.X - move_di, Char.Location.Y);
                    direction = 1;
                }

                // Change Image
                if (CharDirection == 0)
                {
                    SetCharImage(direction, 1);
                    CharDirection = 1;
                }
                else if (CharDirection == 1)
                {
                    SetCharImage(direction, 2);
                    CharDirection = 2;
                }
                else if (CharDirection == 2)
                {
                    SetCharImage(direction, 3);
                    CharDirection = 3;
                }
                else if (CharDirection == 3)
                {
                    SetCharImage(direction, 0);
                    CharDirection = 0;
                }
            }

            // 만약 Layer1의 경계선을 넘어 갈 경우
            if (Char.Location.X <= move_di)
                Char.Location = new Point(move_di, Char.Location.Y);
            if (Char.Location.Y <= move_di)
                Char.Location = new Point(Char.Location.X, move_di);
            if (Char.Location.X >= Layer1.Width - 54)
                Char.Location = new Point(Layer1.Width - 54 - move_di, Char.Location.Y);
            if (Char.Location.Y >= Layer1.Height - 54)
                Char.Location = new Point(Char.Location.X, Layer1.Height - 54 - move_di);

            #endregion

            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Right || e.KeyCode == Keys.Left)
                label1.Text = "x :" + Char.Location.X / 32 + "\ny :" + Char.Location.Y / 32;

            // 우측 화면의 최대 bound
            if (e.KeyCode == Keys.Right && Char.Location.X > panel1.Width / 2 && (Layer1.Width - Char.Location.X) - move_di * 2 > panel1.Width / 2)
            {
                Layer1.Location = new Point(Layer1.Location.X - move_di, Layer1.Location.Y);
               // UI.Location = new Point(UI.Location.X + move_di, UI.Location.Y);
            }

            // 좌측 화면의 최대 bound
            if (e.KeyCode == Keys.Left && Char.Location.X > panel1.Width / 2 && (Layer1.Width - Char.Location.X) - move_di * 2 > panel1.Width / 2)
            {
                Layer1.Location = new Point(Layer1.Location.X + move_di, Layer1.Location.Y);
               // UI.Location = new Point(UI.Location.X - move_di, UI.Location.Y);
            }

            // 아래측 화면의 최대 bound
            if(e.KeyCode == Keys.Down && Char.Location.Y > panel1.Height/2 && (Layer1.Height - Char.Location.Y) - move_di * 2 > panel1.Height / 2)
            {
                Layer1.Location = new Point(Layer1.Location.X, Layer1.Location.Y - move_di);
              //  UI.Location = new Point(UI.Location.X, UI.Location.Y + move_di);
            }

            // 위측 화면의 최대 bound
            if (e.KeyCode == Keys.Up && Char.Location.Y > panel1.Height / 2 && (Layer1.Height - Char.Location.Y) - move_di * 2 > panel1.Height / 2)
            {
                Layer1.Location = new Point(Layer1.Location.X, Layer1.Location.Y + move_di);
              //  UI.Location = new Point(UI.Location.X, UI.Location.Y - move_di);
            }
           }


        // Change Char Image
        private void SetCharImage(int x, int y)
        {
            Bitmap Bitmap_char = new Bitmap(@"Character\char1.png");
            Rectangle cloneRect = new Rectangle(y * Bitmap_char.Width / 4, x * Bitmap_char.Height / 4, Bitmap_char.Width / 4, Bitmap_char.Height / 4);
            System.Drawing.Imaging.PixelFormat format = Bitmap_char.PixelFormat;
            Bitmap cloneBitmap = Bitmap_char.Clone(cloneRect, format);
            Char.Image = new Bitmap(cloneBitmap);
            Char.Size = new Size(Bitmap_char.Width / 4, Bitmap_char.Height / 4);
            Bitmap_char.Dispose();
            cloneBitmap.Dispose();
        }

        // Tileset form Closed Event
        private void TilesetSelect_FormClosed(object sender, EventArgs e)
        {
            Form1 frm1 = (Form1)this.Owner;
            frm1.Menu_isopen = 0;
        }
    }
}
