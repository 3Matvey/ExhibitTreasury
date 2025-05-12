using ExhibitTreasury.UI.ViewModels;
namespace ExhibitTreasury.UI.Pages;

public partial class CreateHallPage : ContentPage
{
    public CreateHallPage(CreateHallViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}
