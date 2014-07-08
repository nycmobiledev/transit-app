using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TransitApp.Core.Models;

namespace TransitApp.Core.Services
{
    public interface _IGtfsService
    {
		List<Stop> GetNearbyStops(double lat,double lon);
    }

	public interface ILocalRpository
	{
		List<Stop> GetNearbyStops(double lat,double lon);
	}
}
