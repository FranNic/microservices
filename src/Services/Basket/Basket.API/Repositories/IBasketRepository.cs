﻿namespace Basket.API.Repositories
{
	using Basket.API.Entities;

	public interface IBasketRepository
	{
		Task<ShoppingCart> GetBasket(string userName);

		Task<ShoppingCart> UpdateBasket(ShoppingCart basket);

		Task DeleteBasket(string userName);
	}
}