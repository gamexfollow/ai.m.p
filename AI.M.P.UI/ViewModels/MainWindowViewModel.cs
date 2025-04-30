using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AI.M.P.UI.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private string _title = "AI Marketing Platform";

        public string Title
        {
            get => _title;
            set
            {
                if (value == _title) return;
                _title = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
