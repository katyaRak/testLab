using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFramework.Pages
{
    class Navigator : AbstractPage
    {
        private IWebDriver driver;
        [FindsBy(How = How.XPath, Using = "//input[@id='find_film']")]
        private IWebElement findFilmInput;

        [FindsBy(How = How.XPath, Using = "//input[@id='year']")]
        private IWebElement yearInput;

        [FindsBy(How = How.XPath, Using = "//input[@id='find_people']")]
        private IWebElement actoreNameInput;

        [FindsBy(How = How.XPath, Using = "//input[@id='birthday']")]
        private IWebElement dateOfBirthInput;

        [FindsBy(How = How.XPath, Using = "//form[@id='formSearchMain']/input[11]")]
        private IWebElement searchButton;

        [FindsBy(How = How.XPath, Using = "//div[@id='searchAdv']/form[3]/input[10]")]
        private IWebElement searchByBirthButton;

        
        public void DoExtendedSearchForFilm(string wordFromilm, string year)
        {
            findFilmInput.SendKeys(wordFromilm);
            yearInput.SendKeys(year);
            searchButton.Click();
        }
        public void DoExtendedSearchForActor(string name, string birth)
        {
            actoreNameInput.SendKeys(name); 
            dateOfBirthInput.SendKeys(birth);
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(4));
            var e = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='searchAdv']/form[3]/input[10]")));
            searchByBirthButton.Click();
        }

        public Navigator(IWebDriver driver) : base(driver) { }
       
    }
}
