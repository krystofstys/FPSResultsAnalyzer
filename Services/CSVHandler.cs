using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using FPSResultsAnalyzer.Results;
using FPSResultsAnalyzer.Enums;

namespace FPSResultsAnalyzer.Services
{
    public class CSVHandler
    {
        private static string gameResultsCSV = "gameresults.csv";

        public static List<GameResult> ReadGameResultsCSV()
        {
            List <GameResult> linesList = new List<GameResult>();

            using (StreamReader stream = new StreamReader(gameResultsCSV))
            {
                string line;

                while ((line = stream.ReadLine()) != null)
                {
                    String[] splitLine = line.Split(",");

                    linesList.Add(new GameResult(Convert.ToDateTime(splitLine[0]),
                        new Score(splitLine[1]),
                        Convert.ToInt32(splitLine[2]),
                        Convert.ToInt32(splitLine[3]),
                        Convert.ToInt32(splitLine[4]),
                        Convert.ToInt32(splitLine[5]),
                        Convert.ToInt32(splitLine[6]),
                        Convert.ToInt32(splitLine[7]),
                        (CharactersEnum)Enum.Parse(typeof(CharactersEnum), splitLine[8]),
                        (ValorantRankEnum)Enum.Parse(typeof(ValorantRankEnum), splitLine[9])));
                }
            }

            return linesList;
        }

        public static void AppendCSV(GameResult gameResult)
        {
            using (StreamWriter stream = new StreamWriter(gameResultsCSV))
            {
                stream.WriteLine(gameResult.ToString());
            }
        }

        public static void CopyCSV(string destinationPath)
        {
            File.Copy(gameResultsCSV, destinationPath + "/gameresults.csv");
        }

        public static void SetGameResultsCSV(string filePath)
        {
            gameResultsCSV = filePath;
        }
    }
}
