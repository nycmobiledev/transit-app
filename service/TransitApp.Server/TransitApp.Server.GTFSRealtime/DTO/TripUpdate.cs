using System;
using System.Collections.Generic;
using System.ComponentModel;
using ProtoBuf;

namespace TransitApp.Server.GTFSRealtime.DTO
{
    [Serializable, ProtoContract(Name = @"TripUpdate")]
    public class TripUpdate : IExtensible
    {
        private readonly List<StopTimeUpdate> _stopTimeUpdate = new List<StopTimeUpdate>();
        private IExtension _extensionObject;
        private ulong _timestamp = default(ulong);
        private TripDescriptor _trip;

        private VehicleDescriptor _vehicle;

        [ProtoMember(1, IsRequired = true, Name = @"trip", DataFormat = DataFormat.Default)]
        public TripDescriptor Trip
        {
            get { return _trip; }
            set { _trip = value; }
        }

        [ProtoMember(3, IsRequired = false, Name = @"vehicle", DataFormat = DataFormat.Default)]
        [DefaultValue(null)]
        public VehicleDescriptor Vehicle
        {
            get { return _vehicle; }
            set { _vehicle = value; }
        }

        [ProtoMember(2, Name = @"stop_time_update", DataFormat = DataFormat.Default)]
        public List<StopTimeUpdate> StopTimeUpdates
        {
            get { return _stopTimeUpdate; }
        }

        [ProtoMember(4, IsRequired = false, Name = @"timestamp", DataFormat = DataFormat.TwosComplement)]
        [DefaultValue(default(ulong))]
        public ulong Timestamp
        {
            get { return _timestamp; }
            set { _timestamp = value; }
        }

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref _extensionObject, createIfMissing);
        }

        [Serializable, ProtoContract(Name = @"StopTimeEvent")]
        public class StopTimeEvent : IExtensible
        {
            private int _delay = default(int);
            private IExtension _extensionObject;

            private long _time = default(long);

            private int _uncertainty = default(int);

            [ProtoMember(1, IsRequired = false, Name = @"delay", DataFormat = DataFormat.TwosComplement)]
            [DefaultValue(default(int))]
            public int Delay
            {
                get { return _delay; }
                set { _delay = value; }
            }

            [ProtoMember(2, IsRequired = false, Name = @"time", DataFormat = DataFormat.TwosComplement)]
            [DefaultValue(default(long))]
            public long Time
            {
                get { return _time; }
                set { _time = value; }
            }

            [ProtoMember(3, IsRequired = false, Name = @"uncertainty", DataFormat = DataFormat.TwosComplement)]
            [DefaultValue(default(int))]
            public int Uncertainty
            {
                get { return _uncertainty; }
                set { _uncertainty = value; }
            }

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref _extensionObject, createIfMissing);
            }
        }

        [Serializable, ProtoContract(Name = @"StopTimeUpdate")]
        public class StopTimeUpdate : IExtensible
        {
            [ProtoContract(Name = @"ScheduleRelationship")]
            public enum ScheduleRelationshipEnum
            {
                [ProtoEnum(Name = @"SCHEDULED", Value = 0)] SCHEDULED = 0,

                [ProtoEnum(Name = @"SKIPPED", Value = 1)] SKIPPED = 1,

                [ProtoEnum(Name = @"NO_DATA", Value = 2)] NO_DATA = 2
            }

            private StopTimeEvent _arrival;
            private StopTimeEvent _departure;
            private IExtension _extensionObject;
            private NyctStopTimeUpdate _nyctStopTimeUpdate;
            private ScheduleRelationshipEnum _scheduleRelationship = ScheduleRelationshipEnum.SCHEDULED;
            private string _stopId = "";

            private uint _stopSequence = default(uint);

            [ProtoMember(1, IsRequired = false, Name = @"stop_sequence", DataFormat = DataFormat.TwosComplement)]
            [DefaultValue(default(uint))]
            public uint StopSequence
            {
                get { return _stopSequence; }
                set { _stopSequence = value; }
            }

            [ProtoMember(4, IsRequired = false, Name = @"stop_id", DataFormat = DataFormat.Default)]
            [DefaultValue("")]
            public string StopId
            {
                get { return _stopId; }
                set { _stopId = value; }
            }

            [ProtoMember(2, IsRequired = false, Name = @"arrival", DataFormat = DataFormat.Default)]
            [DefaultValue(null)]
            public StopTimeEvent Arrival
            {
                get { return _arrival; }
                set { _arrival = value; }
            }

            [ProtoMember(3, IsRequired = false, Name = @"departure", DataFormat = DataFormat.Default)]
            [DefaultValue(null)]
            public StopTimeEvent Departure
            {
                get { return _departure; }
                set { _departure = value; }
            }

            [ProtoMember(5, IsRequired = false, Name = @"schedule_relationship", DataFormat = DataFormat.TwosComplement)
            ]
            [DefaultValue(ScheduleRelationshipEnum.SCHEDULED)]
            public ScheduleRelationshipEnum ScheduleRelationship
            {
                get { return _scheduleRelationship; }
                set { _scheduleRelationship = value; }
            }

            [ProtoMember(1001, IsRequired = false, Name = @"nyct_stop_time_update", DataFormat = DataFormat.Default)]
            [DefaultValue(null)]
            public NyctStopTimeUpdate NyctStopTimeUpdate
            {
                get { return _nyctStopTimeUpdate; }
                set { _nyctStopTimeUpdate = value; }
            }

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref _extensionObject, createIfMissing);
            }
        }
    }
}