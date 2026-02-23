using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.Generic;

namespace CrossDeviceNetworkTool.Models
{
    public class CommandPacket : PacketBase
    {
        public string Name { get; set; }
        public string Action { get; set; }
        public List<string> Flags { get; set; } = new List<string>();

        public CommandPacket() { Type = "command"; }
    }
}
