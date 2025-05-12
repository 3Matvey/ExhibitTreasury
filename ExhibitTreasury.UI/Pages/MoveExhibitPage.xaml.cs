using ExhibitTreasury.UI.ViewModels;
namespace ExhibitTreasury.UI.Pages;

public partial class MoveExhibitPage : ContentPage
{
    public MoveExhibitPage(MoveExhibitViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}
