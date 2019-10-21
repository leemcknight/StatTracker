using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McKnight.StatTracker.Model
{
    public class Pitch
    {
        public PitchResult PitchResult { get; set; }
        public AfterPitchEvent AfterPitchEvent { get; set; }
        public string Description
        { get
            {
                string pitchString = "";
                switch (PitchResult)
                {
                    case PitchResult.Ball:
                        pitchString = "Ball";
                        break;
                    case PitchResult.CalledBall:
                        pitchString = "Called Ball";
                        break;
                    case PitchResult.CalledStrike:
                        pitchString = "Called Strike";
                        break;
                    case PitchResult.Foul:
                        pitchString = "Foul Ball";
                        break;
                    case PitchResult.FoulBallOnPitchout:
                        pitchString = "Pitchout, fouled off";
                        break;
                    case PitchResult.FoulBunt:
                        pitchString = "Bunt attempt, fouled off";
                        break;
                    case PitchResult.FoulTip:
                        pitchString = "Foul Tip";
                        break;
                    case PitchResult.FoulTipOnBunt:
                        pitchString = "Bunt attempt, foul tip";
                        break;
                    case PitchResult.HitBatter:
                        pitchString = "Hit By Pitch";
                        break;
                    case PitchResult.InPlayByBatter:
                        pitchString = "In Play";
                        break;
                    case PitchResult.InPlayByPitchout:
                        pitchString = "Pitchout.  In play";
                        break;
                    case PitchResult.IntentionalBall:
                        pitchString = "Intentional Ball";
                        break;
                    case PitchResult.MissedBuntAttempt:
                        pitchString = "Bunt attempt, missed";
                        break;
                    case PitchResult.NoPitch:
                        pitchString = "No pitch";
                        break;
                    case PitchResult.Pitchout:
                        pitchString = "Pitchout";
                        break;
                    case PitchResult.Strike:
                        pitchString = "Strike";
                        break;
                    case PitchResult.SwingingOnPitchout:
                        pitchString = "Pitchout, Swung on";
                        break;
                    case PitchResult.SwingingStrike:
                        pitchString = "Strike Swinging";
                        break;
                    case PitchResult.Unknown:
                        pitchString = "Unknown";
                        break;
                }

                switch (AfterPitchEvent)
                {
                    case AfterPitchEvent.BlockedByCatcher:
                        pitchString += ", blocked by catcher";
                        break;
                    case AfterPitchEvent.FollowingPickoffAttempt:
                        pitchString += ", following pickoff attempt";
                        break;
                    case AfterPitchEvent.PickoffToFirst:
                        pitchString += ", pickoff to first";
                        break;
                    case AfterPitchEvent.PickoffToSecond:
                        pitchString += ", pickoff to second";
                        break;
                    case AfterPitchEvent.PickoffToThird:
                        pitchString += ", pickoff to third";
                        break;
                    case AfterPitchEvent.PlayNotInvolvingBatter:
                        pitchString += ", play not involving batter";
                        break;
                    case AfterPitchEvent.RunnerGoingOnPitch:
                        pitchString += ", runner goes";
                        break;
                }
                return pitchString;
            }
        }
    }
}
