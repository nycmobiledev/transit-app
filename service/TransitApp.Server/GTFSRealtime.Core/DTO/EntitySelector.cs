using System;
using System.ComponentModel;
using ProtoBuf;

namespace TransitApp.Server.GTFSRealtime.Core.DTO
{
    [Serializable, ProtoContract(Name = @"EntitySelector")]
    public class EntitySelector : IExtensible
    {
        private string _agencyId = "";
        private IExtension _extensionObject;

        private string _routeId = "";

        private int _routeType = default(int);
        private string _stopId = "";

        private TripDescriptor _trip;

        [ProtoMember(1, IsRequired = false, Name = @"agency_id", DataFormat = DataFormat.Default)]
        [DefaultValue("")]
        public string AgencyId
        {
            get { return _agencyId; }
            set { _agencyId = value; }
        }

        [ProtoMember(2, IsRequired = false, Name = @"route_id", DataFormat = DataFormat.Default)]
        [DefaultValue("")]
        public string RouteId
        {
            get { return _routeId; }
            set { _routeId = value; }
        }

        [ProtoMember(3, IsRequired = false, Name = @"route_type", DataFormat = DataFormat.TwosComplement)]
        [DefaultValue(default(int))]
        public int RouteType
        {
            get { return _routeType; }
            set { _routeType = value; }
        }

        [ProtoMember(4, IsRequired = false, Name = @"trip", DataFormat = DataFormat.Default)]
        [DefaultValue(null)]
        public TripDescriptor Trip
        {
            get { return _trip; }
            set { _trip = value; }
        }

        [ProtoMember(5, IsRequired = false, Name = @"stop_id", DataFormat = DataFormat.Default)]
        [DefaultValue("")]
        public string StopId
        {
            get { return _stopId; }
            set { _stopId = value; }
        }

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref _extensionObject, createIfMissing);
        }
    }
}