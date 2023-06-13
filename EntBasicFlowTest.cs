using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumTraining;

[TestFixture]
public class EntBasicFlowTest : BaseTest
{
	[Test]
	public void LoginTest()
	{
		drv.Navigate().GoToUrl(Environment.GetEnvironmentVariable("ENT_QA_URL"));
		drv.Manage().Window.Maximize();
		drv.FindElement(By.Name("username")).SendKeys(Environment.GetEnvironmentVariable("ENT_QA_USER"));
		drv.FindElement(By.Name("password")).SendKeys(Environment.GetEnvironmentVariable("ENT_QA_PASS"));
		drv.FindElement(By.Name("_companyText")).SendKeys(Environment.GetEnvironmentVariable("ENT_QA_COMPANY"));
		

		drv.FindElement(By.CssSelector("input[type=submit]")).Click(); 

		Thread.Sleep(4000);

		var version = drv.FindElement(By.CssSelector(".menu-logo img")).GetAttribute("title");

		
		drv.FindElement(By.CssSelector(".menu-primary > .menu-list > li:nth-of-type(2) > .menu-drop")).Click();
		drv.FindElement(By.CssSelector("[aria-owns='dropdown-894']")).Click();


		drv.FindElement(By.XPath("(//td[text()='New'])[1]")).Click();
		drv.FindElement(By.CssSelector("span[title='Pick-Up']")).Click();
		drv.FindElement(By.CssSelector(".id-btn-save")).Click();
		drv.FindElement(By.CssSelector(".id-view-details")).Click();
		drv.FindElement(By.CssSelector("div#WoActivityLogGrid  .kg-collapse > div")).Click();

		var record = drv.FindElement(By.CssSelector(".menu-logo img")).GetAttribute("title");

		Assert.That(record, Is.EqualTo("Picked Up"));


	}
}
