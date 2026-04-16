Feature: SmokeTesting

This feature has smoke scenarios to test login, registration, End-to-End and search functionality of the application.

Background:
	Given Launching the Application

@endtoend @smoke
Scenario: Successfully purchase a product
	Given user is on the homepage
	And user adds a product to the cart
	When user enters required checkout details
	And user clicks on proceed to checkout
	Then order should be placed successfully

@smoke
Scenario: Login with valid credentials
	Given user is on the homepage
	And user navigates to the login page
	When user enters valid username and password <username> <password>
	Then user should be logged in successfully
Examples:
	| username | password    |
	| 'Pawan'  | 'Pawan@123' |

@smoke
Scenario: User should be able to search and find relevant products.
	Given user is on the homepage
	When user enters keyword and category <keyword> <category>
	Then Results match search keyword
Examples:
	| keyword | category |
	| 'shirt' | '0,68'   |

@smoke
Scenario: Validate User is able to register successfully
	Given user is on the homepage
	When user fills the registration form with valid details
	Then user is able to register successfully