namespace BowlingGame
{
    public class Bowling
    {
        public Bowling()
        {

        }

        public int CurrentFrame { get; set; } = 1;
        public int Score { get; set; } = -1;

        public void StartGame()
        {
            Console.WriteLine($"Starting Game");
            RollFrame();
        }

        public void RollFrame()
        {
            Console.WriteLine($"Frame: {CurrentFrame}");
            Console.WriteLine($"Press Enter to Roll for Frame {CurrentFrame}");
            //Console.ReadLine();

            int currentRoll = 1;

            int maxRolls = CurrentFrame < 9 ? 2 : 3;

            while (currentRoll <= maxRolls)
            {
                int rollValue = RollBall();
                Console.WriteLine($"Roll {currentRoll}: Pins Hit: {rollValue}");
                currentRoll++;
            }

            CurrentFrame++;
        }

        public int RollBall()
        {
            Random rand = new Random();
            int rollValue = rand.Next(0, 10);

            return rollValue;
        }
    }
}
