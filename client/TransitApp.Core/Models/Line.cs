using System;
using System.Collections.Generic;
using System.Linq;

namespace TransitApp.Core.Models
{	
    public class Line
    {
        public virtual string Id { get; set; }

        public virtual string Name { get; set; }        

        public virtual string Description { get; set; }

        public virtual string Start { get; set; }

        public virtual string End { get; set; }
    }
}