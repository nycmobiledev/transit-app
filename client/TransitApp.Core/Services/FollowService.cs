using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TransitApp.Core.Models;

namespace TransitApp.Core.Services
{
    public class FollowService : IFollowService
    {
        private readonly ILocalDataService _localDbService;

        public FollowService(ILocalDataService localDbService)
        {
            _localDbService = localDbService;
        }

        public ICollection<Follow> GetFollows()
        {
            //var follows = _localDbService.GetFollows();

            //return follows;

            throw new NotImplementedException();
        }

        //public ICollection<Follow> GetFollows()
        //{
        //    var follows = Connection.Table<Follow>().ToList();

        //    foreach (var follow in follows)
        //    {
        //        follow.Line = this.Get<Line>(follow.LineId);
        //        follow.Station = this.Get<Station>(follow.StationId);
        //    }

        //    return follows;
        //}

        public ICollection<FollowStation> GetFollowsGroupByStation()
        {
            throw new NotImplementedException();

            //var follows = _localDbService.GetFollows();
            //var followStations = new List<FollowStation>();

            //var i = follows.GroupBy(x => x.Station).Count();

            //foreach (var followGroup in follows.GroupBy(x => x.Station))
            //{
            //    var fs = new FollowStation() { Station = followGroup.Key };
            //    fs.Lines = new List<FollowLine>();

            //    foreach (var line in followGroup.Key.Lines)
            //    {
            //        fs.Lines.Add(new FollowLine()
            //        {
            //            Line = line,
            //            IsFollow = followGroup.Any(x => x.LineId == line.Id)
            //        });
            //    }

            //    followStations.Add(fs);
            //}

            //return followStations;
        }

        public void AddFollows(string stationId, string[] lineIds)
        {
            foreach (var lineId in lineIds)
            {
                //_localDbService.Connection.InsertOrReplace(new Follow() { StationId = stationId, LineId = lineId });
            }
        }

        public void DeleteFollows(string stationId, string[] lineIds = null)
        {
            if (lineIds == null || lineIds.Length == 0)
            {
                //_localDbService.Connection.Execute("DELETE FROM Follows WHERE StationId=@1", stationId);
            }
            else
            {
                foreach (var lineId in lineIds)
                {
                    //_localDbService.Connection.Delete(new Follow() { StationId = stationId, LineId = lineId });
                }
            }
        }
    }
}
