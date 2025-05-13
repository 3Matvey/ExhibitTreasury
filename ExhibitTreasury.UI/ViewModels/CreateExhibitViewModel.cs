// ViewModels/CreateExhibitViewModel.cs
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ExhibitTreasury.Application.ExhibitUseCases.Commands;

namespace ExhibitTreasury.UI.ViewModels
{
    [QueryProperty(nameof(HallId), "HallId")]
    public partial class CreateExhibitViewModel : ObservableObject
    {
        private readonly IMediator _mediator;

        public CreateExhibitViewModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        [ObservableProperty]
        private int hallId;

        [ObservableProperty]
        private string name = string.Empty;

        [ObservableProperty]
        private decimal appraisedValue;

        [ObservableProperty]
        private int yearCreated;

        [ObservableProperty]
        private string material = string.Empty;

        [ObservableProperty]
        private string artist = string.Empty;

        private bool CanSave() =>
            !string.IsNullOrWhiteSpace(Name)
            && AppraisedValue > 0
            && YearCreated > 0;

        [RelayCommand(CanExecute = nameof(CanSave))]
        private async Task SaveAsync()
        {
  //          var hall = await _mediator.Send(new GetHallByIdQuery(HallId));
//            HallTitle = hall.Name;

            await _mediator.Send(new AddExhibitCommand(
                Name,
                AppraisedValue,
                YearCreated,
                Material,
                Artist,
                HallId));

            await Shell.Current.GoToAsync("..");
        }

        partial void OnNameChanged(string oldValue, string newValue)
        {
            SaveCommand.NotifyCanExecuteChanged();
        }
        partial void OnAppraisedValueChanged(decimal oldValue, decimal newValue)
            => SaveCommand.NotifyCanExecuteChanged();
        partial void OnYearCreatedChanged(int oldValue, int newValue)
            => SaveCommand.NotifyCanExecuteChanged();

        [RelayCommand]
        private async Task CancelAsync()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}
