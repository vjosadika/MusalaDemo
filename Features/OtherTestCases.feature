Feature: OtherTestCases

Background: 
	Given I open Musala webpage

Scenario: TestCase2 
	Given I click Company tab
	And I verify that the correct URL is loaded 'https://www.musala.com/company/'
	And I verify that there is a Leadership section
	When I click on facebook link from footer
	And I verify that the correct URL is loaded 'https://www.facebook.com/MusalaSoft?fref=ts'
	And I verify that the Musala facebook image appears

Scenario: TestCase3 
	Given I click Careers tab
	And I click Check our position button
	And I verify that the correct URL is loaded 'https://www.musala.com/careers/join-us/'
	And I filter 'Anywhere' location via dropdown
	And I open position 'Experienced Automation QA Engineer' by name
	And I verify that one of four main sectors is shown: 'General description'
	And I verify that one of four main sectors is shown: 'Requirements'
	And I verify that one of four main sectors is shown: 'Responsibilities'
	And I verify that one of four main sectors is shown: 'What we offer'
	And I verify that Apply button is present
	When I click Apply button
	And I insert invalid data, invalid email: 'test@test'
	And I click send button on the form
	Then I should get an error message after clicking send button 'One or more fields have an error. Please check and try again.'
	And I close popup message
	And I should get an error message 'The e-mail address entered is invalid.'
	And I should get an error message about missing fields 'The field is required.'

Scenario: TestCase4
	Given I click Careers tab
	And I click Check our position button
	And I filter 'Skopje' location via dropdown
	And I print the open positions by city
	#And I filter 'Sofia' location via dropdown
	#And I print the open positions by city