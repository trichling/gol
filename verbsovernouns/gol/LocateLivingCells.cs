using System;
using System.Collections.Generic;

namespace gol
{
    public class LocateLivingCells
    {
        private HashSet<LocateCellAt> livingCells;
        
        public LocateLivingCells()
        {
            livingCells = new HashSet<LocateCellAt>();
        }

        public void Resurrect(LocateCellAt localizeCellAt)
        {
            livingCells.Add(localizeCellAt);
        }

        public void Die(LocateCellAt localizeCellAt)
        {
            livingCells.Remove(localizeCellAt);
        }

        public bool IsAlive(LocateCellAt localizeCellAt)
        {
            return livingCells.Contains(localizeCellAt);
        }

        public int NumberOfLivingCells()
        {
            return livingCells.Count;
        }

        public void Apply(ChangeCellState action, LocateCellAt at)
        {
            switch (action)
            {
                case StayDead stayDead:
                case Die die:
                    Die(at);
                    break;

                case Resurrect resurrect:
                case Survive survive:
                    Resurrect(at);
                    break;
            }
        }
    }
}