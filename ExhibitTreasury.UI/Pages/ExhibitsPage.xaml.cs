using ExhibitTreasury.Domain.Entities;
using ExhibitTreasury.UI.ViewModels;

namespace ExhibitTreasury.UI.Pages
{
    public partial class ExhibitsPage : ContentPage
    {
        readonly ExhibitsViewModel _vm;
        public ExhibitsPage(ExhibitsViewModel vm)
        {
            InitializeComponent();
            BindingContext = _vm = vm;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await _vm.LoadExhibitsCommand.ExecuteAsync(null);
        }

        private async void OnExhibitSelected(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.FirstOrDefault() is Exhibit ex)
            {
                await Shell.Current.GoToAsync(
                  nameof(ExhibitDetailsPage),
                  new Dictionary<string, object> { ["Exhibit"] = ex });
                ((CollectionView)sender).SelectedItem = null;
            }
        }
    }
}
