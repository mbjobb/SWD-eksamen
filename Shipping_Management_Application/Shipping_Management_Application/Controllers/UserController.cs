using Shipping_Management_Application.Models;
using Shipping_Management_Application.Repositories;

namespace Shipping_Management_Application.Controllers{
    public class UserController{
        private readonly IUserRepository _userRepository;
        private readonly IOrderRepository _orderRepository;

        public UserController(IUserRepository userRepository, IOrderRepository orderRepository){
            _userRepository = userRepository;
            _orderRepository = orderRepository;
        }

        public User CreateUser(string name, string email, int Bank){
            return new User("Ola Nordmann", "Ola@nordmann", 100); // Placeholder
        }

        public User? Login(string email){
            return _userRepository.GetUser(email);
        }
        
    }
}