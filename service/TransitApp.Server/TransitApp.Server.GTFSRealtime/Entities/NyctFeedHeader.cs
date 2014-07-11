using System;
using System.Collections.Generic;
using ProtoBuf;

namespace TransitApp.Server.GTFSRealtime.Entities
{
    [Serializable, ProtoContract(Name = @"NyctFeedHeader")]
    public class NyctFeedHeader : IExtensible
    {
        private readonly List<TripReplacementPeriod> _tripReplacementPeriod = new List<TripReplacementPeriod>();
        private IExtension _extensionObject;
        private string _nyctSubwayVersion;

        [ProtoMember(1, IsRequired = true, Name = @"nyct_subway_version", DataFormat = DataFormat.Default)]
        public string NyctSubwayVersion
        {
            get { return _nyctSubwayVersion; }
            set { _nyctSubwayVersion = value; }
        }

        [ProtoMember(2, Name = @"trip_replacement_period", DataFormat = DataFormat.Default)]
        public List<TripReplacementPeriod> TripReplacementPeriod
        {
            get { return _tripReplacementPeriod; }
        }

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref _extensionObject, createIfMissing);
        }
    }
}