namespace Shipping_Management_Application.Models{
    public class User{
        public string UserId{ get; private set; }
        public string Name{ get; set; }
        public string Email{ get; private set; }
        public int Bank{ get; }
        
        public User(string name, string email, int bank){
            Name = name;
            Email = email;
            Bank = bank;
        }
        
    }
}