using FPSResultsAnalyzer.Services;
using System;
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

namespace FPSResultsAnalyzer.Views
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class SaveCSVDialog : Window
    {
        public SaveCSVDialog()
        {
            InitializeComponent();
        }

        public string CSVPath
        {
            get { return CSVPathBox.Text; }
            set { CSVPathBox.Text = value; }
        }

        private void OKButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            try
            {
                CSVHandler.CopyCSV(CSVPath);
            } catch (System.IO.FileNotFoundException) {
                var dialog = new ErrorDialog("No game info was added yet.");
                dialog.ShowDialog();
            }

            DialogResult = true;
        }
    }
}
