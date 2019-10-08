using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McKnight.StatTracker.Model
{
    public class AtBat
    {
        public int Inning { get; set; }
        public string BatterId { get; set; }
        public List<PitchType> Pitches { get; set; }
        public string FinalCount { get; set; }
        public Play Play { get; set; }
    }
}
