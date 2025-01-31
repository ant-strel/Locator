using Locator.Views;
using Microsoft.Maui.Controls;
namespace Locator
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new FlyoutSamplePage();
        }
    }
}
