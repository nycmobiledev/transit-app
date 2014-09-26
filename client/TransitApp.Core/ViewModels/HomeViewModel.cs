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
        public enum Section
        {
            Unknown,
            Alarts,
            About
        }

        private MvxCommand<MenuViewModel> selectMenuItemCommand;

        private List<MenuViewModel> menuItems;

        public HomeViewModel()
        {
            this.menuItems = new List<MenuViewModel>
                              {
								  new MenuViewModel{Section = Section.Alarts,Title = "Alerts"},
				                  new MenuViewModel{Section = Section.About,Title = "About"}
                              };
        }

        public List<MenuViewModel> MenuItems
        {
            get { return this.menuItems; }
            set { this.menuItems = value; this.RaisePropertyChanged(() => this.MenuItems); }
        }

        public ICommand SelectMenuItemCommand
        {
            get
            {
                return this.selectMenuItemCommand ?? (this.selectMenuItemCommand = new MvxCommand<MenuViewModel>(this.ExecuteSelectMenuItemCommand));
            }
        }

        public Section GetSectionForViewModelType(Type type)
        {

            if (type == typeof(AboutViewModel))
                return Section.About;

            if (type == typeof(AlertsViewModel))
                return Section.Alarts;

            return Section.Unknown;
        }

        private void ExecuteSelectMenuItemCommand(MenuViewModel item)
        {
            switch (item.Section)
            {
                case Section.About:
                    this.ShowViewModel<AboutViewModel>();
                    break;
                case Section.Alarts:
                    this.ShowViewModel<AlertsViewModel>();
                    break;

            }
        }
    }
}
