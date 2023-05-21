Feature: ClickBackToGridButton

A short summary of the feature

@ClickBackToGridOrderButtonFromSalesOrderPage
Scenario: The user clicks on back-button from salesorder page
	Given The user is landed on salesorder page and view salesorder-grid and details-toolbar
	When The user clicks on backToList-button
	Then The user is landed on pubs page
