namespace BowlingGame
{
    public class Bowling
    {
        public Bowling()
        {
           
        }

        public int CurrentFrame { get; set; }
        public int Score { get; set; } = -1;

        public void StartGame()
        {
            Console.WriteLine($"Starting Game");
            CurrentFrame++;

            RollFrame();  
            
        }

        public void RollFrame()
        {
            Console.WriteLine($"Frame: {CurrentFrame}");
            Console.WriteLine($"Press Enter to Roll for Frame {CurrentFrame}");
            //Console.ReadLine();

            int roll = RollBall();
            Console.WriteLine($"Roll: {roll}");
            
        }

        public int RollBall()
        {
            Random rand = new Random();
            int rollValue = rand.Next(0, 10);

            return rollValue;
        }
    }
}
