using System;
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
    public partial class TitleForm : Form
    {
        // Timer
        Timer Start_opacity = new Timer(); // 시작시 투명도
        Form1 frm1;

        public TitleForm()
        {
            InitializeComponent();
        }

        private void TitleForm_Load(object sender, EventArgs e)
        {
            frm1 = (Form1)this.Owner;

            label1.Text = "v" + frm1.Version;

            this.Size = new Size(Screen.PrimaryScreen.Bounds.Width / 4 - 30, Screen.PrimaryScreen.Bounds.Height/4);
            this.Location = new Point(Screen.PrimaryScreen.Bounds.Width / 2 - (Screen.PrimaryScreen.Bounds.Width / 4 - 30)/2,
                Screen.PrimaryScreen.Bounds.Height / 2 - (Screen.PrimaryScreen.Bounds.Height / 4)/2);

            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.BackgroundImage = Properties.Resources.Img_Title;

            // Start Opacity
            this.Opacity = 0;
            Start_opacity.Interval = 15;
            Start_opacity.Tick += new EventHandler(FormOpacity);
            Start_opacity.Start();
        }

        //타이머 함수 - 시작시 투명도 조절
        private void FormOpacity(object sender, EventArgs e)
        {
            if (this.Opacity == 1)
            {
                frm1.EditorShow();

                Start_opacity.Stop();
                Start_opacity.Dispose();
                this.Dispose();
            }
            else
                this.Opacity += 0.01;
        }
    }
}
