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

        public bool CheckForRabbits(int x, int y)
        {
            for (int di = -2; di <= 2; di++)
            {
                for (int dj = -2; dj <= 2; dj++)
                {
                    if (Math.Abs(di) + Math.Abs(dj) > 2) continue;
                    int ni = (x + di + Grid.GridSize) % Grid.GridSize;
                    int nj = (y + dj + Grid.GridSize) % Grid.GridSize;

                    if (grid.Rabbits[ni, nj] > 0)
                    {
                        grid.Foxes[x, y] = Math.Min(grid.Foxes[x, y] + 3, maxFoxSatiety);
                        grid.Rabbits[ni, nj] = 0;
                        return true;
                    }
                }
            }
            return false;
        }

        public void Move(int x, int y)
        {
            int[] directions = { -1, 0, 1 };
            ShuffleArray(directions);

            foreach (var dx in directions)
            {
                foreach (var dy in directions)
                {
                    if (dx == 0 && dy == 0) continue;
                    int ni = (x + dx + Grid.GridSize) % Grid.GridSize;
                    int nj = (y + dy + Grid.GridSize) % Grid.GridSize;

                    if (grid.Rabbits[ni, nj] == 0 && grid.Foxes[ni, nj] == 0)
                    {
                        grid.Foxes[ni, nj] = grid.Foxes[x, y];
                        grid.Foxes[x, y] = 0;
                        return;
                    }
                }
            }
        }


    }
}
