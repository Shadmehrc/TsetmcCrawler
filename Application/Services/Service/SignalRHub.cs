using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Services.ServiceInterface;
using Domain.Models.Models;
using Microsoft.AspNetCore.SignalR;

namespace Application.Services.Service
{
    public class SignalRHub : Hub ,ISignalRHub 
    {
        public async Task SendMessage(string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", message);
        }

        // Method to send a list of data to all connected clients
        public async Task SendData(List<Symbol> data)
        {
            await Clients.All.SendAsync("ReceiveData", data);
        }
    }
}
