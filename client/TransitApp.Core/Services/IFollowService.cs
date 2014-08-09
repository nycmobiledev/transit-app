using Cirrious.MvvmCross.Community.Plugins.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TransitApp.Core.Models;

namespace TransitApp.Core.Services
{
    public interface IFollowService
    {
        ICollection<Station> GetFollows();
        void AddFollow(Station station);

        void DeleteFollow(Station station);
    }
}