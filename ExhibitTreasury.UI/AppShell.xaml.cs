using ExhibitTreasury.UI.Pages;

namespace ExhibitTreasury.UI
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ExhibitDetailsPage), typeof(ExhibitDetailsPage));
            Routing.RegisterRoute(nameof(CreateHallPage), typeof(CreateHallPage));
            Routing.RegisterRoute(nameof(CreateExhibitPage), typeof(CreateExhibitPage));
            Routing.RegisterRoute(nameof(EditExhibitPage), typeof(EditExhibitPage));
            Routing.RegisterRoute(nameof(MoveExhibitPage), typeof(MoveExhibitPage));
            Routing.RegisterRoute(nameof(ExhibitsPage), typeof(ExhibitsPage));

        }
    }
}
