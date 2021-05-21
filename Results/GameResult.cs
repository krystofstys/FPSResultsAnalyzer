using FPSResultsAnalyzer.Enums;
using FPSResultsAnalyzer.Results;
using System;

namespace FPSResultsAnalyzer.Results
{
    public class GameResult
    {
        public DateTime Date { get; set; }
        public Score Score { get; set; }
        public int Kills { get; set; }
        public int Assists { get; set; }
        public int Deaths { get; set; }
        public int FirstKills { get; set; }
        public int TeamPlacement { get; set; }
        public int OverallPlacement { get; set; }
        public CharactersEnum Character { get; set; }
        public ValorantRankEnum ValorantRank { get; set; }

        public GameResult(DateTime date, Score score, int kills, int assists, int deaths, int firstKills, int teamPlacement, int overallPlacement, CharactersEnum character, ValorantRankEnum valorantRank) {
            this.Date = date;
            this.Score = score;
            this.Kills = kills;
            this.Assists = assists;
            this.FirstKills = firstKills;
            this.Deaths = deaths;
            this.Character = character;
            this.ValorantRank = valorantRank;
            this.TeamPlacement = teamPlacement;
            this.OverallPlacement = overallPlacement;      }

        public override string ToString()
        {
            return Convert.ToString(this.Date) + "," +
                this.Score.ToString() + "," + 
                Convert.ToString(this.Kills) + "," + 
                Convert.ToString(this.Assists) + "," + 
                Convert.ToString(this.Deaths) + "," + 
                Convert.ToString(this.FirstKills) + "," +
                Convert.ToString(this.TeamPlacement) + "," + 
                Convert.ToString(this.OverallPlacement) + "," +
                this.Character.ToString() + "," + 
                this.ValorantRank;
        }

        public double GetKillDeathRatio()
        {
            return this.Kills / this.Deaths;
        }
    }
}
