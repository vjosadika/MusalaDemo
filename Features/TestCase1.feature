Feature: TestCase1

Background: 
	Given I open Musala webpage

Scenario: TestCase1
	Given I click Contact Us
	And I fill the required information
	And I fill an invalid email address as "<email>"
	When I click send button
	Then I should get an error message 'The e-mail address entered is invalid.'
	

	Examples:
		| email |
		| 1     |
		| 2     |
		| 3     |
		| 4     |
		| 5     |	