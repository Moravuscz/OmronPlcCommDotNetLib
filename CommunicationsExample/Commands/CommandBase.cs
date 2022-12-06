using System;
using System.Windows.Input;

namespace CommunicationsExample.Commands
{
    /// <summary>
    /// Implements the <see cref="ICommand"/> interface
    /// </summary>
    public abstract class CommandBase : ICommand
    {
        #region Public Events

        public event EventHandler CanExecuteChanged;

        #endregion Public Events



        #region Public Methods

        public virtual bool CanExecute(object parameter) => true;

        public abstract void Execute(object parameter);

        #endregion Public Methods



        #region Protected Methods

        protected void OnCanExecuteChanged() => CanExecuteChanged?.Invoke(this, new EventArgs());

        #endregion Protected Methods
    }
}