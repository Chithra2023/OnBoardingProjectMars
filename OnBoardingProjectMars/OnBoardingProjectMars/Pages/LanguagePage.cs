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
        // Find Elements
        private IWebElement addNewLanguageButton => driver.FindElement(By.XPath(w_addNewLanguageButton));
        private IWebElement addLanguageTextBox => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[1]/input"));
        private IWebElement languageLevelDropdown => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[2]/select"));
        private IWebElement addLanguageButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[3]/input[1]"));
        private IWebElement addedLanguage => driver.FindElement(By.XPath(w_addedLanguage));
        private IWebElement addedLanguageLevel => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[2]"));
        private IWebElement editLanguageButton => driver.FindElement(By.XPath(w_editLanguageButton));
        private IWebElement editLanguageTextBox => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td/div/div[1]/input"));
        private IWebElement editLevelDropdown => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td/div/div[2]/select"));
        private IWebElement updateButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td/div/span/input[1]"));
        private IWebElement editedLanguage => driver.FindElement(By.XPath(w_editedLanguage));
        private IWebElement deleteButton => driver.FindElement(By.XPath("//td[text()='German']//parent::tr//following-sibling::span[@class='button']//i[@class='remove icon']"));

        private bool isDeleted;
        private IList<IWebElement> languagesList => driver.FindElements(By.TagName("td"));

        //Wait for elements
        private string w_addNewLanguageButton = "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div";
        private string w_addedLanguage = "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[1]";
        private string w_editLanguageButton = "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[3]/span[1]/i";
        private string w_editedLanguage = "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td[1]";

        public void AddLanguage(String Language, string Level)
        {
            //Wait for 'Add New' language button and click
            Wait.WaitForElementToBeClickable(driver, "XPath", w_addNewLanguageButton, 5);
            addNewLanguageButton.Click();

            //Enter language name
            addLanguageTextBox.SendKeys(Language);

            //Choose the language level form dropdown 
            languageLevelDropdown.Click();
            SelectElement selectAddLanguageLevel = new SelectElement(languageLevelDropdown);
            selectAddLanguageLevel.SelectByText(Level);

            // click Add Language button 
            addLanguageButton.Click();
        }
        public string GetAddedLanguage()
        {
            //Get language of last row
            Wait.WaitForElementToBeVisible(driver, "XPath", w_addedLanguage, 5);
            return addedLanguage.Text;
        }
        public void EditLanguage(string Language, string Level)
        {
            //Click on Edit Language icon in first row                
            Wait.WaitForElementToBeClickable(driver, "XPath", w_editLanguageButton, 5);
            editLanguageButton.Click();

            // Edit the language name
            editLanguageTextBox.Clear();
            editLanguageTextBox.SendKeys(Language);

            // Change the lanagueg level
            editLevelDropdown.Click();
            SelectElement selectEditLanguageLevel = new SelectElement(editLevelDropdown);
            selectEditLanguageLevel.SelectByText(Level);

            // click on the update button
            updateButton.Click();
        }
        public string GetEditedLanguage(string Language)
        {
            //Get edited  language text of first row
            try
            {
                Wait.WaitForTextToBePresent(driver, "XPath", w_editedLanguage, 5, Language);
                //Thread.Sleep(1000);
                return editedLanguage.Text;
            }
            catch (Exception)
            {
                return "locator not found";
            }
        }


        public void DeleteLanguage()
        {
            deleteButton.Click();
        }

        public bool GetDeletedLanguage(string Language)
        {

            Wait.WaitForElementToBeVisible(driver, "TagName", "td", 5);
            isDeleted = false;
            for (int i = 0; i < languagesList.Count; i++)
            {
                if (languagesList[i].Text != Language)
                {
                    isDeleted = true;
                }
            }
            return isDeleted;
        }
    }
}
