using System;
using System.Windows.Input;
using WavenCore.Nodes;

namespace IHM.Commands.Build
{
    internal class AddNodeCommand : ICommand
    {
        #region Fields and Enums

        private readonly Action _update;

        #endregion

        #region Constructors

        public AddNodeCommand(Action update) {
            _update = update;
        }

        #endregion

        #region Implementation of ICommand

        public bool CanExecute(object? parameter) {
            return parameter is Node node && node.Actual < node.Max;
        }

        public void Execute(object? parameter) {
            if (parameter is not Node node) {
                return;
            }

            node.Add();
            _update.Invoke();
        }

        public event EventHandler? CanExecuteChanged;

        #endregion
    }
}