using ExhibitTreasury.UI.ViewModels;

namespace ExhibitTreasury.UI.Pages
{
    public partial class HallsPage : ContentPage
    {
        private readonly HallsViewModel _viewModel;

        public HallsPage(HallsViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            BindingContext = _viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (_viewModel.LoadHallsCommand.CanExecute(null))
            {
                _viewModel.LoadHallsCommand.Execute(null);
            }
        }
    }
}
