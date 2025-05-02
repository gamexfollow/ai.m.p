using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using AI.M.P.Application.DTOs;
using AI.M.P.Application.UseCases;
using AI.M.P.UI.Helpers;

namespace AI.M.P.UI.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        // Título de la ventana
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

        // ■ Propiedades enlazadas a los TextBox
        private string _email = string.Empty;
        public string Email
        {
            get => _email;
            set
            {
                if (value == _email) return;
                _email = value;
                OnPropertyChanged();
                CreateAccountCommand.RaiseCanExecuteChanged();
            }
        }

        private string _displayName = string.Empty;
        public string DisplayName
        {
            get => _displayName;
            set
            {
                if (value == _displayName) return;
                _displayName = value;
                OnPropertyChanged();
                CreateAccountCommand.RaiseCanExecuteChanged();
            }
        }

        // ■ Inyección del UseCase y comando
        private readonly RegisterAccountUseCase _registerUseCase;
        public RelayCommand CreateAccountCommand { get; }

        // Constructor con DI del UseCase
        public MainWindowViewModel(RegisterAccountUseCase registerUseCase)
        {
            _registerUseCase = registerUseCase;

            CreateAccountCommand = new RelayCommand(
                async () =>
                {
                    var dto = new AccountDto
                    {
                        Email = this.Email,
                        DisplayName = this.DisplayName
                    };
                    await _registerUseCase.ExecuteAsync(dto);
                    MessageBox.Show("✅ Cuenta creada correctamente!");
                },
                () => !string.IsNullOrWhiteSpace(Email)
                      && !string.IsNullOrWhiteSpace(DisplayName)
            );
        }

        // INotifyPropertyChanged
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
