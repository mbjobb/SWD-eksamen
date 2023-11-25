using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping_Management_Application.UI
{
    internal class LoginAuthentication
    {

        private readonly bool _isAuthenticated = true;
        public bool Authentication(string username, string password)
        {
            while (_isAuthenticated) return true;
            return false;

        }
    }
}
