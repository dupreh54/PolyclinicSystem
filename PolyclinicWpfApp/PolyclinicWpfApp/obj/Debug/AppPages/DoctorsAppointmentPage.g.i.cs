﻿#pragma checksum "..\..\..\AppPages\DoctorsAppointmentPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "1AF990CA6F8702610E98E1E11732FFC6143261AA05AA8F7B567C046BDDA73319"
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
    /// DoctorsAppointmentPage
    /// </summary>
    public partial class DoctorsAppointmentPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 44 "..\..\..\AppPages\DoctorsAppointmentPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock PatientFullNameTB;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\AppPages\DoctorsAppointmentPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock PatientMedicalPolicyTB;
        
        #line default
        #line hidden
        
        
        #line 79 "..\..\..\AppPages\DoctorsAppointmentPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock ComplaintsTB;
        
        #line default
        #line hidden
        
        
        #line 106 "..\..\..\AppPages\DoctorsAppointmentPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox AppointmentResultTextBox;
        
        #line default
        #line hidden
        
        
        #line 130 "..\..\..\AppPages\DoctorsAppointmentPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CompletedStateBtn;
        
        #line default
        #line hidden
        
        
        #line 143 "..\..\..\AppPages\DoctorsAppointmentPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button OverdueStateBtn;
        
        #line default
        #line hidden
        
        
        #line 155 "..\..\..\AppPages\DoctorsAppointmentPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BackBtn;
        
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
            System.Uri resourceLocater = new System.Uri("/PolyclinicWpfApp;component/apppages/doctorsappointmentpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\AppPages\DoctorsAppointmentPage.xaml"
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
            this.PatientFullNameTB = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.PatientMedicalPolicyTB = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.ComplaintsTB = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.AppointmentResultTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.CompletedStateBtn = ((System.Windows.Controls.Button)(target));
            
            #line 133 "..\..\..\AppPages\DoctorsAppointmentPage.xaml"
            this.CompletedStateBtn.MouseEnter += new System.Windows.Input.MouseEventHandler(this.ExitBtn_MouseEnter);
            
            #line default
            #line hidden
            
            #line 133 "..\..\..\AppPages\DoctorsAppointmentPage.xaml"
            this.CompletedStateBtn.MouseLeave += new System.Windows.Input.MouseEventHandler(this.ExitBtn_MouseLeave);
            
            #line default
            #line hidden
            
            #line 133 "..\..\..\AppPages\DoctorsAppointmentPage.xaml"
            this.CompletedStateBtn.Click += new System.Windows.RoutedEventHandler(this.CompletedStateBtn_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.OverdueStateBtn = ((System.Windows.Controls.Button)(target));
            
            #line 146 "..\..\..\AppPages\DoctorsAppointmentPage.xaml"
            this.OverdueStateBtn.MouseEnter += new System.Windows.Input.MouseEventHandler(this.ExitBtn_MouseEnter);
            
            #line default
            #line hidden
            
            #line 146 "..\..\..\AppPages\DoctorsAppointmentPage.xaml"
            this.OverdueStateBtn.MouseLeave += new System.Windows.Input.MouseEventHandler(this.ExitBtn_MouseLeave);
            
            #line default
            #line hidden
            
            #line 146 "..\..\..\AppPages\DoctorsAppointmentPage.xaml"
            this.OverdueStateBtn.Click += new System.Windows.RoutedEventHandler(this.OverdueStateBtn_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.BackBtn = ((System.Windows.Controls.Button)(target));
            
            #line 158 "..\..\..\AppPages\DoctorsAppointmentPage.xaml"
            this.BackBtn.MouseEnter += new System.Windows.Input.MouseEventHandler(this.ExitBtn_MouseEnter);
            
            #line default
            #line hidden
            
            #line 158 "..\..\..\AppPages\DoctorsAppointmentPage.xaml"
            this.BackBtn.MouseLeave += new System.Windows.Input.MouseEventHandler(this.ExitBtn_MouseLeave);
            
            #line default
            #line hidden
            
            #line 158 "..\..\..\AppPages\DoctorsAppointmentPage.xaml"
            this.BackBtn.Click += new System.Windows.RoutedEventHandler(this.BackBtn_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

