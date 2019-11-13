using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McKnight.StatTracker.Model
{
    public class Franchise
    {
        public string CurrentFranchiseId { get; set; }
        public string FranchiseId { get; set; }
        public string League { get; set; }
        public string Division { get; set; }
        public string Location { get; set; }
        public string Nickname { get; set; }
        public string AlternateNicknames { get; set; }
        public DateTime? FirstGame { get; set; }
        public DateTime? LastGame { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string SvgPath { get { return "Data/franchises/img/svg/" + CurrentFranchiseId + ".svn"; } }
    }
}
