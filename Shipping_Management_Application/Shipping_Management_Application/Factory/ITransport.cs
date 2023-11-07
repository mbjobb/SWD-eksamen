namespace Shipping_Management_Application.Services.Factory{
    public interface ITransport{
        string Deliver();
        int GetShippingCost();
    }
}