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
    public sealed partial class Income : Page
    {
        LogControl log = new LogControl();
        public Income()
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
        private async void appbar_buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            uiStock();
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

        private  void newIncomeMessage_Click(object sender, RoutedEventArgs e)
        {
            uiStock();
        }
        private async void uiStock()//差调用进货函数
        {
            bool flag = true;
            if (codeOfCMDTextbox.Text == "")
                flag = false;
            if (nameOfCMDTextbox.Text == "")
                flag = false;
            if (incomeNumsTextbox.Text == "")
                flag = false;
            if (incomePriceTextbox.Text == "")
                flag = false;
          
            if (!flag)
            {
                var dialog = new ContentDialog()
                {
                    Title = "错误提示：",
                    Content = "请完整地填好进货信息",
                    PrimaryButtonText = "确定",
                    SecondaryButtonText = "取消",
                    FullSizeDesired = false,
                };
                dialog.PrimaryButtonClick += (_s, _e) => { };
                await dialog.ShowAsync();
            }
            else
            {
                float incomePrice;
                
                int num;
                try
                {
                    incomePrice = float.Parse(incomePriceTextbox.Text);
                 
                    num = int.Parse(incomeNumsTextbox.Text);
                }
                catch (FormatException es)
                {
                    var dialog = new ContentDialog()
                    {
                        Title = "错误提示：",
                        Content = es.Message,
                        PrimaryButtonText = "确定",
                        SecondaryButtonText = "取消",
                        FullSizeDesired = false,
                    };
                    dialog.PrimaryButtonClick += (_s, _e) => { };
                    await dialog.ShowAsync();
                    incomeNumsTextbox.Text = "";
                  
                    incomeNumsTextbox.Text = "";
                    return;
                }
                LogMessage lm = new LogMessage();
                lm.commodityName = nameOfCMDTextbox.Text;
                lm.id = codeOfCMDTextbox.Text;
                lm.flag = true;
                lm.time = DatePicker.Date.Date;
                lm.time += TimePicker.Time;
                lm.price = incomePrice;
                lm.num = num;
                App.todayLogMessage.Add(lm);

                await new MessageDialog("新增商品"+lm.commodityName+"编号为"+lm.id+"进货价格为:"+incomePrice+",数量为"+num+". 成功").ShowAsync();
                codeOfCMDTextbox.Text = "";
                nameOfCMDTextbox.Text = "";
                incomeNumsTextbox.Text = "";
                incomePriceTextbox.Text = "";
               


            }
        }
        
    }
}
