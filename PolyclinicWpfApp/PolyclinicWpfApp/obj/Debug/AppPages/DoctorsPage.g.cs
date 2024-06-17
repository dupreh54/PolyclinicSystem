﻿#pragma checksum "..\..\..\AppPages\DoctorsPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "7C462B0B5F86B31904798693AFA169ADAA1ABACBCB6855EEFEC9B09F33A8DF7B"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.MahApps;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using PolyclinicWpfApp.AppPages;
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


namespace PolyclinicWpfApp.AppPages {
    
    
    /// <summary>
    /// DoctorsPage
    /// </summary>
    public partial class DoctorsPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\..\AppPages\DoctorsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid MainGrid;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\AppPages\DoctorsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ExitBtn;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\AppPages\DoctorsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button windowHideBtn;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\..\AppPages\DoctorsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button windowMaxMinBtn;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\..\AppPages\DoctorsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button windowCloseBtn;
        
        #line default
        #line hidden
        
        
        #line 84 "..\..\..\AppPages\DoctorsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock UserFullNameTB;
        
        #line default
        #line hidden
        
        /// <summary>
        /// FunctionFrame Name Field
        /// </summary>
        
        #line 87 "..\..\..\AppPages\DoctorsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        public System.Windows.Controls.Frame FunctionFrame;
        
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
            System.Uri resourceLocater = new System.Uri("/PolyclinicWpfApp;component/apppages/doctorspage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\AppPages\DoctorsPage.xaml"
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
            this.MainGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            
            #line 16 "..\..\..\AppPages\DoctorsPage.xaml"
            ((System.Windows.Controls.Border)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Border_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 3:
            this.ExitBtn = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\..\AppPages\DoctorsPage.xaml"
            this.ExitBtn.Click += new System.Windows.RoutedEventHandler(this.ExitBtn_Click);
            
            #line default
            #line hidden
            
            #line 21 "..\..\..\AppPages\DoctorsPage.xaml"
            this.ExitBtn.MouseEnter += new System.Windows.Input.MouseEventHandler(this.ExitBtn_MouseEnter);
            
            #line default
            #line hidden
            
            #line 21 "..\..\..\AppPages\DoctorsPage.xaml"
            this.ExitBtn.MouseLeave += new System.Windows.Input.MouseEventHandler(this.ExitBtn_MouseLeave);
            
            #line default
            #line hidden
            return;
            case 4:
            this.windowHideBtn = ((System.Windows.Controls.Button)(target));
            
            #line 42 "..\..\..\AppPages\DoctorsPage.xaml"
            this.windowHideBtn.Click += new System.Windows.RoutedEventHandler(this.windowHideBtn_Click);
            
            #line default
            #line hidden
            
            #line 45 "..\..\..\AppPages\DoctorsPage.xaml"
            this.windowHideBtn.MouseEnter += new System.Windows.Input.MouseEventHandler(this.ExitBtn_MouseEnter);
            
            #line default
            #line hidden
            
            #line 45 "..\..\..\AppPages\DoctorsPage.xaml"
            this.windowHideBtn.MouseLeave += new System.Windows.Input.MouseEventHandler(this.ExitBtn_MouseLeave);
            
            #line default
            #line hidden
            return;
            case 5:
            this.windowMaxMinBtn = ((System.Windows.Controls.Button)(target));
            
            #line 55 "..\..\..\AppPages\DoctorsPage.xaml"
            this.windowMaxMinBtn.Click += new System.Windows.RoutedEventHandler(this.windowMaxMinBtn_Click);
            
            #line default
            #line hidden
            
            #line 58 "..\..\..\AppPages\DoctorsPage.xaml"
            this.windowMaxMinBtn.MouseEnter += new System.Windows.Input.MouseEventHandler(this.ExitBtn_MouseEnter);
            
            #line default
            #line hidden
            
            #line 58 "..\..\..\AppPages\DoctorsPage.xaml"
            this.windowMaxMinBtn.MouseLeave += new System.Windows.Input.MouseEventHandler(this.ExitBtn_MouseLeave);
            
            #line default
            #line hidden
            return;
            case 6:
            this.windowCloseBtn = ((System.Windows.Controls.Button)(target));
            
            #line 68 "..\..\..\AppPages\DoctorsPage.xaml"
            this.windowCloseBtn.Click += new System.Windows.RoutedEventHandler(this.windowCloseBtn_Click);
            
            #line default
            #line hidden
            
            #line 71 "..\..\..\AppPages\DoctorsPage.xaml"
            this.windowCloseBtn.MouseEnter += new System.Windows.Input.MouseEventHandler(this.ExitBtn_MouseEnter);
            
            #line default
            #line hidden
            
            #line 71 "..\..\..\AppPages\DoctorsPage.xaml"
            this.windowCloseBtn.MouseLeave += new System.Windows.Input.MouseEventHandler(this.ExitBtn_MouseLeave);
            
            #line default
            #line hidden
            return;
            case 7:
            this.UserFullNameTB = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 8:
            this.FunctionFrame = ((System.Windows.Controls.Frame)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
