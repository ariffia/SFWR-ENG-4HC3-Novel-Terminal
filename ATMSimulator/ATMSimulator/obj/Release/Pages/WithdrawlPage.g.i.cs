﻿#pragma checksum "..\..\..\Pages\WithdrawlPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "AC8D38CEB23918F546B2307C5A411A1C"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34011
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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


namespace ATMSimulator.Pages {
    
    
    /// <summary>
    /// WithdrawlPage
    /// </summary>
    public partial class WithdrawlPage : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\..\Pages\WithdrawlPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button FromChequingButton;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\Pages\WithdrawlPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button FromSavingButton;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\Pages\WithdrawlPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock ConfirmationText;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\Pages\WithdrawlPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ConfirmButton;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\Pages\WithdrawlPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TransactionAmount;
        
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
            System.Uri resourceLocater = new System.Uri("/ATMSimulator;component/pages/withdrawlpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\WithdrawlPage.xaml"
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
            this.FromChequingButton = ((System.Windows.Controls.Button)(target));
            
            #line 11 "..\..\..\Pages\WithdrawlPage.xaml"
            this.FromChequingButton.Click += new System.Windows.RoutedEventHandler(this.SelectAccount_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.FromSavingButton = ((System.Windows.Controls.Button)(target));
            
            #line 12 "..\..\..\Pages\WithdrawlPage.xaml"
            this.FromSavingButton.Click += new System.Windows.RoutedEventHandler(this.SelectAccount_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.ConfirmationText = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            
            #line 27 "..\..\..\Pages\WithdrawlPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Cancel_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.ConfirmButton = ((System.Windows.Controls.Button)(target));
            
            #line 28 "..\..\..\Pages\WithdrawlPage.xaml"
            this.ConfirmButton.Click += new System.Windows.RoutedEventHandler(this.ConfirmButton_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.TransactionAmount = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            
            #line 52 "..\..\..\Pages\WithdrawlPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.AppendToTextbox_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 53 "..\..\..\Pages\WithdrawlPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.AppendToTextbox_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 54 "..\..\..\Pages\WithdrawlPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.AppendToTextbox_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 55 "..\..\..\Pages\WithdrawlPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.AppendToTextbox_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 56 "..\..\..\Pages\WithdrawlPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.AppendToTextbox_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            
            #line 57 "..\..\..\Pages\WithdrawlPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.AppendToTextbox_Click);
            
            #line default
            #line hidden
            return;
            case 13:
            
            #line 58 "..\..\..\Pages\WithdrawlPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.AppendToTextbox_Click);
            
            #line default
            #line hidden
            return;
            case 14:
            
            #line 59 "..\..\..\Pages\WithdrawlPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.AppendToTextbox_Click);
            
            #line default
            #line hidden
            return;
            case 15:
            
            #line 60 "..\..\..\Pages\WithdrawlPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.AppendToTextbox_Click);
            
            #line default
            #line hidden
            return;
            case 16:
            
            #line 72 "..\..\..\Pages\WithdrawlPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.AppendToTextbox_Click);
            
            #line default
            #line hidden
            return;
            case 17:
            
            #line 73 "..\..\..\Pages\WithdrawlPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Decimal_Click);
            
            #line default
            #line hidden
            return;
            case 18:
            
            #line 79 "..\..\..\Pages\WithdrawlPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.backspace_Click);
            
            #line default
            #line hidden
            return;
            case 19:
            
            #line 80 "..\..\..\Pages\WithdrawlPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.clear_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
