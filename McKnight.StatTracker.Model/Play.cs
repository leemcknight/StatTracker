using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McKnight.StatTracker.Model
{
    
    public class Play
    {        
        private IList<PlayModifier> modifiers = new List<PlayModifier>();
        private IList<string> baseAdvances = new List<string>();                        
        
        public IList<PlayModifier> Modifiers  {
            get { return modifiers;  }
        }

        public IList<string> BaseAdvances {
            get { return baseAdvances;  }
        }

        public string PlayDescription
        {
            get; set;
        }

        public string SummaryDescription { get; set; }

        public string FullDescription { get; set; }

        public string BaseAdvanceString { get; set; }

    }
}
