using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace FountainProgrammer.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LayoutPage : Page
    {
        public LayoutPage()
        {
            this.InitializeComponent();
            CreateGrid();
        }

        

        private async void CreateGrid()
        {
            await Task.Delay(2000);
            for (int i = 0; i < 30; i++)
            {
                Line line = new Line();
                if (i == 0)
                {
                    line.Stroke = new SolidColorBrush(Windows.UI.Colors.Red);
                    line.StrokeThickness = 5;
                }
                else line.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);

                line.X1 = 0;
                line.X2 = 0;
                line.Y2 = 304;
                //line.StrokeThickness = 16;
                line.Translation = new Vector3(16*i, 10, 0);

                LayoutRoot.Children.Add(line);
            }

            for (int i = 0; i < 21; i++)
            {
                Line line = new Line();
                if (i == 20)
                {
                    line.Stroke = new SolidColorBrush(Windows.UI.Colors.Green);
                    line.StrokeThickness = 5;
                }
                else line.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);
                line.X1 = 0;
                line.X2 = 464;
                line.Y2 = 0;
                //line.StrokeThickness = 16;
                line.Translation = new Vector3(0, 16*i - 6, 0);

                LayoutRoot.Children.Add(line);
            }

            
        }
    }
}
