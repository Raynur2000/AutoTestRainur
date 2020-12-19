// Задание 1 
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

[TestFixture]
public class LoginAndLogout1Test {
  private IWebDriver driver;
  public IDictionary<string, object> vars {get; private set;}
  private IJavaScriptExecutor js;
  [SetUp]
  public void SetUp() {
    driver = new ChromeDriver("/Users/raynurkhasanov/Downloads/");
    js = (IJavaScriptExecutor)driver;
    vars = new Dictionary<string, object>();
  }
  [TearDown]
  protected void TearDown() {
    driver.Quit();
  }
  [Test]
  public void loginAndLogout1Test() {
    driver.Navigate().GoToUrl("https://univer.tatar/");
    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
    driver.Manage().Window.Size = new System.Drawing.Size(1280, 777);
    driver.FindElement(By.CssSelector(".uk-navbar-transparent > #tm-show-on-mobile .uk-visible\\@m")).Click();
    driver.FindElement(By.Id("id_username")).Click();
    driver.FindElement(By.Id("id_username")).SendKeys("admin2020");
    driver.FindElement(By.Id("password")).Click();
    driver.FindElement(By.Id("password")).SendKeys("RainurAdmin2000");
    driver.FindElement(By.Name("login")).Click();
    Thread.Sleep(5000);
    driver.FindElement(By.CssSelector(".uk-navbar-transparent > #tm-show-on-mobile a > .uk-border-circle")).Click();
    driver.FindElement(By.LinkText("Чыгу")).Click();
  }
}
