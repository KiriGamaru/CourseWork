using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork
{
    public class Emitter
    {
        public int ParticlesCount = 500;//кол-во частиц
        List<Particle> particles = new List<Particle>();
        public int MousePositionX;
        public int MousePositionY;
        //поля под гравитацию
        public float GravitationX = 0;
        public float GravitationY = 0; // пусть гравитация будет силой один пиксель за такт, нам хватит

        public List<IImpactPoint> impactPoints = new List<IImpactPoint>(); // тут буду хранится точки притяжения

        public void UpdateState()//функция обновления состояния системы
        {
            foreach (var particle in particles)
            {
                particle.Life -= 1;// уменьшаю здоровье

                if (particle.Life < 0)// если здоровье кончилось
                {
                    ResetParticle(particle);
                }
                else
                {
                    // каждая точка по-своему воздействует на вектор скорости
                    foreach (var point in impactPoints)
                    {
                        point.ImpactParticle(particle);
                    }

                    // гравитация воздействует на вектор скорости, поэтому пересчитываем его
                    particle.SpeedX += GravitationX;
                    particle.SpeedY += GravitationY;

                    particle.X += particle.SpeedX;
                    particle.Y += particle.SpeedY;
                }
            }

            // генерация частиц
            // генерирую не более 10 штук за тик
            for (var i = 0; i < 10; ++i)
            {
                if (particles.Count < ParticlesCount) // пока частиц меньше максимального числа генерируем новые
                {
                    var particle = new ParticleColorful();
                    particle.FromColor = Color.Yellow;
                    particle.ToColor = Color.FromArgb(0, Color.Magenta);

                    ResetParticle(particle);
                    particles.Add(particle);
                }
                else
                {
                    break;
                }
            }

        }

        
        public void Render(Graphics g)
        {
            // отрисовка частиц
            foreach (var particle in particles)
            {
                particle.Draw(g);
            }

            //точки притяжения - розовые кружочки
            foreach (var point in impactPoints)
            {
                point.Render(g);
            }
        }// функция рендеринга


        public virtual void ResetParticle(Particle particle)// момент генерации частицы и сброса ее состояния, когда жизнь кончается
        {
            particle.Life = 20 + Particle.rnd.Next(100);// восстанавливаю здоровье
            // перемещаю частицу в место положения курсора
            particle.X = MousePositionX;
            particle.Y = MousePositionY;
            //сброс состояния частицы
            var direction = (double)Particle.rnd.Next(360);
            var speed = 1 + Particle.rnd.Next(10);

            particle.SpeedX = (float)(Math.Cos(direction / 180 * Math.PI) * speed);
            particle.SpeedY = -(float)(Math.Sin(direction / 180 * Math.PI) * speed);

            particle.Radius = 2 + Particle.rnd.Next(10);// рандомный размер частицы
        }
    }


    public class TopEmitter : Emitter
    {
        public int Width; // длина экрана

        public override void ResetParticle(Particle particle)
        {
            base.ResetParticle(particle); // вызываем базовый сброс частицы, там жизнь переопределяется и все такое

            //параметры движения
            particle.X = Particle.rnd.Next(Width); // позиция X -- произвольная точка от 0 до Width
            particle.Y = 0;  // ноль -- это верх экрана 

            particle.SpeedY = 1; // падаем вниз по умолчанию
            particle.SpeedX = Particle.rnd.Next(-2, 2); // разброс влево и вправа у частиц 
        }
    }

}
