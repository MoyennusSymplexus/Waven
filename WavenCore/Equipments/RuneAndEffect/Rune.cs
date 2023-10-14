using System;
using System.Xml.Serialization;
using WavenCore.Metadata;

namespace WavenCore.Equipments.RuneAndEffect
{
    [Serializable]
    public class Rune : Effect
    {
        #region Properties

        [XmlIgnore]
        public bool IsActive { get; set; }
        [XmlIgnore]
        public object IsComputable => Type != EffectType.NotComputable;

        #endregion
    }
}