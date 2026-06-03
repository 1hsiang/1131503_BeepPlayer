using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1131503_簡易版電子琴
{
    public partial class frmBeepPlayer : Form
    {
        public frmBeepPlayer()
        {
            InitializeComponent();
            InitializeButton();
        }
        [DllImport("kernel32.dll")]
        public static extern bool Beep(int frequency, int duration);
        int[] freq = { 523, 587, 659, 698, 784, 880, 988, 1046 };
        private void btn1_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.Enabled = false;
            Beep(freq[btn.TabIndex], 300);
            btn.Enabled = true;
        }
        private void InitializeButton()
        {
            // 讓btn1~btn8共用同一個事件處理函式
            btn2.Click += btn1_Click;
            btn3.Click += btn1_Click;
            btn4.Click += btn1_Click;
            btn5.Click += btn1_Click;
            btn6.Click += btn1_Click;
            btn7.Click += btn1_Click;
            btn8.Click += btn1_Click;
        }

        int initWidth = 0;
        int initHeight = 0;
        bool layoutReady = false;

        Dictionary<Control, Rectangle> initControl = new Dictionary<Control, Rectangle>();

        private void SaveInitialLayout()
        {
            initWidth = palMain.Width;
            initHeight = palMain.Height;

            initControl.Clear();

            foreach (Control ctl in palMain.Controls)
            {
                initControl[ctl] = new Rectangle(
                    ctl.Left,
                    ctl.Top,
                    ctl.Width,
                    ctl.Height
                );
            }

            layoutReady = true;
        }

        private void frmBeepPlayer_Load(object sender, EventArgs e)
        {
            SaveInitialLayout();
        }



        private void frmBeepPlayer_SizeChanged(object sender, EventArgs e)
        {
            if (!layoutReady || initWidth == 0 || initHeight == 0)
                return;

            double width = this.palMain.Width;
            double height = this.palMain.Height;

            double iRatioWidth = width / this.initWidth;
            double iRatioHeight = height / this.initHeight;

            foreach (Control ctl in this.palMain.Controls)
            {
                if (!initControl.ContainsKey(ctl))
                    continue;

                Rectangle r = initControl[ctl];

                ctl.Left = (int)(r.Left * iRatioWidth);
                ctl.Top = (int)(r.Top * iRatioHeight);
                ctl.Width = (int)(r.Width * iRatioWidth);
                ctl.Height = (int)(r.Height * iRatioHeight);
            }
        }
    }
}
