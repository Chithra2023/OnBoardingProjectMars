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

        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
        public void AddSkills(IWebDriver driver, string Skill, string SkillLevel)
        {
            // Identify and click the AddNew Skill button
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/thead/tr/th[3]/div")));
            IWebElement addNewSkillsButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/thead/tr/th[3]/div"));
            addNewSkillsButton.Click();

           // Enter the Skills name
            IWebElement addSkillsTextBox = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/div[1]/input"));
            addSkillsTextBox.SendKeys(Skill);

            //Select the skill level from the dropdown
            IWebElement addSkillLevelDropdown = driver.FindElement(By.Name("level"));
            addSkillLevelDropdown.Click();
            SelectElement selectAddSkillLevel = new SelectElement(addSkillLevelDropdown);
            selectAddSkillLevel.SelectByText(SkillLevel);

            //Click on Add skill to add the details
            wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/span/input[1]")));
            IWebElement addSkillButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/span/input[1]"));
            addSkillButton.Click();

        }

        public void GetAddedSkills(IWebDriver driver, string Skill, string SkillLevel)
        {
            // Reading all the skill elements in the table
            wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.TagName("td")));
            IList<IWebElement> skillList = driver.FindElements(By.TagName("td"));
                   
            //boolean value to verify if the skill is added
            bool skillAddedStatus = false;
            for (int i = 0; i < skillList.Count; i++)
            {
                //Verifying if skill is added to the table

                if (skillList[i].Text == Skill)
                {
                    //true if skill present
                    skillAddedStatus = true;
                    break;
                }
            }

            Assert.That(skillAddedStatus, "Skill not added");
            driver.Quit();
        }
    }
}
