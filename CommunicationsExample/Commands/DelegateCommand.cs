using System;

namespace CommunicationsExample.Commands
{
    /// <summary>
    /// Command designed to execute a method on the ViewModel the Command is called from
    /// </summary>
    public class DelegateCommand : CommandBase
    {
        #region Private Fields

        private readonly Action<object> _executeAction;

        #endregion Private Fields

        #region Public Constructors + Destructors

        public DelegateCommand(Action<object> executeAction) => _executeAction = executeAction;

        #endregion Public Constructors + Destructors



        #region Public Methods

        public override bool CanExecute(object parameter) => true;

        public override void Execute(object parameter) => _executeAction(parameter);

        #endregion Public Methods
    }
}