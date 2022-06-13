using System.Threading.Tasks;
using Dapper;
using DiscountAPIApp.Entities;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace DiscountAPIApp.Repositories
{
    public class DiscountRepository : IDiscountRepository
    {
        private readonly IConfiguration _configuration;

        public DiscountRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<Coupon> GetDiscount(string productName)
        {
            using var connection = new NpgsqlConnection(_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var coupon = await connection.QueryFirstAsync<Coupon>("SELECT * FROM Coupon WHERE ProductName=@ProductName", new { ProductName = productName });
            if (coupon == null)
            {
                return new Coupon()
                {
                    ProductName = "No Discount",
                    Amount = 0,
                    Description = "No Discount Desc"
                };
            }
            return coupon;
        }

        public Task<bool> CreateDiscount(Coupon coupon)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeleteDiscount(string productName)
        {
            throw new System.NotImplementedException();
        }


        public Task<bool> UpdateDiscount(Coupon coupon)
        {
            throw new System.NotImplementedException();
        }
    }
}
