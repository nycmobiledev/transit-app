﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Cirrious.MvvmCross.WindowsPhone.Views;
using TransitApp.Core.ViewModels;

namespace TransitApp.WindowsPhone.Views
{
    public partial class FollowsView : MvxPhonePage
    {
        public FollowsView()
        {
            InitializeComponent();
        }

        private void AppBarAdd_Click(object sender, EventArgs e)
        {
            (this.ViewModel as FollowsViewModel).GoToAddCommand.Execute(null);
        }
    }
}