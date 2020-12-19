// Задание 2 
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
using AutoTestRainur;

[TestFixture]
public class LoginAndLogout2Test:TestBase {
    
    [Test]
    public void loginAndLogout2Test()
    {
        AccountData user = new AccountData("admin2020", "RainurAdmin2000");
        OpenHomePage();
        Login(user);
        Logout();
    }

    public void OpenHomePage() 
    {
        driver.Navigate().GoToUrl("https://univer.tatar/");
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
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        driver.FindElement(By.CssSelector(".uk-navbar-transparent > #tm-show-on-mobile a > .uk-border-circle")).Click();
        driver.FindElement(By.LinkText("Чыгу")).Click();
    }
}