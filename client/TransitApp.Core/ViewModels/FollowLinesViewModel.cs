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
    public class FollowEditsViewModel : BaseViewModel
    {
        private readonly IFollowService _service;
        public FollowEditsViewModel(IFollowService service)
        {
            _service = service;
        }
    }
}
