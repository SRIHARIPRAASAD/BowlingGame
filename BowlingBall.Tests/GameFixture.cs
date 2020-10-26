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

        [Fact]
        public void GetScoreForAllSparesWorks()
        {
            Game game = new Game();
            for (int i = 0; i < 21; i++)
            {
                game.Roll(5);  //For two chances in a frame, each roll got 5pins
            }

            Assert.Equal(150, game.GetScore());
        }

        [Fact]
        public void GetScoreForAllStrikesWorks()
        {
            Game game = new Game();
            for (int i = 0; i < 12; i++)
            {
                game.Roll(10); //For two chances in a frame, 10pins got hit by first chance
            }

            Assert.Equal(300, game.GetScore());
        }

        [Fact]
        public void GetScoreInMiddleOfRolls()
        {
            Game game = new Game();
            for (int i = 0; i < 10; i++)
            {
                game.Roll(1); //for 10 rolls score
            }

            Assert.Equal(10, game.GetScore());
        }

        [Theory]
        [InlineData(new int[] { 7, 2, 4, 2, 4, 6, 3, 1, 5, 4, 2, 7, 4, 3, 4, 5, 6, 4, 3, 7, 5 }, 94)]
        [InlineData(new int[] { 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 10 }, 155)]
        [InlineData(new int[] { 5, 5, 10, 10, 6, 3, 6, 4, 7, 3, 2, 6, 4, 3, 2, 7, 5, 4 }, 136)]
        public void GetScoreForRandomPinsWorks(int[] inputPins, int expected)
        {
            Game game = new Game();
            for (int i = 0; i < inputPins.Length; i++)
            {
                game.Roll(inputPins[i]);
            }

            Assert.Equal(expected, game.GetScore());
        }

    }
}
