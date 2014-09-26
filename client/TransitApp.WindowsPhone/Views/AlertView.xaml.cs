using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using TransitApp.Core.ViewModels;
using Cirrious.CrossCore;
using System.ComponentModel;

namespace TransitApp.WindowsPhone.Views
{
    public partial class AlertsView : UserControl
    {
        public AlertsView()
        {
            InitializeComponent();
            
            if (!DesignerProperties.GetIsInDesignMode(this))
            {
                DataContext = new AlertsViewModel();
            }
        }               
    }
}
