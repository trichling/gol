using System;
using System.Threading.Tasks;

namespace gol
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var minimumLocation = new LocateCellAt(0,0);
            var maximumLocation = new LocateCellAt(10, 20);
            var enumerateCells = new EnumerateCells(minimumLocation, maximumLocation);

            var nextGeneration = Square();

            while (true)
            {
                Console.WriteLine(new PrintGeneration(enumerateCells, nextGeneration));
                await Task.Delay(500);
                Console.Clear();
                nextGeneration = new ProceedToNextGeneration(enumerateCells).FromCurrentGeneration(nextGeneration);
            }
        }

        private static LocateLivingCells Square()
        {
            var square = new LocateLivingCells();

            square.Resurrect(new LocateCellAt(4, 9));
            square.Resurrect(new LocateCellAt(4, 10));
            square.Resurrect(new LocateCellAt(4, 11));

            square.Resurrect(new LocateCellAt(5, 9));
            square.Resurrect(new LocateCellAt(5, 10));
            square.Resurrect(new LocateCellAt(5, 11));

            square.Resurrect(new LocateCellAt(6, 9));
            square.Resurrect(new LocateCellAt(6, 10));
            square.Resurrect(new LocateCellAt(6, 11));

            return square;
        }

        private static LocateLivingCells TenCellRow()
        {
            var tenCellRow = new LocateLivingCells();

            tenCellRow.Resurrect(new LocateCellAt(5, 5));
            tenCellRow.Resurrect(new LocateCellAt(5, 6));
            tenCellRow.Resurrect(new LocateCellAt(5, 7));
            tenCellRow.Resurrect(new LocateCellAt(5, 8));
            tenCellRow.Resurrect(new LocateCellAt(5, 9));
            tenCellRow.Resurrect(new LocateCellAt(5, 10));
            tenCellRow.Resurrect(new LocateCellAt(5, 11));
            tenCellRow.Resurrect(new LocateCellAt(5, 12));
            tenCellRow.Resurrect(new LocateCellAt(5, 13));
            tenCellRow.Resurrect(new LocateCellAt(5, 14));
            
            return tenCellRow;
        }
    }
}
