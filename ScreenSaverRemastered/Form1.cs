using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenSaverRemastered
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public Form1(Rectangle bounds)
        {
            InitializeComponent();
            Bounds = bounds;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Cursor.Hide();
            TopMost = true;
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            FireworkRenderer.Load(Bounds);
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            CloseScreenSaver();
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            CloseScreenSaver();
        }

        private void CloseScreenSaver()
        {
            Application.Exit();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            FireworkRenderer.Render(e.Graphics);
        }

        Point LastMousePosition;

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (!LastMousePosition.IsEmpty)
            {
                if (Math.Abs(LastMousePosition.X - e.Location.X) > 5 || Math.Abs(LastMousePosition.Y - e.Location.Y) > 5)
                {
                    CloseScreenSaver();
                }
            }

            LastMousePosition = e.Location;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Invalidate(true);
        }
    }
}