﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork
{
    public abstract class IImpactPoint
    {
        public float X; 
        public float Y;

        // абстрактный метод с помощью которого будем изменять состояние частиц
        // притягивать или отталкивать
        public abstract void ImpactParticle(Particle particle);

        // базовый класс для отрисовки точечки
        public void Render(Graphics g)
        {
            g.FillEllipse(
                    new SolidBrush(Color.LightPink),
                    X - 5,
                    Y - 5,
                    10,
                    10
                );
        }
    }
    public class GravityPoint : IImpactPoint
    {
        public int Power = 100; // сила притяжения

        public override void ImpactParticle(Particle particle)
        {
            float gX = X - particle.X;
            float gY = Y - particle.Y;
            float r2 = (float)Math.Max(100, gX * gX + gY * gY);

            particle.SpeedX += gX * Power / r2;
            particle.SpeedY += gY * Power / r2;
        }
    }

    public class AntiGravityPoint : IImpactPoint
    {
        public int Power = 100; // сила отторжения

        public override void ImpactParticle(Particle particle)
        {
            float gX = X - particle.X;
            float gY = Y - particle.Y;
            float r2 = (float)Math.Max(100, gX * gX + gY * gY);

            particle.SpeedX -= gX * Power / r2; // тут минусики вместо плюсов
            particle.SpeedY -= gY * Power / r2; // и тут
        }
    }
}