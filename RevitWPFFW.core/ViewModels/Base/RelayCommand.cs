using System;
using System.Windows.Input;

namespace RevitWPFFW.core
{
    /// <summary>
    /// Routes Commands to the ICommand Interface
    /// </summary>
    public class RelayCommand : ICommand
    {
        #region Private Fields
        /// <summary>
        /// Action to Execute
        /// </summary>
        private readonly Action<object> _executeMethod;

        /// <summary>
        /// Determines if Action can be executed
        /// </summary>
        private readonly Predicate<object> _canExecuteMethod;
        #endregion

        #region Constructors
        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="action"></param>
        public RelayCommand(Action<object> action) : this(action, null) { }

        /// <summary>
        /// Constructor with Properties
        /// </summary>
        /// <param name="action"></param>
        /// <param name="canExecute"></param>
        public RelayCommand(Action<object> action, Predicate<object> canExecute)
        {
            this._executeMethod = action;
            this._canExecuteMethod = canExecute;
        }

        #endregion

        #region Events
        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Defines the method that determines whether the command can execute in its current state
        /// </summary>
        /// <param name="parameter">Data used by the command.  If the command does not require data to be passed, this object can be set to <see langword="null"/></param>
        /// <returns>If this command can be executed; otherwise, <see langword="false""/></returns>
        public bool CanExecute(object parameter)
        {
            return _canExecuteMethod == null || _canExecuteMethod(parameter);
        }

        /// <summary>
        /// Defines the method to be called when the command is invoked
        /// </summary>
        /// <param name="parameter">Data used by the command.  If the command does not require data to be passed, this object can be set to <see langword="null"/></param>
        public void Execute(object parameter)
        {
            if (CanExecute(parameter)) _executeMethod(parameter);
        }
        #endregion
    }
}
