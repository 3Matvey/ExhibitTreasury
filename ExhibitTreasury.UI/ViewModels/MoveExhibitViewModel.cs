// ViewModels/MoveExhibitViewModel.cs
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ExhibitTreasury.Application.ExhibitUseCases.Queries;
using ExhibitTreasury.Domain.Entities;
using MediatR;
using Microsoft.Maui.Controls;

namespace ExhibitTreasury.UI.ViewModels
{
    [QueryProperty(nameof(Exhibit), "Exhibit")]
    public partial class MoveExhibitViewModel : ObservableObject
    {
        private readonly IMediator _mediator;

        public MoveExhibitViewModel(IMediator mediator)
        {
            _mediator = mediator;
            Halls = new ObservableCollection<Hall>();
            LoadHallsCommand = new AsyncRelayCommand(LoadHallsAsync);
        }

        [ObservableProperty]
        private Exhibit exhibit = default!;

        [ObservableProperty]
        private ObservableCollection<Hall> halls;

        [ObservableProperty]
        private Hall? selectedHall;

        public IAsyncRelayCommand LoadHallsCommand { get; }

        private async Task LoadHallsAsync()
        {
            var all = await _mediator.Send(new ExhibitTreasury.Application.HallUseCases.Queries.GetAllHallsQuery());
            Halls.Clear();
            foreach (var h in all) Halls.Add(h);
        }
        partial void OnExhibitChanged(Exhibit value)
        {
            // Запускаем загрузку залов сразу после того, как VM получил Exhibit
            LoadHallsCommand.Execute(null);
        }
        private bool CanMove() => SelectedHall is not null && SelectedHall.Id != Exhibit.HallId;

        [RelayCommand(CanExecute = nameof(CanMove))]
        private async Task MoveAsync()
        {
            // TODO: добавить в Application-слое команду MoveExhibitCommand или аналог
            // await _mediator.Send(new MoveExhibitCommand(Exhibit.Id, SelectedHall!.Id));

            await Shell.Current.GoToAsync("..");
        }

        partial void OnSelectedHallChanged(Hall? oldValue, Hall? newValue)
            => MoveCommand.NotifyCanExecuteChanged();

        [RelayCommand]
        private async Task CancelAsync()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}
