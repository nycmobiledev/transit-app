using Microsoft.WindowsAzure.Mobile.Service;

namespace transit_app.DataObjects
{
    public class Train : EntityData
    {
        public string Text { get; set; }

        public bool InService { get; set; }
    }
}