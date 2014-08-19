using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TransitApp.Core.Models;

namespace TransitApp.Core.Services
{
    public interface IFollowService
    {
        ICollection<Follow> GetFollows();
        FollowStation GetFollowStation(string stationId);
        ICollection<FollowStation> GetFollowsStations();


        void AddFollows(string stationId, string[] lineIds);

        void DeleteFollows(string stationId, string[] lineIds = null);
    }
}