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
        Emitter emitter;

        bool dots = false;

        List<Particle> particles = new List<Particle>();//пустой список частиц
        public Form1()
        {
            InitializeComponent();
            picDisplay.Image = new Bitmap(picDisplay.Width, picDisplay.Height);// привязка изображения

            emitter = new TopEmitter
            {
                Width = picDisplay.Width,
                GravitationY = 0.25f
            };

                // гравитон
                emitter.impactPoints.Add(new GravityPoint
                {
                    X = (float)(picDisplay.Width * 0.25),
                    Y = picDisplay.Height / 2
                });

                // в центре антигравитон
                emitter.impactPoints.Add(new AntiGravityPoint
                {
                    X = picDisplay.Width / 2,
                    Y = picDisplay.Height / 2
                });

                // снова гравитон
                emitter.impactPoints.Add(new GravityPoint
                {
                    X = (float)(picDisplay.Width * 0.75),
                    Y = picDisplay.Height / 2
                });


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


        // добавляем переменные для хранения положения мыши
        private int MousePositionX = 0;
        private int MousePositionY = 0;

        private void picDisplay_MouseMove(object sender, MouseEventArgs e)
        {
            //заносим положение мыши в переменные для хранения положения мыши
            emitter.MousePositionX = e.X;
            emitter.MousePositionY = e.Y;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (emitter.GravitationY == 0)
            { emitter.GravitationY = 1; }
            else
            { emitter.GravitationY = 0; }
        }

    }
}
