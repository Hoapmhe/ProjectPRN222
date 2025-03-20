﻿using Microsoft.EntityFrameworkCore;
using ProjectPrn222.Models;
using ProjectPrn222.Models.DTO;
using ProjectPrn222.Service.Iterface;

namespace ProjectPrn222.Service.Implement
{
	public class OrderService : IOrderService
	{
		private readonly AppDbContext _context;
		public OrderService(AppDbContext context)
		{
			_context = context;
		}
		public int AddOrder(Order order)
		{
			_context.Orders.Add(order);
			_context.SaveChanges();
			
			return order.OrderId;
		}

		public void AddOrderDetails(IEnumerable<OrderDetail> orderDetails)
		{
			_context.OrderDetails.AddRange(orderDetails);
			_context.SaveChanges();
		}

		public List<MonthlyRevenueModel> GetRevenueInMonth()
		{
            var sixMonthsAgo = DateTime.Now.AddMonths(-5); // Lấy dữ liệu từ 6 tháng gần nhất (bao gồm tháng hiện tại)

            return _context.Orders
                .Where(o => o.OrderDate >= sixMonthsAgo)
                .GroupBy(o => new { o.OrderDate.Year, o.OrderDate.Month }) // Nhóm theo năm + tháng
                .Select(g => new MonthlyRevenueModel
                {
                    Year = g.Key.Year,
                    Month = g.Key.Month,
                    Revenue = g.Sum(o => o.FinalTotal)
				})
                .AsEnumerable() // Chuyển sang xử lý trong C# (không phải SQL)
				.OrderBy(g => g.Year)
				.ThenBy(g => g.Month)
                .ToList();
        }
	}
}
