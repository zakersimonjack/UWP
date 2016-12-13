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
    public sealed partial class MouthReport : Page
    {
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
        private  void Display()
        {
            PageTitle.Text = year + "年" + mouth + "月";
        }
        private void mouthPicker_DateChanged(object sender, DatePickerValueChangedEventArgs e)
        {
            DateTimeOffset DT = new DateTimeOffset();
            DT = mouthPicker.Date.Date;
            year = DT.Year;
            mouth = DT.Month;
            Display();
        }
    }
}
