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
            driver.FindElement(By.XPath("//input[@id='id_username']")).Click();
            driver.FindElement(By.XPath("//input[@id='id_username']")).SendKeys(user.Username);
            driver.FindElement(By.XPath("//input[@id='password']")).Click();
            driver.FindElement(By.XPath("//input[@id='password']")).SendKeys(user.Password);
            driver.FindElement(By.Name("login")).Click();
        }

        public void LoginInAdminPanel(AccountData user)
        {
            driver.Navigate().GoToUrl("https://univer.tatar/admin/login/?next=/admin/");
            driver.FindElement(By.Id("id_username")).SendKeys(user.Username);
            driver.FindElement(By.Id("id_password")).Click();
            driver.FindElement(By.Id("id_password")).SendKeys(user.Password);
            driver.FindElement(By.Id("id_password")).SendKeys(Keys.Enter);
        }
        
        public void Logout()
        {
            driver.FindElement(By.CssSelector(".uk-navbar-transparent > #tm-show-on-mobile a > .uk-border-circle")).Click();
            driver.FindElement(By.LinkText("Чыгу")).Click();
        }
    }
}