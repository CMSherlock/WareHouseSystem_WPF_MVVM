﻿#pragma checksum "..\..\..\View\StockGoodsWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "C1F1509F6576D5909264436D3E11F8DE1F112EEE5C4E770130C330A92BE2C16E"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using MVVM_WareHouse.View;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace MVVM_WareHouse.View {
    
    
    /// <summary>
    /// StockGoodsWindow
    /// </summary>
    public partial class StockGoodsWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 15 "..\..\..\View\StockGoodsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox IDInput;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\View\StockGoodsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox NameInput;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\View\StockGoodsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TypeInput;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\View\StockGoodsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox PriceInput;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\View\StockGoodsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ManufacturalInput;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\View\StockGoodsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox StorageAmountInput;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\View\StockGoodsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock WarningText;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\View\StockGoodsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SubmitButton;
        
        #line default
        #line hidden
        
        
        #line 93 "..\..\..\View\StockGoodsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CancelButton;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/MVVM_WareHouse;component/view/stockgoodswindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\View\StockGoodsWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 9 "..\..\..\View\StockGoodsWindow.xaml"
            ((MVVM_WareHouse.View.StockGoodsWindow)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.DragWindow);
            
            #line default
            #line hidden
            return;
            case 2:
            this.IDInput = ((System.Windows.Controls.TextBox)(target));
            
            #line 15 "..\..\..\View\StockGoodsWindow.xaml"
            this.IDInput.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.SubmitCheck);
            
            #line default
            #line hidden
            return;
            case 3:
            this.NameInput = ((System.Windows.Controls.TextBox)(target));
            
            #line 19 "..\..\..\View\StockGoodsWindow.xaml"
            this.NameInput.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.SubmitCheck);
            
            #line default
            #line hidden
            return;
            case 4:
            this.TypeInput = ((System.Windows.Controls.TextBox)(target));
            
            #line 23 "..\..\..\View\StockGoodsWindow.xaml"
            this.TypeInput.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.SubmitCheck);
            
            #line default
            #line hidden
            return;
            case 5:
            this.PriceInput = ((System.Windows.Controls.TextBox)(target));
            
            #line 27 "..\..\..\View\StockGoodsWindow.xaml"
            this.PriceInput.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.TextBox_TextChanged);
            
            #line default
            #line hidden
            
            #line 28 "..\..\..\View\StockGoodsWindow.xaml"
            this.PriceInput.KeyDown += new System.Windows.Input.KeyEventHandler(this.TxtIndex_KeyDown);
            
            #line default
            #line hidden
            return;
            case 6:
            this.ManufacturalInput = ((System.Windows.Controls.TextBox)(target));
            
            #line 33 "..\..\..\View\StockGoodsWindow.xaml"
            this.ManufacturalInput.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.SubmitCheck);
            
            #line default
            #line hidden
            return;
            case 7:
            this.StorageAmountInput = ((System.Windows.Controls.TextBox)(target));
            
            #line 37 "..\..\..\View\StockGoodsWindow.xaml"
            this.StorageAmountInput.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.TextBox_TextChanged);
            
            #line default
            #line hidden
            
            #line 38 "..\..\..\View\StockGoodsWindow.xaml"
            this.StorageAmountInput.KeyDown += new System.Windows.Input.KeyEventHandler(this.TxtIndex_KeyDown);
            
            #line default
            #line hidden
            return;
            case 8:
            this.WarningText = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 9:
            this.SubmitButton = ((System.Windows.Controls.Button)(target));
            
            #line 44 "..\..\..\View\StockGoodsWindow.xaml"
            this.SubmitButton.Click += new System.Windows.RoutedEventHandler(this.Submit);
            
            #line default
            #line hidden
            return;
            case 10:
            this.CancelButton = ((System.Windows.Controls.Button)(target));
            
            #line 93 "..\..\..\View\StockGoodsWindow.xaml"
            this.CancelButton.Click += new System.Windows.RoutedEventHandler(this.CloseWindow);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

