using NUnit.Framework;
using OnBoardingProjectMars.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoardingProjectMars.Pages
{
    public class CertificationsPage : CommonDriver
    {
        //Find elements
        public IWebElement addNewCertificationButton => driver.FindElement(By.XPath(w_addNewCertificationButton));
        public IWebElement addCertificateTextBox => driver.FindElement(By.Name("certificationName"));
        public IWebElement addCertifiedFromTextBox => driver.FindElement(By.Name("certificationFrom"));
        public IWebElement addCertificationYearDropBox => driver.FindElement(By.Name("certificationYear"));
        public IWebElement addCertificateButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/div/div[3]/input[1]"));
        public IWebElement addedCertification => driver.FindElement(By.XPath(w_addedCertification));


        //Wait for Elements
        public string w_addNewCertificationButton = "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/thead/tr/th[4]/div";
        public string w_addedCertification = "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[last()]/tr/td[1]";
        public void AddCertifications(string Certificate, string From, String Year)
        {
            //Wait for 'Add New' certification button and click
            Wait.WaitForElementToBeClickable(driver, "XPath", w_addNewCertificationButton, 5);
            addNewCertificationButton.Click();

            //Enter Certification name
            addCertificateTextBox.SendKeys(Certificate);

            // Enter the certified From details
            addCertifiedFromTextBox.SendKeys(From);

            //Choose the year of Certification
            addCertificationYearDropBox.Click();
            SelectElement selectAddCertificationYear = new SelectElement(addCertificationYearDropBox);
            selectAddCertificationYear.SelectByText(Year);

            // Add the Certification Details by cliking Add Button
            addCertificateButton.Click();
        }
        public string GetAddedCertificate()
        {
            //Get Certification from last row
            Wait.WaitForElementToBeVisible(driver, "XPath", w_addedCertification, 5);
            return addedCertification.Text;
        }
    }
}
