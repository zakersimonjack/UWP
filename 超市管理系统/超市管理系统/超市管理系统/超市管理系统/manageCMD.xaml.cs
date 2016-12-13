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
    public sealed partial class manageCMD : Page
    {
        List<CommodityMessage> nameList = new List<CommodityMessage>();

        public manageCMD()
        {
            addItems();
            this.InitializeComponent();
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.Frame.CanGoBack)
            {
                this.Frame.GoBack();
            }
        }

        private void CMDnameOfListBox_DataContextChanged(FrameworkElement sender, DataContextChangedEventArgs args)
        {

        }

        private void editCMD_Click(object sender, RoutedEventArgs e)
        {
            editCMDMessage();
        }
        private async void editCMDMessage()
        {
            bool flag = true;
            float price;
            int numbers;
            float incomePrice;
            string name = nameComboBox.SelectedItem.ToString();
            if (priceTextBox.Text == "")
            {
                flag = false;

            }
            if (numbersTextBox.Text == "")
            {
                flag = false;
            }
            try
            {
                price = float.Parse(priceTextBox.Text);
                numbers = int.Parse(numbersTextBox.Text);
                incomePrice = float.Parse(incomePriceTextBlock.Text);
            }
            catch (FormatException es)
            {
                await new MessageDialog(es.Message).ShowAsync();
                return;
            }
            if (!flag)
            {
                await new MessageDialog("请先进行查询得到商品具体信息").ShowAsync();
            }
            else
            {
                CommodityMessage ms = new CommodityMessage();
                foreach (var cm in nameList)
                {
                    if (cm.commodityName == name)
                    {
                        ms = cm;
                        break;
                    }
                }
                ms.outPrice = price;
                ms.num = numbers;
                //
                var dialog = new ContentDialog()
                {
                    Title = "消息提示",
                    Content = "您要修改" + name + "的售价为:" + price + "，剩余数量为" + numbers + "吗",
                    PrimaryButtonText = "确定",
                    SecondaryButtonText = "取消",
                    FullSizeDesired = false,
                };

                dialog.PrimaryButtonClick += async (_s, _e) =>
                {

                    //在这里写删除函数,信息放在MS中
                    await new MessageDialog("修改成功").ShowAsync();
                };
                await dialog.ShowAsync();

            }

        }

        private void search_Click(object sender, RoutedEventArgs e)
        {
            string name = nameComboBox.SelectedItem.ToString();

            CommodityMessage ms = new CommodityMessage();
            foreach (var cm in nameList)
            {
                if (cm.commodityName == name)
                {
                    ms = cm;
                    break;
                }
            }
            priceTextBox.Text = ms.outPrice.ToString();
            numbersTextBox.Text = ms.num.ToString();
            incomePriceTextBlock.Text = ms.inPrice.ToString();

        }
        private async void addItems()
        {
            Random ran = new Random();
            CommodityMessage cm = new CommodityMessage();
            for (int i = 0; i < 5; i++)
            {
                cm.commodityName = "name" + i;
                cm.num = ran.Next(1, 500);
                cm.inPrice = ran.Next();
                cm.outPrice = ran.Next();
                nameList.Add(cm);
            }
            foreach (var i in nameList)
            {
                string name = i.commodityName;
                try
                {
                    nameComboBox.Items.Add(name);
                }
                catch (NullReferenceException e)
                {
                    await new MessageDialog("正在加载商品名单").ShowAsync();
                } 

            }
        }
    }
}
