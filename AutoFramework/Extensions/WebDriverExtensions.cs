using AutoFramework.Base;
using AutoFramework.Config;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoFramework.Extensions
{
    public static class WebDriverExtensions
    {
        public static void WaitForpageLoaded(this IWebDriver driver)
        {
            driver.WaitForCondition(drv =>
            {
                string state = drv.ExecuteJs("return document.readyState").ToString();
                return state == "complete";
            }, Settings.Timeout);
        }

        internal static void WaitForCondition<T>(this T obj, Func<T, bool> condition, int timeOut)
        {
            Func<T, bool> execute =
                (arg) =>
                {
                    try
                    {
                        return condition(arg);
                    }
                    catch (Exception e)
                    {
                        return false;
                    }
                };

            var sw = Stopwatch.StartNew();
            while (sw.ElapsedMilliseconds < timeOut)
            {
                if (execute(obj))
                {
                    break;
                }
            }
        }

        internal static object ExecuteJs(this IWebDriver driver, string scripts)
        {
            return ((IJavaScriptExecutor)DriverContext.Driver).ExecuteScript(scripts);
        }

    }
}

