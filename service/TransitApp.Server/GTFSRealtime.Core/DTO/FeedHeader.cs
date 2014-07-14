using System;
using System.ComponentModel;
using ProtoBuf;

namespace TransitApp.Server.GTFSRealtime.Core.DTO
{
    [Serializable, ProtoContract(Name = @"FeedHeader")]
    public class FeedHeader : IExtensible
    {
        [ProtoContract(Name = @"Incrementality")]
        public enum Incrementality
        {
            [ProtoEnum(Name = @"FULL_DATASET", Value = 0)] FULL_DATASET = 0,

            [ProtoEnum(Name = @"DIFFERENTIAL", Value = 1)] DIFFERENTIAL = 1
        }

        private IExtension _extensionObject;

        private string _gtfsRealtimeVersion;

        private Incrementality _incrementality = Incrementality.FULL_DATASET;
        private NyctFeedHeader _nyctFeedHeader;

        private ulong _timestamp = default(ulong);

        [ProtoMember(1, IsRequired = true, Name = @"gtfs_realtime_version", DataFormat = DataFormat.Default)]
        public string GtfsRealtimeVersion
        {
            get { return _gtfsRealtimeVersion; }
            set { _gtfsRealtimeVersion = value; }
        }

        [ProtoMember(2, IsRequired = false, Name = @"incrementality", DataFormat = DataFormat.TwosComplement)]
        [DefaultValue(Incrementality.FULL_DATASET)]
        public Incrementality DataIncrementality
        {
            get { return _incrementality; }
            set { _incrementality = value; }
        }

        [ProtoMember(3, IsRequired = false, Name = @"timestamp", DataFormat = DataFormat.TwosComplement)]
        [DefaultValue(default(ulong))]
        public ulong Timestamp
        {
            get { return _timestamp; }
            set { _timestamp = value; }
        }

        [ProtoMember(1001, IsRequired = false, Name = @"nyct_feed_header", DataFormat = DataFormat.Default)]
        [DefaultValue(null)]
        public NyctFeedHeader NyctFeedHeader
        {
            get { return _nyctFeedHeader; }
            set { _nyctFeedHeader = value; }
        }

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref _extensionObject, createIfMissing);
        }
    }
}