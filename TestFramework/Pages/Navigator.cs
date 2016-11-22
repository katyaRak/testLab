using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFramework.Pages
{
    class Navigator
    {
        private IWebDriver driver;
        [FindsBy(How = How.XPath, Using = "//input[@id='find_film']")]
        private IWebElement inputFindFilm;
        [FindsBy(How = How.XPath, Using = "//input[@id='year']")]
        private IWebElement inputYear;
        [FindsBy(How = How.XPath, Using = "//input[@id='find_people']")]
        private IWebElement inputActoreName;
        [FindsBy(How = How.XPath, Using = "//input[@id='birthday']")]
        private IWebElement inputDateOfBirth;
        [FindsBy(How = How.XPath, Using = "//form[@id='formSearchMain']/input[11]")]
        private IWebElement searchBut;
        [FindsBy(How = How.XPath, Using = "//div[@id='searchAdv']/form[3]/input[10]")]
        private IWebElement searchByBirthBtn;

        public void fillInputFindFilm()
        {
            inputFindFilm.SendKeys("свет");
        }
        public void fillInputYear()
        {
            inputYear.SendKeys("2016");
        }
        public void fillInputActoreName()
        {
            inputActoreName.SendKeys("Дакота");
        }
        public void fillInputDateOfBirth()
        {
            inputDateOfBirth.SendKeys("1994");
        }
        public void ClicksearchByBirthBtn()
        {
            searchByBirthBtn.Click();
        }


        public void ClickSearchBut()
        {
            searchBut.Click();
        }

        public Navigator(IWebDriver driver)
        {
            // TODO: Complete member initialization
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }
    }
}
