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
    public partial class Panorama : Form
    {
        public Panorama()
        {
            InitializeComponent();
        }

        private void Panorama_Load(object sender, EventArgs e)
        {
            FormClosed += Panorama_FormClosed;

            var rootDirectoryInfo = new DirectoryInfo(@"Panorama");

            foreach (var file in rootDirectoryInfo.GetFiles())
            {
                if (file.Name.Contains(".png"))
                {
                    string[] spear = { ".png" };
                    string[] words = file.Name.Split(spear, StringSplitOptions.RemoveEmptyEntries);

                    comboBox1.Items.Add(words[0]);
                }
            }

            comboBox1.SelectedIndex = 0;
        }

        // Tileset form Closed Event
        private void Panorama_FormClosed(object sender, EventArgs e)
        {
            Form1 frm1 = (Form1)this.Owner;
            frm1.Menu_isopen = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("정말로 파노라마 이미지를 레이어1에 적용 하시겠습니까?",
                    "Map Editor",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.No)
            {

            }
            else
            {
                Form1 frm1 = (Form1)this.Owner;
                frm1.PanoramaFile(comboBox1.SelectedItem.ToString() + ".png");
                frm1.Menu_isopen = 0;
                this.Dispose();
            }
        }
    }
}
