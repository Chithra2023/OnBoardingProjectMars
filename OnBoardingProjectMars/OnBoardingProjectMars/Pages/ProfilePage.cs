using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnBoardingProjectMars.Utilities;

namespace OnBoardingProjectMars.Pages
{
    public class ProfilePage : CommonDriver
    {
        //Find Elements
        public IWebElement languageTab => driver.FindElement(By.XPath(w_languageTab));
        public IWebElement skillsTab => driver.FindElement(By.XPath(w_skillsTab));
        public IWebElement certificationTab => driver.FindElement(By.XPath(w_certificationTab));

        //Wait for Elements
        public string w_languageTab = "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[1]";
        public string w_skillsTab = "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[2]";
        public string w_certificationTab = "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[4]";
        public void GoToLanguageTab()
        {
            //Wait for Language Tab and click 
            Wait.WaitForElementToBeClickable(driver, "XPath", w_languageTab, 5);
            languageTab.Click();
        }
        public void GoToSkillsTab()
        {
            //Wait for Skills Tab and  Click 
            Wait.WaitForElementToBeClickable(driver, "XPath", w_skillsTab, 5);
            skillsTab.Click();
        }
        public void GoToCertificationsTab()
        {
            //Wait for Certifications Tab and  Click 
            Wait.WaitForElementToBeClickable(driver, "XPath", w_certificationTab, 5);
            certificationTab.Click();
        }
    }
}
