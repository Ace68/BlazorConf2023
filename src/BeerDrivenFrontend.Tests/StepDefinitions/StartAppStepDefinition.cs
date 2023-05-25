using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace BeerDrivenFrontend.Tests.StepDefinitions;

[Binding]
public class StartAppStepDefinition
{
	private IWebDriver Driver { get; }
	private const string Url = "https://beerblazor.azurewebsites.net/";

	public StartAppStepDefinition()
	{
		var chromeOptions = new ChromeOptions();
		chromeOptions.AddArguments("headless");
		Driver = new ChromeDriver(Environment.CurrentDirectory, chromeOptions);
	}

	[When(@"The user starts the application")]
	public void WhenTheUserStartsTheApplication()
	{
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

	[AfterScenario]
	public void AfterScenario()
	{
		Driver.Quit();
	}
}