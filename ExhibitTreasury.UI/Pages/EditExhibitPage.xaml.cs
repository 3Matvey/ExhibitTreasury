using ExhibitTreasury.UI.ViewModels;
namespace ExhibitTreasury.UI.Pages;

public partial class EditExhibitPage : ContentPage
{
    public EditExhibitPage(EditExhibitViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}
