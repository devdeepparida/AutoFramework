using AutoFramework.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoFramework.Config
{
    public class Settings
    {
        public static int Timeout { get; set; }

        public static string IsReporting { get; set; }

        public static string TestType { get; set; }

        public static string Url { get; set; }

        public static string BuildName { get; set; }

        public static BrowserType BrowserType { get; set; }

        public static string IsLog { get; set; }

        public static string LogPath { get; set; }

        public static string DriverPath { get; set; }
    }
}
