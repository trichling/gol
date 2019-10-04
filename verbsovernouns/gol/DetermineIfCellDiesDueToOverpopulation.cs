namespace gol
{
    public class DetermineIfCellDiesDueToOverpopulation
    {
        private readonly int numberOfLivingNeighbours;

        public DetermineIfCellDiesDueToOverpopulation(int numberOfLivingNeighbours)
        {
            this.numberOfLivingNeighbours = numberOfLivingNeighbours;
        }

        public ChangeCellState DetermineCellAction()
        {
            if (numberOfLivingNeighbours > 3)
                return ChangeCellState.Die;

            return ChangeCellState.Survive;
        }
    }
}