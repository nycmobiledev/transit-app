using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TransitApp.Core.Models
{
     public class Station
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Area { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }        
                 
        public ICollection<Line> Lines { get; set; }

        [Obsolete]
        public bool IsFollowing { get; set; }

        public override int GetHashCode()
        {
            return ("Station-" + Id).GetHashCode();
        }
        public override bool Equals(object obj)
        {
            if (obj is Station)
            {
                return this.Id == (obj as Station).Id;

            }
            else
            {
                return false;
            }

        }
    }
}
