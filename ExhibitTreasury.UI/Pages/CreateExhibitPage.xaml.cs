using ExhibitTreasury.UI.ViewModels;
namespace ExhibitTreasury.UI.Pages;

public partial class CreateExhibitPage : ContentPage
{
    public CreateExhibitPage(CreateExhibitViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}
