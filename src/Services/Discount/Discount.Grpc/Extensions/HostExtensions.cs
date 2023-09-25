namespace Discount.Grpc.Extensions
{
	using Npgsql;

	public static class HostExtensions
	{
		public static WebApplication MigrateDatabase(this WebApplication app)
		{
			using (var scope = app.Services.CreateScope())
			{
				var configuration = scope.ServiceProvider.GetRequiredService<IConfiguration>();
				using var dbConnection = new NpgsqlConnection(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
				dbConnection.Open();

				using var command = new NpgsqlCommand
				{
					Connection = dbConnection,
				};

				command.CommandText = @"DROP TABLE IF EXISTS Coupon";
				command.ExecuteNonQuery();

				// add command directly from file 
				command.CommandText = File.ReadAllText("Data/Coupon.sql");
				command.ExecuteNonQuery();
			}

			return app;
		}
	}
}
