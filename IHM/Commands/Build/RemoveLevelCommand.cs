using System;
using System.Windows.Input;
using WavenCore.Equipments;
using WavenCore.Spells;

namespace IHM.Commands.Build
{
    internal class RemoveLevelCommand : ICommand
    {
        #region Fields and Enums

        private readonly Action _update;

        #endregion

        #region Constructors

        public RemoveLevelCommand(Action update) {
            _update = update;
        }

        #endregion

        #region Implementation of ICommand

        public bool CanExecute(object? parameter) {
            return parameter switch {
                       Equipment node        => node.Level > 1,
                       SpellWithSummary node => node.Level > 1,
                       _                     => false
                   };
        }

        public void Execute(object? parameter) {
            switch (parameter) {
                case Equipment node:
                    node.RemoveLevel();
                    _update.Invoke();
                    break;
                case SpellWithSummary node:
                    node.RemoveLevel();
                    _update.Invoke();
                    break;
            }
        }

        public event EventHandler? CanExecuteChanged;

        #endregion
    }
}