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
using System.Threading.Tasks;
using Windows.UI.Xaml.Shapes;
using System.Numerics;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace FountainProgrammer.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class GridPage : Page
    {

        private List<Line> _gridLines = new List<Line>();
        private int lineAmount;
        
        public GridPage()
        {
            this.InitializeComponent();
        }

        private void CreateGrid()
        {
            var colSpacing = PageRoot.Width / lineAmount;
            var rowSpacing = PageRoot.Height / lineAmount;

            for(int i=0; i<= lineAmount; i++)
            {
                Line line = new Line();
                line.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);
                line.X1 = 0;
                line.X2 = 0;
                line.Y2 = PageRoot.Height;
                line.Translation = new Vector3((float)colSpacing * i, 0, 0);
                LayoutRoot.Children.Add(line);
                _gridLines.Add(line);
            }

            for (int i = 0; i <= lineAmount; i++)
            {
                Line line = new Line();
                line.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);
                line.X1 = 0;
                line.X2 = PageRoot.Width;
                line.Y2 = 0;
                line.Translation = new Vector3(0, (float)rowSpacing * i, 0);
                LayoutRoot.Children.Add(line);
                _gridLines.Add(line);
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (e.Parameter != null)
                lineAmount = (int)e.Parameter;
            else lineAmount = 100;

            CreateGrid();
        }
    }
}
