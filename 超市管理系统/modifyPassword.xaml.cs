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

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上有介绍

namespace 超市管理系统
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class modifyPassword : Page
    {
        public modifyPassword()
        {
            this.InitializeComponent();
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            if(this.Frame.CanGoBack)
            {
                Frame.GoBack();
            }
        }

        private async void editButton_Click(object sender, RoutedEventArgs e)
        {
            string loginName = App.loginperson.loginName;
            bool flag = true;
            string errorConment = "";
            string password = App.loginperson.password;
            if (!password.Equals(oldPasswordTextBox.Password))
            {
                flag = false;
                errorConment = "请填正确的密码";
            }
            if (oldPasswordTextBox.Password == "")
            {
                flag = false;
                errorConment = "信息未填满";
            }
            if (newPasswordAgainTextBox.Password == "")
            {
                flag = false;
                errorConment = "信息未填满";
            }
            if (newPasswordAgainTextBox.Password == "")
            {

                flag = false;
                errorConment = "信息未填满";

            }
            if (newPasswordAgainTextBox.Password != newPasswordTextBox.Password)
            {
                flag = false;
                errorConment = "两次输入密码不正确";
            }
            if (!flag)
            {
                var dialog = new ContentDialog()
                {
                    Title = "错误提示：",
                    Content = errorConment,
                    PrimaryButtonText = "确定",
                    SecondaryButtonText = "取消",
                    FullSizeDesired = false,
                };
                dialog.PrimaryButtonClick += (_s, _e) => { };
                await dialog.ShowAsync();
            }
            else
            {
                var dialog = new ContentDialog()
                {
                    Title = "提示：",
                    Content = "您确定要修改" + App.loginperson.loginName + "的密码吗？",
                    PrimaryButtonText = "确定",
                    SecondaryButtonText = "取消",
                    FullSizeDesired = false,
                };
                dialog.PrimaryButtonClick += async (_s, _e) =>
                {
                    Person person = new Person();
                    person.loginName = App.loginperson.loginName;
                    person.name = App.loginperson.name;
                    person.password = App.loginperson.password;
                    person.level = App.loginperson.level;
                    App.loginperson.modifyPassword(person, newPasswordAgainTextBox.Password);
                    await new MessageDialog("修改成功").ShowAsync();
                };
                await dialog.ShowAsync();
                oldPasswordTextBox.Password = "";
                newPasswordAgainTextBox.Password = "";
                newPasswordAgainTextBox.Password = "";
            }
        }
    }
}

       
 
