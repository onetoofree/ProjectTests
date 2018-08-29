Feature: FeatureFileOne
Some basic test

@SmokeTest
@Browser:Chrome
Scenario:  Some Google search
Given I have navigated to the Historic Photo Portal homepage
	And I login using the following credentials
	| Username | Password |
	| bob      | bob      |
	When I click login
	Then the welcome message 'Welcome' and username 'bob' are displayed