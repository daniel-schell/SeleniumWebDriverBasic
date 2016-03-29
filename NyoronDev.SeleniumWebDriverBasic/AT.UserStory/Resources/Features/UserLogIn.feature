Feature: Addition
	  In order to log in into the web page
	  As a user of the web page
	  I...

@usercanlogin
Scenario: User can log in
	Given I open web page
	When I put a "mngr32226" UserId
	And I put a "hytydAp" Password
	Then I can log in

@usercantlogin
Scenario: User cant log in
	Given I open web
	When I put a invalid "invalidUser" UserId
	And I put a invalid "invalidPassword" Password	
	Then I cant log

