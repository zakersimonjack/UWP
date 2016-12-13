using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public sealed partial class todayReport : Page
    {
        public ObservableCollection<todayLogMessage> dayLogList = new ObservableCollection<todayLogMessage>();
        private int mouth;
        private int year;
        private int day;
        Manager manager = (Manager)App.loginperson;
        public todayReport()
        {
            this.InitializeComponent();
            DateTime dt = DateTime.Now;
            year = dt.Year;
            mouth = dt.Month;
            day = dt.Day;
            Display();
            backButton.Visibility = Visibility.Visible;
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.Frame.CanGoBack)
            {
                this.Frame.GoBack();
            }
        }

        private void dayPicker_DateChanged(object sender, DatePickerValueChangedEventArgs e)
        {
            DateTimeOffset DT = new DateTimeOffset();
            DT = dayPicker.Date.Date;
            day = DT.Day;
            year = DT.Year;
            mouth = DT.Month;
            Display();
        }

        private void Display()
        {
            dayLogList.Clear();
            dayListView.DataContext = dayLogList;
            PageTitle.Text = year + "年" + mouth + "月"+day+"日";
            List<LogMessage> dayList = new List<LogMessage>();
            DateTime dt = dayPicker.Date.Date;

            dayList = manager.getLogMessageByDay(dt);
            if(dayList!=null)
            {
                  foreach (var a in dayList)
             {
                 string type = "";
                 float price;
                 string Catepory = "";
                 if (a.flag == true)
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
                 DateTime logTime = a.time;
                 todayLogMessage s = new todayLogMessage(type, a.commodityName, a.id, a.num.ToString(), price.ToString(), Catepory, logTime);
                dayLogList.Add(s);
             }
            }
           
             dayListView.DataContext = dayLogList;
             
              Money thisDay = new Money();
            thisDay = manager.getAmountOfMoney(dt, flagCode.day);
              incomeAll.Text = "收入："+thisDay.inMoney.ToString();
              sellAll.Text ="支出"+ thisDay.outMoney.ToString();
            allDB.Text = "总收益"+(thisDay.outMoney - thisDay.inMoney).ToString();
        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {

        }
        private void ApplicationBarIconButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
  
}
