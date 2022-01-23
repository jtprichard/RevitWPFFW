using System;
using System.Windows;
using System.Windows.Controls;
using PB.RevitWPFFW.core;

namespace PB.RevitWPFFW.ui
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();
            //DataContext = RevitDocument.CurrentViewModels.Page1ViewModel;
            DataContext = Page1ViewModel.CurrentViewModel;

        }

        /// <summary>
        /// Control Expansion for Page 1B Control Reference
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExpandButton_Click(object sender, RoutedEventArgs e)
        {
            if (Page1BControl.Height == 0)
                Page1BControl.Height = Double.NaN + 20;
            else
                Page1BControl.Height = 0;
        }
    }
}
