using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Web.Http;
using Microsoft.WindowsAzure.Mobile.Service;
using TransitApp.Server.WebApi.DataObjects;

namespace TransitApp.Server.WebApi
{
    public static class WebApiConfig
    {
        public static void Register()
        {
            // Use this class to set configuration options for your mobile service
            ConfigOptions options = new ConfigOptions();


            // Use this class to set WebAPI configuration options
            HttpConfiguration config = ServiceConfig.Initialize(new ConfigBuilder(options));


            // To display errors in the browser during development, uncomment the following
            // line. Comment it out again when you deploy your service for production use.
#if DEBUG
            config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;
#endif
        }
    }

}

