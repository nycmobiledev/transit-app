using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.WindowsAzure.Mobile.Service;
using TransitApp.Server.GTFSStatic.Infrastructure.Data;
using TransitApp.Server.WebApi.DataObjects;

namespace TransitApp.Server.WebApi.Controllers
{
    public class TransitAlertController : ApiController
    {
//        protected override void Initialize(HttpControllerContext controllerContext)
//        {
//            base.Initialize(controllerContext);
//            MobileServiceContext context = new MobileServiceContext();
//            DomainManager = new EntityDomainManager<TransitAlert>(context, Request, Services);
//        }
//
//        // GET tables/TransitAlert
//        public IQueryable<TransitAlert> GetAllTransitAlert()
//        {
//            return Query(); 
//        }
//
//        // GET tables/TransitAlert/48D68C86-6EA6-4C25-AA33-223FC9A27959
//        public SingleResult<TransitAlert> GetTransitAlert(string tripId, string routeId, int batchVersion, string stationId)
//        {
//            return Lookup(tripId);
//        }
//
//        // GET tables/TransitAlert
//       /* public IQueryable<TransitAlert> GetTransitAlertsByStation(string[] stationIds)
//        {
//            return Query();
//        }*/
//
//        // PATCH tables/TransitAlert/48D68C86-6EA6-4C25-AA33-223FC9A27959
//        public Task<TransitAlert> PatchTransitAlert(string id, Delta<TransitAlert> patch)
//        {
//             return UpdateAsync(id, patch);
//        }
//
//        // POST tables/TransitAlert/48D68C86-6EA6-4C25-AA33-223FC9A27959
//        public async Task<IHttpActionResult> PostTransitAlert(TransitAlert item)
//        {
//            TransitAlert current = await InsertAsync(item);
//            return CreatedAtRoute("Tables", new { id = current.Id }, current);
//        }
//
//        // DELETE tables/TransitAlert/48D68C86-6EA6-4C25-AA33-223FC9A27959
//        public Task DeleteTransitAlert(string id)
//        {
//             return DeleteAsync(id);
//        }
        
        public IEnumerable<TransitAlert> GetAlertsForStations( string stationsCsv)
        {
            var dbConnStr = ConfigurationManager.ConnectionStrings["MTA_DB"].ConnectionString;

            var alertsForStations = new List<TransitAlert>();

            List<string> stations = stationsCsv.Split(',').ToList();


            if (null == stations || stations.Count == 0)
            {
                return alertsForStations;
            }

            using (SqlConnection conn = new SqlConnection(dbConnStr))
            {

                conn.Open();

                StringBuilder sb = new StringBuilder();

                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    string sql = "SELECT * FROM SubwaySchedule WHERE ArrivalTime BETWEEN @from AND @to AND StationId IN ({0})";
                    string[] paramArray = stations.Select((x, i) => "@stn" + i).ToArray();
                    cmd.CommandText = string.Format(sql, string.Join(",", paramArray));

                    cmd.Parameters.Add(new SqlParameter("@from", DateTime.Now));
                    cmd.Parameters.Add(new SqlParameter("@to", DateTime.Now.AddMinutes(30)));


                    for (int i = 0; i < stations.Count; ++i)
                    {
                        cmd.Parameters.Add(new SqlParameter("@stn" + i, stations[i]));
                    }

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            alertsForStations.Add(ReadTransitAlert(reader));
                        }
                    }
                }
            }

           
            return alertsForStations;
        }

        private static TransitAlert ReadTransitAlert(SqlDataReader reader)
        {
            return new TransitAlert()
            {
                TripId =  reader.GetFieldValue<string>(reader.GetOrdinal("TripId")),
                StationId = reader.GetFieldValue<string>(reader.GetOrdinal("StationId")),
                RouteId = reader.GetFieldValue<string>(reader.GetOrdinal("RouteId")),
                RouteName = reader.GetFieldValue<string>(reader.GetOrdinal("RouteName")),
                StationName = reader.GetFieldValue<string>(reader.GetOrdinal("StationName")),
                ArrivalTime = reader.GetFieldValue<DateTime>(reader.GetOrdinal("ArrivalTime")),
                ArrivalTimeSeconds = reader.GetFieldValue<int>(reader.GetOrdinal("ArrivalTimeSeconds")),
                Direction = reader.GetFieldValue<string>(reader.GetOrdinal("Direction")),
                DestinationStationId = reader.GetFieldValue<string>(reader.GetOrdinal("DestinationStationId")),
                IsRealtime = reader.GetFieldValue<bool>(reader.GetOrdinal("IsRealtime")),

            };
        }

        [HttpPost]
        public IEnumerable<TransitAlert> GetSchedule([FromBody] List<Follow> follows)
        {
             var dbConnStr = ConfigurationManager.ConnectionStrings["MTA_DB"].ConnectionString;

            var schedule = new List<TransitAlert>();


            if (null == follows || follows.Count == 0)
            {
                return schedule;
            }

            var query = new DataTable();

            query.Columns.Add("StationId", typeof (string));
            query.Columns.Add("RouteId", typeof(string));

            foreach (var follow in follows)
            {
                query.Rows.Add(follow.StationId, follow.LineId);
            }

            using (SqlConnection conn = new SqlConnection(dbConnStr))
            {

                conn.Open();

                using (var cmd = new SqlCommand("sp_GetSubwaySchedule", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;



                    TimeZoneInfo easternZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
                    DateTime easternTimeNow = TimeZoneInfo.ConvertTime(DateTime.UtcNow, TimeZoneInfo.Utc,
                                                                    easternZone);


                    SqlParameter tvpParam = cmd.Parameters.AddWithValue("@query", query); //Needed TVP
                    tvpParam.SqlDbType = SqlDbType.Structured; //tells ADO.NET we are passing TVP


                    cmd.Parameters.AddWithValue("@startTime", easternTimeNow);
                    cmd.Parameters.AddWithValue("@endtime", easternTimeNow.AddMinutes(30));


                    

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            schedule.Add(ReadTransitAlert(reader));
                        }
                    }
                }
            }
            return schedule;
        }
    }
}