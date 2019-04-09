using FountainProgrammer.Pages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace FountainProgrammer
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private Dictionary<string, Type> _pages = new Dictionary<string, Type>();

        public MainPage()
        {
            this.InitializeComponent();
            _pages.Add("Fixtures", typeof(FixturesPage));
            _pages.Add("Components", typeof(ComponentsPage));
            _pages.Add("Layout", typeof(LayoutPage));
        }

        private void NavView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            var page = args.InvokedItemContainer;

            if (page != null && _pages.ContainsKey(page.Tag.ToString()) && !Equals(ContentFrame.CurrentSourcePageType, _pages[page.Tag.ToString()]))
            {
                ContentFrame.Navigate(_pages[page.Tag.ToString()]);
            }
        }

        private void FixturesFrame_NavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

        private async void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            /*
            StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
            StorageFile sampleFile = await storageFolder.GetFileAsync("UnityProject/FountainInfo.txt");
            await FileIO.WriteTextAsync(sampleFile, "Swift as a shadow");
            */

            FileSavePicker savePicker = new FileSavePicker();
            savePicker.SuggestedStartLocation = PickerLocationId.DocumentsLibrary;
            // Dropdown of file types the user can save the file as
            savePicker.FileTypeChoices.Add("Plain Text", new List<string>() { ".txt" });
            // Default file name if the user does not type one in or select a file to replace
            savePicker.SuggestedFileName = "New Document";

            var file = await savePicker.PickSaveFileAsync();

            await FileIO.WriteTextAsync(file, "Testing1");
        }
    }
}
