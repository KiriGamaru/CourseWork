using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseWork
{
    public partial class Form1 : Form
    {
        List<Particle> particles = new List<Particle>();//пустой список частиц
        public Form1()
        {
            InitializeComponent();
            picDisplay.Image = new Bitmap(picDisplay.Width, picDisplay.Height);// привязка изображения
        }

        // добавил функцию обновления состояния системы
        private void UpdateState()
        {
            foreach (var particle in particles)
            {
                particle.Life -= 1;// уменьшаю здоровье
                                    
                if (particle.Life < 0)// если здоровье кончилось
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
                else {
                    particle.X += particle.SpeedX;
                    particle.Y += particle.SpeedY;
                }
            }

            // генерация частиц
            // генерирую не более 10 штук за тик
            for (var i = 0; i < 10; ++i)
            {
                if (particles.Count < 500) // пока частиц меньше 500 генерируем новые
                {
                    var particle = new ParticleColorful();
                    particle.FromColor = Color.Yellow;
                    particle.ToColor = Color.FromArgb(0, Color.Magenta);
                    particle.X = MousePositionX;
                    particle.Y = MousePositionY;
                    particles.Add(particle);
                }
                else
                {
                    break; // а если частиц уже 500 штук, то ничего не генерирую
                }
            }

        }

        // функция рендеринга
        private void Render(Graphics g)
        {
            // утащили сюда отрисовку частиц
            foreach (var particle in particles)
            {
                particle.Draw(g);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            UpdateState(); // каждый тик обновляем систему

            using (var g = Graphics.FromImage(picDisplay.Image))
            {
                g.Clear(Color.Black); // очистка picDisplay
                Render(g); // рендерим систему
            }

            picDisplay.Invalidate();//обновление picDisplay
        }


        // добавляем переменные для хранения положения мыши
        private int MousePositionX = 0;
        private int MousePositionY = 0;

        private void picDisplay_MouseMove(object sender, MouseEventArgs e)
        {
            //заносим положение мыши в переменные для хранения положения мыши
            MousePositionX = e.X;
            MousePositionY = e.Y;
        }
    }
}
