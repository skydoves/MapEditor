using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace MapEditor
{
    public partial class NewMap : Form
    {
        public NewMap()
        {
            InitializeComponent();
        }

        private void NewMap_Load(object sender, EventArgs e)
        {
            FormClosed += TilesetSelect_FormClosed;

            textBox2.KeyPress += textBox2_KeyPress;
            textBox3.KeyPress += textBox2_KeyPress;
        }

        // Form Closed Event
        private void TilesetSelect_FormClosed(object sender, EventArgs e)
        {
            Form1 frm1 = (Form1)this.Owner;
            frm1.Menu_isopen = 0;
        }

        void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.Compare(textBox1.Text.ToString(), "") != 0 && String.Compare(textBox2.Text.ToString(), "") != 0 && String.Compare(textBox3.Text.ToString(), "") != 0)
            {
                try
                {
                    // Make a New png File in Map folder - Layer1
                    Bitmap NewFile = new Bitmap(Int32.Parse(textBox2.Text.ToString()) * 32, Int32.Parse(textBox3.Text.ToString()) * 32);
                    Graphics g = Graphics.FromImage(NewFile);

                    for (int i = 0; i <= NewFile.Height / 32; i++)
                    {
                        for (int k = 0; k <= NewFile.Width / 32; k++)
                        {
                            Point pt = new Point(k * 32, i * 32);
                            g.DrawImage(Properties.Resources.clear, pt);
                        }
                    }
                    NewFile.Save(@"Maps\" + textBox1.Text + ".png", ImageFormat.Png);
                    g.Dispose();

                    // Make a New png File in Map folder - Layer2
                    Bitmap NewFile2 = new Bitmap(Int32.Parse(textBox2.Text.ToString()) * 32, Int32.Parse(textBox3.Text.ToString()) * 32);
                    NewFile2.Save(@"Maps\" + textBox1.Text + "_layer2.png", ImageFormat.Png);

                    Form1 frm1 = (Form1)this.Owner;
                    frm1.Menu_isopen = 0;
                    frm1.RefreshFileList();
                    this.Dispose();
                }
                catch
                {
                    MessageBox.Show("빈 칸 형식이 맞지 않습니다.");
                }
            }
            else
                MessageBox.Show("빈 칸을 모두 채워주세요!");
        }
    }
}
