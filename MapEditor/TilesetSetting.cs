using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapEditor
{
    public partial class TilesetSetting : Form
    {
        Bitmap TileSet;
        Label[] bounds;
        string[] Datas;
        string FileDatapath;
        int Changed = 0; // 수정이 일어날경우 1로 바뀐다. -> 종료시 질문

        public TilesetSetting()
        {
            InitializeComponent();
        }

        private void TilesetSetting_Load(object sender, EventArgs e)
        {
            // Form Closed Event
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(Form1_FormClosing);
            this.FormClosed += TilesetSelect_FormClosed;

            panel1.Controls.Add(pictureBox1);
            panel1.BorderStyle = BorderStyle.FixedSingle;
        }

        public void TilesetLoad(string FileName)
        {
            // File path save
            FileDatapath = @"Tilesets\Tileset Data\" + FileName + ".txt";

            // Tileset Image Load
            TileSet = new Bitmap(@"Tilesets\" + FileName + ".png");
            pictureBox1.Image = TileSet;
            pictureBox1.Size = new System.Drawing.Size(256, TileSet.Height / 32 * 32);

            // Make Label
            MakeLabel();

            // TIleset Data Load
            try
            {
                // Get Tileset Data char by char
                int count = 0;
                string path = @"Tilesets\Tileset Data\" + FileName + ".txt";
                string Data = File.ReadAllText(path);

                foreach (char c in Data)
                {
                    bounds[count].Text = c.ToString();
                    Datas[count] = c.ToString();
                    count++;
                }
            }

            catch // Not exist txt file data
            {
                for (int i = 0; i < TileSet.Height / 32; i++)
                {
                    for (int k = 0; k < 8; k++)
                    {
                        int index = i * 8 + k;
                        bounds[index].Text = "O";
                        Datas[index] = "O";
                    }
                }
            }

        }

        private void MakeLabel()
        {
            bounds = new Label[TileSet.Height/32 * 8];
            Datas = new string[TileSet.Height / 32 * 8];

            for(int i=0; i<TileSet.Height/32; i++)
            {
                for(int k=0; k<8; k++)
                {
                    int index = i * 8 + k;
                    bounds[index] = new Label();
                    bounds[index].Name = index.ToString();
                    bounds[index].Size = new Size(32, 32);
                    bounds[index].Location = new Point(k*32, i*32);
                    bounds[index].BorderStyle = BorderStyle.FixedSingle;
                    bounds[index].BackColor = Color.Transparent;
                    bounds[index].DoubleClick += LabelDoubleClick;
                    bounds[index].Click += new EventHandler(LabelClick);
                    bounds[index].Font = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
                    pictureBox1.Controls.Add(bounds[index]);
                }
            }
        }

        private void LabelClick(object sender, EventArgs e)
        {
            Control ctl = sender as Control;

            if (ctl.Text.Contains("O"))
            {
                ctl.Text = "X";
                Datas[Int32.Parse(ctl.Name)] = "X";
            }
            else if (ctl.Text.Contains("X"))
            {
                ctl.Text = "U";
                Datas[Int32.Parse(ctl.Name)] = "U";
            }
            else if (ctl.Text.Contains("U"))
            {
                ctl.Text = "O";
                Datas[Int32.Parse(ctl.Name)] = "O";
            }

            if (Changed == 0)
                Changed = 1;
        }

        private void LabelDoubleClick(object sender, EventArgs e)
        {
            Control ctl = sender as Control;

            if (ctl.Text.Contains("O"))
            {
                ctl.Text = "X";
                Datas[Int32.Parse(ctl.Name)] = "X";
            }
            else if (ctl.Text.Contains("X"))
            {
                ctl.Text = "U";
                Datas[Int32.Parse(ctl.Name)] = "U";
            }
            else if (ctl.Text.Contains("U"))
            {
                ctl.Text = "O";
                Datas[Int32.Parse(ctl.Name)] = "O";
            }

            if (Changed == 0)
                Changed = 1;
        }

        // Button Click . Save
        private void button_save_Click(object sender, EventArgs e)
        {
            // Text FIie - Tileset Data Save
            string Datastring = "";

            for(int i=0; i<TileSet.Height/32 * 8; i++)
                Datastring += Datas[i];

            System.IO.File.WriteAllText(FileDatapath, Datastring);

            // Form Close
            Form1 frm1 = (Form1)this.Owner;
            frm1.Menu_isopen = 0;
            frm1.TilesetDataChanged();
            this.Dispose();
        }

        // Tileset form Closed Event
        private void TilesetSelect_FormClosed(object sender, EventArgs e)
        {
            Form1 frm1 = (Form1)this.Owner;
            frm1.Menu_isopen = 0;
        }

        // Tileset form Closing Event
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Changed == 1)
            {
                switch (e.CloseReason)
                {
                    case CloseReason.UserClosing:
                        if (MessageBox.Show("파일이 저장되지 않았습니다.\n그래도 종료 하시겠습니까?",
                                            "Map Editor",
                                            MessageBoxButtons.YesNo,
                                            MessageBoxIcon.Question) == DialogResult.No)
                        {
                            e.Cancel = true;
                        }
                        break;
                }
            }
        }
    }
}
