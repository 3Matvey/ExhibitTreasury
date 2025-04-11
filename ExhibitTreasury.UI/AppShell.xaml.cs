using ExhibitTreasury.UI.Pages;

namespace ExhibitTreasury.UI
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ExhibitDetailsPage), typeof(ExhibitDetailsPage));
        }
    }
}
