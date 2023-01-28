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
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

        public void AddCertifications(IWebDriver driver, string Certificate, string From, String Year)
        {
            //Identify and Click on 'Add New' certification button using explicit wait to be clickable
            wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/thead/tr/th[4]/div")));
            IWebElement addNewCertificationButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/thead/tr/th[4]/div"));
            addNewCertificationButton.Click();

            //Enter the Certification details - enter Certification name
            IWebElement addCertificateTextBox = driver.FindElement(By.Name("certificationName"));
            addCertificateTextBox.SendKeys(Certificate);

            // Enter the certified From details
            IWebElement addCertifiedFromTextBox = driver.FindElement(By.Name("certificationFrom"));
            addCertifiedFromTextBox.SendKeys(From);

            //Choose the year of Certification
            IWebElement addCertificationYearDropBox = driver.FindElement(By.Name("certificationYear"));
            addCertificationYearDropBox.Click();
            SelectElement selectAddCertificationYear = new SelectElement(addCertificationYearDropBox);
            selectAddCertificationYear.SelectByText(Year);

            // Add the Certification Details by cliking Add Button
            wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/div/div[3]/input[1]")));
            IWebElement addCertificateButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/div/div[3]/input[1]"));
            addCertificateButton.Click();
        }

        public void GetAddedCertificate(IWebDriver driver, string Certificate)
        {
            // Reading all the skill elements in the table
            wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.TagName("td")));
            ReadOnlyCollection<IWebElement> certificateElements = driver.FindElements(By.TagName("td"));

            //boolean value to verify if the certificate is added
            bool certificateAddedStatus = false;

            //Verifying if Certificate is added to the table
            for (int i = 0; i < certificateElements.Count; i++)
            {
                if (certificateElements[i].Text == Certificate)
                {
                    certificateAddedStatus = true;
                    break;
                }
            }
            Assert.True(certificateAddedStatus, "Certificate not added");
            driver.Quit();
        }
    }
}
