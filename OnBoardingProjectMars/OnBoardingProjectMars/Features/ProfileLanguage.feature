Feature: ProfileLanguage

User is able to add maximum of four different languages in the profile page of SkillSwap Portal
User is able to edit and delete the languages added

Background: Logging in to Skill Swap portal
    Given  User logged into Skillswap portal sucessfully

Scenario Outline: 01 Add language to the Profile page
Given User navigated to the Languages tab
When User adds a new '<Language>' and '<Level>'
Then The '<Language>' and '<Level>' should be added sucessfully
Examples: 
| Language | Level          |
| French   | Fluent         |
| German   | Conversational |

Scenario Outline: 02 Edit Language with valid details
Given User navigated to the Languages tab
When User update the '<Language>' and '<Level>'
Then The '<Language>' and '<Level>' should be updated sucessfully
Examples: 
| Language   | Level            |
| English_US | Basic            |
| English_UK | Conversational   |
| Hindi      | Fluent           |
| Japaneese  | Native/Bilingual |

Scenario Outline: Delete a Language from profile
Given User navigated to the Languages tab
When User deletes the '<Language>'
Then The '<Language>' should be deleted from the profile page
Examples: 
| Language |
| German   |


#Scenario Outline: Add four languages with four different levels to profile
#Given User navigated to the Languages tab
#When User adds four different '<Language>' with different '<Level>'
#Then The four languages should be added sucessfully.
#And The add new button should not be visible
#Examples: 
#| Language   | Level            |
#| Language 1 | Basic            |
#| Language 2 | Converstaional   |
#| Language 3 | Fluent           |
#| Language 4 | Native/Bilingual |

#Scenario: Add New button displayed on deletion of one languge from the list of four
#Given User navigated to the Languages tab
#When User delete a language from the four languages
#Then The Add New button should be visible

#Scenario Outline: All fields are mandatory while adding language
#Given User navigated to the Languages tab
#When User adds '<Language>' and '<Level>' with insuffient details
#Then The language should not be added and display the '<Message>'
#Examples: 
#| Language | Level                 | Message                         |
#| English  | Choose Language Level | Please enter language and level |
#|          | Basic                 | Please enter language and level |
#|          | Choose Language Level | Please enter language and level |

#Scenario Outline: Duplicate language added
#Given User navigated to the Languages tab
#And User have  the language 'English' with level 'Basic' added in profile
#When User enter the details '<Language>' and <Level> with already existing language name
#Then The language should not be duplicated and display the '<Message>'
#Examples: 
#| Language | Level  | Message											   |
#| English  | Fluent | Duplicated data                                      |
#| English  | Basic  | This language is already exist in your language list |

#Scenario: Cancel without adding the language
#Given User navigated to the Languages tab
#When User Click on Add New Button and enter the language name and level
#And User click on the Cancel button
#Then The langauge should not be added to the profile

#Scenario Outline: All fields are mandatory while editing language
#Given User navigated to the Languages tab
#When User updates '<Language>' and '<Level>' with insuffient details
#Then The language should not be updated and display the '<Message>'
#Examples: 
#| Language | Level                 | Message                         |
#| English  | Choose Language Level | Please enter language and level |
#|          | Basic                 | Please enter language and level |
#|          | Choose Language Level | Please enter language and level |

#Scenario Outline:  Duplicate record through edit
#Given User navigated to the Languages tab
#And User have the following two languages added in profile. 'English' with level 'Basic' & 'French' with level 'Fluent'
#When User click on edit icon of the languge 'English'
#And User update the language name as 'French'
#Then User should see the message that duplicated record can not be created

