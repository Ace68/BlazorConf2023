using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace BeerDrivenFrontend.Modules.Pubs.Tests.StepDefinitions;

[Binding]
public class CreateSalesOrderStepDefinitions
{
	private IWebDriver Driver { get; set; }
	private const string Url = "https://beerblazor.azurewebsites.net/";

	private IWebElement _pubsGrid;

	[Given(@"The user is on the sales order page")]
	public void GivenTheUserIsOnTheSalesOrderPage()
	{
		var chromeOptions = new ChromeOptions();
		chromeOptions.AddArguments("headless");
		Driver = new ChromeDriver(Environment.CurrentDirectory, chromeOptions);
		Driver.Navigate().GoToUrl(Url);
		Driver.Manage().Window.Maximize();
		Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

		Driver.Navigate().GoToUrl($"{Url}/pubs");
	}

	[When(@"The user enters the data")]
	public void WhenTheUserEntersTheData()
	{
		_pubsGrid = Driver.FindElement(By.Id("pubsgrid"));
	}

	[Then(@"The sales order is created")]
	public void ThenTheSalesOrderIsCreated()
	{
		Assert.True(_pubsGrid != null);
	}



	public void GivenInputOrderParameters()
	{
		var salesOrder = new
		{
			OrderId = Guid.NewGuid().ToString(),
			OrderNumber = $"{DateTime.UtcNow.Year:0000}{DateTime.UtcNow.Month:00}{DateTime.UtcNow.Day:00}-{DateTime.UtcNow.Hour:00}{DateTime.UtcNow.Minute:00}{DateTime.UtcNow.Second:00}",
			OrderDate = DateTime.UtcNow,
			CustomerId = Guid.NewGuid().ToString(),
			CustomerName = "John Doe",
			TotalAmount = 100.0
		};
	}
}