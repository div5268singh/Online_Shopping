using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace Online_Shopping_Model.ViewModel
{
    public class CustomerViewModel
    {
        public int CustomerId { get; set; }
        public int RoleId { get; set; }
        public string CustomerName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public int PostalCode { get; set; }
        public string Country { get; set; }
        public string Photo { get; set; }
        //public IFormFile PhotoPath { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

    }
}
