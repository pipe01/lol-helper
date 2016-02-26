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

namespace LoL_Helper
{
    public partial class CustomForm : Form
    {
        public CustomForm()
        {
            InitializeComponent();
        }

        #region Shadow
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect, // x-coordinate of upper-left corner
            int nTopRect, // y-coordinate of upper-left corner
            int nRightRect, // x-coordinate of lower-right corner
            int nBottomRect, // y-coordinate of lower-right corner
            int nWidthEllipse, // height of ellipse
            int nHeightEllipse // width of ellipse
         );

        [DllImport("dwmapi.dll")]
        public static extern int DwmExtendFrameIntoClientArea(IntPtr hWnd, ref MARGINS pMarInset);

        [DllImport("dwmapi.dll")]
        public static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);

        [DllImport("dwmapi.dll")]
        public static extern int DwmIsCompositionEnabled(ref int pfEnabled);

        private bool m_aeroEnabled = true;                     // variables for box shadow
        private const int CS_DROPSHADOW = 0x00020000;
        private const int WM_NCPAINT = 0x0085;
        private const int WM_ACTIVATEAPP = 0x001C;

        public struct MARGINS                           // struct for box shadow
        {
            public int leftWidth;
            public int rightWidth;
            public int topHeight;
            public int bottomHeight;
        }

        private const int WM_NCHITTEST = 0x84;          // variables for dragging the form
        private const int HTCLIENT = 0x1;
        private const int HTCAPTION = 0x2;

        protected override CreateParams CreateParams
        {
            get
            {
                m_aeroEnabled = CheckAeroEnabled();

                CreateParams cp = base.CreateParams;
                if (!m_aeroEnabled)
                    cp.ClassStyle |= CS_DROPSHADOW;

                return cp;
            }
        }

        private bool CheckAeroEnabled()
        {
            if (Environment.OSVersion.Version.Major >= 6)
            {
                int enabled = 0;
                DwmIsCompositionEnabled(ref enabled);
                return (enabled == 1) ? true : false;
            }
            return false;
        }

        protected override void WndProc(ref Message m)
        {
            const int wmNcHitTest = 0x84;
            const int htBottomLeft = 16;
            const int htBottomRight = 17;
            switch (m.Msg)
            {
                case WM_NCPAINT:                        // box shadow
                    if (m_aeroEnabled)
                    {
                        var v = 2;
                        int bs = 1;
                        DwmSetWindowAttribute(this.Handle, 2, ref v, 4);
                        MARGINS margins = new MARGINS()
                        {
                            bottomHeight = bs,
                            leftWidth = bs,
                            rightWidth = bs,
                            topHeight = bs
                        };
                        DwmExtendFrameIntoClientArea(this.Handle, ref margins);
                    }
                    break;
                case wmNcHitTest:
                    if (!ResizeCorner)
                        break;
                    int x = (int)(m.LParam.ToInt64() & 0xFFFF);
                    int y = (int)((m.LParam.ToInt64() & 0xFFFF0000) >> 16);
                    Point pt = PointToClient(new Point(x, y));
                    Size clientSize = ClientSize;
                    if (pt.X >= clientSize.Width - 16 && pt.Y >= clientSize.Height - 16 && clientSize.Height >= 16)
                    {
                        m.Result = (IntPtr)(IsMirrored ? htBottomLeft : htBottomRight);
                        return;
                    }
                    break;
                default:
                    break;
            }
            base.WndProc(ref m);

            if (m.Msg == WM_NCHITTEST && (int)m.Result == HTCLIENT)     // drag the form
                m.Result = (IntPtr)HTCAPTION;

        }
        #endregion

        public Color ColorClosePress { get; set; } = Color.Maroon;
        public Color ColorCloseHover { get; set; } = Color.Firebrick;
        public Color ColorClose { get; set; } = Color.DarkRed;

        public Color ColorMinimizePress { get; set; } = Color.Olive;
        public Color ColorMinimizeHover { get; set; } = Color.FromArgb(255, 255, 128);
        public Color ColorMinimize { get; set; } = Color.FromArgb(192, 192, 0);

        public bool ResizeCorner { get; set; } = true;

        private void CustomForm_Load(object sender, EventArgs e)
        {

        }

        private void CustomForm_TextChanged(object sender, EventArgs e)
        {
            lblTitle.Text = this.Text;
        }

        private void picCerrar_MouseEnter(object sender, EventArgs e)
        {
            picCerrar.BackColor = ColorCloseHover;
        }

        private void picCerrar_MouseLeave(object sender, EventArgs e)
        {
            picCerrar.BackColor = ColorClose;
        }

        private void picCerrar_MouseDown(object sender, MouseEventArgs e)
        {
            picCerrar.BackColor = ColorClosePress;
        }

        private void picCerrar_MouseUp(object sender, MouseEventArgs e)
        {
            picCerrar.BackColor = ColorClose;
            this.Close();
        }

        private void picMin_MouseDown(object sender, MouseEventArgs e)
        {
            picMin.BackColor = ColorMinimizePress;
        }

        private void picMin_MouseEnter(object sender, EventArgs e)
        {
            picMin.BackColor = ColorMinimizeHover;
        }

        private void picMin_MouseUp(object sender, MouseEventArgs e)
        {
            picMin.BackColor = ColorMinimize;
            this.WindowState = FormWindowState.Minimized;
        }

        private void picMin_MouseLeave(object sender, EventArgs e)
        {
            picMin.BackColor = ColorMinimize;
        }

        int x, y;

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                var p = PointToScreen(e.Location.Substract(x, y));
                this.Location = p;
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            x = e.X;
            y = e.Y;
        }

        private void CustomForm_BackColorChanged(object sender, EventArgs e)
        {
            panTitleBar.BackColor = this.BackColor.Darken(25);
        }
    }
}
