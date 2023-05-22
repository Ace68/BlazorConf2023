using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace BeerDrivenFrontend.Modules.Pubs.Tests.StepDefinitions;

[Binding]
public class SalesOrderNumberIsFilledStepDefinitions
{
	private IWebDriver Driver { get; set; }
	private const string Url = "https://beerblazor.azurewebsites.net/";

	private IWebElement _addButton;
	private IWebElement _saveButton;
	private IWebElement _alertMessage;
	private IWebElement _orderNumber;

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

	[Given(@"User navigate to SalesOrder page")]
	public void GivenUserNavigateToSalesOrderPage()
	{
		Driver.Navigate().GoToUrl($"{Url}pubs");
		Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

		_addButton = Driver.FindElement(By.Id("add-button"));
		_addButton.Click();

		_saveButton = Driver.FindElement(By.Id("save-button"));
	}

	[When(@"User fills OrderNumber")]
	public void WhenUserFillsOrderNumber()
	{
		_orderNumber = Driver.FindElement(By.Id("order-number"));
		_orderNumber.SendKeys($"{DateTime.UtcNow.Year:0000}{DateTime.UtcNow.Month:00}{DateTime.UtcNow.Day:00}-01");
	}

	[Then(@"User click on save-button")]
	public void ThenUserClickOnSave_Button()
	{
		_saveButton.Click();
		Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

		_alertMessage = Driver.FindElement(By.Id("alert-message"));
		Assert.Equal(string.Empty, _alertMessage.Text);
	}

	[AfterScenario]
	public void AfterScenario()
	{
		Driver.Quit();
	}
}