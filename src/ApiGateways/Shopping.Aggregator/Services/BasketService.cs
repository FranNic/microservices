﻿using Shopping.Aggregator.Models;

namespace Shopping.Aggregator.Services
{
    public interface IBasketService
	{
		Task<BasketModel> GetBasket(string userName);
	}

	public class BasketService : IBasketService
	{
		private readonly HttpClient _client;

		public BasketService(HttpClient client)
		{
			_client = client ?? throw new ArgumentNullException(nameof(client));
		}

		public async Task<BasketModel> GetBasket(string userName)
		{
			var response = await _client.GetAsync($"/api/v1/Basket/{userName}");
			response.EnsureSuccessStatusCode();

			var basket = await response.Content.ReadFromJsonAsync<BasketModel>();

			return basket;
		}
	}
}
