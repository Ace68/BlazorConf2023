using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace BeerDrivenFrontend.Modules.Pubs.Tests.StepDefinitions;

[Binding]
public class ShowPubsGridStepDefinitions
{
	private IWebDriver Driver { get; set; }
	private const string Url = "https://beerblazor.azurewebsites.net/";

	private IWebElement _pubsGrid;

	[BeforeScenario]
	public void BeforeScenario()
	{
		var chromeOptions = new ChromeOptions();
		chromeOptions.AddArgument("--headless");
		Driver = new ChromeDriver(chromeOptions);
		Driver = new ChromeDriver(Environment.CurrentDirectory, chromeOptions);
	}

	[Given(@"The user is landed on home page")]
	public void GivenTheUserIsLandedOnHomePage()
	{
		Driver.Navigate().GoToUrl(Url);
		Driver.Manage().Window.Maximize();
		Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
	}

	[When(@"The user navigates to pubs page")]
	public void WhenTheUserNavigatesToPubsPage()
	{
		Driver.Navigate().GoToUrl($"{Url}pubs");
		Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
	}

	[Then(@"The pubsgrid is displayed")]
	public void ThenThePubsGridIsDisplayed()
	{
		_pubsGrid = Driver.FindElement(By.Id("pubsgrid"));
		Assert.True(_pubsGrid != null);
	}

	[AfterScenario]
	public void AfterScenario()
	{
		Driver.Quit();
	}
}