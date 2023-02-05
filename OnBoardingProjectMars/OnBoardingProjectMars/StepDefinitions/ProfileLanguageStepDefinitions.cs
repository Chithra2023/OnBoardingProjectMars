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
        LoginPage loginPageObj;
        ProfilePage profilePageObj;
        LanguagePage languagePageObj;
        public ProfileLanguageStepDefinitions()
        {
            driver = new ChromeDriver();
            loginPageObj = new LoginPage();
            profilePageObj = new ProfilePage();
            languagePageObj = new LanguagePage();
        }
        [Given(@"User logged into Skillswap portal sucessfully")]
        public void GivenUserLoggedIntoSkillswapPortalSucessfully()
        {
            loginPageObj.loginActions();
        }

        [Given(@"User navigated to the Languages tab")]
        public void GivenUserNavigatedToTheLanguagesTab()
        {
             profilePageObj.GoToLanguageTab();
        }

        [When(@"User adds a new '([^']*)' and '([^']*)'")]
        public void WhenUserAddsANewAnd(string Language, string Level)
        {
            languagePageObj.AddLanguage(Language, Level);
        }

        [Then(@"The '([^']*)' and '([^']*)' should be added sucessfully")]
        public void ThenTheAndShouldBeAddedSucessfully(string Language, string Level)
        {
            string newAddedLanguage = languagePageObj.GetAddedLanguage();
            Assert.That(newAddedLanguage == Language, "New Language could not be added sucessfully");
            driver.Quit();
        }

        [When(@"User update the '([^']*)' and '([^']*)'")]
        public void WhenUserUpdateTheAnd(string Language, string Level)
        {
             languagePageObj.EditLanguage(Language, Level);
        }

        [Then(@"The '([^']*)' and '([^']*)' should be updated sucessfully")]
        public void ThenTheAndShouldBeUpdatedSucessfully(string Language, string Level)
        {
            string editedLanguage = languagePageObj.GetEditedLanguage(Language);
            Assert.That(editedLanguage == Language, "The language is not updated");
            driver.Quit();
        }
        [When(@"User deletes the '([^']*)'")]
        public void WhenUserDeletesThe(string Language)
        {
             languagePageObj.DeleteLanguage();
        }

        [Then(@"The '([^']*)' should be deleted from the profile page")]
        public void ThenTheShouldBeDeletedFromTheProfilePage(string Language)
        {
            bool isDeleted = languagePageObj.GetDeletedLanguage(Language);
            Assert.True(isDeleted);
            driver.Quit();
        }
    }
}
