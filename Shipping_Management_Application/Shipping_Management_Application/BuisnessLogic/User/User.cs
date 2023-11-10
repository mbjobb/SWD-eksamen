namespace Shipping_Management_Application.BuisnessLogic.User
{
    public class User
    {
        public readonly int _userId;
        public double UserBalance { get; private set; }
        public string UserEmail { get; set; }
        internal string UserName { get; set; }

        public List<Order> Orders { get; private set; }


    }
}