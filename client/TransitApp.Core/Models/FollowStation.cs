using System;
using System.Collections.Generic;
using System.Linq;

namespace TransitApp.Core.Models
{
    public class FollowStation
    {
        public Station Station { get; set; }

        public ICollection<FollowLine> Lines { get; set; }
    }
}
