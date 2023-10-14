using System;
using System.Windows.Input;
using IHM.Model;
using WavenCore.Equipments;

namespace IHM.Commands.Build
{
    internal class AddCuffCommand : ICommand
    {
        #region Fields and Enums

        private readonly BuildModel _buildModel;

        private readonly Action _update;

        #endregion

        #region Constructors

        public AddCuffCommand(Action update, BuildModel buildModel) {
            _update     = update;
            _buildModel = buildModel;
        }

        #endregion

        #region Implementation of ICommand

        public bool CanExecute(object? parameter) {
            return true;
        }

        public void Execute(object? parameter) {
            if (parameter is not Equipment equipment) {
                return;
            }

            _buildModel.AddCuff(equipment);
            _update.Invoke();
        }

        public event EventHandler? CanExecuteChanged;

        #endregion
    }
}