using System;
using System.Xml.Serialization;
using WavenCore.Metadata;

namespace WavenCore.Equipments.RuneAndEffect
{
    [Serializable]
    public class Effect
    {
        #region Properties

        [XmlIgnore]
        public string Description => Type == EffectType.NotComputable ? "Effet non pris en compte" : $"Add {Value}% {Type}";
        public int         Value       { get; set; }
        public EffectType  Type        { get; set; }
        public TriggerType TriggerType { get; init; }

        #endregion
    }
}