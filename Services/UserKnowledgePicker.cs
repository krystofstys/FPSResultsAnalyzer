using FPSResultsAnalyzer.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FPSResultsAnalyzer.Services
{
    public class UserKnowledgePicker
    {
        private CSGORankEnum CSGORank;
        private ValorantRankEnum ValorantRank;
        private double HoursPlayedCSGO;
        private double HoursPlayedValorant;

        public UserKnowledgePicker(CSGORankEnum csgoRank, ValorantRankEnum valorantRank, double hoursPlayedCSGO, double hoursPlayedValorant)
        {
            this.CSGORank = csgoRank;
            this.ValorantRank = valorantRank;
            this.HoursPlayedCSGO = hoursPlayedCSGO;
            this.HoursPlayedValorant = hoursPlayedValorant;
        }

        public GameKnowledgeLevelEnum GetKnowledgeLevel()
        {
            if (this.HighKnowledgeLevel())
            {
                return GameKnowledgeLevelEnum.High;
            }

            if (this.MediocreKnowledgeLevel())
            {
                return GameKnowledgeLevelEnum.Mediocre;
            }

            return GameKnowledgeLevelEnum.Low;
        }

        private bool HighKnowledgeLevel()
        {
            return (((int)this.CSGORank >= 14) && (this.HoursPlayedCSGO > 2000)) || (((int)this.ValorantRank >= 15) && (this.HoursPlayedValorant >= 1000));
        }

        private bool MediocreKnowledgeLevel()
        {
            return (((int)this.CSGORank >= 9) || ((this.HoursPlayedCSGO > 800))) ||
                ((((int)this.ValorantRank >= 12)) || (this.HoursPlayedValorant >= 500));
        }

        public static GameKnowledgeLevelEnum LoadKnowledgeLevel()
        {
            using (StreamReader stream = new StreamReader("userknowledge.csv"))
            {
                string line = stream.ReadLine();

                String[] splitLine = line.Split(",");

                UserKnowledgePicker userKnowledgePicker = new UserKnowledgePicker((CSGORankEnum)Enum.Parse(typeof(CSGORankEnum), splitLine[0]),
                    (ValorantRankEnum)Enum.Parse(typeof(ValorantRankEnum), splitLine[1]),
                    Convert.ToDouble(splitLine[2]),
                    Convert.ToDouble(splitLine[3]));

                return userKnowledgePicker.GetKnowledgeLevel();
            }
        }
    }
}
