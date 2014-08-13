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

        public FollowEditViewModel(IFollowService service)
        {
            _service = service;
        }

        public Station Station { get; set; }
    }
}
