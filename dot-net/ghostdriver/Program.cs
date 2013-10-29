using System;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Support.UI;
using log4net;
using log4net.Config;

namespace GhostDriver.Example
{
    class Program
    {
        private static ILog Log = LogManager.GetLogger(typeof (Program));

        static void Main(string[] args)
        {
            BasicConfigurator.Configure();

            PhantomJSDriver driver = new PhantomJSDriver();
            driver.Navigate().GoToUrl("https://duckduckgo.com/");
            Log.InfoFormat("Your title is ... {0}", driver.Title);

            var searchElement = driver.FindElementById("search_form_input_homepage");
            searchElement.SendKeys("Why duck go?");
            searchElement.Submit();

            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(d => ((PhantomJSDriver)d).FindElementById("search_form_input"));

            Log.InfoFormat("Your new title is ... {0}", driver.Title);

            driver.Dispose();
        }
    }
}
