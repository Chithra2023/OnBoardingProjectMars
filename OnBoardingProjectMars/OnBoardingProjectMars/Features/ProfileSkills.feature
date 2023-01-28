Feature: ProfileSkills

User is able to add Skills with three different levels in the profile page of SkillSwap Portal
User is able to edit and delete the skills added

Background: Logging in to Skill Swap portal
    Given  User logged into Skillswap portal sucessfully

Scenario Outline: Add Skills with all three skill levels
Given User navigate to the Skills tab
When User add a new '<Skill>' and '<SkillLevel>'
Then The '<Skill>' and '<SkillLevel>' should be added sucessfully to skills tab
Examples: 
| Skill   | SkillLevel   |
| Skill 1 | Beginner     |
| Skill 2 | Intermediate |
| Skill 3 | Expert       |

#Scenario Outline: All fields are mandatory while adding skills
#Given User navigate to the Skills tab
#And User adds '<Skill>' and '<SkillLevel>' with out suffient details
#Then The skills should not be added and should display the '<Message>'
#Examples: 
#| Skill      | SkillLevel         | Message                                 |
#| Leadership | Choose Skill Level | Please enter skill and experience level |
#|            | Beginner           | Please enter skill and experience level |
#|            | Choose Skill Level | Please enter skill and experience level |

#Scenario Outline: Duplicate Skills added
#Given User navigate to the Skills tab
#And User have  the skill 'Automation' with level 'Beginner' added in profile
#When User enter the details '<Skill>' and '<SkillLevel>' with already existing skill name
#Then The skill should not be added and should display the '<Message>'
#Examples: 
#| Language    | Level    | Message                                         |
#| Automation  | Beginner | This skill is already exists in your skill list |
#| Automation  | Expert   | Duplicated data								   |

#Scenario: Cancel without adding the Skill
#Given User navigated to the Skills tab
#When User Click on Add New Button and enter the Skill name and level
#And User click on the Cancel button
#Then The Skill should not be added to the profile

#Scenario Outline: Edit the Skill with valid details
#Given User navigated to the Skills tab
#When User edit the '<Skill>' and 'SkillLevel>'
#Then The <Skill> and <SkillLevel> should be updated  and should display the '<Message>'
#Examples:
#| Language    | Level  | Message                                    |
#| Leadership  | Fluent | Leadership has been updated to your skills |
#| Softskill   | Expert | Softskill has been update to your skills   |

#Scenario Outline: All fields are mandatory while editing skills
#Given User navigate to the Skills tab
#And User edit '<Skill>' and '<SkillLevel>' with insuffient details
#Then The skills should not be updated and should display the '<Message>'
#Examples: 
#| Skill      | SkillLevel         | Message                                 |
#| Leadership | Choose Skill Level | Please enter skill and experience level |
#|            | Beginner           | Please enter skill and experience level |
#|            | Choose Skill Level | Please enter skill and experience level |

#Scenario Outline:  Duplicate Skill through edit
#Given User navigated to the Skills tab
#And User have the following two skills added in my profile. 'Skill1' with level 'Beginner' & 'Skill2' with level 'Expert'
#When User click on edit icon of the skill 'Skill2'
#And User update the skill name as 'Skill1'
#Then User should see the message that duplicated record can not be created

#Scenario: Delete Skill from profile
#Given User navigated to the Skills tab
#When User delete the Skill
#Then The Skill should be deleted from the profile.