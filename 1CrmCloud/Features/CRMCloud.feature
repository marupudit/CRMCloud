Feature:1CRMCloud

Automation tests for the portal https://demo.1CRMCloud.com/

Scenario: Creating a new contact
Given I log in to the 1CRMCould as a admin registered user
    And I navigated to "Contacts" under "Sales & Marketing"
When I enter new contact details
| Fields     | Values              |
| First Name | Sri                 |
| Last Name  | Burugupalli         |
| Role       | Sales               |
| Category   | Customers,Suppliers |
    And I save the contact details
Then I verify the contact details created

Scenario: Run Report
Given I log in to the 1CRMCould as a admin registered user
    And I navigated to "Reports" under "Reports & Settings"
When I find "Project Profitability" report
    And I run report
Then I verify that results were returned
| Table Header | Account Name, Project Name, Status, Start Date, Assigned User, Period, Expected Cost, Actual Cost |

Scenario: Remove events from Activity log
Given I log in to the 1CRMCould as a admin registered user
    And I navigated to "Activity Log" under "Reports & Settings"
When I select first 3 items in the table
    And I delete the logs
Then I verify logs are deleted
