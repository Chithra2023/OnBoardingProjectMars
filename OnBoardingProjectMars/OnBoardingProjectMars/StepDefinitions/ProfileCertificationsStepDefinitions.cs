using NUnit.Framework;
using OnBoardingProjectMars.Pages;
using OnBoardingProjectMars.Utilities;
using System;
using TechTalk.SpecFlow;

namespace OnBoardingProjectMars.StepDefinitions
{
    [Binding]
    public class ProfileCertificationsStepDefinitions : CommonDriver
    {
        ProfilePage profilePageObj;
        CertificationsPage certificationPageObj;
        public ProfileCertificationsStepDefinitions()
        {
            profilePageObj = new ProfilePage();
            certificationPageObj = new CertificationsPage();
        }

        [Given(@"User navigated to the Certifications tab")]
        public void GivenUserNavigatedToTheCertificationsTab()
        {
            profilePageObj.GoToCertificationsTab();
        }

        [When(@"User adds the '([^']*)', '([^']*)' and '([^']*)' with valid details")]
        public void WhenUserAddsTheAndWithValidDetails(string Certificate, string From, string Year)
        {
            certificationPageObj.AddCertifications(Certificate, From, Year);
        }

        [Then(@"The '([^']*)' should be added to profile page")]
        public void ThenTheShouldBeAddedToProfilePage(string Certificate)
        {
            string certificateAdded = certificationPageObj.GetAddedCertificate();
            Assert.That(certificateAdded == Certificate, "Certificate not added sucessfully");
            driver.Quit();
        }

    }
}
