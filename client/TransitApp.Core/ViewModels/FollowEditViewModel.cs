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
    public class FollowEditViewModel : BaseViewModel
    {
        private readonly IFollowService _service;
		private Station _station;

        public FollowEditViewModel(IFollowService service)
        {
            _service = service;
        }        

		public void Init(Station station)
		{
			_station = station; // because when it 

		}

		public Station Station  {
			get {
				return _station;
			}
			set {
				this._station = value;
				this.RaisePropertyChanged (() => this.Station);
			}
		}
    }
}
