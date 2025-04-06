using System.Collections.ObjectModel;
using System.Threading.Tasks;
using ExhibitTreasury.Domain.Entities;
using MediatR;
using ExhibitTreasury.Application.ExhibitUseCases.Queries;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ExhibitTreasury.UI.ViewModels
{
    public partial class HallsViewModel : ObservableObject
    {
        private readonly IMediator _mediator;

        public HallsViewModel(IMediator mediator)
        {
            _mediator = mediator;
            Halls = new ObservableCollection<Hall>();
            Exhibits = new ObservableCollection<Exhibit>();

            // Команды
            LoadHallsCommand = new AsyncRelayCommand(LoadHallsAsync);
            LoadExhibitsCommand = new AsyncRelayCommand(LoadExhibitsAsync);
        }

        // Коллекция залов
        [ObservableProperty]
        private ObservableCollection<Hall> halls;

        // Коллекция экспонатов выбранного зала
        [ObservableProperty]
        private ObservableCollection<Exhibit> exhibits;

        // Текущий выбранный зал
        [ObservableProperty]
        private Hall? selectedHall;

        // Команды
        public IAsyncRelayCommand LoadHallsCommand { get; }
        public IAsyncRelayCommand LoadExhibitsCommand { get; }

        private async Task LoadHallsAsync()
        {
            // Предполагается, что GetAllHallsQuery уже реализован
            var result = await _mediator.Send(new Application.HallUseCases.Queries.GetAllHallsQuery());
            Halls.Clear();
            foreach (var hall in result)
            {
                Halls.Add(hall);
            }
            // При необходимости сразу установить первый зал как выбранный
            if (Halls.Count > 0)
            {
                SelectedHall = Halls[0];
            }
        }

        private async Task LoadExhibitsAsync()
        {
            if (SelectedHall is null)
                return;

            Exhibits.Clear();
            var data = await _mediator.Send(new GetExhibitsByHallQuery(SelectedHall.Id));
            foreach (var exhibit in data)
            {
                Exhibits.Add(exhibit);
            }
        }

        // Этот partial-метод генерируется благодаря CommunityToolkit.Mvvm для свойства SelectedHall
        partial void OnSelectedHallChanged(Hall? value)
        {
            // Как только меняется выбранный зал, автоматически загружаем экспонаты
            if (value is not null)
            {
                LoadExhibitsCommand.ExecuteAsync(null);
            }
        }
    }
}
