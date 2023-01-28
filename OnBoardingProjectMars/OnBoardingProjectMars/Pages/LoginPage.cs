using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoardingProjectMars.Pages
{
    public class LoginPage
    {
        public void loginActions(IWebDriver driver)
        {
            //Open Chrome browser

            driver.Manage().Window.Maximize();

            // Launch the turnup portal
            Thread.Sleep(1000);
            driver.Navigate().GoToUrl("http://192.168.0.107:5000/");

            // Identify the Sign in button
            IWebElement signInButton = driver.FindElement(By.XPath("//*[@id=\"home\"]/div/div/div[1]/div/a"));
            signInButton.Click();

            //Identify username textbox and eneter valid username
            IWebElement usernameTextbox = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[1]/input"));
            usernameTextbox.SendKeys("Chithra.Narayanan@gmail.com");

            //Identify the password field and enter valid password
            IWebElement passwordTextbox = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[2]/input"));
            passwordTextbox.SendKeys("Test123");

            //Identify the Login Button and click
            IWebElement loginButton = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[4]/button"));
            loginButton.Click();
        }
    }
}
