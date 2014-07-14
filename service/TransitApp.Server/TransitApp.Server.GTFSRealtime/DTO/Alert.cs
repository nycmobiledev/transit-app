using System;
using System.Collections.Generic;
using System.ComponentModel;
using ProtoBuf;

namespace TransitApp.Server.GTFSRealtime.DTO
{
    [Serializable, ProtoContract(Name = @"Alert")]
    public class Alert : IExtensible
    {
        [ProtoContract(Name = @"Cause")]
        public enum CauseStatus
        {
            [ProtoEnum(Name = @"UNKNOWN_CAUSE", Value = 1)] UNKNOWN_CAUSE = 1,

            [ProtoEnum(Name = @"OTHER_CAUSE", Value = 2)] OTHER_CAUSE = 2,

            [ProtoEnum(Name = @"TECHNICAL_PROBLEM", Value = 3)] TECHNICAL_PROBLEM = 3,

            [ProtoEnum(Name = @"STRIKE", Value = 4)] STRIKE = 4,

            [ProtoEnum(Name = @"DEMONSTRATION", Value = 5)] DEMONSTRATION = 5,

            [ProtoEnum(Name = @"ACCIDENT", Value = 6)] ACCIDENT = 6,

            [ProtoEnum(Name = @"HOLIDAY", Value = 7)] HOLIDAY = 7,

            [ProtoEnum(Name = @"WEATHER", Value = 8)] WEATHER = 8,

            [ProtoEnum(Name = @"MAINTENANCE", Value = 9)] MAINTENANCE = 9,

            [ProtoEnum(Name = @"CONSTRUCTION", Value = 10)] CONSTRUCTION = 10,

            [ProtoEnum(Name = @"POLICE_ACTIVITY", Value = 11)] POLICE_ACTIVITY = 11,

            [ProtoEnum(Name = @"MEDICAL_EMERGENCY", Value = 12)] MEDICAL_EMERGENCY = 12
        }

        [ProtoContract(Name = @"Effect")]
        public enum EffectStatus
        {
            [ProtoEnum(Name = @"NO_SERVICE", Value = 1)] NO_SERVICE = 1,

            [ProtoEnum(Name = @"REDUCED_SERVICE", Value = 2)] REDUCED_SERVICE = 2,

            [ProtoEnum(Name = @"SIGNIFICANT_DELAYS", Value = 3)] SIGNIFICANT_DELAYS = 3,

            [ProtoEnum(Name = @"DETOUR", Value = 4)] DETOUR = 4,

            [ProtoEnum(Name = @"ADDITIONAL_SERVICE", Value = 5)] ADDITIONAL_SERVICE = 5,

            [ProtoEnum(Name = @"MODIFIED_SERVICE", Value = 6)] MODIFIED_SERVICE = 6,

            [ProtoEnum(Name = @"OTHER_EFFECT", Value = 7)] OTHER_EFFECT = 7,

            [ProtoEnum(Name = @"UNKNOWN_EFFECT", Value = 8)] UNKNOWN_EFFECT = 8,

            [ProtoEnum(Name = @"STOP_MOVED", Value = 9)] STOP_MOVED = 9
        }

        private readonly List<TimeRange> _activePeriod = new List<TimeRange>();

        private readonly List<EntitySelector> _informedEntity = new List<EntitySelector>();

        private CauseStatus _cause = CauseStatus.UNKNOWN_CAUSE;
        private TranslatedString _descriptionText;

        private EffectStatus _effect = EffectStatus.UNKNOWN_EFFECT;
        private IExtension _extensionObject;
        private TranslatedString _headerText;

        private TranslatedString _url;

        [ProtoMember(1, Name = @"active_period", DataFormat = DataFormat.Default)]
        public List<TimeRange> ActivePeriod
        {
            get { return _activePeriod; }
        }

        [ProtoMember(5, Name = @"informed_entity", DataFormat = DataFormat.Default)]
        public List<EntitySelector> InformedEntity
        {
            get { return _informedEntity; }
        }

        [ProtoMember(6, IsRequired = false, Name = @"cause", DataFormat = DataFormat.TwosComplement)]
        [DefaultValue(CauseStatus.UNKNOWN_CAUSE)]
        public CauseStatus Cause
        {
            get { return _cause; }
            set { _cause = value; }
        }

        [ProtoMember(7, IsRequired = false, Name = @"effect", DataFormat = DataFormat.TwosComplement)]
        [DefaultValue(EffectStatus.UNKNOWN_EFFECT)]
        public EffectStatus Effect
        {
            get { return _effect; }
            set { _effect = value; }
        }

        [ProtoMember(8, IsRequired = false, Name = @"url", DataFormat = DataFormat.Default)]
        [DefaultValue(null)]
        public TranslatedString Url
        {
            get { return _url; }
            set { _url = value; }
        }

        [ProtoMember(10, IsRequired = false, Name = @"header_text", DataFormat = DataFormat.Default)]
        [DefaultValue(null)]
        public TranslatedString HeaderText
        {
            get { return _headerText; }
            set { _headerText = value; }
        }

        [ProtoMember(11, IsRequired = false, Name = @"description_text", DataFormat = DataFormat.Default)]
        [DefaultValue(null)]
        public TranslatedString DescriptionText
        {
            get { return _descriptionText; }
            set { _descriptionText = value; }
        }

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref _extensionObject, createIfMissing);
        }
    }
}