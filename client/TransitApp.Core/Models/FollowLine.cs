using Cirrious.MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TransitApp.Core.Models
{
    public class FollowLine : MvxNotifyPropertyChanged
    {
        public Line Line { get; set; }

        private bool _isFollowed;

        public bool IsFollowed
        {
            get
            {
                return _isFollowed;
            }
            set
            {
                _isFollowed = value;
                this.RaisePropertyChanged(() => this.IsFollowed);
            }
        }
    }
}
