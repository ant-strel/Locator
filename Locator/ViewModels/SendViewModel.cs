using CommunicationLib.Services;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Locator.VMs
{
    public class SendViewModel : INotifyPropertyChanged
    {
        private double _longtitude;
        private double _latitude;
        private string _uuid = Guid.NewGuid().ToString();
        private TrackerService _trackerService;

        public double Longtitude { get => _longtitude; set { _longtitude = value; OnPropertyChanged(); } }

        public double Latitude { get => _latitude; set { _latitude = value; OnPropertyChanged(); } }
        public string UUID { get => _uuid; set { _uuid = value; OnPropertyChanged(); } }
 
        public bool TimerVisibility { get => _timerVisib; set; }
        public void AddTrackerService(TrackerService trackerService) => _trackerService = trackerService;

        public ICommand SendLocationCommand => new Command(SendLocation);
        public ICommand StartLocationTimerCommand => new Command(StartTimer);
        public ICommand StopLocationTimerCommand => new Command(StopTimer);

        private void StartTimer(object obj)
        {
            
        }
        private void StopTimer(object obj)
        {

        }

        public void SendLocation(object obj)
        {
            DefineLocation();
         //  await _trackerService.Track(_uuid,_longtitude,_latitude);
        }

        private async void DefineLocation()
        {
            var location = await Geolocation.Default.GetLocationAsync();
            if (location != null)
            {
                Longtitude = location.Longitude;
                Latitude = location.Latitude;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
