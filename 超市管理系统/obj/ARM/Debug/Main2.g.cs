﻿#pragma checksum "D:\uwp\UWP\超市管理系统\Main2.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "7FA4C279AD32C8013FF8AFD7643B116F"
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
    partial class BlankPage1 : 
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
                    this.cvs1 = (global::Windows.UI.Xaml.Data.CollectionViewSource)(target);
                }
                break;
            case 2:
                {
                    this.LayoutRoot = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 3:
                {
                    this.todayListView = (global::Windows.UI.Xaml.Controls.ListView)(target);
                }
                break;
            case 4:
                {
                    global::Windows.UI.Xaml.Controls.TextBlock element4 = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                    #line 176 "..\..\..\Main2.xaml"
                    ((global::Windows.UI.Xaml.Controls.TextBlock)element4).SelectionChanged += this.TextBlock_SelectionChanged;
                    #line default
                }
                break;
            case 5:
                {
                    this.backButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 177 "..\..\..\Main2.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.backButton).Click += this.backButton_Click;
                    #line default
                }
                break;
            case 6:
                {
                    this.Chart = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 178 "..\..\..\Main2.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.Chart).Click += this.Chart_Click;
                    #line default
                }
                break;
            case 7:
                {
                    this.logout = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 179 "..\..\..\Main2.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.logout).Click += this.logout_Click_2;
                    #line default
                }
                break;
            case 8:
                {
                    this._columnItem = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 9:
                {
                    this.buttonGrid = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 10:
                {
                    this.ManageAccount = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 68 "..\..\..\Main2.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.ManageAccount).Click += this.ManageAccount_Click;
                    #line default
                }
                break;
            case 11:
                {
                    this.Sell_Tile = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 74 "..\..\..\Main2.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.Sell_Tile).Click += this.Sell_Tile_Click;
                    #line default
                }
                break;
            case 12:
                {
                    this.Income_Tile = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 81 "..\..\..\Main2.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.Income_Tile).Click += this.Income_Tile_Click;
                    #line default
                }
                break;
            case 13:
                {
                    this.SearchToday = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 88 "..\..\..\Main2.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.SearchToday).Click += this.SearchToday_Click;
                    #line default
                }
                break;
            case 14:
                {
                    this.MouthReport = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 95 "..\..\..\Main2.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.MouthReport).Click += this.MouthReport_Click;
                    #line default
                }
                break;
            case 15:
                {
                    this.YearReport = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 101 "..\..\..\Main2.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.YearReport).Click += this.YearReport_Click;
                    #line default
                }
                break;
            case 16:
                {
                    this.SearchOfCommodity = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 108 "..\..\..\Main2.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.SearchOfCommodity).Click += this.SearchOfCommodity_Click;
                    #line default
                }
                break;
            case 17:
                {
                    this.ManageAccount2 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 114 "..\..\..\Main2.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.ManageAccount2).Click += this.ManageAccount_Click;
                    #line default
                }
                break;
            case 18:
                {
                    this.SummaryMoneyOfcommodity = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 19:
                {
                    this.SummaryMoneyOfSellCommodity = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
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

