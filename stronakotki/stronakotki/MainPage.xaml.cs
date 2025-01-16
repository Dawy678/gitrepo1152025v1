using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Shapes;
using System.Collections.ObjectModel;
using System.IO;

namespace stronakotki
{
    public partial class MainPage : ContentPage
    {
        ObservableCollection<Kotki> koteczek = new ObservableCollection<Kotki>();
        public void GetKotki()
        {
            koteczek.Add(new Kotki()
            {
                KotkiName = "Bialuszek",
                KotkiUrl = "bialuszekzdjecie.jpg"
            });
            koteczek.Add(new Kotki()
            {
                KotkiName = "Czarnuszek",
                KotkiUrl = "czarnuszekzdjecie.jpg"
            });
            koteczek.Add(new Kotki()
            {
                KotkiName = "Toffi",
                KotkiUrl = "toffizdjecie.jpg"
            });
            koteczek.Add(new Kotki()
            {
                KotkiName = "Brzydal(Chłopczyk)",
                KotkiUrl = "brzydalzdjecie.jpg"
            });
            koteczek.Add(new Kotki()
            {
                KotkiName = "Pers Pampers",
                KotkiUrl = "perspamperszdjecie.jpg"
            });
        }
        public MainPage()
        {
            InitializeComponent();
            GetKotki();
            collectionView.ItemsSource = koteczek;
        }
        private void Entry_Unfocused(object sender, FocusEventArgs e)
        {
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            var result = await FilePicker.PickAsync(new PickOptions
            {
                PickerTitle = "Wybierz zdjecie kotka prosze",
                FileTypes = FilePickerFileType.Images
            });
            if (result == null)
            {
                return;
            }
            var stream = await result.OpenReadAsync();
            koteczek.Add(new Kotki() { KotkiName = wybrananazwakotka.Text, KotkiUrl = ImageSource.FromStream(() => stream) });
            Console.WriteLine(ImageSource.FromStream(() => stream).ToString);
        }
    }

}
