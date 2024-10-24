namespace Szimulacio_Lib
{
    public class Simulation
    {
        private Grid grid;
        private Rabbit rabbit;
        private Fox fox;
        private int rounds;
        private const int gridSize = 20;
        private Random random;

        public Simulation()
        {
            grid = new Grid();
            rabbit = new Rabbit(grid);
            fox = new Fox(grid);
            random = new Random();
        }

        public void Initialize(int initialRabbits = 5, int initialFoxes = 5)
        {
            grid.InitializeGrass();

            for (int i = 0; i < initialRabbits; i++)
            {
                int x, y;
                do
                {
                    x = random.Next(Grid.GridSize);
                    y = random.Next(Grid.GridSize);
                } while (grid.Rabbits[x, y] > 0);

                rabbit.Place(x, y);
            }

            for (int i = 0; i < initialFoxes; i++)
            {
                int x, y;
                do
                {
                    x = random.Next(Grid.GridSize);
                    y = random.Next(Grid.GridSize);
                } while (grid.Foxes[x, y] > 0 || grid.Rabbits[x, y] > 0);

                fox.Place(x, y);
            }
        }

        public void Run()
        {
            while (true)
            {
                Console.Clear();
                grid.UpdateGrass();
                grid.PrintGrid();
                rabbit.Update();
                fox.Update();
                rounds++;
                Console.WriteLine($"{rounds}. kör");
                System.Threading.Thread.Sleep(1000);

                if (!CheckPopulation())
                {
                    return;
                }
            }
        }

        private bool CheckPopulation()
        {
            bool hasRabbits = false;
            bool hasFoxes = false;

            for (int i = 0; i < Grid.GridSize; i++)
            {
                for (int j = 0; j < Grid.GridSize; j++)
                {
                    if (grid.Rabbits[i, j] > 0)
                        hasRabbits = true;
                    if (grid.Foxes[i, j] > 0)
                        hasFoxes = true;
                }
            }

            if (!hasRabbits && !hasFoxes)
            {
                Console.WriteLine($"Kihaltak a nyulak és a rókák! A szimuláció leállt a {rounds}. körben!");
                return false;
            }
            else if (!hasRabbits)
            {
                Console.WriteLine($"Kihaltak a nyulak! A szimuláció leállt a(z) {rounds}. körben!");
                return false;
            }
            else if (!hasFoxes)
            {
                Console.WriteLine($"Kihaltak a rókák! A szimuláció leállt a(z) {rounds}. körben!");
                return false;
            }

            return true;
        }
    }
}
