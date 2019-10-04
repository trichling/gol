using System;
using System.Collections.Generic;
using System.Linq;

namespace gol
{
    public class LocateCellAt
    {
        public static bool IsAt(int row, int column, LocateCellAt location)
        {
            return location.Equals(new LocateCellAt(row, column));
        }

        private readonly int row;
        private readonly int column;

        public LocateCellAt(int row, int column)
        {
            this.row = row;
            this.column = column;
        }

        public LocateCellAt CellAtOffset(LocateCellAt offset)
        {
            return new LocateCellAt(this.row + offset.row, this.column + offset.column);
        }

        public (int rows, int columns) DistanceTo(LocateCellAt destination)
        {
            return (destination.row - row, destination.column - column);
        }

        public IEnumerable<LocateCellAt> DetermineNeighbourhood()
        {
            return new (int row, int column)[] 
                        { (-1, -1), (-1, 0), (-1, 1), 
                          (0 , -1),          (0 , 1),
                          (1 , -1), (1 , 0), (1 , 1)
                        }
                        .Select(offset => new LocateCellAt(offset.row, offset.column))
                        .Select(offset => CellAtOffset(offset));
        }

        public override bool Equals(object obj)
        {
            return obj is LocateCellAt at &&
                   row == at.row &&
                   column == at.column;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(row, column);
        }
    }
}