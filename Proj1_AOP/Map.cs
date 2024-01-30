namespace AOP_project
{

    public  class Map
    {
        private ResourceType[,] cells = new ResourceType[Engine.n, Engine.m];

        public Map(int width, int height)
        {
            cells = new ResourceType[width, height];
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
