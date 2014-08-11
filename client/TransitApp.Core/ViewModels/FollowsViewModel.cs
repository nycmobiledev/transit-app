using Cirrious.MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TransitApp.Core.Models;
using TransitApp.Core.Services;

namespace TransitApp.Core.ViewModels
{
    public class FollowsViewModel : BaseViewModel
    {
        private readonly IFollowService _service;
		private ICollection<Follow> _follows;

        public FollowsViewModel(IFollowService service)
		{
			_service = service;			        
		}

		public ICollection<Follow> Follows {
			get {
				return _follows;
			}
			set {
				this._follows = value;
				this.RaisePropertyChanged (() => this.Follows);
			}
		}

        private void RefleshFollows() {
            Follows = _service.GetFollows();
        }
    }
}
