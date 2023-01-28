using OnBoardingProjectMars.Pages;
using OnBoardingProjectMars.Utilities;
using System;
using TechTalk.SpecFlow;

namespace OnBoardingProjectMars.StepDefinitions
{
    [Binding]
    public class ProfileCertificationsStepDefinitions : CommonDriver
    {
        [Given(@"User navigated to the Certifications tab")]
        public void GivenUserNavigatedToTheCertificationsTab()
        {
            ProfilePage profilePageObj = new ProfilePage();
            profilePageObj.GoToCertificationsTab(driver);
        }

        [When(@"User adds the '([^']*)', '([^']*)' and '([^']*)' with valid details")]
        public void WhenUserAddsTheAndWithValidDetails(string Certificate, string From, string Year)
        {
            CertificationsPage certificationPageObj = new CertificationsPage();
            certificationPageObj.AddCertifications(driver, Certificate, From, Year);

        }

        [Then(@"The '([^']*)' should be added to profile page")]
        public void ThenTheShouldBeAddedToProfilePage(string Certificate)
        {
            CertificationsPage certificationPageObj = new CertificationsPage();
            certificationPageObj.GetAddedCertificate(driver, Certificate);
        }

    }
}
