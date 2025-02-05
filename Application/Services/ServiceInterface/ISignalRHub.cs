using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models.Models;
using Microsoft.AspNetCore.SignalR;

namespace Application.Services.ServiceInterface
{
    public interface ISignalRHub
    {
        public  Task SendMessage(string message);


        public  Task SendData(string data);

    }
}
