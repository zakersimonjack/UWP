﻿#pragma checksum "D:\uwp\UWP\超市管理系统\超市管理系统\超市管理系统\sellPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "EAFAAA855316BF6E85FC7DFEEF5C6A18"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace 超市管理系统
{
    partial class sellPage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                {
                    this.Sell = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 114 "..\..\..\sellPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.Sell).Click += this.Sell_Click;
                    #line default
                }
                break;
            case 2:
                {
                    this.DatePicker = (global::Windows.UI.Xaml.Controls.DatePicker)(target);
                }
                break;
            case 3:
                {
                    this.TimePicker = (global::Windows.UI.Xaml.Controls.TimePicker)(target);
                }
                break;
            case 4:
                {
                    this.discountComboBox = (global::Windows.UI.Xaml.Controls.ComboBox)(target);
                }
                break;
            case 5:
                {
                    this.buyNumsTextbox = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 6:
                {
                    this.priceOfCMDTextBlock = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 7:
                {
                    this.remainNumsTextblock = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 8:
                {
                    this.searchCMDNumber = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 60 "..\..\..\sellPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.searchCMDNumber).Click += this.searchCMDNumber_Click;
                    #line default
                }
                break;
            case 9:
                {
                    this.codeOfCMDTextbox = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 10:
                {
                    this.nameOfCMDTextbox = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 11:
                {
                    this.backButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 19 "..\..\..\sellPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.backButton).Click += this.backButton_Click;
                    #line default
                }
                break;
            case 12:
                {
                    global::Windows.UI.Xaml.Controls.AppBarButton element12 = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    #line 124 "..\..\..\sellPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)element12).Click += this.appbar_buttonAdd_Click;
                    #line default
                }
                break;
            case 13:
                {
                    global::Windows.UI.Xaml.Controls.AppBarButton element13 = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    #line 129 "..\..\..\sellPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)element13).Click += this.appbar_buttonFinish_Click;
                    #line default
                }
                break;
            case 14:
                {
                    global::Windows.UI.Xaml.Controls.AppBarButton element14 = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    #line 134 "..\..\..\sellPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)element14).Click += this.appbar_buttonCancel_Click;
                    #line default
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

