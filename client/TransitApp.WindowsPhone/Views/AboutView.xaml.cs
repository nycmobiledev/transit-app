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
using Microsoft.Phone.Tasks;

namespace TransitApp.WindowsPhone.Views
{
    public partial class AboutView : UserControl
    {
        public AboutView()
        {
            InitializeComponent();
        }

        private void WebView_Loaded(object sender, RoutedEventArgs e)
        {
            this.WebView.NavigateToString("<html><body style='background:#000;color:#fff'>" + (this.DataContext as AboutViewModel).Content + "</body></html>");
        }

        private void WebView_Navigating(object sender, NavigatingEventArgs e)
        {
            e.Cancel = true;
            WebBrowserTask task = new WebBrowserTask() { Uri = e.Uri };
            task.Show();
        }        
    }
}
