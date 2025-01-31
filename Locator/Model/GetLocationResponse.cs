using Google.Protobuf.WellKnownTypes;

namespace CommunicationLib.DTO
{
    public class GetLocationResponse
    {
        public Coordinates Coordinates { get; set; }
        public Timestamp Deadline { get; set; }
    }
}
