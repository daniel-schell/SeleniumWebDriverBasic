# BDD with SpecFlow and Selenium
Acceptance Test Driven Development Tutorial.
Tutorial to make a basic acceptance automated testing BDD architecture with SpecFlow Features and Selenium WebDriver  using Page Object / Page Factory Patterns.

Web Page: http://demo.guru99.com/V4/index.php
UserId: mngr32226
Password: hytydAp

** Note: User is valid only for 20 days, after that you need create a new User at http://demo.guru99.com/

Project Structure
---------------------------------------
- 1. PageObject Factory
	- PO.Factory
		- Resources
			+ String
	+ PO.Factory.Contracts
- 2. Acceptance Tests
	- AT.UserStory
		- Resources
			+ Features
			+ String
- 3. Cross Layer
	+ CL.Autofac
	+ CL.Entities
	+ CL.SetUpWebDriver

PageObject Factory Project
- Abstraction Layer that provides functionality tests page. Each class is a page and the methods are functionality.

Acceptance Tests
- Solution for acceptance tests, use the PageObject Factory Project.

Cross Layer
- Helpers.

# Selenium WebDriver 
- http://www.seleniumhq.org/projects/webdriver/
- WebDriver is a tool for automating web application testing, and in particular to verify that they work as expected. It aims to provide a friendly API that's easy to explore and understand, easier to use than the Selenium-RC (1.0) API, which will help to make your tests easier to read and maintain.

# Page Object / Page Factory Patterns  http://www.seleniumhq.org/docs/06_test_design_considerations.jsp#page-object-design-pattern
- Page Object is a Design Pattern which has become popular in test automation for enhancing test maintenance and reducing code duplication. A page object is an object-oriented class that serves as an interface to a page of your AUT. The tests then use the methods of this page object class whenever they need to interact with the UI of that page. The benefit is that if the UI changes for the page, the tests themselves don’t need to change, only the code within the page object needs to change. Subsequently all changes to support that new UI are located in one place.

# SpecFLow
 - http://www.specflow.org/
 - SpecFlow is a tool for writing tests in Gherkin that the business can understand.
 - Gherkin provides Give / When / Then Scenario
 
 # Autofac 
 - http://autofac.org/
 - Autofac is an open-source dependency injection (DI) or inversion of control (IoC) container developed on Google 

IDE: Visual Studio 2012
Created with C#, SpecFLow and Firefox WebDriver.

If you have any question please, contact me jsernajaen@gmail.com or https://www.linkedin.com/in/juansernajaen