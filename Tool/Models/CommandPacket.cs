namespace Tool.Models
{
    public class CommandPacket : PacketBase
    {
        public string Name { get; set; }
        public string Action { get; set; }
        public List<string> Flags { get; set; } = new List<string>();

        public CommandPacket() { Type = "command"; }
    }
}
