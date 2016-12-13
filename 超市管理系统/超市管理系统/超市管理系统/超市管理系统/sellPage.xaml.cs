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
    public sealed partial class sellPage : Page
    {
        public sellPage()
        {
            this.InitializeComponent();
        }

        private void searchCMDNumber_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Sell_Click(object sender, RoutedEventArgs e)
        {

        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.Frame.CanGoBack)
            {
                this.Frame.GoBack();
            }
        }
        private async void appbar_buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            //用于隐藏软键盘
            Focus(FocusState.Pointer);
            //await 
        }
        //新增一条记账记录并返回
        private async void appbar_buttonFinish_Click(object sender, RoutedEventArgs e)
        {
            // if (await SaveVoucher())
            // {
            //保存成功则返回上一页
            //     Frame.GoBack();
            //  }
        }
        //返回
        private void appbar_buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }
       // private void 
    }
}
