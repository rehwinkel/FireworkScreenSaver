using System;
using System.Collections.Generic;
using System.Drawing;

namespace ScreenSaverRemastered
{
    public class FireworkRenderer
    {
        public static List<Particle> fireworks = new List<Particle>();

        public static Rectangle Bounds;
        public static int Meter;
        public static Random rand = new Random();

        public static void Load(Rectangle bounds)
        {
            Bounds = bounds;
            Meter = Bounds.Height / 100;
        }

        private static int tick = 0;

        public static void Render(Graphics g)
        {
            tick++;
            if(tick == 15)
            {
                fireworks.Add(new Firework(rand.Next(Bounds.Width), Bounds.Height));
                tick = 0;
            }

            SolidBrush brush = new SolidBrush(Color.FromArgb(255, 255, 255, 255));

            foreach(Particle f in fireworks.ToArray())
            {
                if (f.IsReadyToDie(Bounds.Height))
                {
                    if(f is Firework)
                    {
                        ((Firework) f).Explode();
                    }
                    fireworks.Remove(f);
                }else
                {
                    f.Render(brush, g);
                }
            }
        }

        public static Color AlphaColor(Color color, int alpha)
        {
            if (alpha < 0) alpha = 0;
            return Color.FromArgb(alpha, color.R, color.G, color.B);
        }

        public static Color RandomHue()
        {
            return HueColor(rand.Next(360));
        }

        public static Color HueColor(double hue)
        {
            hue = hue % 360;

            int hueTransform = (int)(255 * ((hue % 60) / 60.0));

            if (hue >= 0 && hue < 60)
            {
                return Color.FromArgb(255, 255, hueTransform, 0);
            }
            if (hue >= 60 && hue < 120)
            {
                return Color.FromArgb(255, 255 - hueTransform, 255, 0);
            }
            if (hue >= 120 && hue < 180)
            {
                return Color.FromArgb(255, 0, 255, hueTransform);
            }
            if (hue >= 180 && hue < 240)
            {
                return Color.FromArgb(255, 0, 255 - hueTransform, 255);
            }
            if (hue >= 240 && hue < 300)
            {
                return Color.FromArgb(255, hueTransform, 0, 255);
            }
            if (hue >= 300 && hue < 360)
            {
                return Color.FromArgb(255, 255, 0, 255 - hueTransform);
            }

            return Color.FromArgb(255, 255, 255, 255);
        }
    }
}