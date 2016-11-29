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

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上有介绍

namespace 超市管理系统
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class BlankPage1 : Page
    { 
        private Frame manageFrame=null;
        public BlankPage1()
        {
            manageFrame = Window.Current.Content as Frame;
            this.InitializeComponent();
          
        }
        private void Income_Tile_Click(object sender, RoutedEventArgs e)
        {

            manageFrame.Navigate(typeof(Income));
        }

        private void Sell_Tile_Click(object sender, RoutedEventArgs e)
        {
            manageFrame.Navigate(typeof(sellPage));
        }


        private void SearchOfCommodity_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SearchToday_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MouthReport_Click(object sender, RoutedEventArgs e)
        {
            manageFrame.Navigate(typeof(MouthReport));
        }

        private void YearReport_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Chart_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ManageAccount_Click(object sender, RoutedEventArgs e)
        {

        }

        private void logout_Click(object sender, RoutedEventArgs e)
        {

        }

        private void logout_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
