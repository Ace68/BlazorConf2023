using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace BeerDrivenFrontend.Tests.StepDefinitions;

[Binding]
public class NavbarItemsSuccessfulLoadedStepDefinitions
{
	private IWebDriver Driver { get; }
	private const string Url = "https://beerblazor.azurewebsites.net/";

	private IWebElement _navMenu { get; set; }
	private IWebElement _navMenuProductionItem { get; set; }
	private IWebElement _navMenuPubsItem { get; set; }

	public NavbarItemsSuccessfulLoadedStepDefinitions()
	{
		var chromeOptions = new ChromeOptions();
		chromeOptions.AddArguments("headless");
		Driver = new ChromeDriver(Environment.CurrentDirectory, chromeOptions);
	}

	[Given(@"The user navigated to the home page")]
	public void GivenTheUserNavigatedToTheHomePage()
	{
		Driver.Navigate().GoToUrl(Url);
		Driver.Manage().Window.Maximize();
		Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
	}

	[When(@"The user landed on the home page")]
	public void WhenTheUserLandedOnTheHomePage()
	{
		_navMenu = Driver.FindElement(By.Id("navmenu"));
		_navMenuProductionItem = _navMenu.FindElement(By.LinkText("Production"));
		_navMenuPubsItem = _navMenu.FindElement(By.LinkText("Pubs"));
	}

	[Then(@"The navbar elements should be loaded successfully")]
	public void ThenTheNavbarElementsShouldBeLoadedSuccessfully()
	{
		Assert.True(_navMenuProductionItem != null);
		Assert.True(_navMenuPubsItem != null);
	}

	[AfterScenario]
	public void AfterScenario()
	{
		Driver.Quit();
	}
}