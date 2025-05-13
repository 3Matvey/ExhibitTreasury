// ViewModels/CreateHallViewModel.cs
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ExhibitTreasury.Application.HallUseCases.Commands;

namespace ExhibitTreasury.UI.ViewModels
{
    public partial class CreateHallViewModel : ObservableObject
    {
        private readonly IMediator _mediator;

        public CreateHallViewModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        [ObservableProperty]
        private string name = string.Empty;

        [ObservableProperty]
        private string description = string.Empty;

        /// <summary>
        /// Можно ли сохранить? (только когда есть имя)
        /// </summary>
        private bool CanSave() => !string.IsNullOrWhiteSpace(Name);

        [RelayCommand(CanExecute = nameof(CanSave))]
        private async Task SaveAsync()
        {
            // Отправляем команду в Application-слой
            await _mediator.Send(new CreateHallCommand(Name, Description));

            // Возвращаемся назад
            await Shell.Current.GoToAsync("..");
        }

        partial void OnNameChanged(string oldValue, string newValue)
        {
            // При изменении имени переключаем CanExecute у Save
            SaveCommand.NotifyCanExecuteChanged();
        }

        [RelayCommand]
        private async Task CancelAsync()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}
