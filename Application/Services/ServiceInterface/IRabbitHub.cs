﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.ServiceInterface
{
    public interface IRabbitHub
    {
        public void SendMessage();
        //public void ReceiveMessage();

    }
}
