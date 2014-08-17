using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TransitApp.Core.Models;
using TransitApp.Core.Services;
using System.Windows.Input;
using Cirrious.MvvmCross.ViewModels;
using Cirrious.MvvmCross.Plugins.Messenger;

namespace TransitApp.Core
{
    public class FollowsChanged : MvxMessage
    {
        public FollowsChanged(object sender)
            : base(sender)
        {

        }

    }
}
