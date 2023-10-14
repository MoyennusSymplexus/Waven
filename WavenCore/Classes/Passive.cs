using System;
using WavenCore.Metadata;

namespace WavenCore.Classes
{
    public class Passive
    {
        #region Fields and Enums

        private readonly Func<CharacterStatSummary?, string>? _computeValue;

        private CharacterStatSummary? _summary;

        #endregion

        #region Constructors

        public Passive(string name, string description, Func<CharacterStatSummary?, string>? computeValue, bool isActive = false) {
            Name          = name;
            Description   = description;
            IsActive      = isActive;
            _computeValue = computeValue;
        }

        #endregion

        #region Properties

        public string Name                { get; }
        public string Description         { get; }
        public string DetailedDescription => ComputeValue();
        public bool   IsActive            { get; set; }

        #endregion

        private string ComputeValue() {
            return _computeValue is null ? string.Empty : _computeValue.Invoke(_summary);
        }

        public void SetSummary(CharacterStatSummary summary) {
            _summary = summary;
        }
    }
}