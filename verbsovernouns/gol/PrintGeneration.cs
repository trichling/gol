using System.Linq;
using System.Text;

namespace gol
{


    public class PrintGeneration
    {
        private readonly EnumerateCells enumerateCells;
        private readonly LocateLivingCells livingCells;

        public PrintGeneration(EnumerateCells enumerateCells, LocateLivingCells livingCells)
        {
            this.enumerateCells = enumerateCells;
            this.livingCells = livingCells;
        }


        override public string ToString()
        {
            var output = new StringBuilder();
            var lastCell = enumerateCells.All().First();

            foreach (var currentCell in enumerateCells.All())
            {
                if (lastCell.DistanceTo(currentCell).rows == 1)
                    output.AppendLine();

                if (livingCells.IsAlive(currentCell))
                    output.Append("X");
                else
                    output.Append(".");

                lastCell = currentCell;
            }   

            
            return output.ToString();
        }
    }

}