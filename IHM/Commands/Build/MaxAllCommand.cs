using System;
using System.Windows.Input;
using IHM.Model;

namespace IHM.Commands.Build
{
    internal class MaxAllCommand : ICommand
    {
        #region Fields and Enums

        private readonly BuildModel _buildModel;

        private readonly Action _update;

        #endregion

        #region Constructors

        public MaxAllCommand(Action update, BuildModel buildModel) {
            _update     = update;
            _buildModel = buildModel;
        }

        #endregion

        #region Implementation of ICommand

        public bool CanExecute(object? parameter) {
            return true;
        }

        public void Execute(object? parameter) {
            _buildModel.MaxAll();
            _update.Invoke();
        }

        public event EventHandler? CanExecuteChanged;

        #endregion
    }
}