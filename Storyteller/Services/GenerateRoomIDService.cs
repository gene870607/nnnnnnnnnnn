using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Storyteller.Services
{
    public class GenerateRoomIDService
    {
        public string GenerateRoomID()
        {
            return DateTime.Now.ToString("yyyyMMddHHmmss");
        }
    }
}
