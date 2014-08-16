using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace TransitApp.Core.Models
{
    public class Follow
    {
        [JsonIgnore]
        public string Id
        {
            get
            {
                return String.Format("{0}-{1}", StationId, LineId);
            }
        }

        public string StationId { get; set; }

        public string LineId { get; set; }

        [JsonIgnore]
        public Station Station { get; set; }

        [JsonIgnore]
        public Line Line { get; set; }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public override string ToString()
        {
            return Id;
        }

        public override bool Equals(object obj)
        {
            if (obj is Follow)
            {
                return Id.Equals((obj as Follow).Id);
            }
            else
            {
                return false;
            }
        }
    }
}