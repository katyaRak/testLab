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
        public bool IsLogOut()
        {
            mainPage = new Pages.MainPage(driver);
            LogOut();
            return mainPage.IsEnterButtonExists();
        }
        public bool IsLogin(string login, string password)   //войти
        {
            mainPage = new Pages.MainPage(driver);
            mainPage.OpenPage();
            mainPage.Authorization(login, password);
            return mainPage.IsLoginLabelExist(login);
        }

    

        public void Search(string name)
        {
            mainPage = new Pages.MainPage(driver);
            mainPage.enterTextToSearch(name);
            searchPage = new Pages.SearchPage(driver);
            searchPage.OpenInfo();
            
        }

        public void AddActoreToFavorite()
        {
            infoPage = new Pages.InfoPage(driver);
            infoPage.ClickListButton();
            infoPage.ClickfavButton();
           
        }
        public void AddFilmToFavorite()
        {
            infoPage = new Pages.InfoPage(driver);
            infoPage.ClickAddFilmToFavoriteButton();
            Thread.Sleep(5000);

        }
        public void DeleteFromFavoritList()
        {
            infoPage = new Pages.InfoPage(driver);
            infoPage.ClickfavButton();
        }
        public void DeleteFavoriteActore()
        {
            infoPage = new Pages.InfoPage(driver);
            infoPage.ClickListButton();
            infoPage.ClickfavButton();
            
        }


        public bool IsAddActoreToFavorite(string name)
        {
            infoPage = new Pages.InfoPage(driver);
            Search(name);
            AddActoreToFavorite();
            infoPage = new Pages.InfoPage(driver);
            return infoPage.IsFavoriteStarsListExist();
        }
        public bool IsDeleteActorFromFavorite(string name)
        {
            infoPage = new Pages.InfoPage(driver);
            Search(name);
            DeleteFavoriteActore();
            return infoPage.IsExistClass();
        }
      
        public bool IsPushMark(string name)
        {
            infoPage = new Pages.InfoPage(driver);
            Search(name);
            infoPage.PushMark();
            return infoPage.IsMyMarkLableExist();
        }
        public bool IsAddFilmToFavorite(string name)
        {
            infoPage = new Pages.InfoPage(driver);
            Search(name);
            AddFilmToFavorite();
            return infoPage.IsFavoriteFilmsListExist();
        }
   
        public bool IsOpenDirectorInfoPageFromFilmPage(string name)
        {
            infoPage = new Pages.InfoPage(driver);
            Search(name);
            infoPage.ClickDirector();
            return infoPage.IsDirectorBestFilmsLabelExist();
        }
        public bool IsPutMarkWithoutAuthorization(string name)
        {
            
            mainPage = new Pages.MainPage(driver);
            mainPage.OpenPage();
            Search(name);
            infoPage = new Pages.InfoPage(driver);
            infoPage.PushMark();

            return infoPage.IsWarningMessageExist();
        }


        public bool IsSearchFilmByExtendedSearch(string wordFromilm, string year)
        {
            mainPage = new Pages.MainPage(driver);
            mainPage.ClickExtendedSearchButton();
            navigator = new Pages.Navigator(driver);
            navigator.DoExtendedSearchForFilm(wordFromilm, year);
            searchPage = new Pages.SearchPage(driver);
            return searchPage.GetFilmName().Contains(wordFromilm);
        }
        public bool IsSearchActoreByExtendedSearch(string name, string birth)
        {
            mainPage = new Pages.MainPage(driver);
            mainPage.ClickExtendedSearchButton();
            navigator = new Pages.Navigator(driver);
            navigator.DoExtendedSearchForActor(name, birth);
            searchPage = new Pages.SearchPage(driver);
            return searchPage.GetactorNameForExtSerch().Contains(name);
        }
        public void AddNoticeOnInfoPage(string noticeText)
        {
            infoPage = new Pages.InfoPage(driver);
            infoPage.ClickaddNotice();
            infoPage.FillFieldNotice(noticeText);
            infoPage.ClickSaveNotice();
        }
        public void DeleteNoticeOnInfoPage()
        {
            infoPage = new Pages.InfoPage(driver);
            infoPage.ClickremoveNotice();
            driver.SwitchTo().Alert().Accept();
        }
        public bool IsAddNotice(string noticeText)
        {
            AddNoticeOnInfoPage(noticeText);
            Thread.Sleep(4000);
            infoPage = new Pages.InfoPage(driver);
            return infoPage.GetNoticeText().Contains(noticeText);
        }
        public bool IsDeleteNotice()
        {
            DeleteNoticeOnInfoPage();

            Thread.Sleep(4000);
            infoPage = new Pages.InfoPage(driver);
            return infoPage.GetNoticeText() == "";
        }
     
        public bool IsSearchLine(string name)
        {
            mainPage = new Pages.MainPage(driver);
            mainPage.enterTextToSearch(name);
            searchPage = new Pages.SearchPage(driver);
            return searchPage.GetFilmName().Contains(name);
        }

        public bool IsSortByMarkAmount(string actoreName)
        {
            mainPage = new Pages.MainPage(driver);
            mainPage.OpenPage();
            Search(actoreName);
            infoPage = new Pages.InfoPage(driver);
            infoPage.ClickSortByMarkAmount();
            return infoPage.IsFirstAmountElementMoreThenSecond();

        }
        public bool IsSortByMark(string actoreName)
        {
            mainPage = new Pages.MainPage(driver);
            mainPage.OpenPage();
            Search(actoreName);
            infoPage = new Pages.InfoPage(driver);
            infoPage.ClickSortByMarkBtn();
            return infoPage.IsFirstMarkElementMoreThenSecond();

        }
    }
}
