using System.Linq;
using gol;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace tests
{
    [TestClass]
    public class UnitTest1
    {
        [DataTestMethod]
        [DataRow(0, false)]
        [DataRow(1, false)]
        [DataRow(2, false)]
        [DataRow(3, false)]
        [DataRow(4, true)]
        [DataRow(5, true)]
        [DataRow(6, true)]
        [DataRow(7, true)]
        [DataRow(8, true)]
        public void DetermineCellAction_DiesDueToOverpopulation(int numberOfLivingNeighbours, bool willDie)
        {
            var rule = new DetermineIfCellDiesDueToOverpopulation(numberOfLivingNeighbours);

            var cellAction = rule.DetermineCellAction();

            if (willDie)
                Assert.AreEqual(ChangeCellState.Die, cellAction);
            else
                Assert.AreEqual(ChangeCellState.Survive, cellAction);
        }

        [DataTestMethod]
        [DataRow(0, true)]
        [DataRow(1, true)]
        [DataRow(2, false)]
        [DataRow(3, false)]
        [DataRow(4, false)]
        [DataRow(5, false)]
        [DataRow(6, false)]
        [DataRow(7, false)]
        [DataRow(8, false)]
        public void DetermineCellAction_DiesDueToUnderpopulation(int numberOfLivingNeighbours, bool willDie)
        {
            var rule = new DetermineIfCellDiesDueToUnderpopulation(numberOfLivingNeighbours);

            var cellAction = rule.DetermineCellAction();

            if (willDie)
                Assert.AreEqual(ChangeCellState.Die, cellAction);
            else
                Assert.AreEqual(ChangeCellState.Survive, cellAction);
        }

        [DataTestMethod]
        [DataRow(0, false)]
        [DataRow(1, false)]
        [DataRow(2, true)]
        [DataRow(3, true)]
        [DataRow(4, false)]
        [DataRow(5, false)]
        [DataRow(6, false)]
        [DataRow(7, false)]
        [DataRow(8, false)]
        public void DetermineCellAction_SurvivesWhenInHabitableZone(int numberOfLivingNeighbours, bool willSurvive)
        {
            var rule = new DetermineIfCellSurvivesWhenInHabitableZone(numberOfLivingNeighbours);

            var cellAction = rule.DetermineCellAction();

            if (willSurvive)
                Assert.AreEqual(ChangeCellState.Survive, cellAction);
            else
                Assert.AreEqual(ChangeCellState.Die, cellAction);
        }

        [DataTestMethod]
        [DataRow(0, false)]
        [DataRow(1, false)]
        [DataRow(2, false)]
        [DataRow(3, true)]
        [DataRow(4, false)]
        [DataRow(5, false)]
        [DataRow(6, false)]
        [DataRow(7, false)]
        [DataRow(8, false)]
        public void DetermineCellAction_RessurectsWhenInHabitableZone(int numberOfLivingNeighbours, bool willRessurect)
        {
            var rule = new DetermineIfCellRessurectsWhenInHabitableZone(numberOfLivingNeighbours);

            var cellAction = rule.DetermineCellAction();

            if (willRessurect)
                Assert.AreEqual(ChangeCellState.Resurrect, cellAction);
            else
                Assert.AreEqual(ChangeCellState.StayDead, cellAction);
        }

        [DataTestMethod]
        [DataRow(true, 0, CellActionEnum.Die)]
        [DataRow(true, 1, CellActionEnum.Die)]
        [DataRow(true, 2, CellActionEnum.Survive)]
        [DataRow(true, 3, CellActionEnum.Survive)]
        [DataRow(true, 4, CellActionEnum.Die)]
        [DataRow(true, 5, CellActionEnum.Die)]
        [DataRow(true, 6, CellActionEnum.Die)]
        [DataRow(true, 7, CellActionEnum.Die)]
        [DataRow(true, 8, CellActionEnum.Die)]
        [DataRow(false, 0, CellActionEnum.StayDead)]
        [DataRow(false, 1, CellActionEnum.StayDead)]
        [DataRow(false, 2, CellActionEnum.StayDead)]
        [DataRow(false, 3, CellActionEnum.Resurrect)]
        [DataRow(false, 4, CellActionEnum.StayDead)]
        [DataRow(false, 5, CellActionEnum.StayDead)]
        [DataRow(false, 6, CellActionEnum.StayDead)]
        [DataRow(false, 7, CellActionEnum.StayDead)]
        [DataRow(false, 8, CellActionEnum.StayDead)]
        public void DetermineCellAction_ApplyAllRules(bool isAlive, int numberOfLivingNeighbours, CellActionEnum expectedAction)
        {
            var rule = new DetermineCellActionByApplyingAllRules(isAlive, numberOfLivingNeighbours);

            var cellAction = rule.DetermineCellAction();

            switch (expectedAction)
            {
                case CellActionEnum.Survive: 
                    Assert.AreEqual(cellAction, ChangeCellState.Survive);
                    break;
                case CellActionEnum.Die: 
                    Assert.AreEqual(cellAction, ChangeCellState.Die);
                    break;
                case CellActionEnum.Resurrect: 
                    Assert.AreEqual(cellAction, ChangeCellState.Resurrect);
                    break;
                case CellActionEnum.StayDead: 
                    Assert.AreEqual(cellAction, ChangeCellState.StayDead);
                    break;
            }
        }

        [TestMethod]
        public void CanLocalizeCellAt()
        {
            var cellLocatation = new LocateCellAt(3, 3);

            Assert.IsTrue(LocateCellAt.IsAt(3, 3, cellLocatation));
        }

        [TestMethod]
        public void CanLocalizeLivingCells()
        {
            var livingCells = new LocateLivingCells();

            livingCells.Resurrect(new LocateCellAt(1, 1));

            Assert.IsTrue(livingCells.IsAlive(new LocateCellAt(1, 1)));
        }

        [TestMethod]
        public void DetermineAdjacentCells_MiddleCellHas8Neighbours()
        {
            var adjacentCells = new LocateAdjacentCells(new EnumerateCells(new LocateCellAt(0, 0), new LocateCellAt(2, 2)));

            var neighbourhood = adjacentCells.DetermineNeighbourhoodOf(new LocateCellAt(1, 1));

            Assert.AreEqual(8, neighbourhood.Count());
        }

        [TestMethod]
        public void DetermineAdjacentCells_TopLeftCellHas3Neighbours()
        {
            var adjacentCells = new LocateAdjacentCells(new EnumerateCells(new LocateCellAt(0, 0), new LocateCellAt(2, 2)));

            var neighbourhood = adjacentCells.DetermineNeighbourhoodOf(new LocateCellAt(0, 0));

            Assert.AreEqual(3, neighbourhood.Count());
        }

        [TestMethod]
        public void DetermineAdjacentCells_BottomRightCellHas3Neighbours()
        {
            var adjacentCells = new LocateAdjacentCells(new EnumerateCells(new LocateCellAt(0, 0), new LocateCellAt(2, 2)));

            var neighbourhood = adjacentCells.DetermineNeighbourhoodOf(new LocateCellAt(2, 2));

            Assert.AreEqual(3, neighbourhood.Count());
        }

        [TestMethod]
        public void CanEnumerateAllCells()
        {
            var enumerateCells = new EnumerateCells(new LocateCellAt(0, 0), new LocateCellAt(10, 10));
            var allCells = enumerateCells.All();

            Assert.AreEqual(11 * 11, allCells.Count());
        }

        [TestMethod]
        public void CanCountLivingCellsInNeighbourhood()
        {
            var livingCells = new LocateLivingCells();

            livingCells.Resurrect(new LocateCellAt(0, 0));
            livingCells.Resurrect(new LocateCellAt(1, 2));
            livingCells.Resurrect(new LocateCellAt(2, 0));

            var numberOfLivingNeighbours = new CountLivingNeighbours(
                new LocateAdjacentCells(new EnumerateCells(new LocateCellAt(0, 0), new LocateCellAt(10, 10))),
                livingCells
            ).NumberOfLivingNeighboursOf(new LocateCellAt(1, 1));

            Assert.AreEqual(3, numberOfLivingNeighbours);
        }

        [TestMethod]
        public void CanProceedToNextGeneration()
        {
            var livingCells = new LocateLivingCells();

            livingCells.Resurrect(new LocateCellAt(0, 0));
            livingCells.Resurrect(new LocateCellAt(1, 2));
            livingCells.Resurrect(new LocateCellAt(2, 0));

            var nextGeneration = new ProceedToNextGeneration(new EnumerateCells(
                new LocateCellAt(0, 0),
                new LocateCellAt(10, 10))
            ).FromCurrentGeneration(livingCells);

            var numberOfLivingNeighboursOf11 = new CountLivingNeighbours(new LocateAdjacentCells(new EnumerateCells(new LocateCellAt(0, 0),
                new LocateCellAt(10, 10))), nextGeneration).NumberOfLivingNeighboursOf(new LocateCellAt(1, 1));
            Assert.AreEqual(0, numberOfLivingNeighboursOf11);
            Assert.AreEqual(1, nextGeneration.NumberOfLivingCells());
            Assert.IsTrue(nextGeneration.IsAlive(new LocateCellAt(1,1)));
        }

        public enum CellActionEnum 
        {
            Survive,
            Die,
            Resurrect,
            StayDead
        }
    }
}
