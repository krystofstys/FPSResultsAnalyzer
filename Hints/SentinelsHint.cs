using FPSResultsAnalyzer.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace FPSResultsAnalyzer.Hints
{
    public class SentinelsHint : IHint
    {
        public string HintString { get; set; }
        public double MinWinLoss { get; set; }
        public int MaxDeaths { get; set; }
        public int MinAssists { get; set; }
        public GameKnowledgeLevelEnum GameKnowledgeLevel { get; set; }
        public ClassTypeEnum ClassType { get; set; }

        public SentinelsHint(string hintString, double minWinLoss, int minAssists, int maxDeaths, GameKnowledgeLevelEnum gameKnowledgeLevel)
        {
            this.HintString = hintString;
            this.MinWinLoss = minWinLoss;
            this.MinAssists = minAssists;
            this.MaxDeaths = maxDeaths;
            this.GameKnowledgeLevel = gameKnowledgeLevel;
            this.ClassType = ClassTypeEnum.Sentinel;
        }
    }
}
