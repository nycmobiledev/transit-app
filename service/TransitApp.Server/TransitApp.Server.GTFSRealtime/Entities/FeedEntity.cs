using System;
using System.ComponentModel;
using ProtoBuf;

namespace TransitApp.Server.GTFSRealtime.Entities
{
    [Serializable, ProtoContract(Name = @"FeedEntity")]
    public class FeedEntity : IExtensible
    {
        private Alert _alert;
        private IExtension _extensionObject;
        private string _id;

        private bool _isDeleted;

        private TripUpdate _tripUpdate;

        private VehiclePosition _vehicle;

        [ProtoMember(1, IsRequired = true, Name = @"id", DataFormat = DataFormat.Default)]
        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }

        [ProtoMember(2, IsRequired = false, Name = @"is_deleted", DataFormat = DataFormat.Default)]
        [DefaultValue(false)]
        public bool IsDeleted
        {
            get { return _isDeleted; }
            set { _isDeleted = value; }
        }

        [ProtoMember(3, IsRequired = false, Name = @"trip_update", DataFormat = DataFormat.Default)]
        [DefaultValue(null)]
        public TripUpdate TripUpdate
        {
            get { return _tripUpdate; }
            set { _tripUpdate = value; }
        }

        [ProtoMember(4, IsRequired = false, Name = @"vehicle", DataFormat = DataFormat.Default)]
        [DefaultValue(null)]
        public VehiclePosition Vehicle
        {
            get { return _vehicle; }
            set { _vehicle = value; }
        }

        [ProtoMember(5, IsRequired = false, Name = @"alert", DataFormat = DataFormat.Default)]
        [DefaultValue(null)]
        public Alert Alert
        {
            get { return _alert; }
            set { _alert = value; }
        }

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref _extensionObject, createIfMissing);
        }
    }
}