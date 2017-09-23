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
    public partial class MessageForm : Form
    {
        // Timer
        Timer Start_opacity = new Timer(); // 시작시 투명도

        public MessageForm()
        {
            InitializeComponent();
        }

        private void Message_Load(object sender, EventArgs e)
        {

        }

        public void MakeMessage(string text)
        {
            label1.Text = text;

            Start_opacity.Interval = 30;
            Start_opacity.Tick += new EventHandler(FormOpacity);
            Start_opacity.Start();
        }

        //타이머 함수 - 시작시 투명도 조절
        private void FormOpacity(object sender, EventArgs e)
        {
            if (this.Opacity == 0)
            {
                Start_opacity.Stop();
                Start_opacity.Dispose();
                this.Dispose();
            }
            else
                this.Opacity -= 0.025;
        }
    }
}
