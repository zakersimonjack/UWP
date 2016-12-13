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
    public sealed partial class MouthReport : Page
    {
        Manager manager = (Manager)App.loginperson;
        public ObservableCollection<todayLogMessage> mouthDisplayList = new ObservableCollection<todayLogMessage>();
        private int mouth;
        private int year;
        public MouthReport()
        {
            this.InitializeComponent();
            mouth = DateTime.Now.Month;
            year = DateTime.Now.Year;
            backButton.Visibility = Visibility.Visible;
            Display();     
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
                    case "上一月":
                        this.mouth--;
                        if (this.mouth <= 0)
                        {
                            this.year--;
                            this.mouth = 12;
                        }
                        break;
                    case "下一月":
                        this.mouth++;
                        if (this.mouth >= 12)
                        {
                            this.year++;
                            this.mouth = 1;
                        }
                        break;
                }
                Display();
            }
            catch
            {
            }
        }
        /// <summary>
        /// Display 已调用函数，只是暂时注释为了能运行
        /// </summary>
        private void Display()
        {
            mouthDisplayList.Clear();
            mouthListView.DataContext = mouthDisplayList;
            PageTitle.Text = year + "年" + mouth + "月";
            List<LogMessage> mouthList = new List<LogMessage>();
            DateTime dt = new DateTime(year,mouth,1);
             mouthList= manager.getLogMessageByMonth(dt);

             foreach (var a in mouthList)
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
                 mouthDisplayList.Add(s);
             }
             mouthListView.DataContext = mouthDisplayList;
             
            Money thisMouth = new Money();
            thisMouth = manager.getAmountOfMoney(dt, flagCode.month);
            incomeAll.Text = "总支出："+thisMouth.inMoney.ToString();
            sellAll.Text = "总收入："+thisMouth.outMoney.ToString();
            allDB.Text = "总收益：" + (thisMouth.outMoney - thisMouth.inMoney).ToString();

        }
      
    }
}
