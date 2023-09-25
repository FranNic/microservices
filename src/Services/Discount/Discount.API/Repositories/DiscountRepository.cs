namespace Discount.API.Repositories
{
	using Dapper;

	using Discount.API.Entities;

	using Npgsql;

	public class DiscountRepository : IDiscountRepository
	{
		private readonly IConfiguration configuration;

		public DiscountRepository(IConfiguration configuration)
		{
			this.configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
		}

		public async Task<bool> CreateDiscount(Coupon coupon)
		{
			using var dbConnection = new NpgsqlConnection(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));

			var affected = await dbConnection.ExecuteAsync(
								"INSERT INTO Coupon (ProductName, Description, Amount) VALUES (@ProductName, @Description, @Amount)",
												new { ProductName = coupon.ProductName, Description = coupon.Description, Amount = coupon.Amount });

			if (affected == 0)
			{
				return false;
			}

			return true;
		}

		public async Task<bool> DeleteDiscount(string productName)
		{
			using var dbConnection = new NpgsqlConnection(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));

			var affected = await dbConnection.ExecuteAsync("DELETE FROM Coupon WHERE ProductName = @ProductName", new { ProductName = productName });

			if (affected == 0)
			{
				return false;
			}

			return true;
		}

		public async Task<Coupon> GetDiscount(string productName)
		{
			using var dbConnection = new NpgsqlConnection(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));

			var coupon = await dbConnection.QueryFirstOrDefaultAsync<Coupon>("SELECT * FROM Coupon WHERE ProductName = @ProductName", new { ProductName = productName });

			if (coupon == null)
			{
				return new Coupon { ProductName = "No Discount", Amount = 0, Description = "No Discount Desc" };
			}

			return coupon;
		}

		public async Task<bool> UpdateDiscount(Coupon coupon)
		{
			using var dbConnection = new NpgsqlConnection(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));

			var affected = await dbConnection.ExecuteAsync(
												"UPDATE Coupon SET ProductName=@ProductName, Description=@Description, Amount=@Amount WHERE Id=@Id",
																								new { ProductName = coupon.ProductName, Description = coupon.Description, Amount = coupon.Amount, Id = coupon.Id });

			if (affected == 0)
			{
				return false;
			}

			return true;
		}
	}
}
