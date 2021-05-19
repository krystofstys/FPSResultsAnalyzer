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
using System.IO;

namespace FPSResultsAnalyzer.Views
{
    /// <summary>
    /// Interaction logic for FPSKnowledgeDialog.xaml
    /// </summary>
    public partial class FPSKnowledgeDialog : Window
    {
        public FPSKnowledgeDialog()
        {
            InitializeComponent();
            CSGORankComboBox.ItemsSource = Enum.GetValues(typeof(CSGORankEnum)).Cast<CSGORankEnum>();
            ValorantRankComboBox.ItemsSource = Enum.GetValues(typeof(ValorantRankEnum)).Cast<ValorantRankEnum>();
        }

        private void AddData_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (!CSGORankComboBox.Text.Equals("Counter-Strike: Global Offenstive rank") && !ValorantRankComboBox.Text.Equals("Valorant rank") && !String.IsNullOrEmpty(CSGOHoursBox.Text) && !String.IsNullOrEmpty(ValorantHoursBox.Text))
            {
                using StreamWriter stream = new StreamWriter("userknowledge.csv");
                stream.WriteLine(CSGORankComboBox.Text + "," + ValorantRankComboBox.Text + "," + CSGOHoursBox.Text + "," + ValorantHoursBox.Text);

                DialogResult = true;
            } else {
                var dialog = new ErrorDialog("Make sure you have picked your rank and hours correctly, if you did not play the game write 0 down and pick none");
                dialog.ShowDialog();
            }
        }
    }        
}
