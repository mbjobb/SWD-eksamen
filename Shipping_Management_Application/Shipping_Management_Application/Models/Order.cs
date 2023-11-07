namespace Shipping_Management_Application.Models{
    public class Order{
        
        public int OrderId{ get; }
        public User user{ get; }
        public Product Product{ get; }
        
        public Order(User user, Product product){
            this.user = user;
            Product = product;
        }

        public Shipping ArrangeShipping(){
            return null; 
        }

        public int AddUpShippingCost(){
            return 0;
        }
    }
}