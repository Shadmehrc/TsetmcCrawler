using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Services.ServiceInterface;
using Domain.Models.Models;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;

namespace Application.Services.Service
{
    public class SignalRHub : Hub, ISignalRHub
    {

        private readonly IHubContext<SignalRHub> _hubContext;

        public SignalRHub(IHubContext<SignalRHub> hubContext) // ✅ Use IHubContext
        {
            _hubContext = hubContext;
        }

        public async Task SendMessage(string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", message);
        }

        public async Task SendData(string data)
        {
            try
            {
                await _hubContext.Clients.All.SendAsync("ReceiveData", data);
            }
            catch (Exception ex)
            {
            }
        }

        public override async Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();
        }


    }

}
