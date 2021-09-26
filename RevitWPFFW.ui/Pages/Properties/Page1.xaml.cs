using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using RevitWPFFW.core;

namespace RevitWPFFW.ui
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();
            DataContext = RevitDocument.CurrentViewModels.Page1ViewModel;

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
