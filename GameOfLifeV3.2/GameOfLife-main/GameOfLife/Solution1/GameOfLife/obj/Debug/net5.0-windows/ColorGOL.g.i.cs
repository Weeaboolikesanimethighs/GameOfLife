﻿#pragma checksum "..\..\..\ColorGOL.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "97C2941407748D49274A469BA09E5FAC6001580A"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using GameOfLife;
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


namespace GameOfLife {
    
    
    /// <summary>
    /// Window2
    /// </summary>
    public partial class Window2 : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\..\ColorGOL.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button startButton;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\ColorGOL.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Canvas gameArea;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\ColorGOL.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button clearButton;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\ColorGOL.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button pauseButton;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\ColorGOL.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button forwardButton;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\ColorGOL.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button loadButton;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\ColorGOL.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button saveImageButton;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\ColorGOL.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button saveButton;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\ColorGOL.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton c_blue;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\ColorGOL.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton c_green;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\ColorGOL.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton c_brown;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\ColorGOL.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton c_black;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.1.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/GameOfLife;component/colorgol.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\ColorGOL.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.1.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.startButton = ((System.Windows.Controls.Button)(target));
            
            #line 11 "..\..\..\ColorGOL.xaml"
            this.startButton.Click += new System.Windows.RoutedEventHandler(this.StartButton_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.gameArea = ((System.Windows.Controls.Canvas)(target));
            return;
            case 3:
            this.clearButton = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\..\ColorGOL.xaml"
            this.clearButton.Click += new System.Windows.RoutedEventHandler(this.ClearButton_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.pauseButton = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\..\ColorGOL.xaml"
            this.pauseButton.Click += new System.Windows.RoutedEventHandler(this.pauseButton_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.forwardButton = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\..\ColorGOL.xaml"
            this.forwardButton.Click += new System.Windows.RoutedEventHandler(this.forwardButton_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.loadButton = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\..\ColorGOL.xaml"
            this.loadButton.Click += new System.Windows.RoutedEventHandler(this.loadButton_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.saveImageButton = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\..\ColorGOL.xaml"
            this.saveImageButton.Click += new System.Windows.RoutedEventHandler(this.saveImageButton_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.saveButton = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\..\ColorGOL.xaml"
            this.saveButton.Click += new System.Windows.RoutedEventHandler(this.saveButton_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.c_blue = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 10:
            this.c_green = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 11:
            this.c_brown = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 12:
            this.c_black = ((System.Windows.Controls.RadioButton)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

