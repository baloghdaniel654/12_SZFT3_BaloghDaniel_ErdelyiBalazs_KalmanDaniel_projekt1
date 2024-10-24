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
        
    }
}
