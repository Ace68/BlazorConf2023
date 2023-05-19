using BeerDrivenFrontend.Modules.Pubs.Extensions.Dtos;
using BeerDrivenFrontend.Modules.Pubs.Extensions.Messages;
using BeerDrivenFrontend.Modules.Shared.Extensions.Dtos;
using BeerDrivenFrontend.Shared.Enums;
using BeerDrivenFrontend.Shared.Messages;
using BlazorComponentBus;
using Microsoft.AspNetCore.Components;

namespace BeerDrivenFrontend.Modules.Pubs.Components;

public class SalesOrderDetailsBase : ComponentBase, IAsyncDisposable
{
	[Parameter] public SalesOrderJson SalesOrder { get; set; } = new();
	[Parameter] public IEnumerable<BeerJson> Beers { get; set; } = Enumerable.Empty<BeerJson>();
	[Parameter] public IEnumerable<CustomerJson> Customers { get; set; } = Enumerable.Empty<CustomerJson>();
	[Parameter] public IEnumerable<WarehouseJson> Warehouses { get; set; } = Enumerable.Empty<WarehouseJson>();

	protected CustomerJson CurrentCustomer { get; set; } = new();
	protected WarehouseJson CurrentWarehouse { get; set; } = new();

	[Inject] private ComponentBus Bus { get; set; } = default!;

	protected override Task OnInitializedAsync()
	{
		Bus.Subscribe<ToolbarElementClicked>(ToolbarEventHandler);

		CurrentCustomer = Customers.Any()
			? Customers.First()
			: new CustomerJson();

		CurrentWarehouse = Warehouses.Any()
			? Warehouses.First()
			: new WarehouseJson();

		return base.OnInitializedAsync();
	}

	private void ToolbarEventHandler(MessageArgs args)
	{
		var @event = args.GetMessage<ToolbarElementClicked>();

		if (!@event.ModuleName.Equals(ModuleNames.Pubs))
			return;

		if (@event.ToolbarElement.Equals(ToolbarElement.ClearAll))
		{
			SalesOrder = new SalesOrderJson
			{
				OrderId = Guid.NewGuid().ToString(),
				OrderNumber = $"{DateTime.UtcNow.Year:0000}{DateTime.UtcNow.Month:00}{DateTime.UtcNow.Day:00}-01",
				OrderDate = DateTime.UtcNow,
				TotalAmount = 0
			};

			StateHasChanged();
			return;
		}

		if (!@event.ToolbarElement.Equals(ToolbarElement.Save))
			return;

		Bus.Publish(new SalesOrderDetailsSubmitted(SalesOrder));
	}

	#region Dispose
	public async ValueTask DisposeAsync()
	{
		await DisposeAsyncInternal();
		GC.SuppressFinalize(this);
	}

	protected virtual async ValueTask DisposeAsyncInternal()
	{
		// Async cleanup mock
		Bus.UnSubscribe<ToolbarElementClicked>(ToolbarEventHandler);
		await Task.Yield();
	}
	#endregion
}