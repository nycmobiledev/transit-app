using System;
using System.Collections.Generic;
using System.Linq;
using Cirrious.MvvmCross.Community.Plugins.Sqlite;

namespace TransitApp.Core.Models
{
	[Table("Lines")]
    public class Line
    {
        [PrimaryKey]
        public virtual string Id { get; set; }

        public virtual string Name { get; set; }

        public virtual string LongName { get; set; }

        public virtual string Description { get; set; }

        public virtual string Start { get; set; }

        public virtual string End { get; set; }
    }
}