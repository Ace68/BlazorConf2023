﻿namespace BeerDrivenFrontend.Modules.Pubs.Extensions.Dtos;

public class SalesOrderJson
{
	public string OrderId { get; set; } = string.Empty;
	public string OrderNumber { get; set; } = string.Empty;
	public DateTime OrderDate { get; set; } = DateTime.MinValue;

	public string CustomerId { get; set; } = string.Empty;
	public string CustomerName { get; set; } = string.Empty;

	public double TotalAmount { get; set; } = 0.0;
}