using System;
using System.Windows;
using System.Windows.Controls;
using Autodesk.Revit.UI;
using RevitWPFFW.core;
using PB.MVVMToolkit.DialogServices;


namespace RevitWPFFW.ui
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : MainPageBase, IDisposable, IDockablePaneProvider
    {
        public static MainPage Instance { get; private set; }
        #region Default Constructor
        /// <summary>
        /// Page Constructor
        /// </summary>
        public MainPage()
        {
            InitializeComponent();
            DataContext = new ViewModelLocator().MainPageViewModel;
            DialogService = new DialogService();
            Instance = this;

            var manager = new DataTemplateManager();

            manager.RegisterDataTemplate<CustomDialogViewModel, CustomDialogView>();

            //DataContext = MainPageViewModel.CurrentViewModel;
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
