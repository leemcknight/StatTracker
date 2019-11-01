using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McKnight.StatTracker.Model
{
    public class Schedule
    {
        public DateTime? Date { get; set; }
        public int GameNumber { get; set; }
        public string DayOfWeek { get; set; }
        public string VisitingTeamId { get; set; }
        public Franchise VisitingTeam { get; set; }
        public string VisitingTeamLeague { get; set; }
        public int VisitingTeamSeasonGameNumber { get; set; }
        public string HomeTeamId { get; set; }
        public Franchise HomeTeam { get; set; }
        public string HomeTeamLeague { get; set; }
        public int HomeTeamSeasonGameNumber { get; set; }
        public string TimeOfDay { get; set; }
        public string PostponementCancellationIndicator { get; set; }
        public DateTime? MakeupDate { get; set; }
    }
}
