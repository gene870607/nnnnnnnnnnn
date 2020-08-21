using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using Storyteller.Interface;
using Storyteller.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Storyteller.Hubs
{
    [Flags]
    public enum ScriptStatus : ushort
    {
        End = 99,
        PerEnd = 98
    }
    public class RoomHub : Hub
    {

        public static List<PairingModel> roleList = new List<PairingModel>();
        public override async Task OnConnectedAsync()
        {
            //連上線
            await base.OnConnectedAsync();
        }


        public async Task AddToGroup(string groupId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupId);

            await Clients.Group(groupId).SendAsync("Send", $"{Context.ConnectionId} has joined the group {groupId}.");
        }

        public async Task RemoveFromGroup(string groupId)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupId);
            await Clients.Group(groupId).SendAsync("Send", $"{Context.ConnectionId} has left the group {groupId}.");
        }

        public Task SendMessageInGames(string groupId, string userName, string message, string rolesImg, int goToSectionIndex)
        {
            return Clients.Group(groupId).SendAsync("ReceiveGroupMessage", userName, message, rolesImg, goToSectionIndex);
        }

        public async Task PassResult(string groupId, int id, int index, string userName)
        {
            if (index == (int)ScriptStatus.End)
            {
                await Clients.Group(groupId).SendAsync("GoEnd", id, index);
            }
            else
            {

                await Clients.Group(groupId).SendAsync("GoToNext", id, index, userName);
            }

        }

        public async Task Like (string index, string groupId, string userName,bool IsLike)
        {
            await Clients.Group(groupId).SendAsync("BeLiked", index, userName, IsLike);
        }




        //配對使用
        public async Task CreateRole(string roleValue, string img)
        {
            roleList.Add(new PairingModel { ConnectionId = Context.ConnectionId, Role = roleValue, Img = img });
            var jsonString = JsonConvert.SerializeObject(roleList);
            await Clients.All.SendAsync("CreateRole", jsonString);
        }

        public async Task RemoveRole()
        {
            var user = roleList.FirstOrDefault(u => u.ConnectionId == Context.ConnectionId);
            roleList.Remove(user);
            var jsonString = JsonConvert.SerializeObject(roleList);
            await Clients.All.SendAsync("RemoveRole", jsonString);
        }


        public async Task Pairing(string roleValue, string img)
        {

            var result = roleList.FirstOrDefault((x) => x.ConnectionId != Context.ConnectionId && x.Role != roleValue);
            if (result != null)
            {
                string roomId = $"beanfun{DateTime.Now.GetHashCode()}";
                await Clients.Client(result.ConnectionId).SendAsync("PairingSuccess", result.Role, img, roomId);
                await Clients.Client(Context.ConnectionId).SendAsync("PairingSuccess", roleValue, result.Img, roomId);
                roleList.Remove(result);
            }

        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            //斷線
            var user = roleList.FirstOrDefault(u => u.ConnectionId == Context.ConnectionId);
            roleList.Remove(user);
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, "SignalR Users");
            await Clients.Others.SendAsync("Leave", Context.ConnectionId);
            await base.OnDisconnectedAsync(exception);
        }

    }
}