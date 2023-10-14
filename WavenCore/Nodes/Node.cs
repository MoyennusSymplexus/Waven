using WavenCore.Metadata;
using WavenCore.Spells;

namespace WavenCore.Nodes
{
    public class Node
    {
        #region Constructors

        public Node(EffectType type, int value, int max) {
            Type  = type;
            Value = value;
            Max   = max;
        }

        #endregion

        #region Properties

        public string     Description => $"Add {Value}% {Type}";
        public int        Value       { get; }
        public EffectType Type        { get; }
        public int        Max         { get; }
        public int        Actual      { get; private set; }

        #endregion

        public void Add() {
            Actual++;
        }

        public void Remove() {
            Actual--;
        }

        public StatSummary GetSummary() {
            int attack = GetStat(EffectType.AttackType);
            int life   = GetStat(EffectType.LifeType);

            return new StatSummary(attack, life, 0, 0, 0, 0, SpellSummary.Empty, 0);
        }

        private int GetStat(EffectType type) {
            if ((Type & type) == 0) {
                return 0;
            }

            return Value * Actual;
        }
    }
}