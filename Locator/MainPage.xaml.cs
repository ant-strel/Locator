using System.Windows.Input;

namespace Locator
{
    public partial class MainPage : FlyoutPage
    {
        public ICommand NavigateCommand { get; }
        public MainPage()
        {
            InitializeComponent();
            NavigateCommand = new Command<string>(NavigateToPage);
            BindingContext = this;
        }
        private async void NavigateToPage(string pageName)
        {
            Page page = pageName switch
            {
                "HomePage" => new HomePage(),
                "SettingsPage" => new SettingsPage(),
                _ => new ContentPage { Title = "Not Found" }
            };

            Detail = new NavigationPage(page);
            IsPresented = false; // Close the flyout after selection
        }

        private async void OnCounterClicked(object sender, EventArgs e)
        {
            PermissionStatus statusWhenItUse = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();
            PermissionStatus statusAlways = await Permissions.CheckStatusAsync<Permissions.LocationAlways>();
            if (statusWhenItUse != PermissionStatus.Granted && statusAlways != PermissionStatus.Granted)
            {
                PermissionStatus status = await Permissions.RequestAsync<Permissions.LocationAlways>();
                return;
            }
                
            var location = await Geolocation.GetLastKnownLocationAsync();
            if (location != null)
            {
            //    lblCoordinates.Text = $"latitude - {location.Latitude} longtitude - {location.Longitude}";
            }
            


            //if (count == 1)
            //    CounterBtn.Text = $"Clicked {count} time";
            //else
            //    CounterBtn.Text = $"Clicked {count} times";

           // SemanticScreenReader.Announce(lblCoordinates.Text);
        }
    }

}
