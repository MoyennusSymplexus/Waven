using System;
using System.Xml.Serialization;
using WavenCore.Equipments.RuneAndEffect;

namespace WavenCore.Equipments
{
    [Serializable]
    public class Ring : Equipment
    {
        #region Properties

        public override string Name      { get; init; } = null!;
        public override Effect Effect    { get; init; } = null!;
        public override Effect BaseStat1 { get; init; } = null!;
        [XmlElement(IsNullable = true)]
        public override Effect? Effect2 { get; init; }
        [XmlElement(IsNullable = true)]
        public override Effect? BaseStat2 { get;  init; }
        public override EquipmentType Type { get; init; } = EquipmentType.Ring;

        #endregion
    }
}