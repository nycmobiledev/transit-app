﻿using System;
using System.Data.SqlClient;
using NUnit.Framework;
using TransitApp.Server.GTFSRealtime.Core.Model;
using TransitApp.Server.GTFSRealtime.Core.Services;
using TransitApp.Server.GTFSRealtime.Infrastructure.Data;
using TransitApp.Server.GTFSRealtime.Infrastructure.MTA;

namespace TransitApp.Server.GTFSRealtime.IntegrationTests.DataLoader
{
    [TestFixture]
    internal class DataLoaderTests
    {
        private string _combinedUrl;
        private FeedMessageService _mtaFeedService;
        private const string ApiKey = "<INSERT API KEY>";
        private const string Url = "http://datamine.mta.info/mta_esi.php?key={0}&feed_id=";

        /*private const string DbConnStr =
            "Server=tcp:tei624ww1k.database.windows.net,1433;Database=mta_nyc_subway;User ID=nymobile.net@tei624ww1k;Password=NYCm0b1l3;Trusted_Connection=False;Encrypt=True;Connection Timeout=30;";
        */

        private const string DbConnStr =
            @"Server=localhost\SQLEXPRESS;Database=mta_nyc_subway;User ID=nymobile.net@tei624ww1k;Password=NYCm0b1l3";

        private SqlConnection _connection = null;

        [TestFixtureSetUp]
        public void SetupTestFixture()
        {
            _combinedUrl = string.Format(Url, ApiKey);
            _mtaFeedService = new FeedMessageService(_combinedUrl);

            _connection = new SqlConnection(DbConnStr);    
        }

        [Test, Ignore]
        public async void Should_Fill_Alerts_Table()
        {
            var msgL = await _mtaFeedService.GetCurrentRealtimeFeedMessage(SubwayLines.L);
            var msgIrt = await _mtaFeedService.GetCurrentRealtimeFeedMessage(SubwayLines.RED_GREEN_S);

            var alertFactory = new AlertFactory();
            var alertsIrt = alertFactory.CreateItemsFromFeedMessage(msgIrt);
            var alertsL = alertFactory.CreateItemsFromFeedMessage(msgL);

            // Clear Tables
            using (var alertRepos = new AlertRepository() { Connection = _connection })
            {
                alertRepos.ClearAll();

                // Load Tables
                alertRepos.AddRange(alertsIrt);
                alertRepos.AddRange(alertsL);
            }
        }

        [Test]
        public async void Should_Fill_All_Tables()
        {
            var msgL = await _mtaFeedService.GetCurrentRealtimeFeedMessage(SubwayLines.L);
            var msgIrt = await _mtaFeedService.GetCurrentRealtimeFeedMessage(SubwayLines.RED_GREEN_S);

            var alertFactory = new AlertFactory();
            var stopTimeFactory = new StopTimeUpdateFactory();
            var tripFactory = new TripFactory();
            var vehicleFactory = new VehiclePositionFactory();

            var alertsIrt = alertFactory.CreateItemsFromFeedMessage(msgIrt);
            var alertsL = alertFactory.CreateItemsFromFeedMessage(msgL);

            using (var alertRepos = new AlertRepository() { Connection = _connection })
            {
                // Clear Tables
                alertRepos.ClearAll();

                // Load Tables
                alertRepos.AddRange(alertsIrt);
                alertRepos.AddRange(alertsL);
            }

            var stopsIrt = stopTimeFactory.CreateItemsFromFeedMessage(msgIrt);
            var stopsL = stopTimeFactory.CreateItemsFromFeedMessage(msgL);

            using (var stopsRepos = new StopTimeUpdateRepository() { Connection = _connection })
            {
                // Clear Tables
                stopsRepos.ClearAll();

                // Load Tables
                stopsRepos.AddRange(stopsIrt);
                stopsRepos.AddRange(stopsL);
            }

            var tripsIrt = tripFactory.CreateItemsFromFeedMessage(msgIrt);
            var tripsL = tripFactory.CreateItemsFromFeedMessage(msgL);

            using (var tripsRepos = new TripRepository() { Connection = _connection })
            {
                // Clear Tables
                tripsRepos.ClearAll();

                // Load Tables
                tripsRepos.AddRange(tripsIrt);
                tripsRepos.AddRange(tripsL);
            }

            var vehiclesIrt = vehicleFactory.CreateItemsFromFeedMessage(msgIrt);
            var vehiclesL = vehicleFactory.CreateItemsFromFeedMessage(msgL);

            using (var vehiclesRepos = new VehiclePositionRepository() { Connection = _connection }) {
                // Clear Tables
                vehiclesRepos.ClearAll();

                // Load Tables
                vehiclesRepos.AddRange(vehiclesIrt);
                vehiclesRepos.AddRange(vehiclesL);
            }
        }
    }
}