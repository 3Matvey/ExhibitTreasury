using CommunityToolkit.Mvvm.ComponentModel;
using ExhibitTreasury.Domain.Entities;

namespace ExhibitTreasury.UI.ViewModels
{
    // При передаче параметра навигации ожидается, что объект будет передан по ключу "Exhibit"
    [QueryProperty(nameof(Exhibit), "Exhibit")]
    public partial class ExhibitDetailsViewModel : ObservableObject
    {
        // Это свойство будет автоматически заполнено, когда мы перейдем на страницу деталей через навигацию.
        [ObservableProperty]
        private Exhibit exhibit;
    }
}
