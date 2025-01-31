using Geo.V1;
using Grpc.Net.Client;
using System;
using System.Threading.Tasks;
using Dto.V1;

namespace CommunicationLib.Impl
{
    public class GrpcTrackerClient : IDisposable
    {
        private readonly string _address;
        private readonly int _port;
        private GrpcChannel _channel;
        private GeoService.GeoServiceClient _client;

        public GrpcTrackerClient(string address, int port)
        {
            _address = address;
            _port = port;
            _channel = GrpcChannel.ForAddress($"{_address}:{_port}");
            _client = new GeoService.GeoServiceClient(_channel);
        }
        public void Dispose()
        {
            _channel?.ShutdownAsync().Wait();
            _channel?.Dispose();
        }
        public async Task<LocateByUUIDResponse> LocateByUUID(string uuid)
        {
            return await _client.LocateByUUIDAsync(new LocateByUUIDRequest { Uuid = uuid });
        }

        public async Task<TrackResponse> Track(string uuid, double latitude, double longitude)
        {
            return await _client.TrackAsync(new TrackRequest
            {
                Uuid = uuid,
                Latlng = new LatLng
                {
                    Latitude = latitude,
                    Longitude = longitude
                }
            });
        }
    }
}
