using System;
using gol;

namespace gol
{
    public class ProceedToNextGeneration
    {
        private readonly EnumerateCells enumerateCells;

        public ProceedToNextGeneration(EnumerateCells enumerateCells)
        {
            this.enumerateCells = enumerateCells;
        }

        public LocateLivingCells FromCurrentGeneration(LocateLivingCells livingCells)
        {
            var countLivingNeighbours = new CountLivingNeighbours(new LocateAdjacentCells(enumerateCells), livingCells);
            var nextGenerationLivingCells = new LocateLivingCells();
            
            foreach (var currentCell in enumerateCells.All())
            {
                var isAlive = livingCells.IsAlive(currentCell);
                var numberOfLivingNeighbours = countLivingNeighbours.NumberOfLivingNeighboursOf(currentCell);
                var cellAction = new DetermineCellActionByApplyingAllRules(isAlive, numberOfLivingNeighbours).DetermineCellAction();

                nextGenerationLivingCells.Apply(cellAction, currentCell);
            }  

            return nextGenerationLivingCells;
        }
    }
}