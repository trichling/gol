namespace gol
{
    public class DetermineIfCellDiesDueToUnderpopulation
    {
        private readonly int numberOfLivingNeighbours;

        public DetermineIfCellDiesDueToUnderpopulation(int numberOfLivingNeighbours)
        {
            this.numberOfLivingNeighbours = numberOfLivingNeighbours;
        }

        public ChangeCellState DetermineCellAction()
        {
            if (numberOfLivingNeighbours < 2)
                return ChangeCellState.Die;

            return ChangeCellState.Survive;
        }
    }
}