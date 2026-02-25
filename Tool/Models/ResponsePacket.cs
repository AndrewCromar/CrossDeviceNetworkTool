namespace Tool.Models
{
    public class ResponsePacket : PacketBase
    {
        public string Name { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }

        public ResponsePacket() { Type = "response"; }
    }
}