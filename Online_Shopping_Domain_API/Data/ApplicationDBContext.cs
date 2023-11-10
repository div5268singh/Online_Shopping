using Microsoft.EntityFrameworkCore;
using Online_Shopping_Domain_API.Models;

namespace Online_Shopping_Domain_API.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }
        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Category> Catagories { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Delivery> Deliveries { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Seller> Sellers { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }

    }
}
