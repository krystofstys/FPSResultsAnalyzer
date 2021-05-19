using System;
using System.Collections.Generic;
using System.Text;

namespace FPSResultsAnalyzer.Results
{
    public class Score
    {
        public int WonRounds { get; set; }
        public int LostRounds { get; set; }

        public Score(int wonRounds, int lostRounds)
        {
            this.WonRounds = wonRounds;
            this.LostRounds = lostRounds;
        }

        public Score(string scoreString)
        {
            string[] splitScore = scoreString.Split(":");
            this.WonRounds = Convert.ToInt32(splitScore[0]);
            this.LostRounds = Convert.ToInt32(splitScore[1]);
        }

        public override string ToString()
        {
            return this.WonRounds.ToString() + ":" + this.LostRounds.ToString();
        }

        public double GetWinLossRatio()
        {
            return this.WonRounds / this.LostRounds;
        }
    }
}
