using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ExhibitTreasury.UI.ViewModels
{
    [QueryProperty(nameof(Exhibit), "Exhibit")]
    public partial class ExhibitDetailsViewModel : ObservableObject
    {
        // Эта страница получает Exhibit через параметр навигации
        [ObservableProperty]
        private Exhibit exhibit = default!;

        // 1) Редактировать
        [RelayCommand]
        private async Task NavigateToEditExhibit()
        {
            await Shell.Current.GoToAsync(
                nameof(ExhibitTreasury.UI.Pages.EditExhibitPage),
                new Dictionary<string, object>
                {
                    ["Exhibit"] = Exhibit
                });
        }

        // 2) Переместить
        [RelayCommand]
        private async Task NavigateToMoveExhibit()
        {
            await Shell.Current.GoToAsync(
                nameof(ExhibitTreasury.UI.Pages.MoveExhibitPage),
                new Dictionary<string, object>
                {
                    ["Exhibit"] = Exhibit
                });
        }

        // 3) Выбрать фото
        [RelayCommand]
        private async Task SelectImage()
        {
            try
            {
                var result = await FilePicker.PickAsync(new PickOptions
                {
                    FileTypes = FilePickerFileType.Images,
                    PickerTitle = "Выберите фото экспоната"
                });
                if (result == null)
                    return;

                // Сохраняем в AppData/Images/{Id}.jpg
                var imagesDir = Path.Combine(FileSystem.AppDataDirectory, "Images");
                Directory.CreateDirectory(imagesDir);
                var dest = Path.Combine(imagesDir, $"{Exhibit.Id}.jpg");

                using var inStream = await result.OpenReadAsync();
                using var outStream = File.OpenWrite(dest);
                await inStream.CopyToAsync(outStream);

                // чтобы конвертер обновился
                OnPropertyChanged(nameof(Exhibit));
            }
            catch (Exception ex)
            {
                //FIXME
                //await Application.Current.MainPage
                  //  .DisplayAlert("Ошибка", ex.Message, "OK");
            }
        }
    }
}
