using System;
using System.Collections.Generic;
using System.Linq;

namespace gol
{
    public class LocateAdjacentCells
    {
        private readonly EnumerateCells enumerateCells;

        public LocateAdjacentCells(EnumerateCells enumerateCells)
        {
            this.enumerateCells = enumerateCells;
        }

        public IEnumerable<LocateCellAt> DetermineNeighbourhoodOf(LocateCellAt localizeCellAt)
        {
            return localizeCellAt.DetermineNeighbourhood()
                         .Where(cellLocation => enumerateCells.IsWithinRange(cellLocation));
        }
    }
}