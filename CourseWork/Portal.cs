using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork
{
    public class Portal : IImpactPoint
    {
        public int Deam = 0;//деаметр портала
        public Color color = Color.White;// цвет портала
        public bool InP;
        public float xOut;
        public float yOut;

        public override void ImpactParticle(Particle particle)
        {
            float gX = X - particle.X;
            float gY = Y - particle.Y;

            double r = Math.Sqrt(gX * gX + gY * gY); // считаем расстояние от центра точки до центра частицы

            if (r + particle.Radius < Deam / 2) // если частица оказалось внутри входого портала
            {
                if (InP == true) // если портал - входной
                {
                    //то перемещаем её в другой портал
                    particle.X = xOut;
                    particle.Y = yOut;
                }
                else // если выходной
                {
                    // то меняем её цвет
                    var newParticle = (ParticleColorful)particle;
                    newParticle.FromColor = color;
                    particle = newParticle;
                }
            }
        }
        //отрисовка портала
        public override void Render(Graphics g)
        {
            if (InP == true) // если портал - входной
            {
                g.DrawEllipse(
                   new Pen(Color.White),
                   X - Deam / 2,
                   Y - Deam / 2,
                   Deam,
                   Deam
               );
            }
            else
            {
                g.DrawEllipse(
                   new Pen(color),
                   X - Deam / 2,
                   Y - Deam / 2,
                   Deam,
                   Deam
               );
            }
        }
    }
}
