using System;
using System.Collections.Generic;
using System.Windows.Input;
using IHM.Commands.Build;
using IHM.Model;
using WavenCore.Spells;

namespace IHM.ViewModel
{
    internal class SpellViewModel
    {
        #region Fields and Enums

        private readonly BuildModel _build;

        #endregion

        #region Constructors

        public SpellViewModel(BuildModel build, Action updateSummary) {
            _build       = build;
            RuneChanged  = new RuneChangedCommand(updateSummary);
            LevelChanged = new LevelChangedCommand(updateSummary);
            AddLevel     = new AddLevelCommand(updateSummary);
            RemoveLevel  = new RemoveLevelCommand(updateSummary);
        }

        #endregion

        #region Properties

        public IEnumerable<SpellWithSummary> Spells       => _build.GetSpellsSummary();
        public ICommand                      RuneChanged  { get; }
        public ICommand                      LevelChanged { get; }
        public ICommand                      AddLevel     { get; }
        public ICommand                      RemoveLevel  { get; }

        #endregion
    }
}