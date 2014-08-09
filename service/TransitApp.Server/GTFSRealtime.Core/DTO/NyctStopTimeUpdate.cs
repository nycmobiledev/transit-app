// Generated from: gtfs-realtime.proto
// Generated from: nyct-subway.proto
// Note: requires additional types generated from: gtfs-realtime.proto

using System;
using System.ComponentModel;
using ProtoBuf;

namespace TransitApp.Server.GTFSRealtime.Core.DTO
{
    [Serializable, ProtoContract(Name = @"NyctStopTimeUpdate")]
    public class NyctStopTimeUpdate : IExtensible
    {
        private string _actualTrack = "";
        private IExtension _extensionObject;
        private string _scheduledTrack = "";

        [ProtoMember(1, IsRequired = false, Name = @"scheduled_track", DataFormat = DataFormat.Default)]
        [DefaultValue("")]
        public string ScheduledTrack
        {
            get { return _scheduledTrack; }
            set { _scheduledTrack = value; }
        }

        [ProtoMember(2, IsRequired = false, Name = @"actual_track", DataFormat = DataFormat.Default)]
        [DefaultValue("")]
        public string ActualTrack
        {
            get { return _actualTrack; }
            set { _actualTrack = value; }
        }

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref _extensionObject, createIfMissing);
        }
    }
}