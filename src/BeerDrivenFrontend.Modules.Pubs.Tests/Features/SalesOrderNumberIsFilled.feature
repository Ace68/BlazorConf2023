Feature: SalesOrderNumberIsFilled

A short summary of the feature

@SalesOrderNumberIsFilled
Scenario: User saves a sales order with OrderNumber filled
	Given User navigate to SalesOrder page
	When User fills OrderNumber
	Then User click on save-button
