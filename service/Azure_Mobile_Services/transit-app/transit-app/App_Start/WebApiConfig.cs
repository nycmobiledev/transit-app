using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Web.Http;
using transit_app.DataObjects;
using transit_app.Models;
using Microsoft.WindowsAzure.Mobile.Service;

namespace transit_app
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
            config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;
            
            Database.SetInitializer(new transit_appInitializer());
        }
    }

    public class transit_appInitializer : DropCreateDatabaseIfModelChanges<transit_appContext>
    {
        protected override void Seed(transit_appContext context)
        {
            List<Train> trains = new List<Train>
            {
                new Train { Id = "1", Text = "First train", InService = false },
                new Train { Id = "2", Text = "Second train", InService = false },
            };

            foreach (Train Train in trains)
            {
                context.Set<Train>().Add(Train);
            }

            base.Seed(context);
        }
    }
}

