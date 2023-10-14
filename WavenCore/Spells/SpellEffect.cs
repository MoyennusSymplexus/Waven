using System;
using WavenCore.Metadata;

namespace WavenCore.Spells
{
    [Serializable]
    public class SpellEffect
    {
        #region Properties

        public int         Value       { get; init; }
        public SpellType   SpellType   { get; init; }
        public TriggerType TriggerType { get; init; }

        #endregion
    }
}