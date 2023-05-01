using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace BeerDrivenFrontend.Tests.StepDefinitions;

[Binding]
public class StartAppStepDefinition : IDisposable
{
	private IWebDriver Driver { get; set; }
	private const string Url = "https://beerblazor.azurewebsites.net/";

	public StartAppStepDefinition()
	{
		var chromeOptions = new ChromeOptions();
		chromeOptions.AddArguments("headless");
		//Driver = new ChromeDriver(Environment.CurrentDirectory, chromeOptions);
		Driver = new ChromeDriver(Environment.CurrentDirectory);
		Driver.Navigate().GoToUrl(Url);
		Driver.Manage().Window.Maximize();
		Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
	}

	[Then(@"The navbar is loaded")]
	public void ThenTheNavbarIsLoaded()
	{
		var navMenu = Driver.FindElement(By.Id("navmenu"));
		Assert.True(navMenu != null);
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
		this.Dispose(true);
		GC.SuppressFinalize(this);
	}

	~StartAppStepDefinition()
	{
		Dispose(false);
	}
	#endregion
}