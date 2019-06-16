using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MVVM_WareHouse.View
{
    /// <summary>
    /// DefaultPage.xaml 的交互逻辑
    /// </summary>
    public partial class DefaultPage : Page
    {
        public DefaultPage()
        {
            InitializeComponent();

            
        }



        /// <summary>
        /// From https://docs.microsoft.com/zh-cn/dotnet/framework/wpf/graphics-multimedia/painting-with-images-drawings-and-visuals
        /// TODO :: FullFill this later
        /// </summary>
        //private void canvasBackgroundExample()
        //{

        //    BitmapImage theImage = new BitmapImage
        //        (new Uri("../../Icon/puppy.jpg", UriKind.Relative));

        //    ImageBrush myImageBrush = new ImageBrush(theImage);

        //    Canvas myCanvas = new Canvas();
        //    myCanvas.Width = 300;
        //    myCanvas.Height = 200;
        //    myCanvas.Background = myImageBrush;

        //    StackPanel.Children.Add(myCanvas);


        //}
    }
}
