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

		ITransitAppDataRefresh _appDataRefresh = null;
		CoolTimer _coolTimer;

		public ITransitAppDataRefresh AppDataRefresh 
		{
			set
			{
				_coolTimer = new CoolTimer (BaseDataCallBack, null, 10000, -1);
				_appDataRefresh = value;
			}
			get
			{
				return _appDataRefresh;
			}
		}

		private void BaseDataCallBack(object state)
		{
			_coolTimer = new CoolTimer (BaseDataCallBack, null, 10000, -1);
			//_appDataRefresh.DataCallBack(state);

		}

        /// <summary>
        /// Gets the service.
        /// </summary>
        /// <typeparam name="TService">The type of the service.</typeparam>
        /// <returns>An instance of the service.</returns>
        public TService GetService<TService>() where TService : class
        {
            return Mvx.Resolve<TService>();
        }

        /// <summary>
        /// Checks if a property already matches a desired value.  Sets the property and
        /// notifies listeners only when necessary.
        /// </summary>
        /// <typeparam name="T">Type of the property.</typeparam>
        /// <param name="backingStore">Reference to a property with both getter and setter.</param>
        /// <param name="value">Desired value for the property.</param>
        /// <param name="property">The property.</param>
        protected void SetProperty<T>(
            ref T backingStore,
            T value,
            Expression<Func<T>> property)
        {
            if (Equals(backingStore, value))
            {
                return;
            }

            backingStore = value;

            this.RaisePropertyChanged(property);
        }

        private long m_Id;
        /// <summary>
        /// Gets or sets the unique ID for the menu
        /// </summary>
        public long Id
        {
            get { return this.m_Id; }
            set { this.m_Id = value; this.RaisePropertyChanged(() => this.Id); }
        }

        private string m_Title = string.Empty;
        /// <summary>
        /// Gets or sets the name of the menu
        /// </summary>
        public string Title
        {
            get { return this.m_Title; }
            set { this.m_Title = value; this.RaisePropertyChanged(() => this.Title); }
        }

        public override void Start()
        {
            //Connect to webservice here?
        }
    }
}
