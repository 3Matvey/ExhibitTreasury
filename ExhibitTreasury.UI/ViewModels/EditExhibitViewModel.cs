// ViewModels/EditExhibitViewModel.cs
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ExhibitTreasury.Domain.Entities;
using MediatR;
using Microsoft.Maui.Controls;

namespace ExhibitTreasury.UI.ViewModels
{
    [QueryProperty(nameof(Exhibit), "Exhibit")]
    public partial class EditExhibitViewModel : ObservableObject
    {
        private readonly IMediator _mediator;

        public EditExhibitViewModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        [ObservableProperty]
        private Exhibit exhibit = default!;

        /// <summary>
        /// Сохраняем изменения в экспонате.
        /// Предполагается, что в Application-слое есть UpdateExhibitCommand.
        /// Если его нет, добавь команду по аналогии с Create/Add.
        /// </summary>
        [RelayCommand]
        private async Task SaveAsync()
        {
            // TODO: заменить на реальную команду обновления
            // await _mediator.Send(new UpdateExhibitCommand(
            //     Exhibit.Id,
            //     Exhibit.Name,
            //     Exhibit.AppraisedValue,
            //     Exhibit.YearCreated,
            //     Exhibit.Material,
            //     Exhibit.Artist,
            //     Exhibit.HallId));

            await Shell.Current.GoToAsync("..");
        }

        [RelayCommand]
        private async Task CancelAsync()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}
