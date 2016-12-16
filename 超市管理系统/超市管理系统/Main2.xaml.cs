using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    public sealed partial class BlankPage1 : Page, INotifyPropertyChanged
    {
        public ObservableCollection<todayLogMessage> Today = new ObservableCollection<todayLogMessage>();
        private Frame manageFrame=null;
        private ObservableCollection<todayLogMessage> today = new ObservableCollection<todayLogMessage>();
        public event PropertyChangedEventHandler PropertyChanged;

        public BlankPage1()
        {
            manageFrame = Window.Current.Content as Frame;
            this.InitializeComponent();

            _columnItem.DataContext = this;
            Loaded += MainPage_Loaded;
          
        }
        private async void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            getMessage();
         todayListView.DataContext = Today;
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
            manageFrame.Navigate(typeof(manageCMD));
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
            manageFrame.Navigate(typeof(manageAcount1));
        }

        private void logout_Click(object sender, RoutedEventArgs e)
        {

        }

        private void logout_Click_1(object sender, RoutedEventArgs e)
        {

        }
        private void getMessage()
        {
           
            foreach(var a in App.todayLogMessage)
            {
                string type = "";
                float price;
                string Catepory = "";
                if (a.flag==true)
                {
                    type = "进货";
                    price = a.price;
                    Catepory = "-";
                }
                else
                {
                    type = "售货";
                    price = a.price * a.discount;
                    Catepory = "+";
                }
                Catepory += Convert.ToString(price * a.num);
                DateTime dt = a.time;
                todayLogMessage s = new todayLogMessage(type,a.commodityName,a.id,a.num.ToString(),price.ToString(),Catepory,dt);
                Today.Add(s);
                //todayListView.Items.Add(s);
                    
                     
           }
          
        } 
    }
}
