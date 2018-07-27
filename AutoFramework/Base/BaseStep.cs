using AutoFramework.Config;
using AutoFramework.Extensions;
using AutoFramework.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoFramework.Base
{
    public abstract class BaseStep: Base
    {
        public virtual void NavigateToSite()
        {
            //Open Browser
            //LogHelpers.WriteLog("Opened URL:" + Settings.Url);
            DriverContext.Browser.GoToUrl(Settings.Url);
        }

        
    }
}
