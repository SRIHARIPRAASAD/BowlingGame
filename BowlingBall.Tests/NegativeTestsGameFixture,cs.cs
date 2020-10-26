using System;
using System.Collections.Generic;
using System.Text;
using Xunit;


namespace BowlingBall.Tests
{
    public class GameFixturesNegativeTests
    {
        [Theory]
        [InlineData(new int[] { 7, 4, 4, 2, 4, 6, 3, 1, 5, 4, 2, 7, 4, 3, 4, 5, 6, 4, 3, 7, 5 })]
        public void GetScoresForInvalidSumForFrame(int[] inputPins)
        {
            Game game = new Game();

            Assert.Throws<InvalidOperationException>(() =>
            {
                for (int i = 0; i < inputPins.Length; i++)
                {
                    game.Roll(inputPins[i]);
                }
            });
        }


        [Theory] ///More rolls then expected for game. 21 is max rolls. Now 24 rolls supplied
        [InlineData(new int[] { 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4,4,4,4 })] 
        public void GetScoresForExceedingRollsGivenForGame(int[] inputPins)
        {
            Game game = new Game();

            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                for (int i = 0; i < inputPins.Length; i++)
                {
                    game.Roll(inputPins[i]);
                }
            });            
        }
    }
}
