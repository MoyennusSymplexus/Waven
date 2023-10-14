using System;
using System.Linq;
using System.Windows.Input;
using IHM.ViewModel;

namespace IHM.Commands.Build
{
    internal class BuildLoadedCommand : ICommand
    {
        #region Fields and Enums

        private readonly BuildViewModel _buildViewModel;

        #endregion

        #region Constructors

        public BuildLoadedCommand(BuildViewModel buildViewModel) {
            _buildViewModel = buildViewModel;
        }

        #endregion

        #region Implementation of ICommand

        public bool CanExecute(object? parameter) {
            return true;
        }

        public void Execute(object? parameter) {
            _buildViewModel.SelectedListClass = _buildViewModel.ListClass.First();
        }

        public event EventHandler? CanExecuteChanged;

        #endregion
    }
}