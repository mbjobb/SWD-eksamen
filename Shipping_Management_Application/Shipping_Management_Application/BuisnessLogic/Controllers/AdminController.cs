﻿using Shipping_Management_Application.Data;
using Shipping_Management_Application.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping_Management_Application.BuisnessLogic.Controllers
{
    public class AdminController
    {
        public IEnumerable<UserEntity> GetAllUserEntities()
        {
            return CrudOperations.GetAllUserEntities();
        }

        public UserEntity CreateAdmin(string username, string password)
        {
            return CrudOperations.CreateAdmin(username, password);
        }
    }
}
