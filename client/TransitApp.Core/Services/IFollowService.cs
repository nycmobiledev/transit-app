using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TransitApp.Core.Models;

namespace TransitApp.Core.Services
{
    public interface IFollowService
    {
        ICollection<FollowStation> GetFollowsGroupByStation();
        ICollection<Follow> GetFollows();

        void AddFollows(string stationId, string[] lineIds);

        void DeleteFollows(string stationId, string[] lineIds = null);
    }
}