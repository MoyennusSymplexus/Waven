using System;
using System.Windows.Input;

namespace IHM.Commands.Build
{
    internal class RuneChangedCommand : ICommand
    {
        #region Fields and Enums

        private readonly Action _update;

        #endregion

        #region Constructors

        public RuneChangedCommand(Action update) {
            _update = update;
        }

        #endregion

        #region Implementation of ICommand

        public bool CanExecute(object? parameter) {
            return true;
        }

        public void Execute(object? parameter) {
            _update.Invoke();
        }

        public event EventHandler? CanExecuteChanged;

        #endregion
    }
}