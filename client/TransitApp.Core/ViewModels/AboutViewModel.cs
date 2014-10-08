using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace TransitApp.Core.ViewModels
{
	public class AboutViewModel : BaseViewModel
    {
        private string _content;
        public string Content
        {
            get
            {
                if (_content==null)
                {                    
                    var assembly = Assembly.Load(new AssemblyName("TransitApp.Core"));
                    var resourceNames = assembly.GetManifestResourceNames();

                    var resourcePaths = resourceNames
                        .Where(x => x.EndsWith("AboutUs.Html", StringComparison.CurrentCultureIgnoreCase))
                        .ToArray();

                    using (StreamReader streamReader = new StreamReader(assembly.GetManifestResourceStream(resourcePaths.Single())))
                    {
                        _content = streamReader.ReadToEnd();
                    }
                }

                return _content;
            }          
        }
    }
}
