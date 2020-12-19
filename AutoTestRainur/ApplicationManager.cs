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
    public class ApplicationManager
    {
        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();
        private IWebDriver driver;
        public IJavaScriptExecutor js;
        private string baseURL;

        private NavigationHelper navigation;
        private LoginHelper auth;
        private CourseHelper course;
        
        public IDictionary<string, object> vars {get; private set;}

        
        private ApplicationManager()
        {
            driver = new ChromeDriver("/Users/raynurkhasanov/Downloads/");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            js = (IJavaScriptExecutor)driver;
            vars = new Dictionary<string, object>();
            driver.Manage().Window.Size = new System.Drawing.Size(1280, 777);
            baseURL = "https://univer.tatar";
            auth = new LoginHelper(this);
            navigation = new NavigationHelper(this, baseURL);
            course = new CourseHelper(this);
            
        }
        
        ~ApplicationManager()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                //ignore
            }
        }

        public static ApplicationManager GetInstance()
        {
            if (!app.IsValueCreated)
            {
                ApplicationManager newInstance = new ApplicationManager();
                newInstance.Navigation.OpenHomePage();
                app.Value = newInstance;
            }
            return app.Value;
        }
        
        public void Stop()
        {
            driver.Quit();
        }

        
        public IWebDriver Driver
        {
            get
            {
                return driver;
            }
        }
        public NavigationHelper Navigation
        {
            get
            {
                return navigation;
            }
        }

        public LoginHelper Auth
        {
            get
            {
                return auth;
            }
        }

        public CourseHelper Course
        {
            get
            {
                return course;
                
            }
        }


    }
}