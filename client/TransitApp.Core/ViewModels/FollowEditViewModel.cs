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
        private readonly IFollowService _followService;
        private FollowStation _followStation;
        private MvxCommand _saveCommand;


        public FollowEditViewModel(IFollowService followService)
        {
            _followService = followService;
        }

        protected override void InitFromBundle(IMvxBundle parameters)
        {
            string value;
            if (parameters.Data != null && parameters.Data.TryGetValue("StationId", out value))
            {
                _followStation = _followService.GetFollowStation(value);
            }
        }

        public Station Station
        {
            get
            {
                return _followStation.Station;
            }
        }

        public ICollection<FollowLine> Lines
        {
            get
            {
                return _followStation.Lines;
            }
        }

        public ICommand SaveCommand
        {
            get
            {
                return _saveCommand ?? (_saveCommand = new MvxCommand(this.ExecuteSaveCommand));
            }
        }

        private void ExecuteSaveCommand()
        {
            var lineIds = this.Lines.Where(x => x.IsFollowed).Select(x => x.Line.Id).ToArray();
            _followService.AddFollows(Station.Id, lineIds);
            Close(this);
        }
    }
}
