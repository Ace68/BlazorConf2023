Feature: ClickAddOrderButton

A short summary of the feature

@ClickAddOrderButtonFromPubsPage
Scenario: [The user clicks on add-button from pubs page]
	Given The user is landed on pubs page and view pubs-grid and grid-toolbar
	When The user clicks on add-button
	Then The user is landed on sales-order page
