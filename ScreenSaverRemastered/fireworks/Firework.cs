using System;
using System.Drawing;

namespace ScreenSaverRemastered
{
    public class Firework : Particle
    {
        private Random rand = new Random();
        private Color color;
        private int type;

        public Firework(double x, double y) : base(x, y)
        {
            accY = (1.6 + FireworkRenderer.rand.NextDouble() * 0.4) * FireworkRenderer.Meter;
            type = rand.Next(3);
            color = FireworkRenderer.RandomHue();
            if(type == 0)
            {
                color = Color.DarkRed;
            }
        }

        public override void Render(SolidBrush b, Graphics g)
        {
            Update();

            b.Color = FireworkRenderer.AlphaColor(color, 32);
            RenderFlare(g, b, FireworkRenderer.Meter * 0.8);
        }

        double deg2rad = 0.01745329251994329576923690768489;

        public void Explode()
        {
            switch (type)
            {
                case 0:
                    ExplodeHeart();
                    break;
                case 1:
                    ExplodeBall();
                    break;
                case 2:
                    ExplodeSpark();
                    break;
            }
        }

        public void ExplodeBall()
        {
            for (int i = 0; i < 80; i++)
            {
                double vel = rand.NextDouble() * 1.2;
                double ax = Math.Sin(i * 4.5 * deg2rad) * vel;
                double ay = Math.Cos(i * 4.5 * deg2rad) * vel;
                FireworkRenderer.fireworks.Add(new Spark(x, y, ax, ay, color));
            }
        }

        public void ExplodeSpark()
        {
            for (int i = 0; i < 20; i++)
            {
                double vel = rand.NextDouble() * 1.2;
                double ax = Math.Sin(i * 18 * deg2rad) * vel;
                double ay = Math.Cos(i * 18 * deg2rad) * vel;
                FireworkRenderer.fireworks.Add(new Spark(x, y, ax, ay, color));
            }

            for (int i = 0; i < 10; i++)
            {
                double vel = rand.NextDouble() * 1.2;
                double ax = Math.Sin(i * 36 * deg2rad) * vel;
                double ay = Math.Cos(i * 36 * deg2rad) * vel;
                FireworkRenderer.fireworks.Add(new Spark(x, y, ax, ay, FireworkRenderer.HueColor(color.GetHue() + 180)));
            }
        }

        public void ExplodeHeart()
        {
            for (int i = 0; i < 60; i++)
            {
                int x2 = i * 6;

                int f = 1;
                if (x2 > 180) f = -1;
                if (x2 > 180) x2 = 360 - x2;
                double vel = heart(x2) * (0.7 + rand.NextDouble() * 0.3);
                double ax = Math.Sin(x2 * deg2rad) * vel * f;
                double ay = Math.Cos(x2 * deg2rad) * vel;
                FireworkRenderer.fireworks.Add(new Spark(x, y, ax, ay, Color.DarkRed));
            }
        }

        public double heart(double x)
        {
            double a = 0.00001932;
            double b = -0.00580493;
            double c = 0.48038548;
            double d = 5;
            double result = a * (x * x * x) + b * (x * x) + c * x + d;
            return result / 10;
        }

        public override bool IsReadyToDie(int height)
        {
            return y > height || IsReadyToDie();
        }


        public override bool IsReadyToDie()
        {
            return accY <= 0;
        }
    }
}