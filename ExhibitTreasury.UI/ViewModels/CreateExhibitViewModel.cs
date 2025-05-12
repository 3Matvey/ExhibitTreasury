// ViewModels/CreateExhibitViewModel.cs
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ExhibitTreasury.Application.ExhibitUseCases.Commands;
using MediatR;
using Microsoft.Maui.Controls;
using CommunityToolkit.Mvvm.Messaging; // если понадобится
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Maui.Controls;
using ExhibitTreasury.Domain.Entities;
using System.Xml.Linq;

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
