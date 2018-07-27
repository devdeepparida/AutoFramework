using AutoFramework.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AutoFramework.Extensions
{
    public static class WebElementExtensions
    {
        public static string GetDropDownSelecetedValue(this IWebElement element)
        {
            SelectElement ddl = new SelectElement(element);
            return ddl.AllSelectedOptions.First().ToString();
        }

        public static IList<IWebElement> GetDropDownSelecetedOptions(this IWebElement element)
        {
            SelectElement ddl = new SelectElement(element);
            return ddl.AllSelectedOptions;
        }

        public static void SelectDropdownByTex(this IWebElement element, string value)
        {
            SelectElement ddl = new SelectElement(element);
            ddl.SelectByText(value);
        }

        public static void SelectDropdownByIndex(this IWebElement element, int value)
        {
            SelectElement ddl = new SelectElement(element);
            ddl.SelectByIndex(value);
        }

        public static void SelectDropdownByValue(this IWebElement element, string value)
        {
            SelectElement ddl = new SelectElement(element);
            ddl.SelectByValue(value);
        }

        public static void MouseHover(this IWebElement element)
        {
            Actions builder = new Actions(DriverContext.Driver);
            builder.MoveToElement(element).Build().Perform();
        }

        public static void AssertElementPresent(this IWebElement element)
        {
            if (!IsElementPresent(element))
                throw new Exception(string.Format("Element Not Present Exception"));
        }

        private static bool IsElementPresent(IWebElement element)
        {
            try
            {
                return element.Displayed;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
