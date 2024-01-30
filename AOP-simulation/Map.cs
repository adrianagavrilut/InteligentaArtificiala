using System.Drawing;

namespace AOP_simulation
{
    public class Map
    {
        public int[,] values;
        public int n { get { return values.GetLength(0); } }
        public int m { get { return values.GetLength(1); } }

        public void Init(int n, int m)
        {
            values = new int[n, m];
        }

        public void Draw(Graphics handler)
        {
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    handler.DrawRectangle(Pens.Gray, i * Engine.deltaX, j * Engine.deltaY, Engine.deltaX, Engine.deltaY);
            handler.FillRectangle(new SolidBrush(Color.AntiqueWhite), n / 2 * Engine.deltaX,  m / 2 * Engine.deltaY, Engine.deltaX, Engine.deltaY);
        }

        public int[,] ConvertToMatrix()
        {
            int[,] matrixToReturn = new int[this.n, this.m];
            for (int i = 0; i < this.n; i++)
            {
                for (int j = 0; j < this.m; j++)
                {
                    if (this.values[i, j] == -1)
                        matrixToReturn[i, j] = this.values[i, j];
                    else
                        matrixToReturn[i, j] = 0;
                }
            }
            return matrixToReturn;
        }

        internal void DrawResources(Graphics handler, int x, int y)
        {
            handler.FillEllipse(Brushes.Red, x * Engine.deltaX, y * Engine.deltaY, 20, 20);
        }
    }
}
