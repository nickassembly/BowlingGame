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

                for (int frame = 1; frame <= 10; frame++)
                {
                    if (IsStrike(rollIndex))
                    {
                        score += 10 + StrikeScoreBonus(rollIndex);

                        if (frame % 3 != 0)
                        {
                            Console.Write($"Frame: {frame} Running Score: {score} |");
                        }
                        else
                        {
                            Console.WriteLine($"Frame: {frame} Running Score: {score} |");
                        }

                        rollIndex++;
                    }
                    else if (IsSpare(rollIndex))
                    {
                        score += 10 + SpareScoreBonus(rollIndex);

                        if (frame % 3 != 0)
                        {
                            Console.Write($"Frame: {frame} Running Score: {score} |");
                        }
                        else
                        {
                            Console.WriteLine($"Frame: {frame} Running Score: {score} |");
                        }

                        rollIndex += 2;
                    }
                    else
                    {
                        score += NormalScore(rollIndex);

                        if (frame % 3 != 0)
                        {
                            Console.Write($"Frame: {frame} Running Score: {score}| ");
                        }
                        else
                        {
                            Console.WriteLine($"Frame: {frame} Running Score: {score}| ");
                        }

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
                int framePins = 0;
                int finalFramePins = 0;

                if (frame == 10)
                {
                    finalFramePins += CalculateRoll(10);

                    if (finalFramePins < 10)
                    {
                        finalFramePins += CalculateRoll(10 - finalFramePins);

                        if (finalFramePins == 10)
                            finalFramePins += CalculateBonusRoll(10);

                        Console.WriteLine($"Total pins hit in Frame {frame} was {framePins + finalFramePins}");
                    }
                    else if (finalFramePins == 10)
                    {
                        finalFramePins += CalculateBonusRoll(10);
                        finalFramePins += CalculateBonusRoll(10);

                        Console.WriteLine($"Total pins hit in Frame {frame} was {framePins + finalFramePins}");
                    }
                    else
                    {
                        Console.WriteLine($"Total pins hit in Frame {frame} was {framePins + finalFramePins}");
                    }

                }
                else
                {
                    framePins += RollFramePins();

                    Console.WriteLine($"Total pins hit in Frame {frame} was {framePins + finalFramePins}");
                }
            }

            Console.WriteLine($"Total Score: {Score}");
        }

        public int RollFramePins()
        {
            CurrentFrame++;

            int totalPinsInFrame = 10;

            int rollScore = CalculateRoll(totalPinsInFrame);

            if (rollScore < totalPinsInFrame)
            {
                rollScore += CalculateRoll(totalPinsInFrame - rollScore);

                _rolls[_currentRoll] = rollScore;
                return rollScore;
            }
            else
            {
                _rolls[_currentRoll] = rollScore;
                return rollScore;
            }
        }

        public void Roll(int pinsHit)
        {
            _rolls[_currentRoll++] = pinsHit;
        }

        private int CalculateRoll(int pinsLeft)
        {
            Random rand = new Random();
            int roll = rand.Next(0, pinsLeft + 1);

            Roll(roll);
            Console.WriteLine($"Roll amount: {roll}");

            return roll;
        }

        private int CalculateBonusRoll(int pinsLeft)
        {
            Random rand = new Random();
            int roll = rand.Next(0, pinsLeft + 1);

            Roll(roll);
            Console.WriteLine($"Bonus Roll Pins: {roll}");
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
