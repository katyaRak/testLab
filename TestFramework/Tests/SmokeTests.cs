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
                    Assert.IsTrue(steps.Enter("testcase", "Testcase2016")); //ok
                    steps.LogOut();
                }  
         [Test]
                 public void search()                                  //ok
                 {
                     steps.Enter("testcase", "Testcase2016");
                     Assert.IsTrue(steps.SearchActor("Том Хэнкс"));
                     steps.DelWhenListOpen();
                     steps.LogOut();
                 } 

            [Test]
                    public void searchDelete()                        //ok          
                    {
                       steps.Enter("testcase", "Testcase2016");
                       Assert.IsTrue(steps.SearchActorDel("Том Хэнкс"));
                       steps.LogOut();
                    } 
       

                   [Test]
                   public void searchFilm()                    //ok             
                   {
                       steps.Enter("testcase", "Testcase2016");
                       Assert.IsTrue(steps.SearchFilmAndPushMark("Свет в океане"));
                       steps.LogOut();
                   } 
         
                   [Test]
                   public void AddFavFilm()                   //ok               
                   {
                       steps.Enter("testcase", "Testcase2016");
                       Assert.IsTrue(steps.AddFavFilm("Свет в океане"));
                       steps.LogOut();
                   } 

        
           [Test]
           public void LookDirectorFilm()                    //ok              
           {
               steps.Enter("testcase", "Testcase2016");
               Assert.IsTrue(steps.LookDirectorFilm("Свет в океане"));
               steps.LogOut();
           } 
        

           [Test]
           public void MarkWithoutAuthorization()                  //ok                
           {
        
               Assert.IsTrue(steps.MarkWithoutAuthorization("Свет в океане"));
         
           } 
        

          
               [Test]
                 public void CheckOut()                           //ok
              {
                  steps.Enter("testcase", "Testcase2016");
                  Assert.IsTrue(steps.LogOutTest());
              
              } 
        [Test]      
             public void NavigateSearch()                           //okkkk
          {
              steps.Enter("testcase", "Testcase2016");   
              Assert.IsTrue(steps.SearchFilmByNavigate());
              steps.LogOut();
          }
           [Test]
             public void SearchActoreByBirthTest()                           //okkkk
             {
                 steps.Enter("testcase", "Testcase2016");
                 Assert.IsTrue(steps.SearchActoreByBirth());
                 steps.LogOut();
             } 

                [Test]

                  public void AddNotice()     //ok
                  {
                      steps.Enter("testcase", "Testcase2016");
                      steps.SearchFavFilm("Свет в океане");
                      Assert.IsTrue(steps.AddNotice());
                      steps.DelNotice();
                      steps.LogOut();

                  } 
           [Test]
          public void RemoveNotice()    //ok
          {
              steps.Enter("testcase", "Testcase2016");
              steps.SearchFavFilm("Свет в океане");
              steps.AddNotice();
              Assert.IsTrue(steps.DeleteNotice());
              steps.LogOut();

          }
    

     [Test]
        public void CheckSearchLineTest()         //ok
        {
            steps.Enter("testcase", "Testcase2016");
            Assert.IsTrue(steps.CheckSearchLine("Свет в океане"));
            steps.LogOut();

        } 
      [Test]
        public void CheckSortByNameTest()        //ok
        {
       
            Assert.IsTrue(steps.CheckSortByName());
           

        } 
        [Test]
        public void CheckSortByMarkTest()        //ok
        {

            Assert.IsTrue(steps.CheckSortByMark());


        }
    }
}
