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
    public class TestBase
    {
        public IWebDriver driver;
        public IDictionary<string, object> vars {get; private set;}
        public IJavaScriptExecutor js;
        
        [SetUp]
        public void SetUp() {
            driver = new ChromeDriver("/Users/raynurkhasanov/Downloads/");
            js = (IJavaScriptExecutor)driver;
            vars = new Dictionary<string, object>();
            driver.Manage().Window.Size = new System.Drawing.Size(1280, 777);

        }
        
        [TearDown]
        protected void TearDown() {
            driver.Quit();
        }
        
    }
}