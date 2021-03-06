using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing; // чтобы исплоьзовать Graphics

namespace CourseWork
{
    public class Particle
    {

        public int Radius; // радуис частицы
        public float X; // X координата положения частицы в пространстве
        public float Y; // Y координата положения частицы в пространстве

        public float SpeedX; // скорость перемещения по оси X
        public float SpeedY; // скорость перемещения по оси Y

        public float Life; // запас здоровья частицы

        public static Random rnd = new Random(); //генератор случайных чисел

        // конструктор по умолчанию будет создавать кастомную частицу
        public Particle()
        {
            // генерируем произвольное направление и скорость
            var direction = (double)rnd.Next(360);
            var speed = 1 + rnd.Next(10);

            // рассчитываем вектор скорости
            SpeedX = (float)(Math.Cos(direction / 180 * Math.PI) * speed);
            SpeedY = -(float)(Math.Sin(direction / 180 * Math.PI) * speed);

            Radius = 2 + rnd.Next(10);
            Life = 20 + rnd.Next(100); //исходный запас здоровья от 20 до 120
        }

        public virtual void Draw(Graphics g)
        {
            float k = Math.Min(1f, Life / 100);// рассчитываем коэффициент прозрачности по шкале от 0 до 1.0

            int alpha = (int)(k * 255);// рассчитываем значение альфа канала в шкале от 0 до 255

            var color = Color.FromArgb(alpha, Color.Black);// создаем цвет из уже существующего, но привязываем к нему еще и значение альфа канала

            var b = new SolidBrush(color);// создали кисть для рисования

            g.FillEllipse(b, X - Radius, Y - Radius, Radius * 2, Radius * 2);// нарисовали залитый кружок радиусом Radius с центром в X, Y

            b.Dispose();// удалили кисть из памяти
        }
    }

    // новый класс для цветных частиц
    public class ParticleColorful : Particle
    {
        // два новых поля под цвет начальный и конечный
        public Color FromColor;
        public Color ToColor;


        // для смеси цветов
        public static Color MixColor(Color color1, Color color2, float k)
        {
            return Color.FromArgb(
                (int)(color2.A * k + color1.A * (1 - k)),
                (int)(color2.R * k + color1.R * (1 - k)),
                (int)(color2.G * k + color1.G * (1 - k)),
                (int)(color2.B * k + color1.B * (1 - k))
            );
        }

        //отрисовка
        public override void Draw(Graphics g)
        {
            float k = Math.Min(1f, Life / 100);

            // так как k уменьшается от 1 до 0, то порядок цветов обратный
            var color = MixColor(ToColor, FromColor, k);
            var b = new SolidBrush(color);

            g.FillEllipse(b, X - Radius, Y - Radius, Radius * 2, Radius * 2);

            b.Dispose();
        }
    }
}
