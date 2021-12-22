using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork
{
    public abstract class Portal
    {
        public float X;
        public float Y;

        // абстрактный метод с помощью которого будем изменять местоположение частиц 
        public abstract void Teleportation(Particle particle, Portal portal);

        // базовый класс для отрисовки портала
        public virtual void Render(Graphics g)
        {
            g.FillEllipse(new SolidBrush(Color.LightPink), X, Y, 10, 10);
        }
    }


    public class InPortal : Portal
    {
        public int Deam = 0;

        public override void Render(Graphics g)
        {
            // окружность с диаметром равным Deam
            g.DrawEllipse(
                   new Pen(Color.White),
                   X - Deam / 2,
                   Y - Deam / 2,
                   Deam,
                   Deam
               );
        }

        public override void Teleportation(Particle particle, Portal portal2)
        {
            float gX = X - particle.X;
            float gY = Y - particle.Y;

            double r = Math.Sqrt(gX * gX + gY * gY); // считаем расстояние от центра точки до центра частицы

            if (r + particle.Radius < Deam / 2) // если частица оказалось внутри окружности
            {
                //то перемещаем её в другой портал
                particle.X = portal2.X;
                particle.Y = portal2.Y;

            }
        }
    }


    public class OutPortal : Portal
    {
        public int Deam = 0;
        public Color color = Color.White;// цвет портала
        public override void Render(Graphics g)
        {
            // окружность с диаметром равным Deam
            g.DrawEllipse(
                   new Pen(color),
                   X - Deam / 2,
                   Y - Deam / 2,
                   Deam,
                   Deam
               );
        }

        public override void Teleportation(Particle particle, Portal portal)
        {
            float gX = X - particle.X;
            float gY = Y - particle.Y;

            double r = Math.Sqrt(gX * gX + gY * gY); // считаем расстояние от центра точки до центра частицы

            if (r + particle.Radius < Deam / 2) // если частица оказалось внутри окружности
            {
                //меняем её цвет
                var newParticle = (ParticleColorful)particle;
                newParticle.FromColor = color;
                particle = newParticle;
            }
        }
    }
}
