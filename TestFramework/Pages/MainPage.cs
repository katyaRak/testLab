using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace TestFramework.Pages
{
    class MainPage: AbstractPage                                            
    {
        
        private const string BASE_URL = "http://kinopoisk.ru/";             //адрес
      //  private IWebDriver driver;

        [FindsBy(How = How.XPath, Using = "//a[text()='Войти на сайт']")]
        private IWebElement buttonEnter;                     //кнопка Вход

        [FindsBy(How = How.Id, Using = "li5top")]
        private IWebElement reiting;

        [FindsBy(How = How.XPath, Using = "//a[text()='поиск лучших']")]
        private IWebElement searchBest;  

        [FindsBy(How = How.XPath, Using = "//a[text()='Мой КиноПоиск']")]
        private IWebElement buttonMyKinopoisk;
        [FindsBy(How = How.XPath, Using = "//a[text()='расширенный поиск']")]
        private IWebElement extendedSearch; 

        
        [FindsBy(How = How.XPath, Using = "//a[text()='Профиль: testcase']")]
        private IWebElement labelLogin;

        [FindsBy(How = How.XPath, Using = "//a[text()='выйти']")]
        private IWebElement logOut;

        [FindsBy(How = How.Id, Using = "search_input")]
        private IWebElement searchInput;

        [FindsBy(How = How.ClassName, Using = "searchButton1")]
        private IWebElement searchButton;

        public MainPage(IWebDriver driver) : base(driver) { }
 /*       public MainPage(IWebDriver driver)                              //конструктор
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        } */

        public void ClickextendedSearch()
        {
            extendedSearch.Click();
        }

        public void OpenPage()                                       //открыть страницу
        {
            driver.Navigate().GoToUrl(BASE_URL);
        }
        public string GetLogin()                 //получить логин пользователя
        {
            return labelLogin.Text;
        }
        public string GetEnterText()
        {
            return buttonEnter.Text;
        }
         public void LogOut() //выйти из профиля
        {
            logOut.Click();
        }
        public void ClickbuttonMyKinopoisk()
         {
             buttonMyKinopoisk.Click();
         }
               
        public void Authorization(string login, string password)
        {
            buttonEnter.Click();
            driver.SwitchTo().Frame("kp2-authapi-iframe").FindElement(By.Name("login")).SendKeys(login);
            driver.FindElement(By.Name("password")).SendKeys(password);
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var e = wait.Until(ExpectedConditions.ElementToBeClickable(By.ClassName("auth__signin")));
            driver.FindElement(By.ClassName("auth__signin")).Click();
            driver.SwitchTo().DefaultContent();
        }

        public void Search( string name)
        {
            searchInput.SendKeys(name);
            searchButton.Click();
        }
       public void ClickLabelLogin()
        {
            labelLogin.Click();
        }
       public void ClickLabelReiting()
       {
           reiting.Click();
       }
       public void ClickLSearchBestInRaiting()
       {
          searchBest.Click();
       }
    }
}
