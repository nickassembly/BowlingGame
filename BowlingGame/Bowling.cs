namespace BowlingGame
{
    public class Bowling
    {
        private List<int> _rolls = new List<int>();
        private int _currentRoll = 0;

        public Bowling()
        {
            for (int i = 0; i <= 21; i++)
            {
                _rolls.Add(0);
            }
        }

        public int CurrentFrame { get; set; } = 1;

        public int Score
        {
            get
            {
                int score = 0;
                int rollIndex = 0;
                for (int frame = 0; frame < 10; frame++)
                {
                    if (IsStrike(rollIndex))
                    {
                        score += 10 + StrikeScoreBonus(rollIndex);
                        rollIndex++;
                    }
                    else if (IsSpare(rollIndex))
                    {
                        score += 10 + SpareScoreBonus(rollIndex);
                        rollIndex += 2;
                    }
                    else
                    {
                        score += NormalScore(rollIndex);
                        rollIndex += 2;
                    }
                }

                return score;
            }
        }

        public void StartGame()
        {
            Console.WriteLine($"Bowling Game:");
            Console.WriteLine($"Press <enter> to start game");
            Console.ReadLine();

            for (int frame = 1; frame <= 10; frame++)
            {
                Console.WriteLine($"Frame: {CurrentFrame}");
                int framePins = RollFramePins();

                if (frame == 10 && framePins == 10)
                {
                   // Strike on 10th frame, roll 1, Player rolls 2 more times (frame 10: roll[stk] + roll roll)
                   // Strike OR Spare on 10th frame, roll 2, player rolls 3rd time. (frame 10: roll, roll[stk or spar] + roll) 
                }

                Console.WriteLine($"Total pins in Frame {CurrentFrame} was {framePins}");
            }
        }

        public int RollFramePins()
        {
            int totalPinsInFrame = 10;

            int rollScore = CalculateRoll(totalPinsInFrame);

            if (rollScore < totalPinsInFrame)
            {
                rollScore += CalculateRoll(totalPinsInFrame - rollScore);

                _rolls[_currentRoll] = rollScore;
                CurrentFrame++;

                return rollScore;
            }
            else
            {
                _rolls[_currentRoll] = rollScore;
                CurrentFrame++;

                return rollScore;
            }
        }

        public void Roll(int pinsHit)
        {
            _rolls[_currentRoll++] = pinsHit;
        }

        public void ProcessStrike()
        {
            CurrentFrame++;
        }

        private int CalculateRoll(int pinsLeft)
        {
            Random rand = new Random();
            int roll = rand.Next(0, pinsLeft);

            Console.WriteLine($"Roll amount: {roll}");
            return roll;
        }

        private bool IsStrike(int rollIndex)
        {
            return _rolls[rollIndex] == 10;
        }

        private int StrikeScoreBonus(int rollIndex)
        {
            return _rolls[rollIndex + 1] + _rolls[rollIndex + 2];
        }

        private bool IsSpare(int rollIndex)
        {
            return _rolls[rollIndex] + _rolls[rollIndex + 1] == 10;
        }

        private int SpareScoreBonus(int rollIndex)
        {
            return _rolls[rollIndex + 2];
        }

        private int NormalScore(int rollIndex)
        {
            return _rolls[rollIndex] + _rolls[rollIndex + 1];
        }

    }
}
