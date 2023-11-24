using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06C_11_17_AOP
{
    public abstract class Agent
    {
        public Point location;
        public int ID;
        public List<Point> path;

        public virtual void Draw(Graphics handler)
        {
            handler.DrawEllipse(Pens.Black, location.X * Engine.deltaX - 5, location.Y * Engine.deltaY - 5, 11, 11);
        }
    }

    public class Explorer : Agent
    {
        public int radius;

        public override void Draw(Graphics handler)
        {
            base.Draw(handler);
            handler.DrawString("explorer", new Font("Arial", 8, FontStyle.Regular), new SolidBrush(Color.Blue), new PointF(location.X * Engine.deltaX, location.Y * Engine.deltaY));
        }
    }

    public class Exploiter : Agent
    {
        public int pRate; //process rate

        public override void Draw(Graphics handler)
        {
            base.Draw(handler);
            handler.DrawString("exploiter", new Font("Arial", 8, FontStyle.Regular), new SolidBrush(Color.Red), new PointF(location.X * Engine.deltaX, location.Y * Engine.deltaY));
        }
    }

    public class Transporter : Agent
    {
        public int capacity;
        public int luRate; // loading, unloading rate
        public int crtCapacity;

        public override void Draw(Graphics handler)
        {
            base.Draw(handler);
            handler.DrawString("transporter", new Font("Arial", 8, FontStyle.Regular), new SolidBrush(Color.Green), new PointF(location.X * Engine.deltaX, location.Y * Engine.deltaY));
        }
    }
}
