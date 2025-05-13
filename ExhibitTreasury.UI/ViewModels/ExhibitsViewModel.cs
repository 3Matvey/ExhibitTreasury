// ViewModels/ExhibitsViewModel.cs
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ExhibitTreasury.Application.ExhibitUseCases.Queries;

namespace ExhibitTreasury.UI.ViewModels
{
    [QueryProperty(nameof(HallId), "HallId")]
    public partial class ExhibitsViewModel : ObservableObject
    {
        readonly IMediator _mediator;

        public ExhibitsViewModel(IMediator mediator)
        {
            _mediator = mediator;
            Exhibits = new ObservableCollection<Exhibit>();
            LoadExhibitsCommand = new AsyncRelayCommand(LoadExhibitsAsync);
            NavigateToCreateExhibitCommand = new AsyncRelayCommand(NavigateToCreateExhibit);
        }

        [ObservableProperty]
        int hallId;

        [ObservableProperty]
        string hallName = string.Empty;

        [ObservableProperty]
        ObservableCollection<Exhibit> exhibits;

        public IAsyncRelayCommand LoadExhibitsCommand { get; }
        public IAsyncRelayCommand NavigateToCreateExhibitCommand { get; }

        private async Task LoadExhibitsAsync()
        {
            // Определим имя зала для заголовка
            var hall = (await _mediator.Send(new ExhibitTreasury.Application.HallUseCases.Queries.GetAllHallsQuery()))
                       .FirstOrDefault(h => h.Id == HallId);
            HallName = hall?.Name ?? "Экспонаты";

            Exhibits.Clear();
            var data = await _mediator.Send(new GetExhibitsByHallQuery(HallId));
            foreach (var ex in data) Exhibits.Add(ex);
        }

        private async Task NavigateToCreateExhibit()
        {
            await Shell.Current.GoToAsync(
              nameof(Pages.CreateExhibitPage),
              new Dictionary<string, object> { ["HallId"] = HallId });
        }
    }
}
