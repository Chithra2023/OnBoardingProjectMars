using NUnit.Framework;
using OnBoardingProjectMars.Pages;
using OnBoardingProjectMars.Utilities;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace OnBoardingProjectMars.StepDefinitions
{
    [Binding]
    public class ProfileLanguageStepDefinitions : CommonDriver
    {
        [Given(@"User logged into Skillswap portal sucessfully")]
        public void GivenUserLoggedIntoSkillswapPortalSucessfully()
        {
            driver = new ChromeDriver();
            LoginPage loginPageObj = new LoginPage();
            loginPageObj.loginActions(driver);
        }

        [Given(@"User navigated to the Languages tab")]
        public void GivenUserNavigatedToTheLanguagesTab()
        {
            ProfilePage profilePageObj = new ProfilePage();
            profilePageObj.GoToLanguageTab(driver);
        }

        [When(@"User adds a new '([^']*)' and '([^']*)'")]
        public void WhenUserAddsANewAnd(string Language, string Level)
        {
            LanguagePage languagePageObj = new LanguagePage();
            languagePageObj.AddLanguage(driver, Language, Level);
        }


        [Then(@"The '([^']*)' and '([^']*)' should be added sucessfully")]
        public void ThenTheAndShouldBeAddedSucessfully(string Language, string Level)
        {
            LanguagePage languagePageObj = new LanguagePage();
            languagePageObj.GetAddedLanguage(driver, Language, Level);
         
        }

        [When(@"User update the '([^']*)' and '([^']*)'")]
        public void WhenUserUpdateTheAnd(string Language, string Level)
        {
            LanguagePage languagePageObj = new LanguagePage();
            languagePageObj.EditLanguage(driver, Language, Level);
        }

        [Then(@"The '([^']*)' and '([^']*)' should be updated sucessfully")]
        public void ThenTheAndShouldBeUpdatedSucessfully(string Language, string Level)
        {
            LanguagePage languagePageObj = new LanguagePage();
            string editedLanguage = languagePageObj.GetEditedLanguage(driver);
            Assert.That(editedLanguage == Language, "The language is not updated");
            driver.Quit();
        }
        [When(@"User deletes the '([^']*)'")]
        public void WhenUserDeletesThe(string Language)
        {
            LanguagePage languagePageObj = new LanguagePage();
            languagePageObj.DeleteLanguage(driver, Language);
        }

        [Then(@"The '([^']*)' should be deleted from the profile page")]
        public void ThenTheShouldBeDeletedFromTheProfilePage(string Language)
        {
            LanguagePage languagePageObj = new LanguagePage();
            languagePageObj.GetDeletedLanguage(driver, Language);
            driver.Quit();
        }



    }
}
