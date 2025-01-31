using CommunicationLib.DTO;
using System.Threading.Tasks;

namespace CommunicationLib.Abstractions
{
    public interface ITrackerService
    {
        public Task<SendLocationResponse> Track(string uuid, double latitude, double longitude);
        public Task<GetLocationResponse> LocateByUUID(string uuid);

    }
}
