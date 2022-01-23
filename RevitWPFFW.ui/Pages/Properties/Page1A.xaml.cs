using System.Windows.Controls;
using PB.RevitWPFFW.core;

namespace PB.RevitWPFFW.ui
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Page1A : UserControl
    {
        public Page1A()
        {
            InitializeComponent();
            //DataContext = Page1ViewModel.CurrentViewModel;
            DataContext = Page1ViewModel.CurrentViewModel;

        }
    }
}
