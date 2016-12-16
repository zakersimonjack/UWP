using System;
using System.Collections.Generic;
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


//“空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409 上有介绍

namespace 超市管理系统
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void loginButton_Click(object sender, RoutedEventArgs e)
        {
            string loginName = loginNameTB.Text;
            string passWord = passWordBox.Password;
            LoginControl logcontroll = null;
            logcontroll=LoginControl.login(loginName, passWord);
            if(logcontroll!=null)
            {
                Person nowPerson = new Person();
                nowPerson = logcontroll.returnPersonMes();
                App.loginperson = nowPerson;
                //loginperson = nowPerson;
            Frame root = Window.Current.Content as Frame;
            root.Navigate(typeof(BlankPage1));
            }
            else
            {
                var dialog = new ContentDialog()
                {
                    Title = "错误提示：",
                    Content = "",
                    PrimaryButtonText = "确定",
                    SecondaryButtonText = "取消",
                    FullSizeDesired = false,
                };
                dialog.PrimaryButtonClick += (_s, _e) => { };
               await dialog.ShowAsync();
            }
        }

        private void forgetButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
