namespace Szimulacio_Lib
{
    public class Rabbit
    {
        private const int maxRabbitSatiety = 5;
        private Grid grid;

        public Rabbit(Grid grid)
        {
            this.grid = grid;
        }

          public void Update()
  {
      for (int i = 0; i < Grid.GridSize; i++)
      {
          for (int j = 0; j < Grid.GridSize; j++)
          {
              if (grid.Rabbits[i, j] > 0)
              {
                  EatGrass(i, j);
                  Move(i, j);
              }
          }
      }
      Reproduce();
  }namespace Szimulacio_Lib
{
    public class Rabbit
    {
        private const int maxRabbitSatiety = 5;
        private Grid grid;

        public Rabbit(Grid grid)
        {
            this.grid = grid;
        }

        public void Place(int x, int y)
        {
            grid.Rabbits[x, y] = new Random().Next(maxRabbitSatiety) + 1;
        }

        public void Update()
        {
            for (int i = 0; i < Grid.GridSize; i++)
            {
                for (int j = 0; j < Grid.GridSize; j++)
                {
                    if (grid.Rabbits[i, j] > 0)
                    {
                        EatGrass(i, j);
                        Move(i, j);
                    }
                }
            }
            Reproduce();
        }

        private void EatGrass(int x, int y)
        {
            if (grid.Grass[x, y] == 2)
            {
                grid.Rabbits[x, y] = Math.Min(grid.Rabbits[x, y] + 2, maxRabbitSatiety);
                grid.Grass[x, y] = 0;
            }
            else if (grid.Grass[x, y] == 1)
            {
                grid.Rabbits[x, y] = Math.Min(grid.Rabbits[x, y] + 1, maxRabbitSatiety);
                grid.Grass[x, y] = 0;
            }
            else
            {
                grid.Rabbits[x, y]--;
            }
        }

        public void Move(int x, int y)
        {
            int[] directions = { -1, 0, 1 };
            Random(directions);

            foreach (var dx in directions)
            {
                foreach (var dy in directions)
                {
                    if (dx == 0 && dy == 0) continue;
                    int ni = (x + dx + Grid.GridSize) % Grid.GridSize;
                    int nj = (y + dy + Grid.GridSize) % Grid.GridSize;

                    if (grid.Rabbits[ni, nj] == 0 && grid.Foxes[ni, nj] == 0 && grid.Grass[ni, nj] != 0)
                    {
                        grid.Rabbits[ni, nj] = grid.Rabbits[x, y];
                        grid.Rabbits[x, y] = 0;
                        return;
                    }
                }
            }
        }

    }
}
