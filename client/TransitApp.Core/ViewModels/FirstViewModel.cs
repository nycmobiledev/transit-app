// --------------------------------------------------------------------------------------------------------------------
// <summary>
//    Defines the FirstViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using TransitApp.Core.ViewModels;

namespace TransitApp.Core.ViewModels
{
    using System.Windows.Input;
    using Cirrious.MvvmCross.ViewModels;

    /// <summary>
    /// Define the FirstViewModel type.
    /// </summary>
    public class FirstViewModel : BaseViewModel
    {
        /// <summary>
        /// Backing field for my property.
        /// </summary>
        private string myProperty = "Mvx Ninja Coder!";

        /// <summary>
        ///  Backing field for my command.
        /// </summary>
        private MvxCommand myCommand;

        /// <summary>
        /// Gets or sets my property.
        /// </summary>
        public string MyProperty
        {
            get { return this.myProperty; }
            set { this.SetProperty(ref this.myProperty, value, () => this.MyProperty); }
        }

        /// <summary>
        /// Gets My Command.
        /// <para>
        /// An example of a command and how to navigate to another view model
        /// Note the ViewModel inside of ShowViewModel needs to change!
        /// </para>
        /// </summary>
        public ICommand MyCommand
        {
            get { return this.myCommand ?? (this.myCommand = new MvxCommand(this.Show)); }
        }

        /// <summary>
        /// Show the view model.
        /// </summary>
        public void Show()
        {
            this.ShowViewModel<FirstViewModel>();
        }
    }
}
