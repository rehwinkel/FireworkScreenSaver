using System;
using System.Drawing;

namespace ScreenSaverRemastered
{
    public class Spark : Particle
    {
        Color color;
        int age;

        public Spark(double x, double y, double ax, double ay, Color color) : base(x, y)
        {
            accX = ax;
            accY = ay;
            this.color = color;
        }

        public override void Render(SolidBrush b, Graphics g)
        {
            age++;
            Update();

            b.Color = FireworkRenderer.AlphaColor(color, 48 - age);
            RenderFlare(g, b, FireworkRenderer.Meter * 0.4);
        }

        public override bool IsReadyToDie()
        {
            return age > 50;
        }
    }
}