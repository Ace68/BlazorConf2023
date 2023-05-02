using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace BeerDrivenFrontend.Tests.StepDefinitions;

[Binding]
public class NavbarElementsLoadedStepDefinition : IDisposable
{
	private IWebDriver Driver { get; }
	private const string Url = "https://beerblazor.azurewebsites.net/";

	public NavbarElementsLoadedStepDefinition()
	{
		var chromeOptions = new ChromeOptions();
		chromeOptions.AddArguments("headless");
		Driver = new ChromeDriver(Environment.CurrentDirectory, chromeOptions);
		Driver.Navigate().GoToUrl(Url);
		Driver.Manage().Window.Maximize();
		Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
	}

	[Then(@"The elements into navbar are successflully loaded")]
	public void ThenTheElementsIntoNavbarAreSuccessflullyLoaded()
	{
		var navMenu = Driver.FindElement(By.Id("navmenu"));
		var navMenuProductionItem = navMenu.FindElements(By.LinkText("Production"));
		var navMenuPubsItem = navMenu.FindElements(By.LinkText("Pubs"));

		Assert.True(navMenuProductionItem != null);
		Assert.True(navMenuPubsItem != null);
	}

	#region Dispose
	public void Dispose(bool disposing)
	{
		if (disposing)
		{
			Driver.Quit();
		}
	}
	public void Dispose()
	{
		Dispose(true);
		GC.SuppressFinalize(this);
	}

	~NavbarElementsLoadedStepDefinition()
	{
		Dispose(false);
	}
	#endregion
}