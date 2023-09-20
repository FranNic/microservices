namespace Ordering.Application.Mappings
{
	using AutoMapper;

	using Ordering.Application.Features.Orders.Commands;
	using Ordering.Application.Features.Orders.Queries;
	using Ordering.Domain.Entities;

	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<Order, OrdersVm>().ReverseMap();
			CreateMap<Order, CheckoutOrderCommand>().ReverseMap();
			CreateMap<Order, UpdateOrderCommand>().ReverseMap();
		}
	}
}