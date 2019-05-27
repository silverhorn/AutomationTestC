using FillOutForm_tests;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumFirst
{
    class Program
    {

        static void Main1(string[] args)
        {
        }

        [SetUp]
        public void Initialize()
        {
            PropertiesCollection.driver = new ChromeDriver(@"C:\\chromedriver_win32");
            PropertiesCollection.driver.Navigate().GoToUrl("https://www.ultimateqa.com/filling-out-forms/"); // Go to url 
            Console.WriteLine("Opened URL"); //Print step
            PropertiesCollection.driver.Manage().Window.Maximize(); //Maximize Browser 
            Console.WriteLine("Maximize the Browser");//Print step


        }
        [TearDown]
        public void CleanUp()
        {
            
            PropertiesCollection.driver.Close(); //close browser
            Console.WriteLine("Close the Browser"); //Print step 
            

        }
        [Test]
        public void ExecuteTest()

        {
            PageObject page = new PageObject();
            //Catch Captcha Before submit
            var beforesubmit = page.BoxNameField();
            //Print Captcha Before submit
            Console.WriteLine("Captcha before submit form: "+beforesubmit);

            //Filling all fields 
            page.SubmitForm("Test", "Test", -1);
            Console.WriteLine("Filling all fields");

            //Catch Captcha After submit
            var aftersubmit = page.BoxNameField();
            Console.WriteLine("Captcha after submit form: "+ aftersubmit);

            //if captcha are diferent print False
            Console.WriteLine("Are captcha before and after submit the same ? " + aftersubmit.Equals(beforesubmit));
        }
        [Test]
        public void TestCorrectNumber()

        {
            PageObject page = new PageObject();
            //Catch Captcha Before submit
            var beforesubmit = page.BoxNameField();
            Console.WriteLine("Captcha before submit form: " + beforesubmit);
            
            var correctResult = Calculation.Addition(beforesubmit);
            
            Console.WriteLine("Correct result is " + correctResult);
            //Filling correct number into captcha box
            page.SubmitForm("Test", "Test", correctResult);

            
            System.Threading.Thread.Sleep(6500);
            //Verifying that success message is "Success"
            var MessageSuccessSubmitForm = page.GetSucessErrorMsgText();
            Console.WriteLine("Message is: " + MessageSuccessSubmitForm);
            Assert.AreEqual("Success", MessageSuccessSubmitForm);

        }
    }
}
