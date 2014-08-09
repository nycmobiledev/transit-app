using System;
using System.Collections.Generic;
using System.Linq;
using Cirrious.MvvmCross.Community.Plugins.Sqlite;

namespace TransitApp.Core.Models
{
	[Table("Follows")]
	public class Follow
	{
		public string StationId { get; set; }

        public string LineId { get; set; }		
	}
}
