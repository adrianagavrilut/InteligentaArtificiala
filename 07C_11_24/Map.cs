using System.Drawing;

namespace _07C_11_24
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

        public void SpawnResources(int x, int y, int c) // locatie si cantitate
        {
            values[x, y] = c;
        }

        public void SpawnDeadZone(int x, int y)
        {
            values[x, y] = -1;
        }

        public void Draw(Graphics handler)
        {
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                {
                    handler.DrawRectangle(Pens.Gray, i * Engine.deltaX, j * Engine.deltaY, Engine.deltaX, Engine.deltaY);
                    if (values[i, j] == -1)
                        handler.FillRectangle(new SolidBrush(Color.Black), i * Engine.deltaX, j * Engine.deltaY, Engine.deltaX, Engine.deltaY);
                    if (values[i, j] > 0)
                        handler.DrawString(values[i, j].ToString(), new Font("Arial", 10, FontStyle.Regular), new SolidBrush(Color.Red), new PointF(i * Engine.deltaX + 2, j * Engine.deltaY + 3));
                }
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

        
    }
}
