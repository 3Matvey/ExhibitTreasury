// Pages/HallsPage.xaml.cs
using ExhibitTreasury.Domain.Entities;
using ExhibitTreasury.UI.ViewModels;

namespace ExhibitTreasury.UI.Pages
{
    public partial class HallsPage : ContentPage
    {
        private readonly HallsViewModel _viewModel;

        public HallsPage(HallsViewModel vm)
        {
            InitializeComponent();
            BindingContext = _viewModel = vm;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await _viewModel.LoadHallsCommand.ExecuteAsync(null);
        }

        private async void OnHallSelected(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.FirstOrDefault() is Hall hall)
            {
                // Navigate to ExhibitsPage, передаём HallId
                await Shell.Current.GoToAsync(
                  nameof(ExhibitsPage),
                  new Dictionary<string, object> { ["HallId"] = hall.Id });
                ((CollectionView)sender).SelectedItem = null;
            }
        }
    }
}
