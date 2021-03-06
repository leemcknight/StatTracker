﻿using McKnight.StatTracker.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McKnight.StatTracker.Services
{
    public class ScheduleReader : CsvReader<Schedule>
    {
        private string teamId;
        
        public ScheduleReader()
        {
            TransformFunc = (arr => {
                var date = GetSafeDate(UnQuote(arr[0]));
                return new Schedule
                {
                    Date = date,
                    GameNumber = int.Parse(UnQuote(arr[1])),
                    DayOfWeek = UnQuote(arr[2]),
                    VisitingTeamId = UnQuote(arr[3]),
                    VisitingTeamLeague = UnQuote(arr[4]),
                    VisitingTeamSeasonGameNumber = int.Parse(arr[5]),
                    HomeTeamId = UnQuote(arr[6]),
                    HomeTeamLeague = UnQuote(arr[7]),
                    HomeTeamSeasonGameNumber = int.Parse(arr[8]),
                    TimeOfDay = arr[9],
                    PostponementCancellationIndicator = arr[10],
                    VisitingTeam = Context.Instance.Franchises
                        .Where(team => team.FranchiseId == UnQuote(arr[3]))
                        .Where(team => date >= team.FirstGame)
                        .Where(team => date <= team.LastGame).FirstOrDefault(),
                    HomeTeam = Context.Instance.Franchises
                        .Where(team => team.FranchiseId == UnQuote(arr[6]))
                        .Where(team => date >= team.FirstGame)
                        .Where(team => date <= team.LastGame).FirstOrDefault(),
                    MakeupDate = GetSafeDate(arr[11])
                };
            });
        }

        public ScheduleReader ForYear(int year)
        {
            Path = "Data/schedule/" + year.ToString() + "SKED.TXT";
            return this;
        }

        public ScheduleReader ForTeam(string teamId)
        {
            this.teamId = teamId;
            return this;
        }

        public override IEnumerable<Schedule> Read()
        {            
            return base.Read().Where(team => team.HomeTeamId == teamId || 
                                    team.VisitingTeamId == teamId);
        }
    }
}
