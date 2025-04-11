using ExhibitTreasury.UI.ViewModels;

namespace ExhibitTreasury.UI.Pages
{
    public partial class ExhibitDetailsPage : ContentPage
    {
        public ExhibitDetailsPage(ExhibitDetailsViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}
