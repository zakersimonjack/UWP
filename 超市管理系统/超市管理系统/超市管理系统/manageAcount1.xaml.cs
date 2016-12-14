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
    public sealed partial class manageAcount1 : Page
    {
        public manageAcount1()
        {
            this.InitializeComponent();
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.Frame.CanGoBack)
            {
                this.Frame.GoBack();
            }
        }

        private void addNewAcount_Click(object sender, RoutedEventArgs e)
        {
            addAcount();
        }
        /// <summary>
        /// 新增账号函数没添加
        /// </summary>
        private async void addAcount()
        {
           
            bool flag = true;
            if (passwordAgainTextBox.Password == "")
                flag = false;
            if (passwordTextBox.Password == "")
                flag = false;
            if (loginNameTextBox.Text == "")
                flag = false;
            if (nameTextBox.Text == "")
                flag = false;
            if(passwordAgainTextBox.Password!=passwordTextBox.Password)     
                flag = false;
            if(!flag)
            { 
                var dialog = new ContentDialog()
                {
                    Title = "错误提示：",
                    Content = "信息未填完整或两次密码不正确",
                    PrimaryButtonText = "确定",
                    SecondaryButtonText = "取消",
                    FullSizeDesired = false,
                };
                dialog.PrimaryButtonClick += (_s, _e) => { };
                await dialog.ShowAsync();
            }
            else
            {
                string password = passwordTextBox.Password;
                string loginName = loginNameTextBox.Text;
                string name = nameTextBox.Text;
                //新建账号函数
                passwordTextBox.Password="";
                passwordAgainTextBox.Password = "";
                loginNameTextBox.Text = "";
                nameTextBox.Text = "";
                await new MessageDialog("新增成功").ShowAsync();
            }
        }

        private void backout_Click(object sender, RoutedEventArgs e)
        {

        }

        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            editPassword();
        }

        private void deleteAcount_Click(object sender, RoutedEventArgs e)
        {
            deleteOneAcount();
        }
        /// <summary>
        /// 删除账号函数没写
        /// </summary>
        private async void deleteOneAcount()
        {
            string name;
            name = (string)nameComboBox.SelectedValue;
            var dialog = new ContentDialog()
            {
                Title = "消息提示",
                Content = "您确定要删除的账号名字是："+name+"吗？",
                PrimaryButtonText = "确定",
                SecondaryButtonText = "取消",
                FullSizeDesired = false,
            };

            dialog.PrimaryButtonClick += async (_s, _e) =>
            {

                //在这里写删除函数
                await new MessageDialog("删除成功").ShowAsync();
            };
            await dialog.ShowAsync();
        }
        private async void editPassword()
        {
            string loginName = App.loginperson.loginName;
            bool flag = true;
            string errorConment = "";
            //要增添对旧密码的判断
            if (oldPasswordTextBox.Password == "")
            {
                flag = false;
                errorConment = "信息未填满";
            }
            if(newPasswordAgainTextBox.Password=="")
            {
                flag = false;
                errorConment = "信息未填满";
            }
            if(newPasswordAgainTextBox.Password=="")
            {
                
                    flag = false;
                    errorConment = "信息未填满";
                
            }
            if(newPasswordAgainTextBox.Password!=newPasswordTextBox.Password)
            {
                flag = false;
                errorConment = "两次输入密码不正确";
            }
            if(!flag)
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
                    Content = "您确定要修改"+App.loginperson.loginName+"的密码吗？",
                    PrimaryButtonText = "确定",
                    SecondaryButtonText = "取消",
                    FullSizeDesired = false,
                };
                dialog.PrimaryButtonClick += async (_s, _e) =>
                {
                    //在这里传入信息
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
