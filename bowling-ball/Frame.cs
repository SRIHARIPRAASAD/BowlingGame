using System;
using System.Collections.Generic;
using System.Text;

namespace BowlingBall
{
    public class Frame
    {
        public int[] Rolls;
        public FrameState State;
        public int Bonus;

        int rollIndex;
        FrameType frameType;

        public FrameType Type
        {
            get { return frameType; }
            set
            {
                if (value == FrameType.LastFrame)
                    Rolls = new int[] { 0, 0, 0 };

                frameType = value;
            }
        }

        public Frame()
        {
            Rolls = new int[] { 0, 0 };
            State = FrameState.NotAttempted;
            rollIndex = -1;
            Bonus = 0;
        }

        public void Roll(int pins)
        {
            Rolls[++rollIndex] = pins;

            if (Rolls[0] == 10)
                State = FrameState.Strike;
            else if (Rolls[0] + Rolls[1] == 10)
                State = FrameState.Spare;
            else if (rollIndex == 1)
                State = FrameState.None;

            if (Rolls[0] + Rolls[1] > 10 && Type != FrameType.LastFrame)
                throw new InvalidOperationException();
        }

        public int GetPinCount()
        {
            if (Type == FrameType.LastFrame)
                return Rolls[0] + Rolls[1] + Rolls[2];
            else
                return Rolls[0] + Rolls[1];
        }
    }
}
