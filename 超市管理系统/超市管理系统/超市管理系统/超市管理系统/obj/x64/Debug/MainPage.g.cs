﻿#pragma checksum "D:\uwp\UWP\超市管理系统\超市管理系统\超市管理系统\超市管理系统\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "A2B46B64D9B3BB57F75EE8CD4D939627"
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
    partial class MainPage : 
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
                    this.loginButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 61 "..\..\..\MainPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.loginButton).Click += this.loginButton_Click;
                    #line default
                }
                break;
            case 2:
                {
                    this.forgetButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 62 "..\..\..\MainPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.forgetButton).Click += this.forgetButton_Click;
                    #line default
                }
                break;
            case 3:
                {
                    this.loginNameTB = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 4:
                {
                    this.passWordBox = (global::Windows.UI.Xaml.Controls.PasswordBox)(target);
                }
                break;
            case 5:
                {
                    this.errorTextblock = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
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

