using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSaverRemastered
{
    public class Particle
    {
        public double x;
        public double y;
        public double accX;
        public double accY;

        private const double gravity = 9.81 / 50;

        public Particle(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public void Update()
        {
            y -= accY;
            x += accX;
            accY -= gravity;
        }

        public virtual void Render(SolidBrush b, Graphics g)
        {
            Update();
        }

        public void RenderFlare(Graphics g, SolidBrush b, double sizeD)
        {
            int size = (int)sizeD;
            //8 size -> 32 alpha
            //4 -> 64
            //2 -> 128
            //1 -> 256 
            for (int i = 0; i < size; i++)
            {
                g.FillRectangle(b, new Rectangle((int)x - (size - i), (int)y - 1 - i, size * 2 - (2 * i), 2 + (2 * i)));
            }
        }

        public virtual bool IsReadyToDie(int height)
        {
            return IsReadyToDie();
        }

        public virtual bool IsReadyToDie()
        {
            return false;
        }
    }
}
