using System.Collections.ObjectModel;
using System.Windows.Input;
using ExhibitTreasury.Application.HallUseCases.Queries;
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
            Halls = [];
            LoadHallsCommand = new AsyncRelayCommand(LoadHallsAsync);
        }

        [ObservableProperty]
        private ObservableCollection<Hall> halls;

        public ICommand LoadHallsCommand { get; }

        private async Task LoadHallsAsync()
        {
            try
            {
                var result = await _mediator.Send(new GetAllHallsQuery());
                Halls.Clear();

                foreach (var hall in result)
                {
                    Halls.Add(hall);
                }
            }
            catch (Exception ex)
            {
                // TODO: лог или отображение ошибки
                Console.WriteLine($"Ошибка при загрузке залов: {ex.Message}");
            }
        }
    }
}
