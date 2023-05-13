using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace SeleniumTraining

{
	public class Tests
	{
		IWebDriver driver;

		[SetUp]
		public void Setup()
		{
			driver = new OpenQA.Selenium.Chrome.ChromeDriver();
		}

		
		[Test]
		public void Test1()
		{
			driver.Navigate().GoToUrl("https://google.com");
			driver.Manage().Window.Maximize();
			//driver.FindElement(By.CssSelector("[name=q]")).SendKeys("JLL" + "\n");
			


		}

		[TearDown]

		public void TearDown()
		{
		//	driver.Quit();
		}
	}
}