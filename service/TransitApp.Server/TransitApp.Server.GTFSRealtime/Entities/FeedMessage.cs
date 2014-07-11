using System;
using System.Collections.Generic;
using ProtoBuf;

namespace TransitApp.Server.GTFSRealtime.Entities
{
    [Serializable, ProtoContract(Name = @"FeedMessage")]
    public class FeedMessage : IExtensible
    {
        private readonly List<FeedEntity> _entity = new List<FeedEntity>();
        private IExtension _extensionObject;
        private FeedHeader _header;

        [ProtoMember(1, IsRequired = true, Name = @"header", DataFormat = DataFormat.Default)]
        public FeedHeader Header
        {
            get { return _header; }
            set { _header = value; }
        }

        [ProtoMember(2, Name = @"entity", DataFormat = DataFormat.Default)]
        public List<FeedEntity> Entity
        {
            get { return _entity; }
        }

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref _extensionObject, createIfMissing);
        }
    }
}