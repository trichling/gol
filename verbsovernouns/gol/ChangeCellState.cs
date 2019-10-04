namespace gol 
{

    public class ChangeCellState
    {
        public static readonly ChangeCellState Die = new Die();
        public static readonly ChangeCellState Survive = new Survive();
        public static readonly ChangeCellState Resurrect = new Resurrect();
        public static readonly ChangeCellState StayDead = new StayDead();

    }

    public class Die : ChangeCellState
    {

    }

    public class Survive : ChangeCellState
    {

    }

    public class Resurrect : ChangeCellState
    {

    }

    public class StayDead : ChangeCellState
    {

    }
}