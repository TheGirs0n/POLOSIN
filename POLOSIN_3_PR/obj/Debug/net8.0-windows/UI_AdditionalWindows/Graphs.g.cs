﻿#pragma checksum "..\..\..\..\UI_AdditionalWindows\Graphs.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "E48F7A4F565A5FDC1628B9D67CF24DFA4256E511"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using LiveCharts.Wpf;
using POLOSIN_3_PR.UI_AdditionalWindows;
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


namespace POLOSIN_3_PR.UI_AdditionalWindows {
    
    
    /// <summary>
    /// Graphs
    /// </summary>
    public partial class Graphs : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\..\..\UI_AdditionalWindows\Graphs.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal LiveCharts.Wpf.CartesianChart ConcentrationGraphs;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\..\UI_AdditionalWindows\Graphs.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ElapsedTimeTextBox;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\..\UI_AdditionalWindows\Graphs.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox MemoryUsedTextBox;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\..\UI_AdditionalWindows\Graphs.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox OperationCountTextBox;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\..\UI_AdditionalWindows\Graphs.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button GetDocument;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\..\UI_AdditionalWindows\Graphs.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid ConcentrationDataGrid;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.10.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/POLOSIN_3_PR;component/ui_additionalwindows/graphs.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\UI_AdditionalWindows\Graphs.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.10.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.ConcentrationGraphs = ((LiveCharts.Wpf.CartesianChart)(target));
            return;
            case 2:
            this.ElapsedTimeTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.MemoryUsedTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.OperationCountTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.GetDocument = ((System.Windows.Controls.Button)(target));
            
            #line 35 "..\..\..\..\UI_AdditionalWindows\Graphs.xaml"
            this.GetDocument.Click += new System.Windows.RoutedEventHandler(this.GetDocument_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.ConcentrationDataGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

