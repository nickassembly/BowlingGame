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
           
            Assert.True(game.CurrentFrame > 0);
        }

        [Fact]
        public void CanRollFrame()
        {
            game.RollFrame();
            Assert.True(game.CurrentFrame > 1);
        }


    }
}
