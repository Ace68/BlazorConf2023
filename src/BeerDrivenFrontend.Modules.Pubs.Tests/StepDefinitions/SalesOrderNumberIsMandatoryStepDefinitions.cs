using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace BeerDrivenFrontend.Modules.Pubs.Tests.StepDefinitions;

[Binding]
public class SalesOrderNumberIsMandatoryStepDefinitions
{
	private IWebDriver Driver { get; set; }
	private const string Url = "https://beerblazor.azurewebsites.net/";

	private IWebElement _addButton;
	private IWebElement _saveButton;
	private IWebElement _alertMessage;

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

	[Given(@"User is on the sales order page")]
	public void GivenUserIsOnTheSalesOrderPage()
	{
		Driver.Navigate().GoToUrl($"{Url}pubs");
		Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

		_addButton = Driver.FindElement(By.Id("add-button"));
		_addButton.Click();

		_saveButton = Driver.FindElement(By.Id("save-button"));
	}

	[When(@"User tries to save the sales order")]
	public void WhenUserTriesToSaveTheSalesOrder()
	{
		_saveButton.Click();
		Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
	}

	[Then(@"User is shown an error message if the sales order number is missing")]
	public void ThenUserIsShownAnErrorMessageIfTheSalesOrderNumberIsMissing()
	{
		_alertMessage = Driver.FindElement(By.Id("alert-message"));

		Assert.Equal("Order Number is Mandatory!", _alertMessage.Text);
	}

	[AfterScenario]
	public void AfterScenario()
	{
		Driver.Quit();
	}
}