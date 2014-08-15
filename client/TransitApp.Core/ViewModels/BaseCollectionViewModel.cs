using System;
using System.Collections.ObjectModel;
using Cirrious.MvvmCross.ViewModels;
using System.Windows.Input;
using System.Threading.Tasks;
using Cirrious.CrossCore;
using Cirrious.CrossCore.Platform;

namespace TransitApp.Core.ViewModels
{
    public abstract class BaseCollectionViewModel<TData,TDetailViewModel> : BaseCollectionViewModel<TData> 
        where TData : new()
        where TDetailViewModel : BaseDetailViewModel<TData>
    {



        protected BaseCollectionViewModel () : base (true)
        {
        }

        protected override void SelectData (TData data)
        {
            var serializedData = Mvx.Resolve<IMvxJsonConverter>().SerializeObject(data);
            ShowViewModel<TDetailViewModel> (new { data = serializedData });
        }
    }

    public abstract class BaseCollectionViewModel<TData> : BaseViewModel<ObservableCollection<TData>> where TData : new()
    {

        private readonly MvxCommand<TData> _selectCommand;

        public ICommand SelectCommand {
            get {
                return _selectCommand;
            }
        }

        private TData _selectedData;

        public TData SelectedData {
            get { 
                return _selectedData;
            }
            set { 
                _selectedData = value;
                RaisePropertyChanged (() => SelectedData);
            }
        }

        private ICommand _refreshCommand;

        public ICommand RefreshCommand {
            get { return _refreshCommand ?? (_refreshCommand = new MvxCommand (async () => await ExecuteRefreshCommand ())); }
        }


        private bool _loadOnStart;

        protected BaseCollectionViewModel (bool loadOnStart = true) : base ()
        {
            _loadOnStart = loadOnStart;
            _selectCommand = new MvxCommand<TData> (SelectData);
        }

        public override void Start ()
        {
            if (_loadOnStart)
                LoadCommand.Execute (null);
        }


        protected BaseCollectionViewModel () : base ()
        {

        }

        protected virtual void AlterData (ObservableCollection<TData> data)
        {

        }

        protected virtual void SelectData (TData data)
        {

        }

        protected override async Task ProcessData ()
        {


            try {
                IsBusy = true;


                var response = await GetData ();

                if (response == null || response.Count == 0) {
                    IsBusy = false;
                    return;
                }

                Data.Clear ();

                AlterData (response);

                Data = response;


                IsBusy = false;




            } catch (Exception e) {
                Cirrious.CrossCore.Mvx.Trace ("{0} - {1}", this.GetType ().Name, e.Message);
            }


        }

        protected async override Task ExecuteLoadCommand ()
        {
            await FetchData ();

        }

        public async Task ExecuteRefreshCommand ()
        {
            await FetchData ();
        }

        protected abstract Task<ObservableCollection<TData>> GetData ();
    }
}

