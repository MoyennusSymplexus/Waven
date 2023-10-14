using System;
using System.Windows.Input;
using IHM.Model;
using WavenCore.Equipments;

namespace IHM.Commands.Build
{
    internal class AddRingCommand : ICommand
    {
        #region Fields and Enums

        private readonly BuildModel _buildModel;

        private readonly Action _update;

        #endregion

        #region Constructors

        public AddRingCommand(Action update, BuildModel buildModel) {
            _update     = update;
            _buildModel = buildModel;
        }

        #endregion

        #region Implementation of ICommand

        public bool CanExecute(object? parameter) {
            return true; // CA BUG _buildModel.CanAddRing();
        }

        public void Execute(object? parameter) {
            if (parameter is not Equipment equipment) {
                return;
            }

            _buildModel.AddRing(equipment);
            _update.Invoke();
        }

        public event EventHandler? CanExecuteChanged;

        #endregion
    }
}