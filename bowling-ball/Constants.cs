using System;
using System.Collections.Generic;
using System.Text;

namespace BowlingBall
{
    public enum FrameState
    {
        Spare,
        Strike,
        None,
        NotAttempted
    }

    public enum FrameType
    {
        Normal,
        LastFrame
    }
}
