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
        public void PrintGrid()
        {
            for (int i = 0; i < GridSize; i++)
            {
                for (int j = 0; j < GridSize; j++)
                {
                    Console.ForegroundColor = Grass[i, j] switch
                    {
                        0 => ConsoleColor.DarkGray,
                        1 => ConsoleColor.Yellow,
                        _ => ConsoleColor.Green
                    };
                    Console.Write(".");

                    if (Rabbits[i, j] > 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("R");
                    }

                    else if (Foxes[i, j] > 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("F");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
            Console.ResetColor();
        }

    }
}
