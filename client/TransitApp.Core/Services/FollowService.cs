using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TransitApp.Core.Models;

namespace TransitApp.Core.Services
{
	public class FollowService : IFollowService
	{
		private readonly ILocalDbService _localDbService;

		public FollowService (ILocalDbService localDbService)
		{
			_localDbService = localDbService;
		}

		public ICollection<Follow> GetFollows ()
		{
			var follows = _localDbService.GetFollows ();

			return follows;
		}

		public void AddFollows (string stationId, string[] lineIds)
		{
			foreach (var lineId in lineIds) {
				_localDbService.Connection.InsertOrReplace (new Follow (){ StationId = stationId, LineId = lineId });
			}
		}

		public void DeleteFollows (string stationId, string[] lineIds)
		{
			if (lineIds == null || lineIds.Length == 0) {
				_localDbService.Connection.Execute ("DELETE FROM Follows WHERE StationId=@1", stationId);
			} else {
				foreach (var lineId in lineIds) {
					_localDbService.Connection.Delete (new Follow (){ StationId = stationId, LineId = lineId });                    
				}
			}			
		}
	}
}
