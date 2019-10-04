using System;
using System.Linq;

namespace gol
{
    public class CountLivingNeighbours
    {
        private LocateAdjacentCells locateAdjacentCells;
        private LocateLivingCells livingCells;

        public CountLivingNeighbours(LocateAdjacentCells locateAdjacentCells, LocateLivingCells livingCells)
        {
            this.locateAdjacentCells = locateAdjacentCells;
            this.livingCells = livingCells;
        }

        public int NumberOfLivingNeighboursOf(LocateCellAt locateCellAt)
        {
            var neighbours = locateAdjacentCells.DetermineNeighbourhoodOf(locateCellAt);
            return neighbours.Count(n => livingCells.IsAlive(n));
        }
    }
}