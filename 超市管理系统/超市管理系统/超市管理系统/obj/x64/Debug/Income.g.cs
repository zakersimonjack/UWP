﻿#pragma checksum "D:\编程文件\超市管理系统\超市管理系统\Income.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "4C6309DD9CC54557302C6D1A167C9C79"
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
    partial class Income : 
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
                    this.newIncomeMessage = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 94 "..\..\..\Income.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.newIncomeMessage).Click += this.newIncomeMessage_Click;
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
                    this.incomeNumsTextbox = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 5:
                {
                    this.incomePriceTextbox = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 6:
                {
                    this.codeOfCMDTextbox = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 7:
                {
                    this.nameOfCMDTextbox = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 8:
                {
                    this.backButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 24 "..\..\..\Income.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.backButton).Click += this.backButton_Click;
                    #line default
                }
                break;
            case 9:
                {
                    global::Windows.UI.Xaml.Controls.AppBarButton element9 = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    #line 108 "..\..\..\Income.xaml"
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)element9).Click += this.appbar_buttonAdd_Click;
                    #line default
                }
                break;
            case 10:
                {
                    global::Windows.UI.Xaml.Controls.AppBarButton element10 = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    #line 113 "..\..\..\Income.xaml"
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)element10).Click += this.appbar_buttonFinish_Click;
                    #line default
                }
                break;
            case 11:
                {
                    global::Windows.UI.Xaml.Controls.AppBarButton element11 = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    #line 118 "..\..\..\Income.xaml"
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)element11).Click += this.appbar_buttonCancel_Click;
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

