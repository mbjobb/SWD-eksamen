namespace Shipping_Management_Application.BuisnessLogic.User
{
    public interface IUserEntity
    {
        public long Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

    }
}
