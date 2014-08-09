using System;
using System.ComponentModel;
using ProtoBuf;

namespace TransitApp.Server.GTFSRealtime.Core.DTO
{
    [Serializable, ProtoContract(Name = @"TimeRange")]
    public class TimeRange : IExtensible
    {
        private ulong _end = default(ulong);
        private IExtension _extensionObject;
        private ulong _start = default(ulong);

        [ProtoMember(1, IsRequired = false, Name = @"start", DataFormat = DataFormat.TwosComplement)]
        [DefaultValue(default(ulong))]
        public ulong Start
        {
            get { return _start; }
            set { _start = value; }
        }

        [ProtoMember(2, IsRequired = false, Name = @"end", DataFormat = DataFormat.TwosComplement)]
        [DefaultValue(default(ulong))]
        public ulong End
        {
            get { return _end; }
            set { _end = value; }
        }

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref _extensionObject, createIfMissing);
        }
    }
}