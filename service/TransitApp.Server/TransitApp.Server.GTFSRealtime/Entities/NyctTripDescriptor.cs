using System;
using System.ComponentModel;
using ProtoBuf;

namespace TransitApp.Server.GTFSRealtime.Entities
{
    [Serializable, ProtoContract(Name = @"NyctTripDescriptor")]
    public class NyctTripDescriptor : IExtensible
    {
        [ProtoContract(Name = @"Direction")]
        public enum TrainDirection
        {
            [ProtoEnum(Name = @"NORTH", Value = 1)] NORTH = 1,

            [ProtoEnum(Name = @"EAST", Value = 2)] EAST = 2,

            [ProtoEnum(Name = @"SOUTH", Value = 3)] SOUTH = 3,

            [ProtoEnum(Name = @"WEST", Value = 4)] WEST = 4
        }

        private TrainDirection _direction = TrainDirection.NORTH;
        private IExtension _extensionObject;
        private bool _isAssigned = default(bool);

        private string _trainId = "";

        [ProtoMember(1, IsRequired = false, Name = @"train_id", DataFormat = DataFormat.Default)]
        [DefaultValue("")]
        public string TrainId
        {
            get { return _trainId; }
            set { _trainId = value; }
        }

        [ProtoMember(2, IsRequired = false, Name = @"is_assigned", DataFormat = DataFormat.Default)]
        [DefaultValue(default(bool))]
        public bool IsAssigned
        {
            get { return _isAssigned; }
            set { _isAssigned = value; }
        }

        [ProtoMember(3, IsRequired = false, Name = @"direction", DataFormat = DataFormat.TwosComplement)]
        [DefaultValue(TrainDirection.NORTH)]
        public TrainDirection Direction
        {
            get { return _direction; }
            set { _direction = value; }
        }

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref _extensionObject, createIfMissing);
        }
    }
}