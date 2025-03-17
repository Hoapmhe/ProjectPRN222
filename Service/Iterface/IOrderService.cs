﻿using ProjectPrn222.Models;

namespace ProjectPrn222.Service.Iterface
{
	public interface IOrderService
	{
		int AddOrder(Order order);
		void AddOrderDetails(IEnumerable<OrderDetail> orderDetails);

	}
}
