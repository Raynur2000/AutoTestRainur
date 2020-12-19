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
public class CourseAddTestTest:TestBase {
  [Test]
  public void courseAddTest()
  {
    AccountData user = new AccountData("admin2020", "RainurAdmin2000");

    OpenHomePage();
    Login(user);
    AddCourse();
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

  public void AddCourse()
  {
    driver.FindElement(By.LinkText("Courses")).Click();
    driver.FindElement(By.CssSelector(".addlink")).Click();
    driver.FindElement(By.Id("id_name")).SendKeys("Новый курс");
    driver.FindElement(By.Id("id_queue_number")).Click();
    driver.FindElement(By.Id("id_queue_number")).SendKeys("10");
    js.ExecuteScript("window.scrollTo(0,698.75)");
    driver.SwitchTo().Frame(1);
    driver.FindElement(By.CssSelector("html")).Click();
    {
      var element = driver.FindElement(By.CssSelector(".cke_editable"));
      js.ExecuteScript("if(arguments[0].contentEditable === 'true') {arguments[0].innerText = '<p>Описание курса&nbsp;</p>'}", element);
    }
    driver.SwitchTo().DefaultContent();
    driver.FindElement(By.Id("id_short_description")).Click();
    driver.FindElement(By.Id("id_short_description")).Click();
    {
      var element = driver.FindElement(By.Id("id_short_description"));
      Actions builder = new Actions(driver);
      builder.DoubleClick(element).Perform();
    }
    driver.FindElement(By.Id("id_short_description")).Click();
    driver.FindElement(By.Id("id_short_description")).SendKeys("Краткое описание курса ");
    driver.FindElement(By.Name("_save")).Click();
  }

  public void Logout()
  {
    driver.FindElement(By.CssSelector("a:nth-child(4)")).Click();
  }
}
