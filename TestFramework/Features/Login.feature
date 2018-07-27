Feature: Login
	Check if the login functionality is working
	as expected with diffrent permutaations and 
	combinations of data

Background: 
	#Given I Delete employee 'AutoUser' before I start running test

@Smoke @positive
Scenario: Check login with correct username and password
	Given I have navigated to the application
	And I see application opened
	When I enter userName and password and click login
	| UserName | Password |
	| devdeep | dev#NANCE33 |
	Then I should Navigated to Home page

