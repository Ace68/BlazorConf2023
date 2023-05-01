Feature: CreateSalesOrder

A short summary of the feature

@CreateSalesOrder
Scenario: Create an Order for Sales
	Given Input order parameters
	When The Json is sent to Api
	Then The order is created
