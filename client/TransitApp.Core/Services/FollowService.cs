using Cirrious.CrossCore;
using Cirrious.MvvmCross.Plugins.File;
using Cirrious.MvvmCross.Plugins.Messenger;
using Newtonsoft.Json;
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
        private IMvxFileStore _fileService;
        private HashSet<Follow> _follows;
        private const string _customerFollowFilePath = "CustomerFollow.json";
        private readonly IMvxMessenger _messenger;

        public FollowService(IMvxFileStore fileService, ILocalDataService localDbService, IMvxMessenger messenger)
        {
            _messenger = messenger;
            _localDbService = localDbService;
            _fileService = fileService;

            ReadFollows();
        }

        public ICollection<Follow> GetFollows()
        {
            return _follows;
        }

        public FollowStation GetFollowStation(string stationId)
        {
            var fs = new FollowStation() { Station = _localDbService.GetStation(stationId), 
                Lines = new List<FollowLine>() };

            foreach (var line in fs.Station.Lines)
            {
                fs.Lines.Add(new FollowLine()
                {
                    Line = line,
                    IsFollowed = _follows.Any(x => x.StationId == stationId && x.LineId == line.Id)
                });
            }

            return fs;
        }

        public ICollection<FollowStation> GetFollowsStations()
        {
            //Match Station.Lines and User.Follows.Lines

            var followStations = new List<FollowStation>();

            foreach (var followGroup in _follows.GroupBy(x => x.Station))
            {
                var fs = new FollowStation()
                {
                    Station = followGroup.Key,
                    Lines = new List<FollowLine>()
                };

                foreach (var line in followGroup.Key.Lines)
                {
                    fs.Lines.Add(new FollowLine()
                    {
                        Line = line,
                        IsFollowed = followGroup.Any(x => x.LineId == line.Id)
                    });
                }

                followStations.Add(fs);
            }

            return followStations;
        }


        public void AddFollows(string stationId, string[] lineIds)
        {
            //Delete First
            foreach (var follow in _follows.Where(x => x.StationId == stationId).ToArray())
            {
                _follows.Remove(follow);
            }

            foreach (var lineId in lineIds)
            {
                _follows.Add(new Follow()
                {
                    StationId = stationId,
                    Station = _localDbService.GetStation(stationId),
                    LineId = lineId,
                    Line = _localDbService.GetLine(lineId)
                });
            }

            WriteFollows();
        }

        public void DeleteFollows(string stationId, string[] lineIds = null)
        {
            if (lineIds == null || lineIds.Length == 0)
            {
                foreach (var follow in _follows.Where(x => x.StationId == stationId).ToArray())
                {
                    _follows.Remove(follow);
                }
            }
            else
            {
                foreach (var follow in _follows.Where(x => x.StationId == stationId && lineIds.Contains(x.LineId)).ToArray())
                {
                    _follows.Remove(follow);
                }
            }

            WriteFollows();
        }

        private void ReadFollows()
        {
            string json;
            if (_fileService.TryReadTextFile(_customerFollowFilePath, out json))
            {
                _follows = JsonConvert.DeserializeObject<HashSet<Follow>>(json);

                foreach (var item in _follows)
                {
                    item.Station = _localDbService.GetStation(item.StationId);
                    item.Line = _localDbService.GetLine(item.LineId);
                }
            }
            else
            {
                _follows = new HashSet<Follow>();
            }
        }

        private void WriteFollows()
        {
            var json = JsonConvert.SerializeObject(_follows);
            _fileService.WriteFile(_customerFollowFilePath, json);

            _messenger.Publish(new FollowsChanged(this));
        }
    }
}
