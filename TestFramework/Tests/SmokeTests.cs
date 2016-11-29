using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;


namespace TestFramework
{
    [TestFixture]
    public class SmokeTests
    {
        private Steps.Steps steps = new Steps.Steps();
        public string login = "testcase";
        public string password = "Testcase2016";
        public string filmName = "Свет в океане";
        public string actorName = "Том Хэнкс";

        [SetUp]
        public void Init()                      //открыть браузер
        {
            steps.InitBrowser();
        }

        [TearDown]
        public void Cleanup()                            //закрыть браузер
        {
            steps.CloseBrowser();
        }
        
            [Test]
                public void authorization()                                  
                {
                    Assert.IsTrue(steps.IsLogin(login, password)); //ok
                    steps.LogOut();
                }  
         [Test]
            public void addActorToFavoriteActorList()                                  //ok
                 {
                     steps.IsLogin(login, password);
                     Assert.IsTrue(steps.IsAddActoreToFavorite(actorName));
                     steps.DeleteFromFavoritList();
                     steps.LogOut();
                 } 

            [Test]
            public void deleteActorFromFavoriteActorList()                        //ok          
                    {
                        steps.IsLogin(login, password);
                        Assert.IsTrue(steps.IsDeleteActorFromFavorite(actorName));
                       steps.LogOut();
                    } 
       

                   [Test]
                   public void putFilmMark()                    //ok             
                   {
                       steps.IsLogin(login, password);
                       Assert.IsTrue(steps.IsPushMark(filmName));
                       steps.LogOut();
                   } 
         
                   [Test]
                   public void addMovieToFavourites()                   //ok               
                   {
                       steps.IsLogin(login, password);
                       Assert.IsTrue(steps.IsAddFilmToFavorite(filmName));
                       steps.LogOut();
                   } 

        
           [Test]
           public void LookDirectorFilm()                    //ok              
           {
               steps.IsLogin(login, password);
               Assert.IsTrue(steps.IsOpenDirectorInfoPageFromFilmPage(filmName));
               steps.LogOut();
           } 
        

           [Test]
           public void PutFilmMarkWithoutAuthorization()                  //ok                
           {

               Assert.IsTrue(steps.IsPutMarkWithoutAuthorization(filmName));
         
           } 
        

          
               [Test]
                 public void CheckLogout()                           //ok
              {
                  steps.IsLogin(login, password);
                  Assert.IsTrue(steps.IsLogOut());
              
              } 
        [Test]      
             public void NavigateSearch()                           //okkkk
          {
              steps.IsLogin(login, password);   
              Assert.IsTrue(steps.IsSearchFilmByExtendedSearch("свет", "2016"));
              steps.LogOut();
          }
           [Test]
             public void SearchActoreByBirthTest()                           //okkkk
             {
                 steps.IsLogin(login, password);
                 Assert.IsTrue(steps.IsSearchActoreByExtendedSearch("Дакота", "1994"));
                 steps.LogOut();
             } 

                [Test]

                  public void AddNotice()     //ok
                  {
                      steps.IsLogin(login, password);
                      steps.Search(filmName);
                      Assert.IsTrue(steps.IsAddNotice("qwerty"));
                      steps.DeleteNoticeOnInfoPage();
                      steps.LogOut();

                  } 
           [Test]
          public void RemoveNotice()    //ok
          {
              steps.IsLogin(login, password);
              steps.Search(filmName);
              steps.IsAddNotice("qwerty");
              Assert.IsTrue(steps.IsDeleteNotice());
              steps.LogOut();

          }
    

     [Test]
        public void CheckSearchLineTest()         //ok
        {
            steps.IsLogin(login, password);
            Assert.IsTrue(steps.IsSearchLine(filmName));
            steps.LogOut();

        } 
      [Test]
        public void CheckSortByNameTest()        //ok
        {

            Assert.IsTrue(steps.IsSortByMarkAmount(actorName));
           

        } 
        [Test]
        public void CheckSortByMarkTest()        //ok
        {

            Assert.IsTrue(steps.IsSortByMark(actorName));


        }
    }
}
