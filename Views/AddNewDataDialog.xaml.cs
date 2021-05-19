using FPSResultsAnalyzer.Enums;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using FPSResultsAnalyzer.Services;
using FPSResultsAnalyzer.Results;

namespace FPSResultsAnalyzer.Views
{
    /// <summary>
    /// Interaction logic for AddNewDataDialog.xaml
    /// </summary>
    public partial class AddNewDataDialog : Window
    {
        public ObservableCollection<int> OverallPlacement { get; set; }
        public ObservableCollection<int> TeamPlacement { get; set; }

        public AddNewDataDialog()
        {
            InitializeComponent();
            CharacterComboBox.ItemsSource = Enum.GetValues(typeof(CharactersEnum)).Cast<CharactersEnum>();
            RankComboBox.ItemsSource = Enum.GetValues(typeof(ValorantRankEnum)).Cast<ValorantRankEnum>();
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
            TeamPlacementComboBox.ItemsSource = TeamPlacement;

        }

        private void AddButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            CSVHandler.AppendCSV(new GameResult(DateTime.Now,
                new Score(WonRoundsBox.Text + ":" + LostRoundsBox.Text),
                Convert.ToInt32(KillsBox.Text),
                Convert.ToInt32(FirstKillsBox.Text),
                Convert.ToInt32(AssistsBox.Text),
                Convert.ToInt32(DeathsBox.Text),
                Convert.ToInt32(TeamPlacementComboBox.SelectedValue),
                Convert.ToInt32(OverallPlacementComboBox.SelectedValue),
                (CharactersEnum)Enum.Parse(typeof(CharactersEnum), CharacterComboBox.SelectedItem.ToString()),
                (ValorantRankEnum)Enum.Parse(typeof(ValorantRankEnum), RankComboBox.SelectedItem.ToString())));

            DialogResult = true;
        }
    }
}
