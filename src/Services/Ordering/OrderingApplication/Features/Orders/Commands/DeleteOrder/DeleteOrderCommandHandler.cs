using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using OrderingApplication.Contracts.Presistence;
using OrderingApplication.Exceptions;
using OrderingDomain.Entities;

namespace OrderingApplication.Features.Orders.Commands.DeleteOrder
{
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand>
    {


        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteOrderCommandHandler> _logger;

        public async Task<Unit> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {

            var orderFromDb = await _orderRepository.GetByIdAsync(request.Id);

            if (orderFromDb == null)
            {
                _logger.LogError("Order does not exists.");
                throw new NotFoundException(nameof(Order), request.Id);
            }

            await _orderRepository.DeleteAsync(orderFromDb);

            _logger.LogInformation("Order deleted successfully.");

            return Unit.Value;
        }
    }
}
