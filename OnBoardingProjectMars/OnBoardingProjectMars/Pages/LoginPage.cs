using OnBoardingProjectMars.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoardingProjectMars.Pages
{
    public class LoginPage : CommonDriver
    {
        //Find Elements    
        private IWebElement signInButton => driver.FindElement(By.XPath("//*[@id=\"home\"]/div/div/div[1]/div/a"));
        private IWebElement usernameTextbox => driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[1]/input"));
        private IWebElement passwordTextbox => driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[2]/input"));
        private IWebElement loginButton => driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[4]/button"));

        public void loginActions()
        {
            //Launch portal
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://192.168.0.107:5000/");
            //Click on SignIn
            signInButton.Click();

            //Enter Username
            usernameTextbox.SendKeys("Chithra.Narayanan@gmail.com");

            //Enter password
            passwordTextbox.SendKeys("Test123");

            //Click Login Button
            loginButton.Click();
        }
    }
}
