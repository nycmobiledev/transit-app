using System;
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
    public partial class HomeView : MvxPhonePage
    {
        public HomeView()
        {
            InitializeComponent();
        }

        private void AppBarRefresh_Click(object sender, EventArgs e)
        {
            (ViewModel as HomeViewModel).AlertsViewModel.RefreshCommand.Execute(null);
        }

        private void AppBarEdit_Click(object sender, EventArgs e)
        {
            (ViewModel as HomeViewModel).AlertsViewModel.GoToEditCommand.Execute(null);
        }

        private void OnPivotSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var target = sender as Pivot;
            if (target.SelectedIndex >= 0)
            {
                this.ApplicationBar.IsVisible = "AppBar".Equals((target.Items[target.SelectedIndex] as PivotItem).Tag);
            }
        }
    }
}