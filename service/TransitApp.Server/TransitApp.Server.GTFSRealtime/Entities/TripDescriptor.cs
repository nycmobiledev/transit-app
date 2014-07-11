using System;
using System.ComponentModel;
using ProtoBuf;

namespace TransitApp.Server.GTFSRealtime.Entities
{
    [Serializable, ProtoContract(Name = @"TripDescriptor")]
    public class TripDescriptor : IExtensible
    {
        [ProtoContract(Name = @"ScheduleRelationship")]
        public enum ScheduleRelationshipEnum
        {
            [ProtoEnum(Name = @"SCHEDULED", Value = 0)] SCHEDULED = 0,

            [ProtoEnum(Name = @"ADDED", Value = 1)] ADDED = 1,

            [ProtoEnum(Name = @"UNSCHEDULED", Value = 2)] UNSCHEDULED = 2,

            [ProtoEnum(Name = @"CANCELED", Value = 3)] CANCELED = 3
        }

        private IExtension _extensionObject;

        private NyctTripDescriptor _nyctTripDescriptor;
        private string _routeId = "";
        private ScheduleRelationshipEnum _scheduleRelationship = ScheduleRelationshipEnum.SCHEDULED;
        private string _startDate = "";
        private string _startTime = "";

        private string _tripId = "";

        [ProtoMember(1, IsRequired = false, Name = @"trip_id", DataFormat = DataFormat.Default)]
        [DefaultValue("")]
        public string TripId
        {
            get { return _tripId; }
            set { _tripId = value; }
        }

        [ProtoMember(5, IsRequired = false, Name = @"route_id", DataFormat = DataFormat.Default)]
        [DefaultValue("")]
        public string RouteId
        {
            get { return _routeId; }
            set { _routeId = value; }
        }

        [ProtoMember(2, IsRequired = false, Name = @"start_time", DataFormat = DataFormat.Default)]
        [DefaultValue("")]
        public string StartTime
        {
            get { return _startTime; }
            set { _startTime = value; }
        }

        [ProtoMember(3, IsRequired = false, Name = @"start_date", DataFormat = DataFormat.Default)]
        [DefaultValue("")]
        public string StartDate
        {
            get { return _startDate; }
            set { _startDate = value; }
        }

        [ProtoMember(4, IsRequired = false, Name = @"schedule_relationship", DataFormat = DataFormat.TwosComplement)]
        [DefaultValue(ScheduleRelationshipEnum.SCHEDULED)]
        public ScheduleRelationshipEnum ScheduleRelationship
        {
            get { return _scheduleRelationship; }
            set { _scheduleRelationship = value; }
        }

        [ProtoMember(1001, IsRequired = false, Name = @"nyct_trip_descriptor", DataFormat = DataFormat.Default)]
        [DefaultValue(null)]
        public NyctTripDescriptor NyctTripDescriptor
        {
            get { return _nyctTripDescriptor; }
            set { _nyctTripDescriptor = value; }
        }

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref _extensionObject, createIfMissing);
        }
    }
}