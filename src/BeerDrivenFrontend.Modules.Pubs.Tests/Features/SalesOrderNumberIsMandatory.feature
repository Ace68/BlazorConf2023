Feature: SalesOrderNumberIsMandatory

A short summary of the feature

@SalesOrderNumberIsMandatory
Scenario: User tries to save a sales order without a sales order number
	Given User is on the sales order page
	When User tries to save the sales order
	Then User is shown an error message if the sales order number is missing
