using FluentAssertions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnBoardingProjectMars.Utilities;
using NUnit.Framework;

namespace OnBoardingProjectMars.Pages
{
    public class SkillsPage : CommonDriver
    {

        //Find Elements
        public IWebElement addNewSkillsButton => driver.FindElement(By.XPath(w_addNewSkillButton));
        public IWebElement addSkillsTextBox => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/div[1]/input"));
        public IWebElement addSkillLevelDropdown => driver.FindElement(By.Name("level"));
        public IWebElement addSkillButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/span/input[1]"));
        public IList<IWebElement> skillList => driver.FindElements(By.TagName("td"));

        // Wait for elements
        public string w_addNewSkillButton = "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/thead/tr/th[3]/div";

        public void AddSkills(string Skill, string SkillLevel)
        {
            // click the AddNew Skill button
            addNewSkillsButton.Click();

            // Enter the Skills name
            addSkillsTextBox.SendKeys(Skill);

            //Select the skill level from the dropdown
            addSkillLevelDropdown.Click();
            SelectElement selectAddSkillLevel = new SelectElement(addSkillLevelDropdown);
            selectAddSkillLevel.SelectByText(SkillLevel);

            //Click on Add skill to add the details
            addSkillButton.Click();
        }

        public bool GetAddedSkills(string Skill)
        {
            Wait.WaitForElementToBeVisible(driver, "TagName", "td", 5);

            //boolean value to verify if the skill is added
            bool skillAddedStatus = false;

            // Reading all the skill elements in the table
            for (int i = 0; i < skillList.Count; i++)
            {
                if (skillList[i].Text == Skill)
                {
                    //true if skill present
                    skillAddedStatus = true;
                    break;
                }
            }
            return skillAddedStatus;
        }
    }
}
