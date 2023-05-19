using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace BeerDrivenFrontend.Modules.Pubs.Tests.StepDefinitions;

[Binding]
public class ClickAddOrderButtonStepDefinitions
{
	private IWebDriver Driver { get; set; }
	private const string Url = "https://beerblazor.azurewebsites.net/";

	private IWebElement _pubsGrid;
	private IWebElement _gridToolbar;
	private IWebElement _addButton;
	private IWebElement _salesOrderGrid;

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

	[Given(@"The user is landed on pubs page and view pubs-grid and grid-toolbar")]
	public void GivenTheUserIsLandedOnPubsPageAndViewPubs_GridAndGrid_Toolbar()
	{
		Driver.Navigate().GoToUrl($"{Url}pubs");
		Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

		_gridToolbar = Driver.FindElement(By.Id("grid-toolbar"));
		_pubsGrid = Driver.FindElement(By.Id("pubs-grid"));
		_addButton = Driver.FindElement(By.Id("add-button"));
	}

	[When(@"The user clicks on add-button")]
	public void WhenTheUserClicksOnAdd_Button()
	{
		_addButton.SendKeys("Add New Element");
	}

	[Then(@"The user is landed on sales-order page")]
	public void ThenTheUserIsLandedOnSales_OrderPage()
	{
		_salesOrderGrid = Driver.FindElement(By.Id("salesorder-grid"));
		Assert.True(_salesOrderGrid != null);
	}

	[AfterScenario]
	public void AfterScenario()
	{
		Driver.Quit();
	}
}