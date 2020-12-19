using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using NUnit.Framework;

namespace AutoTestRainur
{
    public class NavigationHelper: HelperBase
    {
        
        private string baseURL;        
        public NavigationHelper(ApplicationManager manager, string baseURL)
            : base(manager)
        {
            this.baseURL = baseURL;
        }

        
        public void OpenHomePage()
        {
            driver.Navigate().GoToUrl("https://univer.tatar/");
        }
        
        public void OpenCourseAddingPage() 
        {
            driver.FindElement(By.LinkText("Courses")).Click();
        }
        
    }
}