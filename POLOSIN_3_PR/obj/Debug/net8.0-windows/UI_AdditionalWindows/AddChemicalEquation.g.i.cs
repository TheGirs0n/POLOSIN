﻿#pragma checksum "..\..\..\..\UI_AdditionalWindows\AddChemicalEquation.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "F76DFB06C549A54AA90EA32ECF30F5838A26435C"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

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
    /// AddChemicalEquation
    /// </summary>
    public partial class AddChemicalEquation : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\..\..\UI_AdditionalWindows\AddChemicalEquation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox LeftChemicalComponentsCountTextBox;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\..\UI_AdditionalWindows\AddChemicalEquation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox RightChemicalComponentsCountTextBox;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\..\UI_AdditionalWindows\AddChemicalEquation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddComponentsToReaction;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\..\UI_AdditionalWindows\AddChemicalEquation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddReaction;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\..\UI_AdditionalWindows\AddChemicalEquation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.GroupBox LeftComponentGroupBox;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\..\UI_AdditionalWindows\AddChemicalEquation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel LeftComponentsStackPanel;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\..\UI_AdditionalWindows\AddChemicalEquation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.GroupBox RightComponentGroupBox;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\..\UI_AdditionalWindows\AddChemicalEquation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel RightComponentsStackPanel;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\..\UI_AdditionalWindows\AddChemicalEquation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label OverralReactionView;
        
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
            System.Uri resourceLocater = new System.Uri("/POLOSIN_3_PR;V1.0.0.0;component/ui_additionalwindows/addchemicalequation.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\UI_AdditionalWindows\AddChemicalEquation.xaml"
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
            this.LeftChemicalComponentsCountTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 13 "..\..\..\..\UI_AdditionalWindows\AddChemicalEquation.xaml"
            this.LeftChemicalComponentsCountTextBox.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.TextBox_PreviewTextInputConcentration);
            
            #line default
            #line hidden
            
            #line 13 "..\..\..\..\UI_AdditionalWindows\AddChemicalEquation.xaml"
            this.LeftChemicalComponentsCountTextBox.PreviewKeyDown += new System.Windows.Input.KeyEventHandler(this.TextBox_PreviewKeyDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.RightChemicalComponentsCountTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 14 "..\..\..\..\UI_AdditionalWindows\AddChemicalEquation.xaml"
            this.RightChemicalComponentsCountTextBox.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.TextBox_PreviewTextInputConcentration);
            
            #line default
            #line hidden
            
            #line 14 "..\..\..\..\UI_AdditionalWindows\AddChemicalEquation.xaml"
            this.RightChemicalComponentsCountTextBox.PreviewKeyDown += new System.Windows.Input.KeyEventHandler(this.TextBox_PreviewKeyDown);
            
            #line default
            #line hidden
            return;
            case 3:
            this.AddComponentsToReaction = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\..\..\UI_AdditionalWindows\AddChemicalEquation.xaml"
            this.AddComponentsToReaction.Click += new System.Windows.RoutedEventHandler(this.AddComponentsToReaction_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.AddReaction = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\..\..\UI_AdditionalWindows\AddChemicalEquation.xaml"
            this.AddReaction.Click += new System.Windows.RoutedEventHandler(this.AddReaction_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.LeftComponentGroupBox = ((System.Windows.Controls.GroupBox)(target));
            return;
            case 6:
            this.LeftComponentsStackPanel = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 7:
            this.RightComponentGroupBox = ((System.Windows.Controls.GroupBox)(target));
            return;
            case 8:
            this.RightComponentsStackPanel = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 9:
            
            #line 32 "..\..\..\..\UI_AdditionalWindows\AddChemicalEquation.xaml"
            ((System.Windows.Controls.TextBox)(target)).PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.TextBox_PreviewTextInputConcentration);
            
            #line default
            #line hidden
            
            #line 32 "..\..\..\..\UI_AdditionalWindows\AddChemicalEquation.xaml"
            ((System.Windows.Controls.TextBox)(target)).PreviewKeyDown += new System.Windows.Input.KeyEventHandler(this.TextBox_PreviewKeyDown);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 38 "..\..\..\..\UI_AdditionalWindows\AddChemicalEquation.xaml"
            ((System.Windows.Controls.TextBox)(target)).PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.TextBox_PreviewTextInputConcentration);
            
            #line default
            #line hidden
            
            #line 38 "..\..\..\..\UI_AdditionalWindows\AddChemicalEquation.xaml"
            ((System.Windows.Controls.TextBox)(target)).PreviewKeyDown += new System.Windows.Input.KeyEventHandler(this.TextBox_PreviewKeyDown);
            
            #line default
            #line hidden
            return;
            case 11:
            this.OverralReactionView = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

