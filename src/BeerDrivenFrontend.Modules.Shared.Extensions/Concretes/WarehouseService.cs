using BeerDrivenFrontend.Modules.Shared.Extensions.Abstracts;
using BeerDrivenFrontend.Modules.Shared.Extensions.Dtos;

namespace BeerDrivenFrontend.Modules.Shared.Extensions.Concretes;

public sealed class WarehouseService : IWarehouseService
{
	public async Task<IEnumerable<WarehouseJson>> GetWarehousesAsync()
	{
		var warehouses = new List<WarehouseJson>
		{
			new()
			{
				WarehouseId = Guid.NewGuid().ToString(),
				WarehouseName = "BeerShop"
			}
		};

		return await Task.FromResult(warehouses);
	}
}