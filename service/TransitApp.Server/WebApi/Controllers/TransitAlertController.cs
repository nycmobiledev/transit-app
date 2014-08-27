using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.WindowsAzure.Mobile.Service;
using TransitApp.Server.WebApi.DataObjects;
using TransitApp.Server.WebApi.Models;

namespace TransitApp.Server.WebApi.Controllers
{
    public class TransitAlertController : TableController<TransitAlert>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            MobileServiceContext context = new MobileServiceContext();
            DomainManager = new EntityDomainManager<TransitAlert>(context, Request, Services);
        }

        // GET tables/TransitAlert
        public IQueryable<TransitAlert> GetAllTransitAlert()
        {
            return Query(); 
        }

        // GET tables/TransitAlert/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<TransitAlert> GetTransitAlert(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/TransitAlert/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<TransitAlert> PatchTransitAlert(string id, Delta<TransitAlert> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/TransitAlert/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public async Task<IHttpActionResult> PostTransitAlert(TransitAlert item)
        {
            TransitAlert current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/TransitAlert/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteTransitAlert(string id)
        {
             return DeleteAsync(id);
        }

    }
}