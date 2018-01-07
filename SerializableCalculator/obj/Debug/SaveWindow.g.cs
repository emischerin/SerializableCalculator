﻿#pragma checksum "..\..\SaveWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5D47968C1EC7F2B6AE27F1F9D317FD34F18ECEA2"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using SerializableCalculator;
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


namespace SerializableCalculator {
    
    
    /// <summary>
    /// SaveWindow
    /// </summary>
    public partial class SaveWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\SaveWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label SelectFormat;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\SaveWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox SelectXml;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\SaveWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SaveButton;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\SaveWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SavePathTextBox;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\SaveWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label EnterPathLabel;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\SaveWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label SaveToXmlLabel;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\SaveWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SelectPathButton;
        
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
            System.Uri resourceLocater = new System.Uri("/SerializableCalculator;component/savewindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\SaveWindow.xaml"
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
            this.SelectFormat = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.SelectXml = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 3:
            this.SaveButton = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\SaveWindow.xaml"
            this.SaveButton.Click += new System.Windows.RoutedEventHandler(this.OnSaveButtonClick);
            
            #line default
            #line hidden
            return;
            case 4:
            this.SavePathTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.EnterPathLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.SaveToXmlLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.SelectPathButton = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\SaveWindow.xaml"
            this.SelectPathButton.Click += new System.Windows.RoutedEventHandler(this.OnSelectPathButtonClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

