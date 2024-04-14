using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MultiShop.Discount.Entities;
using System.Data;

namespace MultiShop.Discount.Context {
    public class DapperContext : DbContext {
        //In order to use dapper we need its configuration
        private readonly IConfiguration configuration;
        private readonly string connectionString;
        public DapperContext(IConfiguration configuration) {
            this.configuration = configuration;
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlServer("Server=DESKTOP-27F5QUI\\SQLEXPRESS;" + // server to connect to
                "initial Catalog=MultiShopDiscount;" + // database to connect to
                "integrated Security=true"); // . true indicates that Windows authentication (integrated security) is used.
        }

        public DbSet<Coupon> Coupons { get; set; }
        public IDbConnection CreateConnection() => new SqlConnection(connectionString);

    }
}
