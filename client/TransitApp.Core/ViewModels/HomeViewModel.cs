using Cirrious.MvvmCross.ViewModels;
using Cirrious.CrossCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TransitApp.Core.Services;
using Cirrious.MvvmCross.Plugins.Location;
using TransitApp.Core.Models;
using System.Windows.Input;

namespace TransitApp.Core.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        private AboutViewModel _aboutViewModel;
        private AlertsViewModel _alertsViewModel;
        private MvxCommand<MenuViewModel> selectMenuItemCommand;

        private List<MenuViewModel> menuItems;        

        public HomeViewModel()
        {            
            this.menuItems = new List<MenuViewModel>
                              {
								  new MenuViewModel{Section = typeof(AlertsViewModel),Title = "Alerts"},
				                  new MenuViewModel{Section = typeof(AboutViewModel),Title = "About"},
                                  new MenuViewModel{Section = typeof(HelpViewModel),Title = "Help"}
                              };
        }

        public List<MenuViewModel> MenuItems
        {
            get { return this.menuItems; }
            set { this.menuItems = value; this.RaisePropertyChanged(() => this.MenuItems); }
        }

        public AlertsViewModel AlertsViewModel
        {
            get
            {
                if (_alertsViewModel == null)
                {
                    _alertsViewModel = new AlertsViewModel();
                }
                return _alertsViewModel;
            }
            set
            {
                _alertsViewModel = value;
            }
        }

        public AboutViewModel AboutViewModel
        {
            get
            {
                if (_aboutViewModel == null)
                {
                    _aboutViewModel = new AboutViewModel();
                }

                return _aboutViewModel;
            }
            set
            {
                _aboutViewModel = value;
            }
        }

        public ICommand SelectMenuItemCommand
        {
            get
            {
                return this.selectMenuItemCommand ?? (this.selectMenuItemCommand = new MvxCommand<MenuViewModel>(x =>
                {   
                    this.ShowViewModel(x.Section);                    
                }));
            }
        }  
    }
}
