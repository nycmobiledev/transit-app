using System;
using System.ComponentModel;
using ProtoBuf;

namespace TransitApp.Server.GTFSRealtime.DTO
{
    [Serializable, ProtoContract(Name = @"VehiclePosition")]
    public class VehiclePosition : IExtensible
    {
        [ProtoContract(Name = @"CongestionLevel")]
        public enum CongestionLevel
        {
            [ProtoEnum(Name = @"UNKNOWN_CONGESTION_LEVEL", Value = 0)] UNKNOWN_CONGESTION_LEVEL = 0,

            [ProtoEnum(Name = @"RUNNING_SMOOTHLY", Value = 1)] RUNNING_SMOOTHLY = 1,

            [ProtoEnum(Name = @"STOP_AND_GO", Value = 2)] STOP_AND_GO = 2,

            [ProtoEnum(Name = @"CONGESTION", Value = 3)] CONGESTION = 3,

            [ProtoEnum(Name = @"SEVERE_CONGESTION", Value = 4)] SEVERE_CONGESTION = 4
        }

        [ProtoContract(Name = @"VehicleStopStatus")]
        public enum VehicleStopStatus
        {
            [ProtoEnum(Name = @"INCOMING_AT", Value = 0)] INCOMING_AT = 0,

            [ProtoEnum(Name = @"STOPPED_AT", Value = 1)] STOPPED_AT = 1,

            [ProtoEnum(Name = @"IN_TRANSIT_TO", Value = 2)] IN_TRANSIT_TO = 2
        }

        private CongestionLevel _congestionLevel = CongestionLevel.UNKNOWN_CONGESTION_LEVEL;
        private VehicleStopStatus _currentStatus = VehicleStopStatus.IN_TRANSIT_TO;
        private uint _currentStopSequence = default(uint);
        private IExtension _extensionObject;
        private Position _position;
        private string _stopId = "";
        private ulong _timestamp = default(ulong);

        private TripDescriptor _trip;

        private VehicleDescriptor _vehicle;

        [ProtoMember(1, IsRequired = false, Name = @"trip", DataFormat = DataFormat.Default)]
        [DefaultValue(null)]
        public TripDescriptor Trip
        {
            get { return _trip; }
            set { _trip = value; }
        }

        [ProtoMember(8, IsRequired = false, Name = @"vehicle", DataFormat = DataFormat.Default)]
        [DefaultValue(null)]
        public VehicleDescriptor Vehicle
        {
            get { return _vehicle; }
            set { _vehicle = value; }
        }

        [ProtoMember(2, IsRequired = false, Name = @"position", DataFormat = DataFormat.Default)]
        [DefaultValue(null)]
        public Position Position
        {
            get { return _position; }
            set { _position = value; }
        }

        [ProtoMember(3, IsRequired = false, Name = @"current_stop_sequence", DataFormat = DataFormat.TwosComplement)]
        [DefaultValue(default(uint))]
        public uint CurrentStopSequence
        {
            get { return _currentStopSequence; }
            set { _currentStopSequence = value; }
        }

        [ProtoMember(7, IsRequired = false, Name = @"stop_id", DataFormat = DataFormat.Default)]
        [DefaultValue("")]
        public string StopId
        {
            get { return _stopId; }
            set { _stopId = value; }
        }

        [ProtoMember(4, IsRequired = false, Name = @"current_status", DataFormat = DataFormat.TwosComplement)]
        [DefaultValue(VehicleStopStatus.IN_TRANSIT_TO)]
        public VehicleStopStatus CurrentStatus
        {
            get { return _currentStatus; }
            set { _currentStatus = value; }
        }

        [ProtoMember(5, IsRequired = false, Name = @"timestamp", DataFormat = DataFormat.TwosComplement)]
        [DefaultValue(default(ulong))]
        public ulong Timestamp
        {
            get { return _timestamp; }
            set { _timestamp = value; }
        }

        [ProtoMember(6, IsRequired = false, Name = @"congestion_level", DataFormat = DataFormat.TwosComplement)]
        [DefaultValue(CongestionLevel.UNKNOWN_CONGESTION_LEVEL)]
        public CongestionLevel CongestionLevelValue
        {
            get { return _congestionLevel; }
            set { _congestionLevel = value; }
        }

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref _extensionObject, createIfMissing);
        }
    }
}