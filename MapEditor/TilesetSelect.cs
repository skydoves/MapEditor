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
    public partial class TilesetSelect : Form
    {
        public TilesetSelect()
        {
            InitializeComponent();
        }

        private void TilesetSelect_Load(object sender, EventArgs e)
        {
            FormClosed += TilesetSelect_FormClosed;

            var rootDirectoryInfo = new DirectoryInfo(@"Tilesets");

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
        private void TilesetSelect_FormClosed(object sender, EventArgs e)
        {
            Form1 frm1 = (Form1)this.Owner;
            frm1.Menu_isopen = 0;
        }

        // Click Select Button
        private void button1_Click(object sender, EventArgs e)
        {
            Form1 frm1 = (Form1)this.Owner;
            frm1.TilesetChanged(comboBox1.SelectedItem.ToString());
            frm1.Menu_isopen = 0;
            this.Dispose();
        }
    }
}
