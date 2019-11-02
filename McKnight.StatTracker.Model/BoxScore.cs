using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McKnight.StatTracker.Model
{
    public class BoxScore
    {
        private IList<string> visitingStartingPlayerIds = new List<string>();

        public string DateString { get; set; }
        public DateTime? Date { get; set; }
        public int GameNumber { get; set; }
        public string DayOfWeek { get; set; }
        public string VisitingTeamId { get; set; }
        public Franchise VisitingTeam { get; set; }
        public string VisitingTeamLeague { get; set; }
        public int VisitingTeamGameNumber { get; set; }
        public string HomeTeamId { get; set; }

        public Franchise HomeTeam { get; set; }
        public string HomeTeamLeague { get; set; }
        public int HomeTeamGameNumber { get; set; }
        public int VisitingScore { get; set; }
        public int HomeScore { get; set; }
        public int TotalOuts { get; set; }
        public string DayNightIndicator { get; set; }
        public string CompletionInformation { get; set; }
        public string ForfeitInformation { get; set; }
        public string ProtestInformation { get; set; }
        public string ParkId { get; set; }

        public Ballpark Ballpark { get; set; }
        public int? Attendance { get; set; }
        public int TimeOfGame { get; set; }
        public IEnumerable<string> VisitingLineScore { get; set; }
        public IEnumerable<string> HomeLineScore { get; set; }
        public int VisitingAtBats { get; set; }
        public int VisitingHits { get; set; }
        public int VisitingDoubles { get; set; }
        public int VisitingTriples { get; set; }
        public int VisitingHomeruns { get; set; }
        public int VisitingRbis { get; set; }
        public int VisitingSacraficeHits { get; set; }
        public int VisitingSacraficeFlies { get; set; }
        public int VisitingHitByPitch { get; set; }
        public int VisitingWalks { get; set; }
        public int VisitingIntentionalWalks { get; set; }
        public int VisitingStrikeouts { get; set; }
        public int VisitingStolenBases { get; set; }
        public int VisitingCaughtStealing { get; set; }
        public int VisitingGroundedIntoDoublePlays { get; set; }
        public int VisitingCatchersInterference { get; set; }
        public int VisitingLeftOnBase { get; set; }
        public int VisitingPitchersUsed { get; set; }
        public int VisitingIndividualEarnedRuns { get; set; } 
        public int VisitingTeamEarnedRuns { get; set; }
        public int VisitingWildPitches { get; set; }
        public int VisitingBalks { get; set; }
        public int VisitingAssists { get; set; }
        public int VisitingErrors { get; set; }
        public int VisitingPassedBalls { get; set; }
        public int VisitingDoublePlays { get; set; }
        public int VisitingTriplePlays { get; set; }
        public int HomeAtBats { get; set; }
        public int HomeHits { get; set; }
        public int HomeDoubles { get; set; }
        public int HomeTriples { get; set; }
        public int HomeHomeruns { get; set; }
        public int HomeRbis { get; set; }
        public int HomeSacraficeHits { get; set; }
        public int HomeSacraficeFlies { get; set; }
        public int HomeHitByPitch { get; set; }
        public int HomeWalks { get; set; }
        public int HomeIntentionalWalks { get; set; }
        public int HomeStrikeouts { get; set; }
        public int HomeStolenBases { get; set; }
        public int HomeCaughtStealing { get; set; }

        public int HomeGroundedIntoDoublePlays { get; set; }
        public int HomeCatchersInterference { get; set; }
        public int HomeLeftOnBase { get; set; }
        public int HomePitchersUsed { get; set; }
        public int HomeIndividualEarnedRuns { get; set; }
        public int HomeTeamEarnedRuns { get; set; }
        public int HomeWildPitches { get; set; }
        public int HomeBalks { get; set; }
        public int HomeAssists { get; set; }
        public int HomeErrors { get; set; }
        public int HomePassedBalls { get; set; }
        public int HomeDoublePlays { get; set; }
        public int HomeTriplePlays { get; set; }
        public string HomePlayUmpireId { get; set; }
        public string FirstBaseUmpireId { get; set; }
        public string SecondBaseUmpireId { get; set; }
        public string ThirdBaseUmpireId { get; set; }
        public string LeftFieldUmpireId { get; set; }
        public string RightFieldUmpireId { get; set; }
        public string VisitingTeamManagerId { get; set; }
        public string VisitingTeamManagerName { get; set; }
        public string HomeTeamManagerId { get; set; }
        public string HomeTeamManagerName { get; set; }
        public string WinningPitcherId { get; set; }
        public string  WinningPitcherName { get; set; }
        public string LosingPitcherId { get; set; }
        public string LosingPitcherName { get; set; }
        public string SavingPitcherId { get; set; }
        public string SavingPitcherName { get; set; }
        public string GameWinningBatterId { get; set; }
        public string GameWinningBatterName { get; set; }
        public string VisitingStartingPitcherId { get; set; }
        public string VisitingStartingPitcherName { get; set; }
        public IList<string> VisitingStartingPlayerIds { get; }
        public IList<string> VisitingStartingPlayerPositions { get; }
        public IList<string> HomeStartingPlayerIds { get; }
        public IList<string> HomeStartingPlayerPositions { get; }
        public string AdditionalInfo { get; set; }
        public string AcquisitionInfo { get; set; }
    }
}
