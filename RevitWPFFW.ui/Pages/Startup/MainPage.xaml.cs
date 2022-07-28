using System;
using System.Windows;
using System.Windows.Controls;
using Autodesk.Revit.UI;
using PB.MVVMToolkit;
using PB.RevitWPFFW.core;


namespace PB.RevitWPFFW.ui
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page, IDisposable, IDockablePaneProvider
    {
        #region Default Constructor
        /// <summary>
        /// Page Constructor
        /// </summary>
        public MainPage()
        {
            //Dummy reference to class in MVVMToolkit to ensure styles reference at startup
            ReferenceClass.Reference();

            InitializeComponent();

            //Assign datacontext
            DataContext = new MainPageViewModel();

        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Dispose Method
        /// </summary>
        public void Dispose()
        {
            this.Dispose();
        }

        /// <summary>
        /// Method to set up Dockable Pane for Revit
        /// </summary>
        /// <param name="data"></param>
        public void SetupDockablePane(DockablePaneProviderData data)
        {
            //Required for Revit
            data.FrameworkElement = this as FrameworkElement;

            //define initial pane position in revit ui
            data.InitialState = new DockablePaneState
            {
                DockPosition = DockPosition.Right,
                MinimumWidth = 300,
                MinimumHeight = 200,
            };
        }
        #endregion
    }
}
