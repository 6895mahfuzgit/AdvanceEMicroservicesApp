using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OrderingApplication.Contracts.Presistence;
using OrderingDomain.Entities;
using OrderingInfrastructure.Presistence;

namespace OrderingInfrastructure.Repositories
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(OrderContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Order>> GetOrdersByUserName(string userName)
        {
            var orderList = await _context.Orders.Where(o => o.UserName == userName).ToListAsync();
            return orderList;
        }

    }
}
