using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Shipping_Management_Application.Data
{
    public class Customer
    {
        // We use DataAnnotations to manage and validate input data
        [Key]
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "First name is required")]
        public string? FirstName { get;  set; }

        [Required(ErrorMessage = "Last name is required")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "Address is required")]
        public string? Address { get;  set; }

        [Required(ErrorMessage = "City is required")]
        public string? City { get;  set; }

        [Required(ErrorMessage = "Region is required")]
        public string? Region { get;  set; }

        [Required(ErrorMessage = "Postal code is required")]
        public string? PostalCode { get;  set; }

        [Required(ErrorMessage = "Country is required")]
        public string? Country { get; set; }

        [Required(ErrorMessage = "Phone is required")]
        public string? Phone { get;  set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string? Email { get;  set; }
         
        public List<Order> Orders { get;  set; }
        

        [JsonConstructor]
        public Customer()
        {

        }
        [JsonConstructor]
       
         public Customer(string? firstName, string? lastName, string? address, string? city, string? region, string? postalCode, string? country, string? phone, string? email)
        {
            
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            City = city;
            Region = region;
            PostalCode = postalCode;
            Country = country;
            Phone = phone;
            Email = email;
        }

        // ToString Method
        public override string ToString()
        {
            return $"Customer ID: {CustomerId}\nName: {FirstName} {LastName}\nAddress: {Address} \nCity: {City} \nRegion: {Region} \nPostalCode: {PostalCode}\nCountry: {Country}\nContact: {Phone} \nEmail: {Email}";
        }

    }


}