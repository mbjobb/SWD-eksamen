namespace Shipping_Management_Application.BuisnessLogic
{
    public interface IUserEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }

    }
}
