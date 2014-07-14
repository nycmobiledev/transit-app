using System;
using System.Collections.Generic;
using System.ComponentModel;
using ProtoBuf;

namespace TransitApp.Server.GTFSRealtime.DTO
{
    [Serializable, ProtoContract(Name = @"TranslatedString")]
    public class TranslatedString : IExtensible
    {
        private readonly List<Translation> _translations = new List<Translation>();

        private IExtension _extensionObject;

        [ProtoMember(1, Name = @"translation", DataFormat = DataFormat.Default)]
        public List<Translation> Translations
        {
            get { return _translations; }
        }

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref _extensionObject, createIfMissing);
        }

        [Serializable, ProtoContract(Name = @"Translation")]
        public class Translation : IExtensible
        {
            private IExtension _extensionObject;
            private string _language = "";
            private string _text;

            [ProtoMember(1, IsRequired = true, Name = @"text", DataFormat = DataFormat.Default)]
            public string Text
            {
                get { return _text; }
                set { _text = value; }
            }

            [ProtoMember(2, IsRequired = false, Name = @"language", DataFormat = DataFormat.Default)]
            [DefaultValue("")]
            public string Language
            {
                get { return _language; }
                set { _language = value; }
            }

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref _extensionObject, createIfMissing);
            }
        }
    }
}