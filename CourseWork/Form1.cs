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

        AntiGravityPoint point1; //поле под антигравитон
        GravityPoint point2; //поле под гравитон

        Portal portal1;//поле под первый портал
        Portal portal2;//поле под второй портал



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

            // антигравитон
            point1 = new AntiGravityPoint // привязываем гравитоны к полям
            {
                X = (float)(picDisplay.Width * 0.25),
                Y = picDisplay.Height / 2
            };
            //гравитон
            point2 = new GravityPoint
            {
                X = (float)(picDisplay.Width * 0.75),
                Y = picDisplay.Height / 2
            };

            //выходной портал
            portal2 = new Portal
            {
                X = -500,
                Y = -500,
                InP = false
            };

            //входной портал
            portal1 = new Portal
            {
                X = -500,
                Y = -500,
                InP = true,
                xOut = portal2.X,
                yOut = portal2.Y
            };

            // привязываем поля к эмиттеру
            emitter.impactPoints.Add(point1);
            emitter.impactPoints.Add(point2);
            emitter.impactPoints.Add(portal1);
            emitter.impactPoints.Add(portal2);

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
            point1.X = e.X;
            point1.Y = e.Y;
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
                portal1.xOut = portal2.X;
                portal1.yOut = portal2.Y;
            }
        }

        private void tbPortalSize_Scroll(object sender, EventArgs e)
        {
            portal1.Deam = tbPortalSize.Value;
            portal2.Deam = tbPortalSize.Value;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                portal2.color = colorDialog1.Color;
                button2.BackColor = colorDialog1.Color;
            }
        }

    }
}
