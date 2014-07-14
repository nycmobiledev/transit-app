using System;
using System.ComponentModel;
using ProtoBuf;

namespace TransitApp.Server.GTFSRealtime.DTO
{
    [Serializable, ProtoContract(Name = @"TripReplacementPeriod")]
    public class TripReplacementPeriod : IExtensible
    {
        private IExtension _extensionObject;
        private TimeRange _replacementPeriod;
        private string _routeId = "";

        [ProtoMember(1, IsRequired = false, Name = @"route_id", DataFormat = DataFormat.Default)]
        [DefaultValue("")]
        public string RouteId
        {
            get { return _routeId; }
            set { _routeId = value; }
        }

        [ProtoMember(2, IsRequired = false, Name = @"replacement_period", DataFormat = DataFormat.Default)]
        [DefaultValue(null)]
        public TimeRange ReplacementPeriod
        {
            get { return _replacementPeriod; }
            set { _replacementPeriod = value; }
        }

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref _extensionObject, createIfMissing);
        }
    }
}