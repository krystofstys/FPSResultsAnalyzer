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
                gameResults.Reverse();

                foreach (GameResult gameResult in GameResults)
                {
                    listboxGameResults.Items.Add(gameResult);
                }

                if (GameResults.Count > 0)
                {
                    HintPicker hintPicker = new HintPicker(GameResults[0], UserKnowledgePicker.LoadKnowledgeLevel());
                
                    hint.Text = hintPicker.PickHint();
                }
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

            bool success = false;
            while (!success)
            {
                try
                {
                    var dialog = new AddNewDataDialog();
                    dialog.ShowDialog();
                    gameResults = CSVHandler.ReadGameResultsCSV();
                    gameResults.Reverse();
                    listboxGameResults.Items.Clear();

                    foreach (GameResult gameResult in GameResults)
                    {
                        listboxGameResults.Items.Add(gameResult);
                    }

                    HintPicker hintPicker = new HintPicker(GameResults[0], UserKnowledgePicker.LoadKnowledgeLevel());

                    hint.Text = hintPicker.PickHint();
                    success = true;
                } catch (Exception ex)
                {
                    (new ErrorDialog(ex.Message)).ShowDialog();
                }
            }
        }

        private void EditMatchButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            EditDataDialog dialog = new EditDataDialog((GameResult) listboxGameResults.SelectedItem);
            dialog.ShowDialog();
            gameResults = dialog.NewGameResults;
            
            if (gameResults == null)
            {
                return;
            }

            gameResults.Reverse();
            listboxGameResults.Items.Clear();            

            foreach (GameResult gr in gameResults)
            {
                listboxGameResults.Items.Add(gr);
            }

            HintPicker hintPicker = new HintPicker(GameResults[0], UserKnowledgePicker.LoadKnowledgeLevel());

            hint.Text = hintPicker.PickHint();
        }

        private void RemoveMatchButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            gameResults = CSVHandler.RemoveCSV((GameResult) listboxGameResults.SelectedItem);
            gameResults.Reverse();
            listboxGameResults.Items.Remove(listboxGameResults.SelectedItem);

            if (GameResults.Count != 0) {
                HintPicker hintPicker = new HintPicker(GameResults[0], UserKnowledgePicker.LoadKnowledgeLevel());

                hint.Text = hintPicker.PickHint();
            }
        }
    }
}
