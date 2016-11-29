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
        private IWebElement loginButton;                     //кнопка Вход

        [FindsBy(How = How.Id, Using = "li5top")]
        private IWebElement reitingButton;


        [FindsBy(How = How.XPath, Using = "//a[text()='расширенный поиск']")]
        private IWebElement extendedSearchButton;


        [FindsBy(How = How.XPath, Using = "//div[@id='perechenlogin']/a[2]")]
        private IWebElement loginLabel;

        [FindsBy(How = How.XPath, Using = "//a[text()='выйти']")]
        private IWebElement logOutButton;

        [FindsBy(How = How.Id, Using = "search_input")]
        private IWebElement searchInput;

        [FindsBy(How = How.ClassName, Using = "searchButton1")]
        private IWebElement searchButton;

        public MainPage(IWebDriver driver) : base(driver) { }

        public void ClickExtendedSearchButton()
        {
            extendedSearchButton.Click();
        }

        public void OpenPage()                                       //открыть страницу
        {
            driver.Navigate().GoToUrl(BASE_URL);
        }
        public bool IsLoginLabelExist(string login)                 //получить логин пользователя
        {
            return loginLabel.Text.Contains(login);
        }
        public bool IsEnterButtonExists()
        {
            return loginButton.Text.Contains("Войти");
        }
         public void LogOut() //выйти из профиля
        {
            logOutButton.Click();
        }
      
               
        public void Authorization(string login, string password)
        {
            loginButton.Click();
            driver.SwitchTo().Frame("kp2-authapi-iframe").FindElement(By.Name("login")).SendKeys(login);
            driver.FindElement(By.Name("password")).SendKeys(password);
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var e = wait.Until(ExpectedConditions.ElementToBeClickable(By.ClassName("auth__signin")));
            driver.FindElement(By.ClassName("auth__signin")).Click();
            driver.SwitchTo().DefaultContent();
        }

        public void enterTextToSearch( string name)
        {
            searchInput.SendKeys(name);
            searchButton.Click();
        }
      
       public void ClickLabelReiting()
       {
           reitingButton.Click();
       }
      
    }
}
