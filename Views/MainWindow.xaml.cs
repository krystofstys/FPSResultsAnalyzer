using FPSResultsAnalyzer.Results;
using FPSResultsAnalyzer.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace FPSResultsAnalyzer.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<GameResult> gameResults = new List<GameResult>();
        public List<GameResult> GameResults { get { return gameResults; } }

        public MainWindow()
        {
            InitializeComponent();
            bool success = false;

            while (!success)
            {
                try
                {
                    UserKnowledgePicker.LoadKnowledgeLevel();
                    success = true;
                }
                catch (System.IO.FileNotFoundException)
                {
                    var dialog = new FPSKnowledgeDialog();
                    dialog.ShowDialog();

                    success = true;
                }
            }

            try
            {
                gameResults = CSVHandler.ReadGameResultsCSV();
            }
            catch (System.IO.FileNotFoundException)
            {
                File.Create("gameresults.csv");
            }
        }

        private void SaveCSVButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var dialog = new SaveCSVDialog();
            dialog.ShowDialog();
        }

        private void AddMatchButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var dialog = new AddNewDataDialog();
            dialog.ShowDialog();
            gameResults = CSVHandler.ReadGameResultsCSV();
        }
    }
}
