using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestFramework.Pages
{
    class InfoPage : AbstractPage
    {
        public InfoPage(IWebDriver driver) : base(driver) { }
       

        [FindsBy(How = How.Id, Using = "btn_fav_film")]
        private IWebElement addFilmToFavoriteButton;

        [FindsBy(How = How.XPath, Using = "//li[@id='ms_folder_745']/a")]
        private IWebElement listNameLabel;

        [FindsBy(How = How.XPath, Using = "//a[text()='Любимые фильмы']")]
        private IWebElement FavoritFilmlsListLabel;

        [FindsBy(How = How.XPath, Using = "//a[text()='все папки']")]
        private IWebElement allFoldersLabel;

        [FindsBy(How = How.XPath, Using = "//div[@id='div_mustsee_main']//span[2]")]
        private IWebElement listButton;

        [FindsBy(How = How.XPath, Using = "//div[@id='div_mustsee_main']//dl/dd[5]")]
        private IWebElement addFavoriteButton;

        [FindsBy(How = How.ClassName, Using = "list_title")]
        private IWebElement listTitleLabel;

        [FindsBy(How = How.ClassName, Using = "s10")]
        private IWebElement tenPointButton;

        [FindsBy(How = How.XPath, Using = "//a[text()='моя оценка']")]
        private IWebElement myMarkLabel;

        [FindsBy(How = How.XPath, Using = "//div[@id='infoTable']/table/tbody/tr[4]/td[2]/a")]
        private IWebElement directorButton;

        [FindsBy(How = How.XPath, Using = "//div[@id='BestFilmList']/h4")]
        private IWebElement bestDirectorFilmsLabel;

        [FindsBy(How = How.ClassName, Using = "tdtext")]
        private IWebElement warningMessage;

        [FindsBy(How = How.Id, Using = "btn_film_notice")]
        private IWebElement addNoticeButton;

        [FindsBy(How = How.XPath, Using = "//div[@id='ta_film_notice']/form/textarea")]
        private IWebElement textareaForNotice;

        [FindsBy(How = How.ClassName, Using = "save")]
        private IWebElement saveNoticeButton;

        [FindsBy(How = How.XPath, Using = "//div[@id='txt_film_notice']/div[1]")]
        private IWebElement noticeText;

        [FindsBy(How = How.ClassName, Using = "remove")]
        private IWebElement removeNoticeButton;
  
        [FindsBy(How = How.XPath, Using = "//div[@id='sort_block']/div[2]/span")]
        private IWebElement sortByButton;

        [FindsBy(How = How.XPath, Using = "//div[@id='sort_block']/div[2]/div/ul/li[6]")]
        private IWebElement sortByMarkAmount;

        [FindsBy(How = How.XPath, Using = "//div[@id='sort_block']/div[2]/div/ul/li[7]")]
        private IWebElement sortByMarkButton;

        [FindsBy(How = How.XPath, Using = "//tr[11]/td/div[2]/div[1]/div[1]/span")]
        private IWebElement markAmountFirstElementLable;

        [FindsBy(How = How.XPath, Using = "//tr[11]/td/div[2]/div[2]/div[1]/span")]
        private IWebElement markAmountSecondElementLable;

        [FindsBy(How = How.XPath, Using = "//tr[11]/td/div[2]/div[1]/div[1]/a")]
        private IWebElement filmMarkFirstElementLable;

        [FindsBy(How = How.XPath, Using = "//tr[11]/td/div[2]/div[2]/div[1]/a")]
        private IWebElement filmMarkSecondElementLable;





        public bool IsFirstAmountElementMoreThenSecond()
        {
            
          int a=Convert.ToInt32(markAmountFirstElementLable.Text);
           int b= Convert.ToInt32(markAmountSecondElementLable.Text);
           return a > b;
        }

        public bool IsFirstMarkElementMoreThenSecond()
        {

            int a = Convert.ToInt32(filmMarkFirstElementLable.Text);
            int b = Convert.ToInt32(filmMarkSecondElementLable.Text);
            return a > b;
        }

     
        public void ClickSortByMarkAmount()
        {
            sortByButton.Click();
            sortByMarkAmount.Click();
            Thread.Sleep(4000);
        }

        public void ClickSortByMarkBtn()
        {
            sortByButton.Click();
            sortByMarkButton.Click();
            Thread.Sleep(4000);
        }

        public void ClickfavButton()
        {
            addFavoriteButton.Click();
        }
        public void ClickListButton()
        {
            listButton.Click();
        }
        public void ClickListTitle()
        {
            listTitleLabel.Click();
        }
        public void ClickAddFilmToFavoriteButton()
        {
            addFilmToFavoriteButton.Click();
            
        }
        public void ClickDirector()
        {
            directorButton.Click();

        }
        public bool IsFavoriteStarsListExist()                 //получить listname
        {
            return listNameLabel.Text.Contains("Любимые звёзды");
        }
        public bool IsFavoriteFilmsListExist()                 //получить listname
        {
            return FavoritFilmlsListLabel.Text.Contains("Любимые фильмы");
        }
        public bool IsExistClass()                 //получить listname
        {
            return addFavoriteButton.GetAttribute("class").Contains("fav");
          
        }
        public void PushMark()
        {
            tenPointButton.Click();
        }
        public bool IsMyMarkLableExist()                 //получить listname
        {
            return String.Equals(myMarkLabel.Text, "моя оценка");
        }
        public bool IsDirectorBestFilmsLabelExist()                 
        {
            return bestDirectorFilmsLabel.Text.Contains("Лучшие фильмы:");
        }
        public bool IsWarningMessageExist()
        {
            return warningMessage.Text.Contains("Для голосования");
        }
        public string GetNoticeText()
        {
            return noticeText.Text;
        }
        public void FillFieldNotice(string noticeText)
        {
            textareaForNotice.SendKeys(noticeText);
        }
        public void ClickremoveNotice()
        {
            removeNoticeButton.Click();
        }
        public void ClickaddNotice()
        {
            addNoticeButton.Click();
        }
        public void ClickSaveNotice()
        {
            saveNoticeButton.Click();
        }
    }
   

}
