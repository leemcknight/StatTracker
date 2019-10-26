using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McKnight.StatTracker.Model
{
    /*
     * Play modifiers and explanations
        Each modifier is preceded by / in a play record. As always, % indicates one the four bases and $ indicates a fielder.


        AP    appeal play
        BP    pop up bunt
        BG    ground ball bunt
        BGDP  bunt grounded into double play
        BINT  batter interference
        BL    line drive bunt
        BOOT  batting out of turn
        BP    bunt pop up
        BPDP  bunt popped into double play
        BR    runner hit by batted ball
        C     called third strike
        COUB  courtesy batter
        COUF  courtesy fielder
        COUR  courtesy runner
        DP    unspecified double play
        E$    error on $
        F     fly
        FDP   fly ball double play
        FINT  fan interference
        FL    foul
        FO    force out
        G     ground ball
        GDP   ground ball double play
        GTP   ground ball triple play
        IF    infield fly rule
        INT   interference
        IPHR  inside the park home run
        L     line drive
        LDP   lined into double play
        LTP   lined into triple play
        MREV  manager challenge of call on the field
        NDP   no double play credited for this play
        OBS   obstruction (fielder obstructing a runner)
        P     pop fly
        PASS  a runner passed another runner and was called out
        R$    relay throw from the initial fielder to $ with no out made
        RINT  runner interference
        SF    sacrifice fly
        SH    sacrifice hit (bunt)
        TH    throw
        TH%   throw to base %
        TP    unspecified triple play
        UINT  umpire interference
UREV  umpire review of call on the field
     */ 
    public class Play
    {
        private string playString;
        private List<string> modifiers = new List<string>();
        private List<string> baseAdvances = new List<string>();        
        private string baseAdvanceString;
        private string playDescription;
        
        public List<string> Modifiers  {
            get { return modifiers;  }
        }

        public List<string> BaseAdvances {
            get { return baseAdvances;  }
        }

        public string PlayDescription
        {
            get; set;
        }

        public string BaseAdvanceString { get; set; }
    }
}
