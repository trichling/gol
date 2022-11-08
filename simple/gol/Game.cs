namespace gol
{
    public class Game
    {

        private bool[,] state;

        public Game(bool[,] initialState)
        {
            var rows = initialState.GetLength(0) ;
            var columns = initialState.GetLength(1);

            state = new bool[rows + 2, columns + 2];
            
            for (var row = 0; row < rows; row++)
                for (var column = 0; column < columns; column++)
                    state[row + 1, column + 1] = initialState[row, column];
        }

        public int NumberOfLivingNeigboursOf(int row, int column)
        {
            var result = 0;
            for (int columnOffset = -1; columnOffset <= 1; columnOffset++)
                for (int rowOffset= -1; rowOffset <= 1; rowOffset++)
                {
                    if (rowOffset == 0 && columnOffset == 0)
                        continue;

                    result += state[row + rowOffset, column + columnOffset] ? 1 : 0;
                }

            return result;
        }

        public bool IsAlive(int row, int column)
        {
            return state[row, column];
        }

        public void Evolve()
        {
            var rows = state.GetLength(0) ;
            var columns = state.GetLength(1);

            var nextState = new bool[rows, columns];

            for (int row = 1; row < rows - 1; row++)
                for(int column = 1; column < columns - 1; column++ )
                {
                    var neigbours = NumberOfLivingNeigboursOf(row, column);

                    if (neigbours < 2)
                        nextState[row, column] = false;
                    
                    if (neigbours == 2 || neigbours == 3)
                         nextState[row, column] = state[row, column];

                    if (neigbours == 3)
                         nextState[row, column] = true;

                    if (neigbours >= 4)
                        nextState[row, column] = false;
                }

            state = nextState;
        }
    }
}