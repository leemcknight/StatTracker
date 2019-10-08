using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McKnight.StatTracker.Model
{
    class Player
    {
        public String FirstName { get; set;  }
        public String LastName { get; set; }
        public override string ToString()
        {
            return FirstName + " " + LastName;
        }
    }
}
