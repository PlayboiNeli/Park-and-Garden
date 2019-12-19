using Park_and_Garden.View;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Contacts;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Park_and_Garden
{
    // Made by János Dominik Haskó

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            MainFrame.Navigate(typeof(Home));
        }

        private void MenuButton_Click(object sender, RoutedEventArgs e)
        {
            MenuSplitView.IsPaneOpen =! MenuSplitView.IsPaneOpen;
        }


        private void MainListView_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListViewItem_Home.IsSelected)
            {
                MainFrame.Navigate(typeof(Home));
            }

            if (ListViewItem_Search.IsSelected)
            {
                MainFrame.Navigate(typeof(Search));
            }

            if (ListViewItem_Add.IsSelected)
            {
                MainFrame.Navigate(typeof(ContactAdd));
            }

            if (ListViewItem_Users.IsSelected)
            {
                MainFrame.Navigate(typeof(ListViewContacts));
            }

        }

    }
}
