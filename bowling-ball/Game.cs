using System;

namespace BowlingBall
{
    public class Game
    {
        public Frame[] Frames = new Frame[10];
        public int frameScore = 0;
        public int currentFrame = 0;

        public Game()
        {
            for (int i = 0; i < 10; i++)
            {
                Frames[i] = new Frame();
                //Check for final frame
                Frames[i].Type = i == 9 ? FrameType.LastFrame : FrameType.Normal;
            }
        } 

        public void Roll(int pins)
        {           
             Frames[currentFrame].Roll(pins);

            if (Frames[currentFrame].State != FrameState.NotAttempted && Frames[currentFrame].Type != FrameType.LastFrame)
                currentFrame++;
        }

        public int GetScore()
        {
            FrameBonusCalculationForStrikeORSpare();
            FinalScoreofAllCombinedFrames();
            return frameScore;
        }

        
        private void FinalScoreofAllCombinedFrames()
        {
            frameScore = 0;
            //Bowling game contains 10 frames. Finalscore is the count from all Frames
            for (int frameIndex = 0; frameIndex < 10; frameIndex++)
            {
                frameScore += Frames[frameIndex].GetPinCount() + Frames[frameIndex].Bonus;
            }
        }

        private void FrameBonusCalculationForStrikeORSpare()
        {
            try
            {
                for (int frameIndex = 0; frameIndex < 10; frameIndex++)
                {
                    //Calculate bonus for Strike
                    if (Frames[frameIndex].State == FrameState.Strike && Frames[frameIndex].Type != FrameType.LastFrame)
                    {
                        if (Frames[frameIndex + 1].Type != FrameType.LastFrame)
                        {
                            if (Frames[frameIndex + 1].State == FrameState.Strike)//Bonus when current frame is strike and next fame is also strike
                                Frames[frameIndex].Bonus = Frames[frameIndex + 1].Rolls[0] + Frames[frameIndex + 2].Rolls[0];
                            else
                                Frames[frameIndex].Bonus = Frames[frameIndex + 1].Rolls[0] + Frames[frameIndex + 1].Rolls[1];//Bonus when current frame is strike and next fame is not a strike
                        }
                        else //for second last frame
                            Frames[frameIndex].Bonus = Frames[frameIndex + 1].Rolls[0] + Frames[frameIndex + 1].Rolls[1];
                    }

                    //Calculate bonus for Spare
                    if (Frames[frameIndex].State == FrameState.Spare && Frames[frameIndex].Type != FrameType.LastFrame)
                        Frames[frameIndex].Bonus = Frames[frameIndex + 1].Rolls[0];

                    //Final
                    if (Frames[frameIndex].Type == FrameType.LastFrame)
                        Frames[frameIndex].Bonus = 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}

