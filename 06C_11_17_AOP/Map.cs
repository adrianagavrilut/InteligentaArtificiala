using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06C_11_17_AOP
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
                        handler.DrawString(values[i, j].ToString(), new Font("Arial", 10, FontStyle.Regular), new SolidBrush(Color.Red), new PointF(i * Engine.deltaX + 5, j * Engine.deltaY + 5));
                }
        }

        public int[,] ConvertToMatrix(Map map)
        {
            int[,] matrixToReturn = new int[map.n, map.m];
            for (int i = 0; i < map.n; i++)
            {
                for (int j = 0; j < map.m; j++)
                {
                    matrixToReturn[i, j] = map.values[i, j];
                }
            }
            return matrixToReturn;
        }
    }
}
