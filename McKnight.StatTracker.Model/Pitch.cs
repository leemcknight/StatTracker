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
    }
}
