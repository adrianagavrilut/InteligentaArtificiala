using System.Drawing;

namespace AOP_project
{
    public class Tile
    {
        public int i, j;

        public Tile(int i, int j)
        {
            this.i = i;
            this.j = j;
        }

        public void DrawTile()
        {
            if (i == Engine.n / 2 && j == Engine.m / 2)
            {
                Engine.grp.FillRectangle(new SolidBrush(Color.AntiqueWhite), i * Engine.length, j * Engine.length, Engine.length, Engine.length);
                Engine.grp.DrawString("HQ", new Font("Calisto MT", 9, FontStyle.Regular), new SolidBrush(Color.Black), new PointF(i * Engine.length + 1, j * Engine.length + 5));
            }
            else if (Engine.map[i, j] == -1)
                Engine.grp.FillRectangle(new SolidBrush(Color.DimGray), i * Engine.length, j * Engine.length, Engine.length, Engine.length);
            else if (Engine.map[i, j] != 0)
            {
                switch (Engine.cells[i, j])
                {
                    case ResourceType.Explorer:
                        Engine.grp.DrawString(Engine.map[i, j].ToString(), new Font("Arial", 10, FontStyle.Bold), new SolidBrush(Color.Gold), i * Engine.length + 3, j * Engine.length + 5);
                        break;
                    case ResourceType.Exploiter:
                        Engine.grp.DrawString(Engine.map[i, j].ToString(), new Font("Arial", 10, FontStyle.Bold), new SolidBrush(Color.SpringGreen), i * Engine.length + 3, j * Engine.length + 5);
                        break;
                    case ResourceType.Transporter:
                        Engine.grp.DrawString("X", new Font("Arial", 10, FontStyle.Bold), new SolidBrush(Color.Red), i * Engine.length + 3, j * Engine.length + 5);
                        //Engine.grp.FillRectangle(new SolidBrush(Color.Black), i * Engine.length, j * Engine.length, Engine.length, Engine.length);
                        break;
                    default:
                        Engine.grp.DrawString(Engine.map[i, j].ToString(), new Font("Arial", 10, FontStyle.Bold), new SolidBrush(Color.Gray), i * Engine.length + 3, j * Engine.length + 5);
                        break;
                }
            }
            Engine.grp.DrawRectangle(Pens.Gray, i * Engine.length, j * Engine.length, Engine.length, Engine.length);
        }
    }
}
