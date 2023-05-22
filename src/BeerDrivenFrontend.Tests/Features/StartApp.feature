Feature: Startup Tests

A short summary of the feature

@StartupApplication
Scenario: App successfully started
	When User navigate to the home page
	Then The navbar is loaded
