﻿#pragma checksum "..\..\EditAuto.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "46C390268BF67570FBA14E5670C84874FE8F630E4506079441D8D088B6F9DEAA"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using Interfaces_Graficas;
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


namespace Interfaces_Graficas {
    
    
    /// <summary>
    /// EditAuto
    /// </summary>
    public partial class EditAuto : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 22 "..\..\EditAuto.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button anadirauto;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\EditAuto.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox introducirmatricula;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\EditAuto.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox introducirmarca;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\EditAuto.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox introducirkilometros;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\EditAuto.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label errormatricula;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\EditAuto.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label errormarca;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\EditAuto.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label errorkilometros;
        
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
            System.Uri resourceLocater = new System.Uri("/Interfaces_Graficas;component/editauto.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\EditAuto.xaml"
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
            this.anadirauto = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\EditAuto.xaml"
            this.anadirauto.Click += new System.Windows.RoutedEventHandler(this.anadirAutoButton);
            
            #line default
            #line hidden
            return;
            case 2:
            this.introducirmatricula = ((System.Windows.Controls.TextBox)(target));
            
            #line 37 "..\..\EditAuto.xaml"
            this.introducirmatricula.SelectionChanged += new System.Windows.RoutedEventHandler(this.introducirMatricula_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.introducirmarca = ((System.Windows.Controls.TextBox)(target));
            
            #line 38 "..\..\EditAuto.xaml"
            this.introducirmarca.SelectionChanged += new System.Windows.RoutedEventHandler(this.introducirMarca_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.introducirkilometros = ((System.Windows.Controls.TextBox)(target));
            
            #line 39 "..\..\EditAuto.xaml"
            this.introducirkilometros.SelectionChanged += new System.Windows.RoutedEventHandler(this.introducirKilometros_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.errormatricula = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.errormarca = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.errorkilometros = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

