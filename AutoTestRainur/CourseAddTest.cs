// Generated by Selenium IDE
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using NUnit.Framework;
using AutoTestRainur;

[TestFixture]
public class CourseAddTestTest:TestBase {
  [Test]
  public void courseAddTest()
  {
    AccountData user = new AccountData("admin2020", "RainurAdmin2000");
    app.Navigation.OpenHomePage();
    app.Auth.LoginInAdminPanel(user);
    app.Navigation.OpenCourseAddingPage();    
    app.Course.AddCourse();
    //app.Auth.Logout();
  }
}
