using Geo.V1;

namespace CommLib
{
    public interface ITrackerClient
    {
        public Task<TrackResponse> Track(string uuid, double latitude, double longitude);
        public Task<LocateByUUIDResponse> LocateByUUID(string uuid);

    }
}
