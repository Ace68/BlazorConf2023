using BeerDrivenFrontend.Modules.Shared.Extensions.Dtos;

namespace BeerDrivenFrontend.Modules.Shared.Extensions.Abstracts;

public interface IWarehouseService
{
	Task<IEnumerable<WarehouseJson>> GetWarehousesAsync();
}