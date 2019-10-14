using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using McKnight.StatTracker.Model;

namespace McKnight.StatTracker.Services
{
    public class AtBatReader
    {
        public AtBat Read(string[] arr)
        {
            PlayReader playReader = new PlayReader();
            AtBat atBat = new AtBat();

            atBat.Inning = int.Parse(arr[1]);
            atBat.BatterId = arr[3];
            atBat.FinalCount = arr[4];
            atBat.Pitches = ParsePitchString(arr[5]);
            return atBat;
        }

        private List<PitchType> ParsePitchString(string pitchString)
        {
            List<PitchType> pitches = new List<PitchType>();
            foreach(char c in pitchString)
            {
                string name = Enum.GetName(typeof(PitchType), c);
                PitchType pitch = (PitchType)Enum.Parse(typeof(PitchType), name);
                pitches.Add(pitch);
            }
            return pitches;
        }
    }
}
