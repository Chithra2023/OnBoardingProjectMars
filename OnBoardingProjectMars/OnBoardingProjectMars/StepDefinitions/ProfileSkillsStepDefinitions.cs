using OnBoardingProjectMars.Pages;
using OnBoardingProjectMars.Utilities;
using System;
using TechTalk.SpecFlow;

namespace OnBoardingProjectMars.StepDefinitions
{
    [Binding]
    public class ProfileSkillsStepDefinitions : CommonDriver
    {
        [Given(@"User navigate to the Skills tab")]
        public void GivenUserNavigateToTheSkillsTab()
        {
            ProfilePage profilePageObj = new ProfilePage();
            profilePageObj.GoToSkillsTab(driver);
        }

        [When(@"User add a new '([^']*)' and '([^']*)'")]
        public void WhenUserAddANewAnd(string Skill, string SkillLevel)
        {
            SkillsPage skillsPageObj = new SkillsPage();
            skillsPageObj.AddSkills(driver, Skill, SkillLevel);
        }

        [Then(@"The '([^']*)' and '([^']*)' should be added sucessfully to skills tab")]
        public void ThenTheAndShouldBeAddedSucessfullyToSkillsTab(string Skill, string SkillLevel)
        {
            SkillsPage skillsPageObj = new SkillsPage();
            skillsPageObj.GetAddedSkills(driver, Skill, SkillLevel);
        }


    }
}
