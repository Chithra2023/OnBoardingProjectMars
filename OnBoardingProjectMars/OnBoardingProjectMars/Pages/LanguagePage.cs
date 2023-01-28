using OnBoardingProjectMars.Utilities;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using SeleniumExtras.WaitHelpers;
using System.Collections.ObjectModel;
using NUnit.Framework;
using NPOI.SS.Formula.Functions;

namespace OnBoardingProjectMars.Pages
{
    public class LanguagePage : CommonDriver
    {
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
        public void AddLanguage(IWebDriver driver, string Language, string Level)
        {
            //Identify and Click on 'Add New' language button using explicit wait to be clickable
            //Thread.Sleep(1000);
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div")));
            IWebElement addNewLanguageButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div"));
            addNewLanguageButton.Click();

            //Enter the language details - enter language name
            IWebElement addLanguageTextBox = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[1]/input"));
            addLanguageTextBox.SendKeys(Language);

            //Choose the language level form dropdown 
            IWebElement languageLevelDropdown = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[2]/select"));
            languageLevelDropdown.Click();

            SelectElement selectAddLanguageLevel = new SelectElement(languageLevelDropdown);
            selectAddLanguageLevel.SelectByText(Level);

            // Identify and click Add Language button to add the language
            // Thread.Sleep(1000);
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[3]/input[1]")));
            IWebElement addLanguageButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[3]/input[1]"));
            addLanguageButton.Click();
        }
        public void GetAddedLanguage(IWebDriver driver, string Language, string Level)
        {
            //reading all the records from the table
            wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.TagName("td")));
            ReadOnlyCollection<IWebElement> allElements = driver.FindElements(By.TagName("td"));

            //boolean value to verify if the language is added
            bool addedLanguageStatus = false;

            //Verifying if language is added to the table
            for (int i = 0; i < allElements.Count; i++)
            {
                if (allElements[i].Text == Language)
                {
                    addedLanguageStatus = true;
                    break;
                }
            }
            Assert.True(addedLanguageStatus, "Language not added");
            driver.Quit();
        }
        public void EditLanguage(IWebDriver driver, string Language, string Level)
        {
            //Identify the edit language button in first row                   
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[3]/span[1]/i")));
            IWebElement editLanguageButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[3]/span[1]/i"));
            editLanguageButton.Click();

            // Update the langaueg name - Clear the language and enter the new language
            IWebElement editLanguageTextBox = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td/div/div[1]/input"));
            editLanguageTextBox.Clear();
            editLanguageTextBox.SendKeys(Language);

            // Change the lanagueg level
            IWebElement editLevelDropdown = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td/div/div[2]/select"));
            editLevelDropdown.Click();
            SelectElement selectEditLanguageLevel = new SelectElement(editLevelDropdown);
            selectEditLanguageLevel.SelectByText(Level);

            // click on the update Language button
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td/div/span/input[1]")));
            IWebElement updateButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td/div/span/input[1]"));
            updateButton.Click();
        }
        public string GetEditedLanguage(IWebDriver driver)
        {
            //wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.TagName("td")));
            Thread.Sleep(1500);
            IWebElement editedLanguage = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[1]"));
            return editedLanguage.Text;
        }
        public string GetEditedLanguageLevel(IWebDriver driver)
        {
            //wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.TagName("td")));
            Thread.Sleep(1500);
            IWebElement editedLanguageLevel = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[2]"));
            return editedLanguageLevel.Text;
        }

        public void DeleteLanguage(IWebDriver driver, string Language)
        {
            IWebElement deleteButton = driver.FindElement(By.XPath("//td[text()='German']//parent::tr//following-sibling::span[@class='button']//i[@class='remove icon']"));
            deleteButton.Click();
        }

        public void GetDeletedLanguage(IWebDriver driver, string Language)
        {

            IWebElement deletedLanguae = driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table"));
            if (deletedLanguae.Text != Language)
            {
                Assert.Pass("Language Deleted Sucessfully");

            }
            else
            {
                Assert.Fail("Language not deleted");
            }

        }




    }
}
