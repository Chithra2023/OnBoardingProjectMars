#Feature: ProfileDetails
#
#Seller updates the profiles details like  Name, Availiability, Hours & Target
#@ignore
#Scenario Outline: Edit the First Name and Last Name in profile page
#	Given I logged into Skillswap portal and in profile tab
#	When I update the '<First Name>' and '<Last Name>
#	Then I should see the first name and last name is updated successfully
#Examples: 
#| First Name       | Last Name       |
#| First Name_Test  | Last Name_Test  |
#| First Name_Test1 | Last Name_Test  |
#| First Name_Test1 | Last Name_Test1 |
#
#@ignore
#Scenario Outline: The first name and last name are mandatory fields in profile page
#	Given I logged into Skillswap portal and in profile tab
#	When I update the '<First Name>' and '<Last Name> with null
#	Then I should see that the first name and last name are mandatory fields and appropriate '<Message>' is displayed
#Examples: 
#| First Name      | Last Name      | Message                                   |
#|                 | Last Name_Test | The first name and last name are required |
#| First Name_Test |                | The first name and last name are required |
#|                 |                | The first name and last name are required |
#
#@ignore
#Scenario Outline: Edit the availability on profile page
#	Given I logged into Skillswap portal and in profile tab
#	When I update the '<Availability>'
#	Then I should see the availability is updated and the '<Message>' should be displayed
#Examples: 
#| Availability     | Message              |
#| Part Time        | Availability updated |
#| Full Time        | Availability updated |
#
#@ignore
#Scenario Outline: Edit the Hours on the profile page
#	Given I logged into Skillswap portal and in profile tab
#	When I update the '<Hours>'
#	Then I should see the Hours is be updated and displayed
#Examples: 
#| Hours                    |
#| Less than 30hours a week |
#| More than 30hours a week |
#| As needed                |
#
#@ignore
#Scenario Outline: Edit the S Earn Target on the profile page
#	Given I logged into Skillswap portal and in profile tab
#	When I update the '<$ Earn Target>'
#	Then I should see the $ Earn Target is  updated and displayed
#	Examples: 
#| $ Earn Target                    |
#| Less than $500 per month         |
#| Between $500 and $1000 per month |
#| More than $1000 per month        |
#
#
#@ignore
#Scenario Outline: Add description on the profile page
#	Given I logged into Skillswap portal and in profile tab
#	When I update the '<Description>'
#	Then I should see the '<Message>' and updated description
#	Examples: 
#| Description                                 | Message                                |
#| I am a good counsellor and I love to travel | Description has been saved sucessfully |
#|                                             | Please, a description is required      |
#
