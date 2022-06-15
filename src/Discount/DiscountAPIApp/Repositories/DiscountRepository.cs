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

        public async Task<bool> CreateDiscount(Coupon coupon)
        {
            using var connection = new NpgsqlConnection(_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var affected = await connection.ExecuteAsync("INSERT INTO coupon( productname, description, amount) values ( @productname, @description, @amount)", new { productname = coupon.ProductName, description = coupon.Description, amount = coupon.Amount });
            if (affected == 0)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> DeleteDiscount(string productName)
        {
            using var connection = new NpgsqlConnection(_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var affected = await connection.ExecuteAsync("DELETE Coupon WHERE ProductName=@ProductName", new { ProductName = productName });
            if (affected == 0)
            {
                return false;
            }
            return true;

        }


        public async Task<bool> UpdateDiscount(Coupon coupon)
        {
            using var connection = new NpgsqlConnection(_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var affected = await connection.ExecuteAsync("UPDATE  coupon SET  productname=@productname, description=@description, amount=@amount WHERE id=@id", new { id = coupon.Id, productname = coupon.ProductName, description = coupon.Description, amount = coupon.Amount });
            if (affected == 0)
            {
                return false;
            }
            return true;
        }
    }
}
