using McKnight.StatTracker.Model;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McKnight.StatTracker.Services
{
    public class GameReader
    {
        private DateTime date;
        private string teamId;
        private string teamLeague;
        private int gameNumber;

        public GameReader ForHomeTeam(string teamId, string teamLeague)
        {
            this.teamId = teamId;
            this.teamLeague = teamLeague;
            return this;
        }

        public GameReader ForDate(DateTime date)
        {
            this.date = date;
            return this;
        }

        public GameReader ForGameNumber(int gameNumber)
        {
            this.gameNumber = gameNumber;
            return this;
        }
        
        public Game Read()
        {
            Game game = null;
            Context context = Context.Instance;
            string file = date.Year.ToString() + teamId + ".EV" + teamLeague;
            string gameId = teamId + this.date.ToString("yyyyMMdd") + gameNumber.ToString();
            IEnumerable<string> lines = File.ReadLines("Data/play_by_play/" + date.Year.ToString() + "/" + file);            
            bool found = false;
            foreach(string line in lines)
            {
                string[] arr = line.Split(',');
                if(found)
                {
                    switch(arr[0])
                    {
                        case "id":                            
                            game.Ballpark = context.Ballparks.Where(ballpark => ballpark.BallparkId == game.BallparkId).FirstOrDefault();
                            game.HomeTeam = context.Franchises
                                .Where(team => team.FranchiseId == game.HomeTeamId)
                                .Where(team => game.Date >= team.FirstGame)
                                .Where(team => game.Date <= team.LastGame)
                                .FirstOrDefault();
                            game.VisitingTeam = context.Franchises
                                .Where(team => team.FranchiseId == game.VisitingTeamId)
                                .Where(team => game.Date.Value >= team.FirstGame.Value)
                                .Where(team => game.Date.Value <= team.LastGame.Value)
                                .FirstOrDefault();
                            return game;                                                       
                        case "version":
                            break;
                        case "info":
                            game.MetaData.Add(arr[1], arr[2]);
                            break;
                        case "start":
                            break;
                        case "sub":
                            break;
                        case "play":
                            game.AtBats.Add(new AtBatReader().Read(arr));
                            break;
                        case "badj":
                            break;
                        case "padj":
                            break;
                        case "ladj":
                            break;
                        case "data":
                            break;
                        case "com":
                            break;
                    }                    
                } else
                {
                    if(arr[0] == "id" && arr[1] == gameId)
                    {
                        found = true;
                        game = new Game();
                        game.Date = date;
                    }
                } 
            }
            game.Ballpark = context.Ballparks.Where(ballpark => ballpark.BallparkId == game.BallparkId).FirstOrDefault();
            game.HomeTeam = context.Franchises
                .Where(team => team.FranchiseId == game.HomeTeamId)
                .Where(team => game.Date >= team.FirstGame)                
                .Where(team => game.Date <= team.LastGame)
                .FirstOrDefault();
            game.VisitingTeam = context.Franchises
                .Where(team => team.FranchiseId == game.VisitingTeamId)
                .Where(team => game.Date >= team.FirstGame)
                .Where(team => game.Date <= team.LastGame)
                .FirstOrDefault();
            return game;
        }
        
    }
}
