using NUnit.Framework;
using OnBoardingProjectMars.Pages;
using OnBoardingProjectMars.Utilities;
using System;
using TechTalk.SpecFlow;

namespace OnBoardingProjectMars.StepDefinitions
{
    [Binding]
    public class ProfileSkillsStepDefinitions : CommonDriver
    {
        ProfilePage profilePageObj;
        SkillsPage skillsPageObj;
        public ProfileSkillsStepDefinitions()
        {
            profilePageObj = new ProfilePage();
            skillsPageObj = new SkillsPage();
        }

        [Given(@"User navigate to the Skills tab")]
        public void GivenUserNavigateToTheSkillsTab()
        {
            profilePageObj.GoToSkillsTab();
        }

        [When(@"User add a new '([^']*)' and '([^']*)'")]
        public void WhenUserAddANewAnd(string Skill, string SkillLevel)
        {
            skillsPageObj.AddSkills(Skill, SkillLevel);
        }

        [Then(@"The '([^']*)' and '([^']*)' should be added sucessfully to skills tab")]
        public void ThenTheAndShouldBeAddedSucessfullyToSkillsTab(string Skill, string SkillLevel)
        {
            bool skillAdded = skillsPageObj.GetAddedSkills(Skill);
            Assert.True(skillAdded);
            driver.Quit();
        }


    }
}
