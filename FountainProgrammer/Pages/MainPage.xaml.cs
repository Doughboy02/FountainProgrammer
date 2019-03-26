using FountainProgrammer.Pages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
    }
}
