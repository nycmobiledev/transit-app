using Cirrious.MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using TransitApp.Core.Models;
using TransitApp.Core.Services;

namespace TransitApp.Core.ViewModels
{
    public class FollowsViewModel : BaseViewModel
    {
        private readonly IFollowService _service;
        private ICollection<FollowStation> _follows;

        public FollowsViewModel(IFollowService service)
        {
            _service = service;
            RefleshFollows();
        }

        public ICollection<FollowStation> Follows
        {
            get
            {
                return _follows;
            }
            set
            {
                this._follows = value;
                this.RaisePropertyChanged(() => this.Follows);
            }
        }

        public ICommand GoToEditCommand
        {
            get
            {
                return new MvxCommand(() => ShowViewModel<FollowEditViewModel>());
            }
        }

        public ICommand GoToAddCommand
        {
            get
            {
                return new MvxCommand(() => ShowViewModel<SearchViewModel>());
            }
        }

        private void RefleshFollows()
        {
            Follows = _service.GetFollowsGroupByStation();
        }

    }
}