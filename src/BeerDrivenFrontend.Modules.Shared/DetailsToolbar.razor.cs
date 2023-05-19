using BeerDrivenFrontend.Shared.Enums;
using BeerDrivenFrontend.Shared.Messages;
using Microsoft.AspNetCore.Components;

namespace BeerDrivenFrontend.Modules.Shared;

public class DetailsToolbarBase : ComponentBase, IAsyncDisposable
{
	[Inject] private BlazorComponentBus.ComponentBus Bus { get; set; } = default!;
	[Parameter] public ModuleNames ModuleName { get; set; } = default!;

	protected Task OnToolbarClick(ToolbarElement toolbarElement)
	{
		return Bus.Publish(new ToolbarElementClicked(toolbarElement, ModuleName));
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
		await Task.Yield();
	}
	#endregion
}