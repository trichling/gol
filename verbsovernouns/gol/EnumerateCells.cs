using System.Collections.Generic;
using System.Linq;
using gol;

namespace gol
{
    public class EnumerateCells
    {
        private LocateCellAt minimumCell;
        private LocateCellAt maximumCell;
        private (int rows, int columns) dimensions;
        private (int rows, int columns) origin;

        public EnumerateCells(LocateCellAt minimumLocation, LocateCellAt maximumLocation)
        {
            this.minimumCell = minimumLocation;
            this.maximumCell = maximumLocation;
            this.dimensions = minimumLocation.DistanceTo(maximumLocation);
            this.origin = new LocateCellAt(0, 0).DistanceTo(minimumLocation);
        }

        public bool IsWithinRange(LocateCellAt cell)
        {
            return All().Contains(cell);
        }

        public IEnumerable<LocateCellAt> All()
        {
            for (int row = origin.rows; row <= dimensions.rows; row++)
                for (int column = origin.columns; column <= dimensions.columns; column++)
                    yield return new LocateCellAt(row, column);
        }
    }
}