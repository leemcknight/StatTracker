using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McKnight.StatTracker.Model
{
    public class Game
    {
        private IDictionary<string, string> metaData = new Dictionary<string, string>();
        private IList<AtBat> atBats = new List<AtBat>();
        public string HomeTeam { get; set; }
        public string VisitingTeam { get; set; }
        public string Date { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public bool UseDH { get; set; }
        public string FieldConditions { get; set; }
        public IList<AtBat> AtBats { get; }
        public IDictionary<string, string> MetaData { get; }
    }
}
