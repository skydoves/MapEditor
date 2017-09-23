using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapEditor
{
    public partial class TransImage : UserControl
    {
        string Path;

        public TransImage(string FilePath)
        {
            InitializeComponent();

            Path = FilePath;
        }

        private void TransImage_Load(object sender, EventArgs e)
        {
            MouseDown += TransImage_MouseDown;

            // Set Mouse Cursor - mouser hover로 조건을 바꿔야할듯.
            Cursor cur = new Cursor(Properties.Resources.mouse_pointer.Handle);
            this.Cursor = cur;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Bitmap test = new Bitmap(Path);
            g.DrawImage(test, new Point(0, 0));
            test.Dispose();
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            //do nothing
        }

        protected override void OnMove(EventArgs e)
        {
            RecreateHandle();
        }


        // Override the CreateParams property:
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle = 0x00000020; //WS_EX_TRANSPARENT
                return cp;
            }
        }


        private void TransImage_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            MessageBox.Show("마우스는 지원하지 않습니다.\n테스트 플레이를 재시작 해주세요.");
        }
    }
}
