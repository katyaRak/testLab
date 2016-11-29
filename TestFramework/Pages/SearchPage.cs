using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFramework.Pages
{
    class SearchPage : AbstractPage
    {
        private IWebDriver driver;

        [FindsBy(How = How.XPath, Using = "//td[@id='block_left_pad']/div/div[3]/div/div[2]/p/a")]
        private IWebElement referenceFoInfoPage;

        public SearchPage(IWebDriver driver) : base(driver) { }                              //конструктор
       
         public void OpenInfo()
          {
              referenceFoInfoPage.Click();
          }
      
         public string GetFilmName()
         {
             return referenceFoInfoPage.Text;
         }
         public string GetactorNameForExtSerch()
         {
             return referenceFoInfoPage.Text;
         }
    }
}
