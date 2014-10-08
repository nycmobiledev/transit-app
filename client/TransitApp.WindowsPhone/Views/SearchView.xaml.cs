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
    public partial class SearchView : MvxPhonePage
    {        
        public SearchView()
        {
            InitializeComponent();
        }

        private void PhoneTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            (ViewModel as SearchViewModel).SearchText = (sender as TextBox).Text;
        }

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            (this.ViewModel as SearchViewModel).GoBack();
        }
    }
}