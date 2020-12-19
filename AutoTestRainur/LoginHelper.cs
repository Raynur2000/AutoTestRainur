using OpenQA.Selenium;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using NUnit.Framework;


namespace AutoTestRainur
{
    public class LoginHelper: HelperBase
    {
        public LoginHelper(ApplicationManager manager)
            : base(manager)
        {
        }

        public void Login(AccountData user)
        {
            driver.FindElement(By.CssSelector(".uk-navbar-transparent > #tm-show-on-mobile .uk-visible\\@m")).Click();
            driver.FindElement(By.Id("id_username")).Click();
            driver.FindElement(By.Id("id_username")).SendKeys(user.Username);
            driver.FindElement(By.Id("password")).Click();
            driver.FindElement(By.Id("password")).SendKeys(user.Password);
            driver.FindElement(By.Name("login")).Click();
        }
        
        public void Logout()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.FindElement(By.CssSelector("a:nth-child(4)")).Click();
        }
    }
}