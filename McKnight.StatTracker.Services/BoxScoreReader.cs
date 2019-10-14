﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using McKnight.StatTracker.Model;

namespace McKnight.StatTracker.Services
{
    public class BoxScoreReader : CsvReader<BoxScore>
    {
        private DateTime date;
        private string teamId;
        private int gameNumber = 1;

        public BoxScoreReader()
        {
            this.TransformFunc = (arr =>
            new BoxScore
            {
                DateString = UnQuote(arr[0]),
                Date = GetSafeDate(arr[0]),
                GameNumber = int.Parse(UnQuote(arr[1])),
                DayOfWeek = UnQuote(arr[2]),
                VisitingTeamId = UnQuote(arr[3]),
                VisitingTeamLeague = UnQuote(arr[4]),
                VisitingTeamGameNumber = int.Parse(UnQuote(arr[5])),
                HomeTeamId = UnQuote(arr[6]),
                HomeTeamLeague = UnQuote(arr[7]),
                HomeTeamGameNumber = int.Parse(UnQuote(arr[8])),
                VisitingScore = int.Parse(arr[9]),
                HomeScore = int.Parse(arr[10]),
                TotalOuts = int.Parse(arr[11]),
                DayNightIndicator = UnQuote(arr[12]),
                CompletionInformation = UnQuote(arr[13]),
                ForfeitInformation = UnQuote(arr[14]),
                ProtestInformation = UnQuote(arr[15]),
                ParkId = UnQuote(arr[16]),
                Attendance = GetSafeInt(arr[17]),
                TimeOfGame = int.Parse(arr[18]),
                VisitingLineScore = UnQuote(arr[19]),
                HomeLineScore = UnQuote(arr[20])                
            });
        }

        public BoxScoreReader ForDate(DateTime date)
        {
            this.date = date;
            Path = "Data/gamelogs/GL" + date.Year.ToString() + ".TXT";
            return this;
        }

        public BoxScoreReader ForTeam(string teamId)
        {
            this.teamId = teamId;
            return this;
        }

        public BoxScoreReader ForGameNumber(int gameNumber)
        {
            this.gameNumber = gameNumber;
            return this;
        }

        public override IEnumerable<BoxScore> Read()
        {
            return from game in base.Read()
                   where game.GameNumber == gameNumber
                   where game.DateString == date.ToString("yyyyMMdd")
                   where (game.HomeTeamId == teamId || game.VisitingTeamId == teamId)
                   select game;
            
        }
    }
}