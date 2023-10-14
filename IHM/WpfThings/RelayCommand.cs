using System;
using System.Diagnostics;
using System.Windows.Input;

namespace IHM
{
    /// <summary>
    ///     A command whose sole purpose is to
    ///     relay its functionality to other
    ///     objects by invoking delegates. The
    ///     default return value for the CanExecute
    ///     method is 'true'.
    /// </summary>
    public class RelayCommand : ICommand
    {
        #region Constructors

        /// <summary>
        ///     Creates a new command.
        /// </summary>
        /// <param name="execute">The execution logic.</param>
        /// <param name="canExecute">The execution status logic.</param>
        public RelayCommand(Action<object?> execute, Predicate<object?>? canExecute = null) {
            _execute    = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        #endregion

        #region ICommand Members

        [DebuggerStepThrough]
        public bool CanExecute(object? parameters) {
            return _canExecute?.Invoke(parameters) ?? true;
        }

        public event EventHandler? CanExecuteChanged {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public void Execute(object? parameters) {
            _execute(parameters);
        }

        #endregion

        #region Fields

        private readonly Action<object?>     _execute;
        private readonly Predicate<object?>? _canExecute;

        #endregion // Fields
    }
}