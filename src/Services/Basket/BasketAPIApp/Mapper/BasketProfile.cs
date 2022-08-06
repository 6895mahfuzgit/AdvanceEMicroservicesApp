using AutoMapper;
using BasketAPIApp.Entities;
using EventBusMessages.Events;

namespace BasketAPIApp.Mapper
{
    public class BasketProfile : Profile
    {
        public BasketProfile()
        {
            CreateMap<BasketCheckout, BasketCheckoutEvent>()
                .ReverseMap();
        }
    }
}
