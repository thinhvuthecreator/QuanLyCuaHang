﻿#pragma checksum "..\..\ThongTinTaiKhoan.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "C0890BC36B2A43ABD6D0C1F4057F1CA41C65D439222B67274ED32D1B4AE9446E"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
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
using ThongTinTaiKhoan;


namespace ThongTinTaiKhoan {
    
    
    /// <summary>
    /// ThongTinTaiKhoan
    /// </summary>
    public partial class ThongTinTaiKhoan : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 25 "..\..\ThongTinTaiKhoan.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock title;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\ThongTinTaiKhoan.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox taiKhoanTextbox;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\ThongTinTaiKhoan.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox matKhauTextbox;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\ThongTinTaiKhoan.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button changePassButton;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\ThongTinTaiKhoan.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button saveButton;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\ThongTinTaiKhoan.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button huyButton;
        
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
            System.Uri resourceLocater = new System.Uri("/ThongTinTaiKhoan;component/thongtintaikhoan.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\ThongTinTaiKhoan.xaml"
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
            this.title = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.taiKhoanTextbox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.matKhauTextbox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.changePassButton = ((System.Windows.Controls.Button)(target));
            
            #line 37 "..\..\ThongTinTaiKhoan.xaml"
            this.changePassButton.Click += new System.Windows.RoutedEventHandler(this.changePassButton_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.saveButton = ((System.Windows.Controls.Button)(target));
            
            #line 45 "..\..\ThongTinTaiKhoan.xaml"
            this.saveButton.Click += new System.Windows.RoutedEventHandler(this.saveButton_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.huyButton = ((System.Windows.Controls.Button)(target));
            
            #line 53 "..\..\ThongTinTaiKhoan.xaml"
            this.huyButton.Click += new System.Windows.RoutedEventHandler(this.huyButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

