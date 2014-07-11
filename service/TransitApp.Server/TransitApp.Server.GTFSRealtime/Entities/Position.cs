using System;
using System.ComponentModel;
using ProtoBuf;

namespace TransitApp.Server.GTFSRealtime.Entities
{
    [Serializable, ProtoContract(Name = @"Position")]
    public class Position : IExtensible
    {
        private float _bearing = default(float);
        private IExtension _extensionObject;
        private float _latitude;

        private float _longitude;
        private double _odometer = default(double);
        private float _speed = default(float);

        [ProtoMember(1, IsRequired = true, Name = @"latitude", DataFormat = DataFormat.FixedSize)]
        public float Latitude
        {
            get { return _latitude; }
            set { _latitude = value; }
        }

        [ProtoMember(2, IsRequired = true, Name = @"longitude", DataFormat = DataFormat.FixedSize)]
        public float Longitude
        {
            get { return _longitude; }
            set { _longitude = value; }
        }

        [ProtoMember(3, IsRequired = false, Name = @"bearing", DataFormat = DataFormat.FixedSize)]
        [DefaultValue(default(float))]
        public float Bearing
        {
            get { return _bearing; }
            set { _bearing = value; }
        }

        [ProtoMember(4, IsRequired = false, Name = @"odometer", DataFormat = DataFormat.TwosComplement)]
        [DefaultValue(default(double))]
        public double Odometer
        {
            get { return _odometer; }
            set { _odometer = value; }
        }

        [ProtoMember(5, IsRequired = false, Name = @"speed", DataFormat = DataFormat.FixedSize)]
        [DefaultValue(default(float))]
        public float Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref _extensionObject, createIfMissing);
        }
    }
}