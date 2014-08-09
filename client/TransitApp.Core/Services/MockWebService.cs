using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TransitApp.Core.Models;

namespace TransitApp.Core.Services
{
    public class MockWebService : IWebService
    {
        public IList<Station> FindStationsByName(string name)
        {
            var list = new List<Station>();

            return list;
        }
        public IList<Alert> GetAlerts(Follow[] follows)
        {
            var list = new List<Alert>();

            list.Add(new Alert()
            {
                TrainId = "1234",
                ArriveTime = DateTime.Now.AddMinutes(5),
                Station = new Station() { Id = "717", Name = "Main - Flushing" },
                Line = new Line() { Id = "7", Start = "Time-Sq", End = "Flushing", Name = "7" }
            });

            return list;
        }
    }
}