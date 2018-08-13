using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace SimpleChatRoom
{
    public class ServerHub : Hub
    {
        public void AddToRoom(string roomName,string userName)
        {
            Groups.Add(Context.ConnectionId, roomName);

            Clients.Group(roomName, new string[0]).addUserIn(roomName,userName);
        }
        public void Send(string roomName, string userName,string msg)
        {
            Clients.Group(roomName, new string[0]).sendMessage(userName,msg);
        }
    }
}