using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.WindowsAzure.Mobile.Service;
using transit_app.DataObjects;
using transit_app.Models;

namespace transit_app.Controllers
{
    public class TrainController : TableController<Train>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            transit_appContext context = new transit_appContext();
            DomainManager = new EntityDomainManager<Train>(context, Request, Services);
        }

        
        public IQueryable<Train> GetAllTrains()
        {
            return Query();
        }

        
        public SingleResult<Train> GetTrain(string id)
        {
            return Lookup(id);
        }


        //just stubs
        public SingleResult<Train> getTrainsForStation(string id)
        {
            return Lookup(id);
        }

        //just stubs
        public SingleResult<Train> findStationsByName(string id)
        {
            return Lookup(id);
        }

    }
}