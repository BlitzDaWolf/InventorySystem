﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Service.Interfaces
{
    public interface IUserService
    {
        string Login(string userName, string password);
        bool Register(string userName, string password, string rePassword, string email);
    }
}
