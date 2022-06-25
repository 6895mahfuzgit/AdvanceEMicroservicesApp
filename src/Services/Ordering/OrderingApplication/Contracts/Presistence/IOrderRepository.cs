using System.Collections.Generic;
using System.Threading.Tasks;
using OrderingDomain.Entities;

namespace OrderingApplication.Contracts.Presistence
{
    public interface IOrderRepository : IAsyncRepository<Order>
    {
        Task<IEnumerable<Order>> GetOrdersByUserName(string userName);
    }
}
