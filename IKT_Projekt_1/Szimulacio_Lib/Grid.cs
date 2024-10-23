namespace Szimulacio_Lib
{
    public class Grid
    {
        public int[,] Grass { get; private set; }
        public int[,] Rabbits { get; private set; }
        public int[,] Foxes { get; private set; }
        public const int GridSize = 20;
        private Random random;

        public Grid()
        {
            Grass = new int[GridSize, GridSize];
            Rabbits = new int[GridSize, GridSize];
            Foxes = new int[GridSize, GridSize];
            random = new Random();
        }

        public void InitializeGrass()
        {
            for (int i = 0; i < GridSize; i++)
            {
                for (int j = 0; j < GridSize; j++)
                {
                    Grass[i, j] = random.Next(3);
                }
            }
        }

        public void UpdateGrass()
        {
            for (int i = 0; i < GridSize; i++)
            {
                for (int j = 0; j < GridSize; j++)
                {
                    if (Grass[i, j] < 2)
                    {
                        Grass[i, j]++;
                    }
                }
            }
        }


    }
}
