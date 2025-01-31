using CommunicationLib.Abstractions;
using CommunicationLib.Impl;
using CommunicationLib.DTO;
using System.Threading.Tasks;

namespace CommunicationLib.Services
{
    public class TrackerService:ITrackerService
    {
        private GrpcTrackerClient _client;
        public TrackerService(string address, int port)
        {
            _client = TrackerClientFactory.Create(address, port);
        }
        public void UpdateClient(string address,int port) => _client = TrackerClientFactory.Update(address, port);
        
        public async Task<GetLocationResponse> LocateByUUID(string uuid)
        {
            var response = await _client.LocateByUUID( uuid );
            return new GetLocationResponse()
            {
                Coordinates = new Coordinates()
                {
                    Latitude = response.Latlng.Latitude,
                    Longitude = response.Latlng.Longitude,
                },
                Deadline = response.Deadline
            };
        }

        public async Task<SendLocationResponse> Track(string uuid, double latitude, double longitude)
        {
            await _client.Track(uuid, latitude, longitude);
            return new SendLocationResponse();
        }
    }
}
