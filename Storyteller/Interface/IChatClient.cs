using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Storyteller.Interface
{
    public interface IChatClient
    {
        //Task AddGroup(string groupName, string user);
        //Task ReceiveMsgGroup(string groupName, string user, string message);
        public Task MessageSender(string user, string message);
    }
}
