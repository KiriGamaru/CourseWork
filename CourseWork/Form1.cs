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
        List<Emitter> emitters = new List<Emitter>();
        Emitter emitter; //поле для эмиттера

        GravityPoint point1; //поле под первую точку
        GravityPoint point2; //поле под вторую точку

        InPortal portal1;//поле под первый портал
        OutPortal portal2;//поле под второй портал

        public Form1()
        {
            InitializeComponent();
            picDisplay.Image = new Bitmap(picDisplay.Width, picDisplay.Height);// привязка изображения

            this.emitter = new Emitter // создаю эмиттер и привязываю его к полю emitter
            {
                Direction = 0,
                Spreading = 10,
                SpeedMin = 10,
                SpeedMax = 10,
                ColorFrom = Color.White,
                ColorTo = Color.FromArgb(0, Color.Black),
                ParticlesPerTick = 10,
                X = picDisplay.Width / 2,
                Y = picDisplay.Height / 2,
            };

            emitters.Add(this.emitter); //добавляю в список emitters, чтобы он рендерился и обновлялся


           
            // гравитоны
            point1 = new GravityPoint // привязываем гравитоны к полям
            {
                X = (float)(picDisplay.Width * 0.25),
                Y = picDisplay.Height / 2
            };
            point2 = new GravityPoint
            {
                X = (float)(picDisplay.Width * 0.75),
                Y = picDisplay.Height / 2
            };

            // привязываем поля к эмиттеру
            emitter.impactPoints.Add(point1);
            emitter.impactPoints.Add(point2);

            /*________________________________________________________
                // антигравитон в центре
                emitter.impactPoints.Add(new AntiGravityPoint
                {
                    X = picDisplay.Width / 2,
                    Y = picDisplay.Height / 2
                });
            ________________________________________________________*/

            //порталы
            portal1 = new InPortal 
            {
                X = -100,
                Y = -100
            };

            portal2 = new OutPortal
            {
                X = -100,
                Y = -100
            };
            // привязываем поля к эмиттеру
            emitter.portals.Add(portal1);
            emitter.portals.Add(portal2);


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            emitter.UpdateState(); // каждый тик обновляем систему

            using (var g = Graphics.FromImage(picDisplay.Image))
            {
                g.Clear(Color.Black); // очистка picDisplay
                emitter.Render(g); // рендерим систему
            }

            picDisplay.Invalidate();//обновление picDisplay
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (emitter.GravitationY == 0)
            { emitter.GravitationY = 1; }
            else
            { emitter.GravitationY = 0; }
        }

        private void tbDirection_Scroll(object sender, EventArgs e)
        {
            emitter.Direction = tbDirection.Value; // направлению эмиттера присваиваем значение ползунка 
            lblDirection.Text = $"{tbDirection.Value}°"; //вывод значения
        }

        private void tbSpreading_Scroll(object sender, EventArgs e)
        {
            emitter.Spreading = tbSpreading.Value; // разбросу присваиваем значение ползунка 
            lblSpreading.Text = $"{tbSpreading.Value}°";//вывод значения
        }

        private void tbGravion_Scroll(object sender, EventArgs e)
        {
            point1.Power = tbGraviton.Value;
        }

        private void tbGraviton2_Scroll(object sender, EventArgs e)
        {
            point2.Power = tbGraviton2.Value;
        }

        private void picDisplay_MouseMove(object sender, MouseEventArgs e)
        {

            foreach (var emitter in emitters)
            {
                emitter.MousePositionX = e.X;
                emitter.MousePositionY = e.Y;
            }

            // а тут передаем положение мыши, в положение гравитона
            point2.X = e.X;
            point2.Y = e.Y;
        }

        private void picDisplay_MouseClick(object sender, MouseEventArgs e)
        {
            foreach (var emitter in emitters)
            {
                emitter.MousePositionX = e.X;
                emitter.MousePositionY = e.Y;
            }

            if (e.Button == MouseButtons.Left)
            {
                portal1.X = e.X;
                portal1.Y = e.Y;
            }

            else
            {
                portal2.X = e.X;
                portal2.Y = e.Y;
            }
        }
    }
}
