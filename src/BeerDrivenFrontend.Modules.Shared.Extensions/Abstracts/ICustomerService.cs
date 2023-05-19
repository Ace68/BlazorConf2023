using BeerDrivenFrontend.Modules.Shared.Extensions.Dtos;

namespace BeerDrivenFrontend.Modules.Shared.Extensions.Abstracts;

public interface ICustomerService
{
	Task<IEnumerable<CustomerJson>> GetCustomersAsync();
}