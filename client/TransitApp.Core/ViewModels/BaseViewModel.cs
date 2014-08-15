// --------------------------------------------------------------------------------------------------------------------
// <summary>
//    Defines the BaseViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
using System.Windows.Input;
using System.Threading.Tasks;


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

    public abstract class BaseViewModel<TData> : BaseViewModel where TData : new()
    {

        private bool _isBusy;

        public bool IsBusy {
            get { return _isBusy; }
            set {
                _isBusy = value;
                RaisePropertyChanged (() => IsBusy);
            }
        }


        private TData _data;

        public TData Data {
            get { return _data; }
            set { 
                _data = value;
                RaisePropertyChanged (() => Data);
            }
        }


        protected BaseViewModel () : base ()
        {
            _data = new TData ();
        }


        private ICommand _loadCommand;

        public ICommand LoadCommand {
            get {
                return _loadCommand ?? (_loadCommand = new MvxCommand (async () => {
                    IsBusy = true;
                    await ExecuteLoadCommand ();
                    IsBusy = false;
                }
                ));
            }
        }



        protected abstract Task ExecuteLoadCommand();

        protected virtual async Task FetchData ()
        {
            await ProcessData ();

        }

        protected virtual async Task ProcessData ()
        {

        }




    }
}
