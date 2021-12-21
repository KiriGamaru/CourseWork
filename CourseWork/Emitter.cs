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
        List<Particle> particles = new List<Particle>();

        public int ParticlesCount = 500;//кол-во частиц

        public int X; // координата X центра эмиттера, будем ее использовать вместо MousePositionX
        public int Y; // соответствующая координата Y 
        public int Direction = 0; // вектор направления в градусах куда сыпет эмиттер
        public int Spreading = 0; // разброс частиц относительно Direction
        public int SpeedMin = 1; // начальная минимальная скорость движения частицы
        public int SpeedMax = 10; // начальная максимальная скорость движения частицы
        public int RadiusMin = 2; // минимальный радиус частицы
        public int RadiusMax = 10; // максимальный радиус частицы
        public int LifeMin = 20; // минимальное время жизни частицы
        public int LifeMax = 100; // максимальное время жизни частицы

        public int ParticlesPerTick = 1;//количество частиц в такт


        public Color ColorFrom = Color.White; // начальный цвет частицы
        public Color ColorTo = Color.FromArgb(0, Color.Black); // конечный цвет частиц

        //поля под гравитацию
        public float GravitationX = 0;
        public float GravitationY = 0; // пусть гравитация будет силой один пиксель за такт, нам хватит

        public List<IImpactPoint> impactPoints = new List<IImpactPoint>(); // тут буду хранится точки притяжения


        public virtual Particle CreateParticle()//метод для генерации частицы
        {
            var particle = new ParticleColorful();
            particle.FromColor = ColorFrom;
            particle.ToColor = ColorTo;

            return particle;
        }

        public void UpdateState()//функция обновления состояния системы
        {
            int particlesToCreate = ParticlesPerTick; // фиксируем счетчик сколько частиц нам создавать за тик

            foreach (var particle in particles)
            {
                if (particle.Life < 0)// если здоровье кончилось
                {
                    //то проверяем надо ли создать частицу
                    if (particlesToCreate > 0)
                    {
                        particlesToCreate -= 1; // сброс частицы равносилен созданию частицы, поэтому уменьшаем счётчик созданных частиц на 1
                        ResetParticle(particle);
                    }
                }
                else
                {
                    particle.X += particle.SpeedX;
                    particle.Y += particle.SpeedY;

                    // каждая точка по-своему воздействует на вектор скорости
                    foreach (var point in impactPoints)
                    {
                        point.ImpactParticle(particle);
                    }

                    // гравитация воздействует на вектор скорости, поэтому пересчитываем его
                    particle.SpeedX += GravitationX;
                    particle.SpeedY += GravitationY;

                    
                }
            }

            // генерация частиц
            while (particlesToCreate >= 1)
            {
                particlesToCreate -= 1;
                var particle = CreateParticle();
                ResetParticle(particle);
                particles.Add(particle);
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
            particle.Life = 20 + Particle.rnd.Next(LifeMin, LifeMax);// восстанавливаю здоровье

            // передаю координаты частицы
            particle.X = X;
            particle.Y = Y;

            //сброс состояния частицы
            var direction = Direction
                 + (double)Particle.rnd.Next(Spreading)
                 - Spreading / 2;

            var speed = Particle.rnd.Next(SpeedMin, SpeedMax);

            particle.SpeedX = (float)(Math.Cos(direction / 180 * Math.PI) * speed);
            particle.SpeedY = -(float)(Math.Sin(direction / 180 * Math.PI) * speed);


            particle.Radius = Particle.rnd.Next(RadiusMin, RadiusMax);
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
