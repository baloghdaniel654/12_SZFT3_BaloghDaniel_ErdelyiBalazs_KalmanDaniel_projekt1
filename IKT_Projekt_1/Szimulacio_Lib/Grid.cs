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


    }
}
