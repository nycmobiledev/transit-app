// --------------------------------------------------------------------------------------------------------------------
// <summary>
//    Defines the BaseViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace TransitApp.Core.ViewModels
{
    using System;
    using System.Linq.Expressions;

    using Cirrious.CrossCore;
    using Cirrious.MvvmCross.ViewModels;

    /// <summary>
    ///    Defines the BaseViewModel type.
    /// </summary>
    public abstract class BaseViewModel : MvxViewModel
    {
        private long _id;
        private string _Title = string.Empty;

        /// <summary>
        /// Gets or sets the unique ID for the menu
        /// </summary>
        public long Id
        {
            get { return this._id; }
            set { this._id = value; this.RaisePropertyChanged(() => this.Id); }
        }
        /// <summary>
        /// Gets or sets the name of the menu
        /// </summary>
        public string Title
        {
            get { return this._Title; }
            set { this._Title = value; this.RaisePropertyChanged(() => this.Title); }
        }
    }
}
