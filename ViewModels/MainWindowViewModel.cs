using Prism.Mvvm;

namespace FPSResultsAnalyzer.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "FPS Results Analyzer";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public MainWindowViewModel()
        {

        }
    }
}
