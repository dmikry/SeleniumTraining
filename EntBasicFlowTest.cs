using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumTraining;

[TestFixture]
public class EntBasicFlowTest
{
	private IWebDriver drv;
	[Test]
	public void LoginTest()

	{
		drv = new ChromeDriver();
		var pickUpComment = "Pick-Up Comment From Autotest";
		drv.Navigate().GoToUrl(Environment.GetEnvironmentVariable("ENT_QA_URL"));
		drv.Manage().Window.Maximize();
		drv.FindElement(By.Name("username")).SendKeys(Environment.GetEnvironmentVariable("ENT_QA_USER"));
		drv.FindElement(By.Name("password")).SendKeys(Environment.GetEnvironmentVariable("ENT_QA_PASS"));
		drv.FindElement(By.Name("_companyText")).SendKeys(Environment.GetEnvironmentVariable("ENT_QA_COMPANY"));
		

		drv.FindElement(By.CssSelector("input[type=submit]")).Click(); 

		Thread.Sleep(4000);

			
		drv.FindElement(By.CssSelector(".menu-primary > .menu-list > li:nth-of-type(2) > .menu-drop")).Click();
		drv.FindElement(By.CssSelector("[aria-owns='dropdown-894']")).Click();

		Thread.Sleep(2000);
		// Preserve WO# with New Status that is going to be Picked Up to return to t later
		var woLink = By.XPath("//td[@data-column='WOStatus'][contains(text(), 'New')][1]/following-sibling::td/a");
		var woNumber = drv.FindElement(woLink).Text;

		//Click on New WO and open Quick View dialog
		drv.FindElement(woLink).Click();
		Thread.Sleep(2000);

		// Action Pick Up
		drv.FindElement(By.XPath("//div[@data-role='woqvdialog']//span[@title='Pick-Up']")).Click();
		Thread.Sleep(2000);

		//Activate Comment area
		drv.FindElement(By.XPath("//form[@class='corrigo-form']/div/textarea")).Click();
		Thread.Sleep(2000);

		// Type a Comment
		drv.FindElement(By.CssSelector("form.corrigo-form textarea")).SendKeys(pickUpComment);
		Thread.Sleep(2000);

		//Close WO Quick View dialog
		drv.FindElement(By.CssSelector("div[data-role=woactionpickupeditdialog] button.id-btn-save")).Click();
		Thread.Sleep(2000);

		//Check in the Activity log that Action "Picked Up" is displayed
		var action = drv.FindElement(By.XPath("//*[@data-role='woactivityloggrid']//tbody//tr[1]//td[@data-column='ActionTitle']"));
		Assert.That(action.Text, Is.EqualTo("Picked Up"));

		//Check in the Activity log that Comment is displayed
		var comment =
			drv.FindElement(By.XPath("//*[@data-role='woactivityloggrid']//tbody//tr[1]//td[@data-column='Comment']"));
		Assert.That(comment.Text, Is.EqualTo(pickUpComment));

		//Closing the Quick View dialog
		drv.FindElement(By.XPath("//button[@class='close btn-dismiss']")).Click();
		Thread.Sleep(1000);

		//Check WO Staus is Opened on WO list page
		//var woStatus = drv.FindElement(By.XPath("//td[@data-column='Number']/a[contains(text(), '" + woNumber + "')]/../../td[@data-column='WOStatus']"));
		//Thread.Sleep(1000);
		//Assert.That(woStatus.Text, Is.EqualTo("Open"));

	}
}
