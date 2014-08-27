using Microsoft.WindowsAzure.Mobile.Service;
using Microsoft.WindowsAzure.Mobile.Service.Tables;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Models;
using System.Data.SqlClient;
using System.Data;

namespace WebApi.ScheduledJobs
{
    public class GetRTTransitInfo : ScheduledJob
    {
        public override Task ExecuteAsync()
        {            
            SqlConnection sqlConn = new SqlConnection("MS_TransitAppDBConnectionString");
            SqlCommand sqlComm = new SqlCommand();            

            var sql_station = "select * from [transitRAWdb].[dbo].[station]";
            var sql_stops = "select * from [transitRAWdb].[dbo].[stops]";
            var sql_transfers = "select * from [transitRAWdb].[dbo].[transfers]";
            var sql_trips = "select * from [transitRAWdb].[dbo].[trips]";
            var sql_shapes = "select * from [transitRAWdb].[dbo].[shapes]";
            var sql_routes = "select * from [transitRAWdb].[dbo].[routes]";
            var sql_stationStops = "select * from [transitRAWdb].[dbo].[station_stops]";
            var sql_stationRoutes = "select * from [transitRAWdb].[dbo].[station_routes]";
            var sql_stopTimes = "select * from [transitRAWdb].[dbo].[stop_times]";
            var sql_rtTrips = "select * from [transitRAWdb].[dbo].[realtime_trips]";
            var sql_rtAlerts = "select * from [transitRAWdb].[dbo].[realtime_alerts]";

            SqlDataAdapter stations_adapter = new SqlDataAdapter(sql_station, sqlConn);
            SqlDataAdapter stops_adapter = new SqlDataAdapter(sql_stops, sqlConn);
            SqlDataAdapter transfers_adapter = new SqlDataAdapter(sql_transfers, sqlConn);
            SqlDataAdapter trips_adapter = new SqlDataAdapter(sql_trips, sqlConn);
            SqlDataAdapter shapes_adapter = new SqlDataAdapter(sql_shapes, sqlConn);
            SqlDataAdapter routes_adapter = new SqlDataAdapter(sql_routes, sqlConn);
            SqlDataAdapter stationstops_adapter = new SqlDataAdapter(sql_stationStops, sqlConn);
            SqlDataAdapter stationroutes_adapter = new SqlDataAdapter(sql_stationRoutes, sqlConn);
            SqlDataAdapter stoptimes_adapter = new SqlDataAdapter(sql_stopTimes, sqlConn);
            SqlDataAdapter realtimetrips_adapter = new SqlDataAdapter(sql_rtTrips, sqlConn);
            SqlDataAdapter realtimealerts_adapter = new SqlDataAdapter(sql_rtAlerts, sqlConn);

            DataSet transitRawData = new DataSet();

            stations_adapter.Fill(transitRawData, "station");
            stops_adapter.Fill(transitRawData, "stops");
            transfers_adapter.Fill(transitRawData, "transfers");
            trips_adapter.Fill(transitRawData, "trips");
            shapes_adapter.Fill(transitRawData, "shapes");
            routes_adapter.Fill(transitRawData, "routes");
            stationstops_adapter.Fill(transitRawData, "stationstops");
            stationroutes_adapter.Fill(transitRawData, "stationroutes");
            stoptimes_adapter.Fill(transitRawData, "stoptimes");
            realtimetrips_adapter.Fill(transitRawData, "realtimetrips");
            realtimealerts_adapter.Fill(transitRawData, "realtimealerts");

            var query = from stationdata in transitRawData.Tables["station"].AsEnumerable()
                        join stationstopdata in transitRawData.Tables["stationstops"].AsEnumerable()
                        on stationdata.Field<string>("station_id") equals stationstopdata.Field<string>("station_id")
                        join stopdata in transitRawData.Tables["stops"].AsEnumerable()
                        on stationstopdata.Field<string>("stop_id") equals stopdata.Field<string>("stop_id");

            throw new NotImplementedException();
        }
    }
}