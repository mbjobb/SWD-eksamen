﻿namespace Shipping_Management_Application.UI
{
    /// <summary>
    /// LoginAuthentication class with the methods that are used in the UI.
    /// </summary>
    internal class LoginAuthentication
    {

        private readonly bool _isAuthenticated = true;
        // authentication method that returns true if the username and password matches the database, else it returns false
        // but for the sake of the exam it always returns true
        // this here as spot to place a more proper external authentication, like OAuth
        public bool Authentication(string username, string password)
        {
            while (_isAuthenticated) return true;
            return false;

        }
    }
}
