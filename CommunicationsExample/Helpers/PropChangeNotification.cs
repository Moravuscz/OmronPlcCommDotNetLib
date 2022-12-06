using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CommunicationsExample.Helpers
{
    /// <summary>
    /// <para>Helper providing implementation of <see cref="INotifyPropertyChanged"/>.</para>
    /// <para>Call <see cref="RaisePropertyChanged(string)"/> from your Property's setter.</para>
    /// </summary>
    public class PropChangeNotification : INotifyPropertyChanged
    {
        #region Public Events

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion Public Events



        #region Protected Methods

        /// <summary>
        /// Raises <see cref="PropertyChanged"/> event to notify subscribers
        /// </summary>
        /// <param name="propertyName">Name of the property that changed</param>
        /// <remarks>Leave <paramref name="propertyName"/> empty for auto-detection</remarks>
        protected void RaisePropertyChanged([CallerMemberName] string propertyName = null) => PropertyChanged?.Invoke(this, e: new PropertyChangedEventArgs(propertyName));

        #endregion Protected Methods
    }
}