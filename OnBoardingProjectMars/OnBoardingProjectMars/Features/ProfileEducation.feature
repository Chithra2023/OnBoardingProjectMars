#Feature: ProfileEducation
#
#User is able to add education details in the profile page of SkillSwap Portal
#User is able to edit and delete the education added
#
#Background: Logging in to Skill Swap portal
#    Given  User logged into Skillswap portal sucessfully
#
#Scenario Outline: Add Education in profile page
#	Given User navigated to the Education tab
#	When User add education with valid details '<University>', '<Country>', '<Title>', '<Degree>' and '<Year of Graduation>'
#	Then The Education details should be added sucessfully
#Examples: 
#| University | Country   | Title  | Degree           | Year of Graducation |
#| Sydney     | Australia | B.Tech | Computer Science | 2017                |
#| Delhi      | India     | PHD    | Finance          | 2023                |
#
#Scenario Outline: All fields are mandatory while adding Education
#Given User navigated to the Education tab
#When User adds education withou sufficient details '<University>', '<Country>', '<Title>', '<Degree>' and '<Year of Graduation>'
#Then The education should not be added and should see the '<Message>'y
#Examples: 
#| University | Country                       | Title | Degree | Year of Graducation | Message                 |
#| London     | Country of College/University | PHD   | Law    | 2017                | Please enter all fields |
#| London     | United Kingdom                | Title | Law    | 2023                | Please enter all fields |
#| London     | United Kingdom                | PHD   |        | 2020                | Please enter all fields |
#| London     | United Kingdom                | PHD   | Law    | Year of Graducation | Please enter all fields |
#|            | United Kingdom                | PHD   | Law    | 2021                | Please enter all fields |
#
#Scenario Outline: Duplicated education added
#Given User navigated to the Education tab
#When User adds the same education details '<University>', '<Country>', '<Title>', '<Degree>' and '<Year of Graduation>'
#Then The education should not be duplicated and should display the '<Message>'
#Examples: 
#| University | Country | Title  | Degree           | Year of Graducation | Message                  |
#| Cochin     | India   | B.Tech | Computer Science | 2017                | Education has been added |
#| Cochin     | India   | B.Tech | Computer Science | 2020                | Duplicated date          |
#
#Scenario: Cancel without adding the education
#Given User navigated to the Education tab
#When User clicks the Add New button and enter the education details
#And User clicks the Cancel button
#Then The education should not be added
#
#Scenario Outline: Edit Education details
#Given User navigated to the Education tab
#When User edit the education details '<University>', '<Country>', '<Title>', '<Degree>' and '<Year of Graduation>'
#Then The education details should be updated.
#Examples: 
#| University  | Country   | Title  | Degree   | Year of Graducation |
#| University1 | Australia | B.Tech | Degree 1 | 2015                |
#| University1 | India     | PHD    | Degree 1 | 2018                |
#
#Scenario: Delete Education from profile
#Given User navigated to the Education tab
#When User delete the education
#Then The educations should be deleted from the profile
