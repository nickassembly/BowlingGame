using System;
using Xunit;

namespace BowlingGame.Tests
{
    public class BowlingTests
    {
        [Fact]
        public void CanRollAllZeros()
        {
            var game = SetUp();

            RollForPins(game, 20, 0);

            Assert.Equal(0, game.Score);
        }

        [Fact]
        public void CanRollOnePerRoll()
        {
            var game = SetUp();

            RollForPins(game, 20, 1);

            Assert.Equal(20, game.Score);
        }

        [Fact]
        public void CanRollSpare()
        {
            var game = SetUp();

            RollSpare(game);
            game.Roll(6);
            RollForPins(game, 17, 0);

            Assert.Equal(22, game.Score);
        }

        [Fact]
        public void CanRollStrike()
        {
            var game = SetUp();

            RollStrike(game);
            game.Roll(3);
            game.Roll(4);
            RollForPins(game, 16, 0);

            Assert.Equal(24, game.Score);
        }

        [Fact]
        public void CanRollAllStrikes()
        {
            var game = SetUp();

            RollForPins(game, 21, 10);

            Assert.Equal(300, game.Score);
        }

        private Bowling SetUp()
        {
            return new Bowling();
        }

        private void RollForPins(Bowling game, int rolls, int pinsHitPerRoll)
        {
            for (int i = 0; i < rolls; i++)
            {
                game.Roll(pinsHitPerRoll);
            }
        }

        private void RollSpare(Bowling game)
        {
            game.Roll(5);
            game.Roll(5);
        }

        private void RollStrike(Bowling game)
        {
            game.Roll(10);
        }

    }
}
