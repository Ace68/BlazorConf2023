using BeerDrivenFrontend.Shared.Enums;

namespace BeerDrivenFrontend.Shared.Messages;

public record ToolbarElementClicked(ToolbarElement ToolbarElement, ModuleNames ModuleName);