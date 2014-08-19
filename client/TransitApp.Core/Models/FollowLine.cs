using System;
using System.Collections.Generic;
using System.Linq;

namespace TransitApp.Core.Models
{
    public class FollowLine
    {
        public Line Line { get; set; }

        public bool IsFollowed { get; set; }
    }
}
