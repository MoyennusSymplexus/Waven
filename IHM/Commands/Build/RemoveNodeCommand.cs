using System;
using System.Windows.Input;
using WavenCore.Nodes;

namespace IHM.Commands.Build
{
    internal class RemoveNodeCommand : ICommand
    {
        #region Fields and Enums

        private readonly Action _update;

        #endregion

        #region Constructors

        public RemoveNodeCommand(Action update) {
            _update = update;
        }

        #endregion

        #region Implementation of ICommand

        public bool CanExecute(object? parameter) {
            return parameter is Node {Actual: > 0};
        }

        public void Execute(object? parameter) {
            if (parameter is not Node node) {
                return;
            }

            node.Remove();
            _update.Invoke();
        }

        public event EventHandler? CanExecuteChanged;

        #endregion
    }
}