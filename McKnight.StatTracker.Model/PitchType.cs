﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McKnight.StatTracker.Model
{
    public enum PitchType
    {
        Ball = 'B',
        CalledStrike = 'C',
        Foul = 'F',
        HitBatter = 'H',
        IntentionalBall = 'I',
        Strike = 'K',
        FoulBunt = 'L',
        MissedBuntAttempt = 'M',
        NoPitch = 'N',
        FoulTipOnBunt = 'O',
        Pitchout = 'P',
        SwingingOnPitchout = 'Q',
        FoulBallOnPitchout = 'R',
        SwingingStrike = 'S',
        FoulTip = 'T',
        Unknown = 'U',
        CalledBall = 'V',
        InPlayByBatter = 'X',
        InPlayByPitchout = 'Y'
    }
}
