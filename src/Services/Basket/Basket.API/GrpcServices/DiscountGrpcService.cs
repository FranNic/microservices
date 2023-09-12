namespace Basket.API.GrpcServices
{
	using Discount.Grpc.Protos;

	public class DiscountGrpcService
	{
		 private readonly DiscountService.DiscountServiceClient _discountProtoService;

        public DiscountGrpcService(DiscountService.DiscountServiceClient discountProtoService)
        {
            _discountProtoService = discountProtoService ?? throw new ArgumentNullException(nameof(discountProtoService));
        }

        public async Task<CouponModel> GetDiscount(string productName)
        {
            var discountRequest = new GetDiscountRequest { ProductName = productName };
            return await _discountProtoService.GetDiscountAsync(discountRequest);
        }
	}
}
