using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;


namespace SeleniumTraining;

[TestFixture]
public class BaseTest
{
	[OneTimeSetUp]
	public void Setup()
	{
		drv = new ChromeDriver();
	}

	[OneTimeTearDown]
	public void ShutDown()
	{
		drv.Quit();
	}

	protected IWebDriver drv;

	protected internal static string DemoHtmlUrl()
	{
		return "file://" + Path.Combine(Environment.CurrentDirectory, @"Resources\", "Examples.html");
	}
}