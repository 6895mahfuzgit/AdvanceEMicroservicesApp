using AutoMapper;
using EventBusMessages.Events;
using OrderingApplication.Features.Orders.Commands.CheckoutOrder;

namespace OrderingAPIApp.Mapping
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<CheckoutOrderCommand, BasketCheckoutEvent>()
                     .ReverseMap();
        }
    }
}
