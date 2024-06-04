Feature: Register User


@mytag
Scenario: Register User
	Given I m on the home Page, Verify that home page is visible successfully with link 'https://automationexercise.com/'
	When Click on 'Signup / Login' button
	Then Verify 'New User Signup!' is visible
	When Enter name and email  address
	| name       | email        |
	| maciektest | mac123@op.pl |
	And Click 'Signup' button
	Then Verify 'Enter Account Information' is visible
	And Fill details: Title, Name, Email, Password, Date of birth
	| title | name       | email        | password | dateOfBirth |
	| Mr.   | maciektest | mac123@op.pl | pas123   | 11 1 1989   |
	And Select checkbox 'Sign up for our newsletter!'
	And Select checkbox 'Receive special offers from our partners!'
	And Fill details: First name, Last name, Company, Address, Address2, Country, State, City, Zipcode, Mobile Number
	When Click 'Create Account' button
	Then Verify 'Account Created!' is visible
	When Click 'Continue' button
	Then Verify 'Logged in as maciektest' is visible
	When Click 'Delete Account' button
	Then Verify 'Account Deleted!' is visible 
	When Click 'Continue' button

@mytag
Scenario: Register User - data from json file
	Given I m on the home Page, Verify that home page is visible successfully with link 'https://automationexercise.com/'
	When Click on 'Signup / Login' button
	Then Verify 'New User Signup!' is visible
	When Enter name and email  address
	| name       | email        |
	| maciektest | mac123@op.pl |
	And Click 'Signup' button
	Then Verify 'Enter Account Information' is visible
	And Fill details: Title, Name, Email, Password, Date of birth
	| title | name       | email        | password | dateOfBirth |
	| Mr.   | maciektest | mac123@op.pl | pas123   | 11 1 1989   |
	And Select checkbox 'Sign up for our newsletter!'
	And Select checkbox 'Receive special offers from our partners!'
	And Fill details
	When Click 'Create Account' button
	Then Verify 'Account Created!' is visible
	When Click 'Continue' button
	Then Verify 'Logged in as maciektest' is visible
	When Click 'Delete Account' button
	Then Verify 'Account Deleted!' is visible 
	When Click 'Continue' button