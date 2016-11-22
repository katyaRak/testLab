using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TestFramework.Pages
{
    class MyKinopoisk
    {
        private IWebDriver driver;


        [FindsBy(How = How.XPath, Using = "//div[@id='content_block']//tr/td/div[1]/ul/li[4]/a")]
        private IWebElement films;

        [FindsBy(How = How.XPath, Using = "//a[@href='/film/722995/']")]
        private IWebElement filmName;

        public void ClickFilms()
        {
            films.Click();
        }
        public void OpenFilm()
        {
            filmName.Click();
        }



        public MyKinopoisk(IWebDriver driver)
        {
            // TODO: Complete member initialization
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }
    }
}
