using System.Collections.Generic;
using System.Linq;
using WavenCore.Metadata;

namespace WavenCore.Nodes
{
    public class Listing
    {
        #region Constructors

        public Listing() {
            Nodes.Add(new Node(EffectType.Life, 50, 1));
            Nodes.Add(new Node(EffectType.Life, 25, 3));
            Nodes.Add(new Node(EffectType.Life, 12, 10));
            Nodes.Add(new Node(EffectType.Life, 5,  15));

            Nodes.Add(new Node(EffectType.Attack, 50, 1));
            Nodes.Add(new Node(EffectType.Attack, 20, 3));
            Nodes.Add(new Node(EffectType.Attack, 7,  10));
            Nodes.Add(new Node(EffectType.Attack, 3,  15));
        }

        #endregion

        #region Properties

        public List<Node> Nodes { get; } = new();

        #endregion

        public StatSummary GetSummary() {
            return Nodes.Aggregate(StatSummary.Empty, (current, node) => current.Combine(node.GetSummary()));
        }
    }
}