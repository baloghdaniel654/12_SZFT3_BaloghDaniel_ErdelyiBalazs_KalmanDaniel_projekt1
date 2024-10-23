namespace Szimulacio_Lib
{
    public class Fox
    {
        private const int maxFoxSatiety = 30;
        private Grid grid;

        public Fox(Grid grid)
        {
            this.grid = grid;
        }

        public void Place(int x, int y)
        {
            grid.Foxes[x, y] = new Random().Next(maxFoxSatiety / 2, maxFoxSatiety + 1);
        }

        public void Update()
        {
            for (int i = 0; i < Grid.GridSize; i++)
            {
                for (int j = 0; j < Grid.GridSize; j++)
                {
                    if (grid.Foxes[i, j] > 0)
                    {
                        if (!CheckForRabbits(i, j))
                        {
                            grid.Foxes[i, j]--;
                        }
                        Move(i, j);
                    }
                }
            }
            Reproduce();
        }




    }
}
