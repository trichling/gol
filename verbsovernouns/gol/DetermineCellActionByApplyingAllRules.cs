using System.Linq;

namespace gol
{
    public class DetermineCellActionByApplyingAllRules
    {
        private readonly bool isAlive;
        private readonly int numberOfLivingNeighbours;

        public DetermineCellActionByApplyingAllRules(bool isAlive, int numberOfLivingNeighbours)
        {
            this.isAlive = isAlive;
            this.numberOfLivingNeighbours = numberOfLivingNeighbours;
        }

        public ChangeCellState DetermineCellAction()
        {
            if (isAlive)
            {
                var outcomes = new ChangeCellState[] {
                    new DetermineIfCellDiesDueToOverpopulation(numberOfLivingNeighbours).DetermineCellAction(),            
                    new DetermineIfCellDiesDueToUnderpopulation(numberOfLivingNeighbours).DetermineCellAction(),            
                    new DetermineIfCellSurvivesWhenInHabitableZone(numberOfLivingNeighbours).DetermineCellAction()
                };

                return outcomes.All(o => o == ChangeCellState.Survive) ? ChangeCellState.Survive : ChangeCellState.Die;
            }
            else
            {
                return new DetermineIfCellRessurectsWhenInHabitableZone(numberOfLivingNeighbours).DetermineCellAction();
            }
        }
    }
}