﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
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
    public sealed partial class YearReport : Page
    {
        public ObservableCollection<todayLogMessage> yearDisplayList = new ObservableCollection<todayLogMessage>();
        Manager manager = (Manager)App.loginperson;
        private int year;

        public YearReport()
        {
            this.InitializeComponent();
            year = DateTime.Now.Year;
            backButton.Visibility = Visibility.Visible;
            Display();
        }
        /// <summary>
        /// 
        /// </summary>
        private void Display()
        {
            yearDisplayList.Clear();
            mouthListView.DataContext = yearDisplayList;
            incomeAll.Text = "";
            sellAll.Text = "";
            allDB.Text = "";
            PageTitle.Text = year + "年";
            List<LogMessage> yearList = new List<LogMessage>();
            float allIncomeMoney = 0f;

            DateTime dt = new DateTime(year, 1, 1);
            yearList = manager.getLogMessageByYear(dt);
            if (yearList != null)
            {
                foreach (var a in yearList)
                {
                    string type = "";
                    float price;
                    string Catepory = "";
                    if (a.flag == true)
                    {
                        type = "进货";
                        allIncomeMoney += a.price * a.num;
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
                    yearDisplayList.Add(s);
                }
                mouthListView.DataContext = yearDisplayList;
                Money yearMoney = new Money();
                yearMoney = manager.getAmountOfMoney(dt, flagCode.year);
                incomeAll.Text = "总支出：" + allIncomeMoney.ToString();
                sellAll.Text = "总收入：" + yearMoney.outMoney.ToString();
                allDB.Text = "总收益：" + (yearMoney.outMoney - yearMoney.inMoney).ToString();
            }
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
             if (this.Frame.CanGoBack)
            {
                this.Frame.GoBack();
            }
        }

      
        private void ApplicationBarIconButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                switch ((sender as AppBarButton).Label)
                {
                    case "上一年":
                        this.year--;
                        break;
                    case "下一年":
                        this.year++;
                        break;
                }
                Display();
            }
            catch
            {
            }
        }

        private async void deleteLog_Click(object sender, RoutedEventArgs e)
        {
            DateTime dt = new DateTime(year, 1, 1);
            var dialog = new ContentDialog()
            {
                Title = "提示：",
                Content = "您确定要删除" + year + "年的日志吗？",
                PrimaryButtonText = "确定",
                SecondaryButtonText = "取消",
                FullSizeDesired = false,
            };
            dialog.PrimaryButtonClick += async (_s, _e) =>
            {
                manager.deleteLogMessage(dt, flagCode.year);
                await new MessageDialog("删除成功").ShowAsync();
            };
            await dialog.ShowAsync();
        }
    }
}
