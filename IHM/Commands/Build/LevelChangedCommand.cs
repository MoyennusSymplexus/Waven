using System;
using System.Windows.Input;
using WavenCore.Equipments;
using WavenCore.Spells;

namespace IHM.Commands.Build
{
    internal class LevelChangedCommand : ICommand
    {
        #region Fields and Enums

        private readonly Action _update;

        #endregion

        #region Constructors

        public LevelChangedCommand(Action update) {
            _update = update;
        }

        #endregion

        #region Nested type: UpdateItem

        public record UpdateItem(Equipment Equipment, int NewLevel);

        #endregion

        #region Nested type: UpdateSpell

        public record UpdateSpell(Spell Equipment, int NewLevel);

        #endregion

        #region Implementation of ICommand

        public bool CanExecute(object? parameter) {
            return parameter is Equipment node && node.Level < Equipment.MaxLevel;
        }

        public void Execute(object? parameter) {
            switch (parameter) {
                case UpdateItem(var equipment, var newLevel):
                    equipment.SetLevel(newLevel);
                    _update.Invoke();
                    return;
                case UpdateSpell(var spell, var newLevel):
                    spell.SetLevel(newLevel);
                    _update.Invoke();
                    break;
            }
        }

        public event EventHandler? CanExecuteChanged;

        #endregion
    }
}