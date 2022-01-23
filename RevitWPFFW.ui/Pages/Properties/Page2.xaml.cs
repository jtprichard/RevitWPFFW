using System.Windows.Controls;
using PB.RevitWPFFW.core;

namespace PB.RevitWPFFW.ui
{
    /// <summary>
    /// Interaction logic for Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        public Page2()
        {
            InitializeComponent();
            DataContext = Page2ViewModel.CurrentViewModel;
        }
    }
}
