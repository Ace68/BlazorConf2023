using BeerDrivenFrontend.Modules.Pubs.Extensions.Abstracts;
using BeerDrivenFrontend.Modules.Pubs.Extensions.Dtos;
using BeerDrivenFrontend.Modules.Shared.Extensions.Abstracts;
using BeerDrivenFrontend.Modules.Shared.Extensions.Dtos;
using BeerDrivenFrontend.Shared.Enums;
using BeerDrivenFrontend.Shared.Messages;
using BlazorComponentBus;
using Microsoft.AspNetCore.Components;

namespace BeerDrivenFrontend.Modules.Pubs;

public class PubsBase : ComponentBase, IDisposable
{
	[Inject] private NavigationManager NavigationManager { get; set; } = default!;
	[Inject] private ComponentBus Bus { get; set; } = default!;
	[Inject] private IBeerService BeerService { get; set; } = default!;
	[Inject] private ICustomerService CustomerService { get; set; } = default!;
	[Inject] private IWarehouseService WarehouseService { get; set; } = default!;

	protected IEnumerable<BeerJson> Beers { get; set; } = Enumerable.Empty<BeerJson>();
	[Parameter] public IEnumerable<CustomerJson> Customers { get; set; } = Enumerable.Empty<CustomerJson>();
	[Parameter] public IEnumerable<WarehouseJson> Warehouses { get; set; } = Enumerable.Empty<WarehouseJson>();

	protected SalesOrderJson SalesOrder { get; set; } = new();

	protected string Message { get; set; } = string.Empty;

	protected bool HideGrid { get; set; }
	protected bool HideDetails { get; set; } = true;

	protected bool IsLoading { get; set; } = true;

	protected override async Task OnInitializedAsync()
	{
		Bus.Subscribe<ToolbarElementClicked>(ToolbarEventHandler);

		await LoadBeersAsync();
		await LoadCustomersAsync();
		await LoadWarehousesAsync();

		await base.OnInitializedAsync();
	}

	private async Task LoadBeersAsync()
	{
		IsLoading = true;
		Beers = await BeerService.GetBeersAsync();
		IsLoading = false;

		StateHasChanged();
	}

	private async Task LoadCustomersAsync()
	{
		Customers = await CustomerService.GetCustomersAsync();
	}

	private async Task LoadWarehousesAsync()
	{
		Warehouses = await WarehouseService.GetWarehousesAsync();
	}

	private async void ToolbarEventHandler(MessageArgs args)
	{
		var @event = args.GetMessage<ToolbarElementClicked>();

		if (!@event.ModuleName.Equals(ModuleNames.Pubs))
			return;

		if (@event.ToolbarElement.Equals(ToolbarElement.Add))
		{
			SalesOrder = new SalesOrderJson
			{
				OrderId = Guid.NewGuid().ToString(),
				OrderNumber = $"{DateTime.UtcNow.Year:0000}{DateTime.UtcNow.Month:00}{DateTime.UtcNow.Day:00}-01",
				OrderDate = DateTime.UtcNow,
				TotalAmount = 0
			};

			HideGrid = true;
			HideDetails = false;
		}

		if (@event.ToolbarElement.Equals(ToolbarElement.Edit))
		{
			if (string.IsNullOrEmpty(SalesOrder.OrderId) || SalesOrder.OrderId.Equals(Guid.Empty.ToString()))
				return;

			HideGrid = true;
			HideDetails = false;
		}

		if (@event.ToolbarElement.Equals(ToolbarElement.Back))
		{
			HideGrid = false;
			HideDetails = true;
		}

		if (@event.ToolbarElement.Equals(ToolbarElement.Close))
			NavigationManager.NavigateTo("/");

		StateHasChanged();
	}

	#region Dispose
	public void Dispose(bool disposing)
	{
		if (disposing)
		{
		}
	}
	public void Dispose()
	{
		this.Dispose(true);
		GC.SuppressFinalize(this);
	}

	~PubsBase()
	{
		Dispose(false);
	}
	#endregion
}