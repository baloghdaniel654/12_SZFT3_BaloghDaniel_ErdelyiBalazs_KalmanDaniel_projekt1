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

    }
}
