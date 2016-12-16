using System;
using System.Collections.Generic;
using System.Diagnostics;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上有介绍

namespace 超市管理系统 {
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class manageAcount1 : Page
    {
        private List<Person> allPersonList = new List<Person>();
        Manager manager = (Manager)App.loginperson;
        public manageAcount1()
        {

            PageLoad();
            this.InitializeComponent();
        }
        private async void PageLoad()
        {
                 allPersonList = manager.returnPersonMes();
   
                foreach (var person in allPersonList)
             {
                string name = person.name;
               try
              {
                    if(!name.Equals(App.loginperson.name))
                    nameComboBox.Items.Add(name);
              }
              catch(NullReferenceException e)
              {
                await new MessageDialog("加载名单完成").ShowAsync();
              }
              }
            try
            {
                if (!allPersonList[0].name.Equals(App.loginperson.name))
                    nameComboBox.Items.Add(allPersonList[0].name);
            }
            catch (NullReferenceException e)
            {
                Debug.WriteLine(allPersonList[0].name);
            }
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
        /// 
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
                Person newPerson = new Person();
                newPerson.loginName = loginName;
                newPerson.password = password;
                newPerson.name = name;
                Level level = new Level();
               if(buyerRadioButton.IsChecked==true)
                {
                    level = Level.buyer;
                }
               else
                {
                    level = Level.seller;
                }
                newPerson.level = level;
                await new MessageDialog("添加"+level+"成功").ShowAsync();
              
                 if(manager.addStaff(newPerson))
                 {
                  passwordTextBox.Password="";
                 passwordAgainTextBox.Password = "";
                 loginNameTextBox.Text = "";
                 nameTextBox.Text = "";
                 await new MessageDialog("新增成功").ShowAsync();
                 }
                 else
                 {
                  await new MessageDialog("新增失败").ShowAsync();
                 }
                 

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
        /// 
        /// </summary>
        private async void deleteOneAcount()
        {
            string name;
            name = nameComboBox.SelectedItem.ToString();
            string deleteLoginname="";
            foreach (var person in allPersonList)
            {
                if (person.name.Equals(name))
                {
                    deleteLoginname = person.loginName;
                    break;
                 }
            }
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

               manager.deleteStaff(deleteLoginname);
                await new MessageDialog("删除成功").ShowAsync();
            };
            await dialog.ShowAsync();
        }
        /// <summary>
        /// 
        /// </summary>
        private async void editPassword()
        {
            string loginName = App.loginperson.loginName;
            bool flag = true;
            string errorConment = "";
            string password = App.loginperson.password;
            if(!password .Equals(oldPasswordTextBox.Password))
            {
                flag = false;
                errorConment = "请填正确的密码";
            }
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
                    Person person = new Person();
                    person.loginName = App.loginperson.loginName;
                    person.name = App.loginperson.name;
                    person.password = App.loginperson.password;
                    person.level = App.loginperson.level;
                    manager.modifyPassword(person, newPasswordAgainTextBox.Password);
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
