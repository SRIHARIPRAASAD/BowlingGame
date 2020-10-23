using System;
using Xunit;

namespace BowlingBall.Tests
{
    public class GameFixture
    {
        [Fact]
        public void GetScoreForAllZeroesWorks()
        {
            Game game = new Game();
            for (int i = 0; i < 20; i++)
            {
                game.Roll(0);
            }

            Assert.Equal(0, game.GetScore());
        }

        [Fact]
        public void GetScoreForAllOnesWorks()
        {
            Game game = new Game();
            for (int i = 0; i < 20; i++)
            {
                game.Roll(1);
            }

            Assert.Equal(20, game.GetScore());
        }        
    }
}
