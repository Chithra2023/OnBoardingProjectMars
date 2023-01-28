Feature: ProfileCertifications

User is able to add certification details in the profile page of SkillSwap Portal
User is able to edit and delete the certifications added
Background: Logging in to Skill Swap portal
    Given  User logged into Skillswap portal sucessfully

Scenario Outline: Add certifications to the profile page
	Given User navigated to the Certifications tab
	When User adds the '<Certificate>', '<From>' and '<Year>' with valid details
	Then The '<Certificate>' should be added to profile page
Examples: 
| Certificate      | From              | Year |
| ISTQB_Foundation | TestingBoard      | 2017 |
| Selenium         | ProjectManagement | 2022 |

#Scenario Outline: All fields are mandatory while adding cerification
#Given User navigated to the Certifications tab
#When User add the  '<Certificate>' , '<From>' and '<Year>' without sufficient details
#Then The certificate should not be added and should display the '<Message>'
#Examples: 
#| Certificate   | From      | Year | Message                                                                |
#| Certificate 1 | Microsoft | Year | Please enter Certification name, Certifcation From, Certification Year |
#| Certificate 1 |           | 2017 | Please enter Certification name, Certifcation From, Certification Year |
#|               | Microsoft | 2000 | Please enter Certification name, Certifcation From, Certification Year |

#Scenario Outline: Duplicate Certification while adding
#Given User navigated to the Certifications tab
#When User add the '<Certificate>' , '<From>' and '<Year>' with existing name
#Then The certification should not be duplicated and display the '<Message>'
#Examples: 
#| Certificate   | From   | Year | Message                                            |
#| Certificate 1 | From 1 | 2016 | Certificate 1 has been added to your certification |
#| Certificate 1 | From 1 | 2017 | Duplicated Data                                    |
#| Certificate 1 | From 2 | 2018 | Certificate 1 has been added to your certification |
#| Certificate 2 | From 1 | 2018 | Certificate 2 has been added to your certification |

#Scenario: Cancel Certification details without adding
#Given User navigated to the Certifications tab
#When User clicks the Add New button and enter the certification details
#And User clicks the Cancel button
#Then The certification should not be added

#Scenario Outline: Edit Certification
#Given User navigated to the Certifications tab
#When User update the details '<Certificate>' , '<From>' and '<Year>'
#Then The certification details should be updated
#Examples:
#| Certificate   | From   | Year |
#| Certificate 8 | From 7 | 2015 |
#| Certificate 5 | From 6 | 2019 |


#Scenario Outline:  Duplicate Certification through edit
#Given User navigated to the Certifications tab
#And User have the following two certifications added in my profile. 'Certificate 8' from 'From 8' and 'Certificate 9' from 'From 9'
#When User click on edit icon of the certificate 'Certificate 9'
#And User update the details '<Certificate>' , '<From>' and '<Year>'
#Then The certification should not be duplicated and should display the '<Message>'
#Examples:
#| Certificate   | From   | Year | Message         |
#| Certificate 8 | From 8 | 2021 | Duplicated Data |

#Scenario: Delete Certificate from profile
#Given User navigated to the Certifications tab
#When User deletes the Certificate
#Then The Certificate should be deleted from the profile.
#
#
#
