using FPSResultsAnalyzer.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace FPSResultsAnalyzer.Hints
{
    public class DuelistsHint : IHint
    {
        public string HintString { get; set; }
        public double MinWinLoss { get; set; }
        public double minKillDeathRatio { get; set; }
        public int minFirstKills { get; set; }
        public GameKnowledgeLevelEnum GameKnowledgeLevel { get; set; }
        public ClassTypeEnum ClassType { get; set; }

        public DuelistsHint(string hintString, double minWinLoss, double minKillDeathRatio, int minFirstKills, GameKnowledgeLevelEnum gameKnowledgeLevel)
        {
            this.HintString = hintString;
            this.MinWinLoss = minWinLoss;
            this.minKillDeathRatio = minKillDeathRatio;
            this.minFirstKills = minFirstKills;
            this.GameKnowledgeLevel = gameKnowledgeLevel;
            this.ClassType = ClassTypeEnum.Duelist;
        }
    }
}
