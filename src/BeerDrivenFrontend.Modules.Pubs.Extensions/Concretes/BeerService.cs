using BeerDrivenFrontend.Modules.Pubs.Extensions.Abstracts;
using BeerDrivenFrontend.Modules.Pubs.Extensions.Dtos;
using BeerDrivenFrontend.Shared.Abstracts;
using BeerDrivenFrontend.Shared.Concretes;
using BeerDrivenFrontend.Shared.Configuration;
using Microsoft.Extensions.Logging;

namespace BeerDrivenFrontend.Modules.Pubs.Extensions.Concretes;

internal sealed class BeerService : BaseHttpService, IBeerService
{
	public BeerService(HttpClient httpClient,
		IHttpService httpService,
		AppConfiguration appConfiguration,
		ILoggerFactory loggerFactory) : base(httpClient, httpService, appConfiguration, loggerFactory)
	{
	}

	public async Task<IEnumerable<BeerJson>> GetBeersAsync()
	{
		try
		{
			var beers = new List<BeerJson>
			{
				new()
				{
					BeerId = Guid.NewGuid().ToString(),
					BeerName = "Muflone IPA",
					Quantity = 10
				},
				new()
				{
					BeerId = Guid.NewGuid().ToString(),
					BeerName = "Muflone Weiss",
					Quantity = 5
				},
				new()
				{
					BeerId = Guid.NewGuid().ToString(),
					BeerName = "Muflone RED",
					Quantity = 30
				}
			};

			return await Task.FromResult(beers);
		}
		catch (Exception ex)
		{
			Logger.LogError(CommonServices.GetDefaultErrorTrace(ex));
			throw;
		}
	}
}