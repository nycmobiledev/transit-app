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

		public FollowsViewModel (IFollowService service)
		{
			_service = service;
			RefleshFollows ();
		}

		public ICollection<FollowStation> Follows {
			get {
				return _follows;
			}
			set {
				this._follows = value;
				this.RaisePropertyChanged (() => this.Follows);
			}
		}

		private Cirrious.MvvmCross.ViewModels.MvxCommand<FollowStation> _goToEditCommandg;

		public ICommand GoToEditCommand {
			get {
				_goToEditCommandg = _goToEditCommandg ?? new MvxCommand<FollowStation> ((x) => 
					ShowViewModel<FollowEditViewModel> (x.Station)
				);

				return _goToEditCommandg;
			}
		}

		public ICommand GoToAddCommand {
			get {
				return new MvxCommand (() => ShowViewModel<SearchViewModel> ());
			}
		}

		private void RefleshFollows ()
		{
			Follows = _service.GetFollowsGroupByStation ();
		}

	}
}