using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        Manager manager = (Manager)App.loginperson;
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
            
                //
                var dialog = new ContentDialog()
                {
                    Title = "消息提示",
                    Content = "您要修改" + name + "的售价为:" + price +  "吗",
                    PrimaryButtonText = "确定",
                    SecondaryButtonText = "取消",
                    FullSizeDesired = false,
                };

                dialog.PrimaryButtonClick += async (_s, _e) =>
                {

                  if(manager.modifyPrice(ms))
                    {
                         await new MessageDialog("修改成功").ShowAsync();
                    }
                  else
                    {
                        await new MessageDialog("修改失败").ShowAsync();
                    }
                    
                 
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
        /// <summary>
        /// 
        /// </summary>
        private async void addItems()
        {
           nameList = manager.getAllCommodityMessage();

            if (nameList != null)
            {
                foreach (var i in nameList)
                {
                    string name = i.commodityName;
                    try
                    {
                        if(i.num!=0)
                        nameComboBox.Items.Add(name);
                    }
                    catch (NullReferenceException e)
                    {
                        await new MessageDialog("正在加载商品名单").ShowAsync();
                    }
                }
                try
                {
                    if (nameList[0].num != 0)
                        nameComboBox.Items.Add(nameList[0].commodityName);
                }
                catch (NullReferenceException e)
                {
                    Debug.WriteLine(nameList[0].commodityName);
                }
            }
            
            else
            {
                await new MessageDialog("服务器错误").ShowAsync();
            }
          
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void deleteAllCMD_Click(object sender, RoutedEventArgs e)
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
            var dialog = new ContentDialog()
            {
                Title = "消息提示",
                Content = "您要清空" + name + "的库存吗？",
                PrimaryButtonText = "确定",
                SecondaryButtonText = "取消",
                FullSizeDesired = false,
            };

            dialog.PrimaryButtonClick += async (_s, _e) =>
            {
                
                  if(manager.clearRepo(ms.id))
                  {
                      await new MessageDialog("清空"+ms.commodityName+"成功").ShowAsync();
                  }
                  else
                {
                    await new MessageDialog("清空" + ms.commodityName + "失败").ShowAsync();
                }
                  
               
            };
            await dialog.ShowAsync();

        }
    }
}
