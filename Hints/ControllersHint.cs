using FPSResultsAnalyzer.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace FPSResultsAnalyzer.Hints
{
    public class ControllersHint : IHint
    {
        public string HintString { get; set; }
        public double MinWinLoss { get; set; }
        public int MinAssists { get; set; }
        public int MaxDeaths { get; set; }
        public int MinFirstKills { get; set; }
        public GameKnowledgeLevelEnum GameKnowledgeLevel { get; set; }
        public ClassTypeEnum ClassType { get; set; }

        public ControllersHint(string hintString, double minWinLoss, int minAssists, int maxDeaths, int minFirstKills, GameKnowledgeLevelEnum gameKnowledgeLevel)
        {
            this.HintString = hintString;
            this.MinWinLoss = minWinLoss;
            this.MinAssists = minAssists;
            this.MaxDeaths = maxDeaths;
            this.MinFirstKills = minFirstKills;
            this.GameKnowledgeLevel = gameKnowledgeLevel;
            this.ClassType = ClassTypeEnum.Controller;
        }
    }
}
