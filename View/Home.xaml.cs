using System;
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
    //Made by János Dominik Haskó

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Home : Page
    {
        public Home()
        {
            this.InitializeComponent();
            
        }


        private void Selector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void HomeListViewSelected_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           if (HomeListViewSelected.SelectedItem == null)
            {
                productstackpanne.Visibility = Visibility.Collapsed;
            }
            if (HomeListViewSelected.SelectedItem != null)
            {
                productstackpanne.Visibility = Visibility.Visible;
            }

        }

        private void MainComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (MainComboBox.SelectedItem.ToString() == "Plants")
            {
                ColorStackPanel.Visibility = Visibility.Collapsed;
            }
            if (MainComboBox.SelectedItem.ToString() == "Goods")
            {
                ColorStackPanel.Visibility = Visibility.Collapsed;
                SizeStackPanel.Visibility = Visibility.Collapsed;

            }
            if (MainComboBox.SelectedItem.ToString() == "Pots")
            {
                ColorStackPanel.Visibility = Visibility.Visible;
                SizeStackPanel.Visibility = Visibility.Visible;
            }
            if (MainComboBox.SelectedItem.ToString() == "Flowers")
            {
                ColorStackPanel.Visibility = Visibility.Visible;
                SizeStackPanel.Visibility = Visibility.Visible;
            }
        }
    }
}
