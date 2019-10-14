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
        public string HomeTeamId
        {
            get { return metaData["hometeam"]; }
        }

        public string VisitingTeamId
        {
            get
            {
                return metaData["visteam"];
            }
        }

        public string HomePlateUmpire
        {
            get { return metaData["umphome"]; }
        }


        public string Date { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public bool UseDH { get; set; }
        public string FieldConditions { get; set; }
        public IList<AtBat> AtBats { get; }
        public IDictionary<string, string> MetaData { get; }
    }
}
