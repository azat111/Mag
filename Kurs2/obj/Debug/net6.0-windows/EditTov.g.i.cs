﻿#pragma checksum "..\..\..\EditTov.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1D3D89DBEE28760B19292034DAC87FD88FE0B3C4"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using Kurs2;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace Kurs2 {
    
    
    /// <summary>
    /// EditTov
    /// </summary>
    public partial class EditTov : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 51 "..\..\..\EditTov.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TovName;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\EditTov.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TovKol;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\EditTov.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TovKat;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\EditTov.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TovStoim;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\EditTov.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image TovPhoto;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\..\EditTov.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView EditTovar;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.2.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Kurs2;component/edittov.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\EditTov.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.2.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 44 "..\..\..\EditTov.xaml"
            ((System.Windows.Controls.Label)(target)).MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.ToVihodBtn);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 45 "..\..\..\EditTov.xaml"
            ((System.Windows.Controls.Label)(target)).MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.ChekZakaziBtn);
            
            #line default
            #line hidden
            return;
            case 3:
            this.TovName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.TovKol = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.TovKat = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.TovStoim = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            
            #line 55 "..\..\..\EditTov.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.EditTovBtn);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 56 "..\..\..\EditTov.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.AddTovBtn);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 57 "..\..\..\EditTov.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.TovPhotoBtn);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 58 "..\..\..\EditTov.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.TovDelBtn);
            
            #line default
            #line hidden
            return;
            case 11:
            this.TovPhoto = ((System.Windows.Controls.Image)(target));
            return;
            case 12:
            this.EditTovar = ((System.Windows.Controls.ListView)(target));
            
            #line 61 "..\..\..\EditTov.xaml"
            this.EditTovar.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.GetTov);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

