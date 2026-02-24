using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossDeviceNetworkTool.Models
{
    public class ResponsePacket : PacketBase
    {
        public string Name { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }

        public ResponsePacket() { Type = "response"; }
    }
}