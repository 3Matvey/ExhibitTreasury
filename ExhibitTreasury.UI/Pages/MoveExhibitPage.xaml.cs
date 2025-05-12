using ExhibitTreasury.UI.ViewModels;
namespace ExhibitTreasury.UI.Pages
{
    public partial class MoveExhibitPage : ContentPage
    {
        private readonly MoveExhibitViewModel _viewModel;

        public MoveExhibitPage(MoveExhibitViewModel vm)
        {
            InitializeComponent();
            _viewModel = vm;
            BindingContext = _viewModel;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            // Загружаем залы для Picker
            if (_viewModel.LoadHallsCommand.CanExecute(null))
                await _viewModel.LoadHallsCommand.ExecuteAsync(null);
        }
    }
}