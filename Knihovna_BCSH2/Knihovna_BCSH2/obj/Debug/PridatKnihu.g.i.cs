﻿#pragma checksum "..\..\PridatKnihu.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "242356AC34BF28A2A5C4922CE3B87D87A3318D2A40367A64D7E662A189ABE630"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Knihovna_BCSH2;
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


namespace Knihovna_BCSH2 {
    
    
    /// <summary>
    /// PridatKnihu
    /// </summary>
    public partial class PridatKnihu : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 23 "..\..\PridatKnihu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox NazevTextBox;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\PridatKnihu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox AutorComboBox;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\PridatKnihu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ZanrTextBox;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\PridatKnihu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox VydavatelTextBox;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\PridatKnihu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox RokVydaniTextBox;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\PridatKnihu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox PocetStranTextBox;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\PridatKnihu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox JazykTextBox;
        
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
            System.Uri resourceLocater = new System.Uri("/Knihovna_BCSH2;component/pridatknihu.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\PridatKnihu.xaml"
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
            this.NazevTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.AutorComboBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 3:
            this.ZanrTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.VydavatelTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.RokVydaniTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.PocetStranTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.JazykTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            
            #line 45 "..\..\PridatKnihu.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.OkButton_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 46 "..\..\PridatKnihu.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.CancelButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

