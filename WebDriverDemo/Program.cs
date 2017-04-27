using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;

namespace WebDriverDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver(@"C:\libraries\");
            
            driver.Url = "http://www.google.com";

            var searchBox = driver.FindElement(By.Id("gbqfq"));
            searchBox.SendKeys("pluralsight");

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            var imagesLink = wait.Until(d =>
                                            {
                                                var elements = driver.FindElements(By.ClassName("kl"));
                                                if (elements.Count > 0)
                                                    return elements[0];
                                                return null;
                                            });

            
            imagesLink.Click();

            var ul = driver.FindElement(By.ClassName("rg_ul"));
            var firstImageLink = ul.FindElements(By.TagName("a"))[0];
            firstImageLink.Click();
        }
    }
}
