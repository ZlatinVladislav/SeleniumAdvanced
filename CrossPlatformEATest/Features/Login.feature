Feature: Login to Advace
	
@positive
Scenario: Login to Advace positive flow
	Given i am on Advance login page.
	When i click login button
	And i write email
	|  email|
	|  hr.pp@amdaris.com|
	And i press next button on email page
	And i write password 
	|  password|
	|  Donetrom926|
	And i press next button on password page
	And i press next button on question page
	Then i can see header of application

	@positive
Scenario: Login to Advace positive flow2
	Given i am on Advance login page.
	When i click login button
	And i write email
	|  email|
	|  hr.pp@amdaris.com|
	And i press next button on email page
	And i write password 
	|  password|
	|  Donetrom926|
	And i press next button on password page
	And i press next button on question page
	Then i can see header of application
