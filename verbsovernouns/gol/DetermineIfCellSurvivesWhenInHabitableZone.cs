namespace gol
{
    public class DetermineIfCellSurvivesWhenInHabitableZone
    {
        private readonly int numberOfLivingNeighbours;

        public DetermineIfCellSurvivesWhenInHabitableZone(int numberOfLivingNeighbours)
        {
            this.numberOfLivingNeighbours = numberOfLivingNeighbours;
        }

        public ChangeCellState DetermineCellAction()
        {
            if (numberOfLivingNeighbours == 2 || numberOfLivingNeighbours == 3)
                return ChangeCellState.Survive;

            return ChangeCellState.Die;
        }
    }
}