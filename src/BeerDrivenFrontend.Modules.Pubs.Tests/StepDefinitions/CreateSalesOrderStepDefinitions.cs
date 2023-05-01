namespace BeerDrivenFrontend.Modules.Pubs.Tests.StepDefinitions;

[Binding]
public class CreateSalesOrderStepDefinitions
{
	[Given(@"Input order parameters")]
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

	[When(@"The Json is sent to Api")]
	public void WhenTheJsonIsSentToApi()
	{
		throw new PendingStepException();
	}

	[Then(@"The order is created")]
	public void ThenTheOrderIsCreated()
	{
		throw new PendingStepException();
	}

}