using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace BeerDrivenFrontend.Modules.Pubs.Tests.StepDefinitions;

[Binding]
public class ClickBackToGridButtonStepDefinitions
{
	private IWebDriver Driver { get; set; }
	private const string Url = "https://beerblazor.azurewebsites.net/";

	private IWebElement _addButton;
	private IWebElement _backToListButton;
	private IWebElement _pubsGrid;

	[BeforeScenario]
	public void BeforeScenario()
	{
		var chromeOptions = new ChromeOptions();
		chromeOptions.AddArgument("--headless");
		Driver = new ChromeDriver(chromeOptions);
		Driver = new ChromeDriver(Environment.CurrentDirectory, chromeOptions);

		Driver.Navigate().GoToUrl(Url);
		Driver.Manage().Window.Maximize();
		Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
	}

	[Given(@"The user is landed on salesorder page and view salesorder-grid and details-toolbar")]
	public void GivenTheUserIsLandedOnSalesorderPageAndViewSalesorder_GridAndDetails_Toolbar()
	{
		Driver.Navigate().GoToUrl($"{Url}pubs");
		Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

		_addButton = Driver.FindElement(By.Id("add-button"));
		_addButton.SendKeys("Add New Element");

		_backToListButton = Driver.FindElement(By.Id("backToList-button"));
	}

	[When(@"The user clicks on backToList-button")]
	public void WhenTheUserClicksOnBackToList_Button()
	{
		_backToListButton.SendKeys("Back To List");
	}

	[Then(@"The user is landed on pubs page")]
	public void ThenTheUserIsLandedOnPubsPage()
	{
		_pubsGrid = Driver.FindElement(By.Id("pubs-grid"));
		Assert.True(_pubsGrid != null);
	}

	[AfterScenario]
	public void AfterScenario()
	{
		Driver.Quit();
	}
}