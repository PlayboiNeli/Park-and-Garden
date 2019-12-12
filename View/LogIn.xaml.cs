﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Park_and_Garden.ViewModel;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Park_and_Garden.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LogIn : Page
    {
        public LogIn()
        {
            this.InitializeComponent();
            
        }
        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UsersViewModel uvm = new UsersViewModel();

            if (uvm.Login(TbxUsername.Text, TbxPassword.Text))
            {
                this.Frame.Navigate(typeof(MainPage));
            }

            
        }

    }
}
