using gol;

namespace tests;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void Can_Initialize_A_Game()
    {

        var game = new Game(new[,] { 
            { true, true}, 
            { true, true}
        });

    }

    [TestMethod]
    public void A_Single_Cell_Has_Zero_Neigbours()
    {

        var game = new Game(new[,] { 
            { true }
        });

        Assert.AreEqual(0, game.NumberOfLivingNeigboursOf(1, 1));
    }

    [TestMethod]
    public void Two_Cells_Have_OPne_Neigbour_Each()
    {
        var game = new Game(new[,] { 
            { true, true }
        });

        Assert.AreEqual(1, game.NumberOfLivingNeigboursOf(1, 1));
        Assert.AreEqual(1, game.NumberOfLivingNeigboursOf(1, 2));
    }

    
    [TestMethod]
    public void Can_Detect_Cell_State()
    {
        var game = new Game(new[,] { 
            { false }
        });

        Assert.IsFalse(game.IsAlive(1, 1));
    }

    [TestMethod]
    public void An_Empty_Board_Stays_Empty()
    {
        var game = new Game(new[,] { 
            { false }
        });

        game.Evolve();

        Assert.IsFalse(game.IsAlive(1, 1));
    }

    [TestMethod]
    public void A_Single_Cell_Dies()
    {
        var game = new Game(new[,] { 
            { true }
        });

        game.Evolve();

        Assert.IsFalse(game.IsAlive(1, 1));
    }

    [TestMethod]
    public void Two_Adjacent_Cells_Die_Both()
    {
        var game = new Game(new[,] { 
            { true, true }
        });

        game.Evolve();

        Assert.IsFalse(game.IsAlive(1, 1));
        Assert.IsFalse(game.IsAlive(1, 2));
    }

    [TestMethod]
    public void A_Cell_With_2_Neigbours_Stays()
    {
        var game = new Game(new[,] { 
            { true, true, true }
        });

        game.Evolve();

        Assert.IsFalse(game.IsAlive(1, 1));
        Assert.IsTrue(game.IsAlive(1, 2));
        Assert.IsFalse(game.IsAlive(1, 3));
    }

    [TestMethod]
    public void A_Cell_With_3_Neigbours_Stays()
    {
        var game = new Game(new[,] { 
            { true, true, true },
            { false, true, false },
        });

        game.Evolve();

        Assert.IsTrue(game.IsAlive(1, 1));
        Assert.IsTrue(game.IsAlive(1, 2));
        Assert.IsTrue(game.IsAlive(1, 3));
        Assert.IsTrue(game.IsAlive(2, 2));
    }

    [TestMethod]
    public void At_Empty_Cell_With_3_Neigbours_A_Cell_Respawns()
    {
        var game = new Game(new[,] { 
            { true, false, true },
            { false, true, false },
        });

        game.Evolve();

        Assert.IsFalse(game.IsAlive(1, 1));
        Assert.IsTrue(game.IsAlive(1, 2));
        Assert.IsFalse(game.IsAlive(1, 3));
        Assert.IsTrue(game.IsAlive(2, 2));
    }

        [TestMethod]
    public void At_Cell_With_4_Neigbours_Dies()
    {
        var game = new Game(new[,] { 
            { true, true, true },
            { true, true, false },
        });

        game.Evolve();

        Assert.IsFalse(game.IsAlive(1, 2));
    }
}