using Xunit;

namespace BowlingGame.Tests
{
    public class BowlingTests
    {
        Bowling game = new();

        [Fact]
        public void CanStartGame()
        {
            game.StartGame();
           
            Assert.Equal(1, game.CurrentFrame);
        }

        [Fact]
        public void CanRollBall()
        {
            game.RollBall();
            Assert.True(game.Score >= 0);
        }


    }
}
