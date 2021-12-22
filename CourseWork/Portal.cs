﻿using System;
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
        public abstract void Teleportation(Particle particle);

        // базовый класс для отрисовки портала
        public virtual void Render(Graphics g)
        {
            g.FillEllipse(new SolidBrush(Color.LightPink), X, Y, 10, 10);
        }
    }


    public class InPortal : Portal
    {
        public int Deam = 100;

        public override void Render(Graphics g)
        {
            // окружность с диаметром равным Deam
            g.DrawEllipse(
                   new Pen(Color.Red),
                   X - Deam / 2,
                   Y - Deam / 2,
                   Deam,
                   Deam
               );
        }

        public override void Teleportation(Particle particle)
        {
            float gX = X - particle.X;
            float gY = Y - particle.Y;

            double r = Math.Sqrt(gX * gX + gY * gY); // считаем расстояние от центра точки до центра частицы

            if (r + particle.Radius < Deam / 2) // если частица оказалось внутри окружности
            {

            }
        }
    }


    public class OutPortal : Portal
    {
        public int Deam = 100;

        public override void Render(Graphics g)
        {
            // окружность с диаметром равным Deam
            g.DrawEllipse(
                   new Pen(Color.Red),
                   X - Deam / 2,
                   Y - Deam / 2,
                   Deam,
                   Deam
               );
        }

        public override void Teleportation(Particle particle)
        {

        }
    }
}