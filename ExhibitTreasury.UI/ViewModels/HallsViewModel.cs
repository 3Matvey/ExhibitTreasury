// ViewModels/HallsViewModel.cs
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
    public partial class HallsViewModel : ObservableObject
    {
        private readonly IMediator _mediator;

        public HallsViewModel(IMediator mediator)
        {
            _mediator = mediator;             // <- правильно присваиваем
            Halls = new ObservableCollection<Hall>();
            Exhibits = new ObservableCollection<Exhibit>();
        }

        // Коллекция залов
        [ObservableProperty]
        private ObservableCollection<Hall> halls;

        // Коллекция экспонатов у выбранного зала
        [ObservableProperty]
        private ObservableCollection<Exhibit> exhibits;

        // Текущий выбранный зал
        [ObservableProperty]
        private Hall? selectedHall;

        // Команда загрузки залов
        [RelayCommand]
        private async Task LoadHallsAsync()
        {
            var all = await _mediator.Send(new ExhibitTreasury.Application.HallUseCases.Queries.GetAllHallsQuery());
            Halls.Clear();
            foreach (var h in all) Halls.Add(h);

            if (Halls.Count > 0)
                SelectedHall = Halls[0];
        }

        // Как только SelectedHall меняется, автоматически грузим экспонаты
        partial void OnSelectedHallChanged(Hall? value)
        {
            if (value is not null)
                LoadExhibitsCommand.Execute(null);
        }

        // Команда загрузки экспонатов
        [RelayCommand(CanExecute = nameof(CanLoadExhibits))]
        private async Task LoadExhibitsAsync()
        {
            if (SelectedHall is null) return;
            Exhibits.Clear();
            var ex = await _mediator.Send(new GetExhibitsByHallQuery(SelectedHall.Id));
            foreach (var e in ex) Exhibits.Add(e);
        }

        private bool CanLoadExhibits() => SelectedHall is not null;

        // Навигация на страницу создания зала
        [RelayCommand]
        private async Task NavigateToCreateHall()
        {
            await Shell.Current.GoToAsync(nameof(ExhibitTreasury.UI.Pages.CreateHallPage));
        }

        // Навигация на страницу создания экспоната (с передачей HallId)
        [RelayCommand]
        private async Task NavigateToCreateExhibit()
        {
            if (SelectedHall == null) return;
            await Shell.Current.GoToAsync(
                nameof(ExhibitTreasury.UI.Pages.CreateExhibitPage),
                new Dictionary<string, object>
                {
                    ["HallId"] = SelectedHall.Id
                });
        }

        // Показ деталей экспоната
        [RelayCommand]
        private async Task ShowExhibitDetails(Exhibit selectedExhibit)
        {
            if (selectedExhibit == null) return;
            await Shell.Current.GoToAsync(
                nameof(ExhibitTreasury.UI.Pages.ExhibitDetailsPage),
                new Dictionary<string, object>
                {
                    ["Exhibit"] = selectedExhibit
                });
        }
    }
}
