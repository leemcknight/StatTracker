using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McKnight.StatTracker.Model
{
    public class Ballpark
    {
        public string BallparkId { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string League { get; set; }
        public string Notes { get; set; }

        public override string ToString()
        {
            return Name + " (" + City + ", " + State + ")";
        }
    }
}
