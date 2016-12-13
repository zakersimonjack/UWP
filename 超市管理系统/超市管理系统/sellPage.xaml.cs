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
    public sealed partial class sellPage : Page
    {
        CommodityMessage cm;
        Seller seller = (Seller)App.loginperson;
        public sellPage()
        {
           
            this.InitializeComponent();
            for (int i = 1; i <= 10; i++)
            {
                discountComboBox.Items.Add(i + "折");
            }
        }

        private async void searchCMDNumber_Click(object sender, RoutedEventArgs e)
        {
            bool flag = true;
            string code = codeOfCMDTextbox.Text;
            CommodityMessage? cm2;

            cm2 = seller.getCommodityById(code);
            if (cm2.HasValue)
            {
                nameOfCMDTextbox.Text = cm2.Value.commodityName;
                remainNumsTextblock.Text = cm2.Value.num.ToString();
                priceOfCMDTextBlock.Text = cm2.Value.outPrice.ToString();

            }
            else
            {
                await new MessageDialog("您查询的商品不存在").ShowAsync();
            }
        }

        private void Sell_Click(object sender, RoutedEventArgs e)
        {

            sell();

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
            sell();
        }
        //新增一条记账记录并返回
        private void appbar_buttonFinish_Click(object sender, RoutedEventArgs e)
        {

            Frame.GoBack();

        }
        //返回
        private void appbar_buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }
        private async void sell()
        {
            int num;
            float price;
            float discount;
            LogMessage ls = new LogMessage();
            try
            {
                num = int.Parse(buyNumsTextbox.Text);
                if (num > int.Parse(remainNumsTextblock.Text))
                {
                    await new MessageDialog("您购买商品的数量超过库存，请重新填数量信息").ShowAsync();
                    buyNumsTextbox.Text = "";
                    return;
                }
                price = float.Parse(priceOfCMDTextBlock.Text);
                discount = Convert.ToSingle(discountComboBox.SelectedIndex+1) * 1 / 10;
                Debug.WriteLine(discount.ToString());
              
            }
            catch (FormatException es)
            {
                await new MessageDialog(es.Message).ShowAsync();
                priceOfCMDTextBlock.Text = "";
                buyNumsTextbox.Text = "";
                return;
            }
            cm.commodityName = nameOfCMDTextbox.Text;
            cm.id = codeOfCMDTextbox.Text;
            ls.commodityName = cm.commodityName;
            ls.discount = discount;
            ls.num = num;
            ls.flag = false;
            ls.price = price;
            ls.id = cm.id;
            DateTime dt = new DateTime();
            dt = DateTime.Now;
            ls.time = dt;
            sellCode code = new sellCode();
            code = seller.sellCommodity(ls);
            switch(code)
            {
                case sellCode.success:
                    await new MessageDialog("商品" + ls.commodityName + "折扣为" + discount + "售出成功!").ShowAsync();
                    App.todayLogMessage.Add(ls);
                    codeOfCMDTextbox.Text = "";
                    nameOfCMDTextbox.Text = "";
                    buyNumsTextbox.Text = "";
                    remainNumsTextblock.Text = "";
                    priceOfCMDTextBlock.Text = "";
                    break;
                case sellCode.miss:
                    await new MessageDialog("服务器错误").ShowAsync();
                    break;
            }
           
        }
    }
}
