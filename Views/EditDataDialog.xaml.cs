using FPSResultsAnalyzer.Enums;
using FPSResultsAnalyzer.Results;
using FPSResultsAnalyzer.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FPSResultsAnalyzer.Views
{
    /// <summary>
    /// Interaction logic for EditDataDialog.xaml
    /// </summary>
    public partial class EditDataDialog : Window
    {
        public List<GameResult> NewGameResults { get; set; }
        public GameResult PreviousResult { get; set; }
        public ObservableCollection<int> OverallPlacement { get; set; }
        public ObservableCollection<int> TeamPlacement { get; set; }
        public EditDataDialog(GameResult gameResult)
        {
            InitializeComponent();
            PreviousResult = gameResult;
            CharacterComboBox.ItemsSource = Enum.GetValues(typeof(CharactersEnum)).Cast<CharactersEnum>();
            CharacterComboBox.SelectedItem = gameResult.Character;
            RankComboBox.ItemsSource = Enum.GetValues(typeof(ValorantRankEnum)).Cast<ValorantRankEnum>();
            RankComboBox.SelectedItem = gameResult.ValorantRank;
            OverallPlacement = new ObservableCollection<int>();
            TeamPlacement = new ObservableCollection<int>();
            
            for (int i = 1; i <= 10; i++)
            {
                OverallPlacement.Add(i);
            }

            for (int i = 1; i <= 5; i++)
            {
                TeamPlacement.Add(i);
            }

            OverallPlacementComboBox.ItemsSource = OverallPlacement;
            OverallPlacementComboBox.SelectedItem = gameResult.OverallPlacement;
            TeamPlacementComboBox.ItemsSource = TeamPlacement;
            TeamPlacementComboBox.SelectedItem = gameResult.TeamPlacement;

            if (gameResult.OverallPlacement == 1)
            {
                MostValuablePlayer.IsChecked = true;
            }

            WonRoundsBox.Text = gameResult.Score.WonRounds.ToString();
            LostRoundsBox.Text = gameResult.Score.LostRounds.ToString();
            KillsBox.Text = gameResult.Kills.ToString();
            AssistsBox.Text = gameResult.Assists.ToString();
            DeathsBox.Text = gameResult.Deaths.ToString();
            FirstKillsBox.Text = gameResult.FirstKills.ToString();
        }

        private void EditButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            NewGameResults = CSVHandler.EditCSV(PreviousResult, new GameResult(DateTime.Now,
                new Score(WonRoundsBox.Text + ":" + LostRoundsBox.Text),
                Convert.ToInt32(KillsBox.Text),                
                Convert.ToInt32(AssistsBox.Text),
                Convert.ToInt32(DeathsBox.Text),
                Convert.ToInt32(FirstKillsBox.Text),
                Convert.ToInt32(TeamPlacementComboBox.SelectedValue),
                Convert.ToInt32(OverallPlacementComboBox.SelectedValue),
                (CharactersEnum)Enum.Parse(typeof(CharactersEnum), CharacterComboBox.SelectedItem.ToString()),
                (ValorantRankEnum)Enum.Parse(typeof(ValorantRankEnum), RankComboBox.SelectedItem.ToString())));

            DialogResult = true;
        }
    }
}
