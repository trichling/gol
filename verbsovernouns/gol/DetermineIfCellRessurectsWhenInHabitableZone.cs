namespace gol
{
    public class DetermineIfCellRessurectsWhenInHabitableZone
    {
        private readonly int numberOfLivingNeighbours;

        public DetermineIfCellRessurectsWhenInHabitableZone(int numberOfLivingNeighbours)
        {
            this.numberOfLivingNeighbours = numberOfLivingNeighbours;
        }

        public ChangeCellState DetermineCellAction()
        {
            if (numberOfLivingNeighbours == 3)
                return ChangeCellState.Resurrect;

            return ChangeCellState.StayDead;
        }
    }
}