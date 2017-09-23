using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace MapEditor
{
    public partial class Help : Form
    {
        public Help()
        {
            InitializeComponent();
        }

        private void Help_Load(object sender, EventArgs e)
        {
            FormClosed += TilesetSelect_FormClosed;

            label2.Text = "           맵에 오류가 발생했다면, Refresh 버튼을 눌러주세요.";
            label4.Text = "MapEditor v" + Properties.Settings.Default.Version; 
        }

        // Form Closed Event
        private void TilesetSelect_FormClosed(object sender, EventArgs e)
        {
            Form1 frm1 = (Form1)this.Owner;
            frm1.Menu_isopen = 0;
        }
    }
}
