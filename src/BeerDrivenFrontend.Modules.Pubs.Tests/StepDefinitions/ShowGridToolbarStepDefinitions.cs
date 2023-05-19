using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace BeerDrivenFrontend.Modules.Pubs.Tests.StepDefinitions;

[Binding]
public class ShowGridToolbarStepDefinitions
{
	private IWebDriver Driver { get; set; }
	private const string Url = "https://beerblazor.azurewebsites.net/";

	private IWebElement _gridToolbar;

	[BeforeScenario]
	public void BeforeScenario()
	{
		var chromeOptions = new ChromeOptions();
		chromeOptions.AddArgument("--headless");
		Driver = new ChromeDriver(chromeOptions);
		Driver = new ChromeDriver(Environment.CurrentDirectory, chromeOptions);
	}

	[Given(@"The user is landed on pubs page")]
	public void GivenTheUserIsLandedOnPubsPage()
	{
		Driver.Navigate().GoToUrl(Url);
		Driver.Manage().Window.Maximize();
		Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
	}

	[When(@"The user load the pubs page")]
	public void WhenTheUserLoadThePubsPage()
	{
		Driver.Navigate().GoToUrl($"{Url}pubs");
		Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
	}

	[Then(@"The gridtoolbar is displayed")]
	public void ThenTheGridtoolbarIsDisplayed()
	{
		_gridToolbar = Driver.FindElement(By.Id("grid-toolbar"));
		Assert.True(_gridToolbar != null);
	}

	[AfterScenario]
	public void AfterScenario()
	{
		Driver.Quit();
	}
}