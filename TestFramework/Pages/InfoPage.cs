using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFramework.Pages
{
    class InfoPage : AbstractPage
    {
        public InfoPage(IWebDriver driver) : base(driver) { }
       

        [FindsBy(How = How.Id, Using = "btn_fav_film")]
        private IWebElement heart;
        [FindsBy(How = How.XPath, Using = "//li[@id='ms_folder_745']/a")]
        private IWebElement listName;
        [FindsBy(How = How.XPath, Using = "//a[text()='Любимые фильмы']")]
        private IWebElement FilmlistName;
        [FindsBy(How = How.XPath, Using = "//a[text()='все папки']")]
        private IWebElement allFolders;
        [FindsBy(How = How.XPath, Using = "//div[@id='div_mustsee_main']//span[2]")]
        private IWebElement listButton;
        [FindsBy(How = How.XPath, Using = "//div[@id='div_mustsee_main']//dl/dd[5]")]
        private IWebElement favButton;
        [FindsBy(How = How.ClassName, Using = "list_title")]
        private IWebElement list_title;
        [FindsBy(How = How.ClassName, Using = "s10")]
        private IWebElement mark;
        [FindsBy(How = How.XPath, Using = "//a[text()='моя оценка']")]
        private IWebElement myMark;
        [FindsBy(How = How.XPath, Using = "//a[text()='Дерек Сиенфрэнс']")]
        private IWebElement director;
        [FindsBy(How = How.XPath, Using = "//a[text()='Валентинка']")]
        private IWebElement anoherFilm;
        [FindsBy(How = How.ClassName, Using = "tdtext")]
        private IWebElement message;
        [FindsBy(How = How.Id, Using = "btn_film_notice")]
        private IWebElement addNotice;
        [FindsBy(How = How.XPath, Using = "//div[@id='ta_film_notice']/form/textarea")]
        private IWebElement fillNotice;
        [FindsBy(How = How.ClassName, Using = "save")]
        private IWebElement saveNotice;
        [FindsBy(How = How.XPath, Using = "//div[@id='txt_film_notice']/div[1]")]
        private IWebElement noticeText;
        [FindsBy(How = How.ClassName, Using = "remove")]
        private IWebElement removeNotice;
        [FindsBy(How = How.XPath, Using = "//div[@id='infoTable']/table/tbody/tr[14]/td[2]/div/a[1]")]
        private IWebElement feecInTheWorld;
        [FindsBy(How = How.XPath, Using = "//td[@id='block_left']//td[1]/div//tr[3]/td[1]/h3")]
        private IWebElement feecInUSA;
        [FindsBy(How = How.XPath, Using = "//td[@id='block_left']//td[1]/div//tr[5]/td[1]/h3")]
        private IWebElement feecInOtherCountries;
        [FindsBy(How = How.XPath, Using = "//td[@id='block_left']//td[1]/x:div//tr[9]/td[1]/h3")]
        private IWebElement feecSum;
        [FindsBy(How = How.XPath, Using = "//div[@id='sort_block']/div[2]/span")]
        private IWebElement sortByBtn;
        [FindsBy(How = How.XPath, Using = "//div[@id='sort_block']/div[2]/div/ul/li[3]")]
        private IWebElement sortByNameBtn;
        [FindsBy(How = How.XPath, Using = "//div[@id='sort_block']/div[2]/div/ul/li[7]")]
        private IWebElement sortByMarkBtn;
        [FindsBy(How = How.XPath, Using = "//tr[11]/td/div[2]/div[1]/table/tbody/tr/td/span[1]/a[1]")]
        private IWebElement labeForChekSort;





   /*     public InfoPage(IWebDriver driver)                              //конструктор
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }*/
        public string GetTextlabeForChekSort()
        {
           return labeForChekSort.Text;
        }

        public void ClickSortBtn()
        {
            sortByBtn.Click();
        }

        public void ClickSortByNameBtn()
        {
            sortByNameBtn.Click();
        }

        public void ClickSortByMarkBtn()
        {
            sortByMarkBtn.Click();
        }

        public void ClickfavButton()
        {
            favButton.Click();
        }
        public void ClickList()
        {
            listButton.Click();
        }
        public void ClickListTitle()
        {
            list_title.Click();
        }
        public void ClickHeart()
        {
            heart.Click();
            
        }
        public void ClickDirector()
        {
            director.Click();

        }
        public string GetListName()                 //получить listname
        {
            return listName.Text;
        }
        public string GetFilmListName()                 //получить listname
        {
            return FilmlistName.Text;
        }
        public string GetClass()                 //получить listname
        {
            return favButton.GetAttribute("class");
          
        }
        public void PushMark()
        {
            mark.Click();
        }
        public string GetMyMark()                 //получить listname
        {
            return myMark.Text;
        }
        public string GetAnotherFilmName()                 
        {
            return anoherFilm.Text;
        }
        public string GetMessageText()
        {
            return message.Text;
        }
        public string GetNoticeText()
        {
            return noticeText.Text;
        }
        public void FillFieldNotice()
        {
            fillNotice.SendKeys("qwerty");
        }
        public void ClickremoveNotice()
        {
            removeNotice.Click();
        }
        public void ClickaddNotice()
        {
            addNotice.Click();
        }
        public void ClickSaveNotice()
        {
            saveNotice.Click();
        }
    }
   

}
