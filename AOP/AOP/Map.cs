using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roboti
{

    public  class Map
    {
        private ResourceType[,] cells = new ResourceType[Engine.n, Engine.m];

        public Map(int width, int height)
        {
            cells = new ResourceType[width, height];
            // Initialize cells to default values (e.g., None)
        }

        public void SetCell(int x, int y, ResourceType type)
        {
            cells[x, y] = type;
        }

        public ResourceType GetCell(int x, int y)
        {
            return cells[x, y];
        }

    }
}
