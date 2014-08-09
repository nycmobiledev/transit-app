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
            //Search,
            //Setting,
            About
        }

        public HomeViewModel()
        {
            this.m_MenuItems = new List<MenuViewModel>
                              {
								  new MenuViewModel{Section = Section.Alarts,Title = "Alerts"},
                                  //new MenuViewModel{Section = Section.Search,Title = "Search"},
                                  //new MenuViewModel{Section = Section.Setting,Title = "Setting"},
				                  new MenuViewModel{Section = Section.About,Title = "About"}
                              };
        }

        private List<MenuViewModel> m_MenuItems;
        public List<MenuViewModel> MenuItems
        {
            get { return this.m_MenuItems; }
            set { this.m_MenuItems = value; this.RaisePropertyChanged(() => this.MenuItems); }
        }


        private MvxCommand<MenuViewModel> m_SelectMenuItemCommand;
        public ICommand SelectMenuItemCommand
        {
            get
            {
                return this.m_SelectMenuItemCommand ?? (this.m_SelectMenuItemCommand = new MvxCommand<MenuViewModel>(this.ExecuteSelectMenuItemCommand));
            }
        }

        private void ExecuteSelectMenuItemCommand(MenuViewModel item)
        {
            //navigate if we have to, pass the id so we can grab from cache... or not
            switch (item.Section)
            {

                case Section.About:
                    this.ShowViewModel<AboutViewModel>(new { item.Id });
                    break;
                case Section.Alarts:
                    this.ShowViewModel<AlertsViewModel>(new { item.Id });
                    break;
//                case Section.Search:
//                    this.ShowViewModel<SearchViewModel>(new { item.Id });
//                    break;
                //case Section.Setting:
                //    this.ShowViewModel<SettingViewModel>(new { item.Id });
                //    break;

            }

        }

        public Section GetSectionForViewModelType(Type type)
        {

            if (type == typeof(AboutViewModel))
                return Section.About;

            if (type == typeof(AlertsViewModel))
                return Section.Alarts;

//            if (type == typeof(SearchViewModel))
//                return Section.Search;
//
//            if (type == typeof(SettingViewModel))
//                return Section.Setting;

            return Section.Unknown;
        }
    }
}
