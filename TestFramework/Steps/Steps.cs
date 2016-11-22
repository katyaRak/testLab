using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace TestFramework.Steps
{
    class Steps
    {
        IWebDriver driver;
        Pages.MainPage mainPage;
        Pages.InfoPage infoPage;
        Pages.SearchPage searchPage;
        Pages.MyKinopoisk myKinopoisk;
        Pages.Navigator navigator;
       

        public void InitBrowser()                         //открыть браузер
        {
            driver = Driver.DriverInstance.GetInstance();
        }

        public void CloseBrowser()                              //закрыть браузер
        {
            Driver.DriverInstance.CloseBrowser();
        }
        public void LogOut()
        {
            mainPage = new Pages.MainPage(driver);
            mainPage.LogOut();
        }
        public bool LogOutTest()
        {
            mainPage = new Pages.MainPage(driver);
            LogOut();
            return mainPage.GetEnterText().Contains("сайт");
        }
        public bool Enter(string login, string password)   //войти
        {
            mainPage = new Pages.MainPage(driver);
            mainPage.OpenPage();
            mainPage.Authorization(login, password);
            return mainPage.GetLogin().Contains(login);
        }

    

        public void Search(string name)
        {
            mainPage = new Pages.MainPage(driver);
            mainPage.Search(name);
            searchPage = new Pages.SearchPage(driver);
            searchPage.openInfo();
            
        }
       
        public void AddFavoriteActore()
        {
            infoPage = new Pages.InfoPage(driver);
           // infoPage.ClickHeart();
            infoPage.ClickList();
            infoPage.ClickfavButton();
           
        }
        public void AddFavoriteFil()
        {
            infoPage = new Pages.InfoPage(driver);
            infoPage.ClickHeart();
            

        }
        public void DelWhenListOpen()
        {
            infoPage = new Pages.InfoPage(driver);
            infoPage.ClickfavButton();
        }
        public void DelFavoriteActore()
        {
            infoPage = new Pages.InfoPage(driver);
            infoPage.ClickList();
            infoPage.ClickfavButton();
            
        }


        public bool SearchActor(string name)
        {
            infoPage = new Pages.InfoPage(driver);
            Search(name);
            AddFavoriteActore();
            Thread.Sleep(5000);
            infoPage = new Pages.InfoPage(driver);
            return infoPage.GetListName().Contains("звёзды");
        }
        public bool SearchActorDel(string name)
        {
            infoPage = new Pages.InfoPage(driver);
            Search(name);
            DelFavoriteActore();
            return infoPage.GetClass().Contains("fav");
        }
        public void SearchFavFilm(string name)
        {
            mainPage = new Pages.MainPage(driver);
            mainPage.Search(name);
            searchPage = new Pages.SearchPage(driver);
            searchPage.openFilmInfo();

        }
        public bool SearchFilmAndPushMark(string name)
        {
            infoPage = new Pages.InfoPage(driver);
            SearchFavFilm(name);
            infoPage.PushMark();
            return String.Equals(infoPage.GetMyMark(), "моя оценка");
        }
        public bool AddFavFilm(string name)
        {
            infoPage = new Pages.InfoPage(driver);
            SearchFavFilm(name);
            AddFavoriteFil();
            return infoPage.GetFilmListName().Contains("фильмы");
        }
        public void OpenFavFilm()
        {
            infoPage = new Pages.InfoPage(driver);
            mainPage = new Pages.MainPage(driver);
            mainPage.ClickbuttonMyKinopoisk();


        }
        public bool LookDirectorFilm(string name)
        {
            infoPage = new Pages.InfoPage(driver);
            mainPage = new Pages.MainPage(driver);
            myKinopoisk = new Pages.MyKinopoisk(driver);
            searchPage = new Pages.SearchPage(driver);
          //  mainPage.ClickbuttonMyKinopoisk();
          //  myKinopoisk.ClickFilms();
        //    myKinopoisk.OpenFilm();
            mainPage.Search(name);
            searchPage.openFilmInfo();
            infoPage.ClickDirector();

            return infoPage.GetAnotherFilmName().Contains("Валентинка");
        }
        public bool MarkWithoutAuthorization(string name)
        {
            infoPage = new Pages.InfoPage(driver);
            mainPage = new Pages.MainPage(driver);
            mainPage.OpenPage();
            SearchFavFilm(name);
            infoPage.PushMark();
            

            return infoPage.GetMessageText().Contains("голосования");
        }
   

        public bool SearchFilmByNavigate()
        {
            mainPage = new Pages.MainPage(driver);
            mainPage.ClickextendedSearch();
            navigator = new Pages.Navigator(driver);
            navigator.fillInputFindFilm();
            navigator.fillInputYear();
            navigator.ClickSearchBut();
            searchPage = new Pages.SearchPage(driver);
            return searchPage.GetFilmName().Contains("Свет");
        }
        public bool SearchActoreByBirth()
        {
            mainPage = new Pages.MainPage(driver);
            mainPage.ClickextendedSearch();
            navigator = new Pages.Navigator(driver);
            navigator.fillInputActoreName();
            navigator.fillInputDateOfBirth();
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(4));
            var e = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='searchAdv']/form[3]/input[10]")));
            navigator.ClicksearchByBirthBtn();
            searchPage = new Pages.SearchPage(driver);
            return searchPage.GetactorNameForExtSerch().Contains("Дакота");
        }
        public void AddNot()
        {
            infoPage = new Pages.InfoPage(driver);
            infoPage.ClickaddNotice();
            infoPage.FillFieldNotice();
            infoPage.ClickSaveNotice();
        }
        public void DelNotice()
        {
            infoPage = new Pages.InfoPage(driver);
            infoPage.ClickremoveNotice();
            driver.SwitchTo().Alert().Accept();
        }
        public bool AddNotice()
        {
            AddNot();
            Thread.Sleep(4000);
            infoPage = new Pages.InfoPage(driver);
            return infoPage.GetNoticeText().Contains("qwerty");
        }
        public bool DeleteNotice()
        {
            DelNotice();

            Thread.Sleep(4000);
            infoPage = new Pages.InfoPage(driver);
            return infoPage.GetNoticeText() == "";
        }
     
        public bool CheckSearchLine(string name)
        {
            mainPage = new Pages.MainPage(driver);
            mainPage.Search(name);
            searchPage = new Pages.SearchPage(driver);
            return searchPage.GetFilmName().Contains("Свет");
        }

        public bool CheckSortByName()
        {
            mainPage = new Pages.MainPage(driver);
            mainPage.OpenPage();
            Search("Том Хэнкс");
            infoPage = new Pages.InfoPage(driver);
            infoPage.ClickSortBtn();
            infoPage.ClickSortByNameBtn();
           // infoPage = new Pages.InfoPage(driver);
            Thread.Sleep(4000);
            return infoPage.GetTextlabeForChekSort().Contains("Ангелы");

        }
        public bool CheckSortByMark()
        {
            mainPage = new Pages.MainPage(driver);
            mainPage.OpenPage();
            Search("Том Хэнкс");
            infoPage = new Pages.InfoPage(driver);
            infoPage.ClickSortBtn();
            infoPage.ClickSortByMarkBtn();
            // infoPage = new Pages.InfoPage(driver);
            Thread.Sleep(4000);
            return infoPage.GetTextlabeForChekSort().Contains("Зеленая");

        }
    }
}
