﻿#pragma checksum "D:\uwp\UWP\超市管理系统\超市管理系统\MouthReport.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "9F1243AEEA90B0346DF28279760C7DB4"
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
    partial class MouthReport : 
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
                    this.ContenPanel = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 2:
                {
                    this.mouthListView = (global::Windows.UI.Xaml.Controls.ListView)(target);
                }
                break;
            case 3:
                {
                    this.allDB = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 4:
                {
                    this.sellAll = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 5:
                {
                    this.incomeAll = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 6:
                {
                    this.backButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 15 "..\..\..\MouthReport.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.backButton).Click += this.backButton_Click;
                    #line default
                }
                break;
            case 7:
                {
                    this.PageTitle = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 8:
                {
                    this.mouthPicker = (global::Windows.UI.Xaml.Controls.DatePicker)(target);
                    #line 17 "..\..\..\MouthReport.xaml"
                    ((global::Windows.UI.Xaml.Controls.DatePicker)this.mouthPicker).DateChanged += this.mouthPicker_DateChanged;
                    #line default
                }
                break;
            case 9:
                {
                    global::Windows.UI.Xaml.Controls.AppBarButton element9 = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    #line 72 "..\..\..\MouthReport.xaml"
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)element9).Click += this.ApplicationBarIconButton_Click;
                    #line default
                }
                break;
            case 10:
                {
                    global::Windows.UI.Xaml.Controls.AppBarButton element10 = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    #line 77 "..\..\..\MouthReport.xaml"
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)element10).Click += this.ApplicationBarIconButton_Click;
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

