using System;
using System.ComponentModel;
using ProtoBuf;

namespace TransitApp.Server.GTFSRealtime.DTO
{
    [Serializable, ProtoContract(Name = @"VehicleDescriptor")]
    public class VehicleDescriptor : IExtensible
    {
        private IExtension _extensionObject;
        private string _id = "";

        private string _label = "";

        private string _licensePlate = "";

        [ProtoMember(1, IsRequired = false, Name = @"id", DataFormat = DataFormat.Default)]
        [DefaultValue("")]
        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }

        [ProtoMember(2, IsRequired = false, Name = @"label", DataFormat = DataFormat.Default)]
        [DefaultValue("")]
        public string Label
        {
            get { return _label; }
            set { _label = value; }
        }

        [ProtoMember(3, IsRequired = false, Name = @"license_plate", DataFormat = DataFormat.Default)]
        [DefaultValue("")]
        public string LicensePlate
        {
            get { return _licensePlate; }
            set { _licensePlate = value; }
        }

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref _extensionObject, createIfMissing);
        }
    }
}