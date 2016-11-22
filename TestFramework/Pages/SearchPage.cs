using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFramework.Pages
{
    class SearchPage
    {
        private IWebDriver driver;

        [FindsBy(How = How.XPath, Using = "//a[text()='Том Хэнкс']")]
        private IWebElement actorName;
        [FindsBy(How = How.XPath, Using = "//a[text()='Дакота Фаннинг']")]
        private IWebElement actorNameForExtSerch;
        [FindsBy(How = How.XPath, Using = "//a[text()='Свет в океане']")]
        private IWebElement filmName; 

          public SearchPage(IWebDriver driver)                              //конструктор
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }
         public void openInfo()
          {
              actorName.Click();
          }
         public void openFilmInfo()
         {
             filmName.Click();
         }
         public string GetFilmName()
         {
             return filmName.Text;
         }
         public string GetactorNameForExtSerch()
         {
             return actorNameForExtSerch.Text;
         }
    }
}
