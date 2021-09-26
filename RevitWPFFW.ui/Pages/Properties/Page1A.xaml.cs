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
    public partial class Page1A : UserControl
    {
        public Page1A()
        {
            InitializeComponent();
            //DataContext = Page1ViewModel.Instance;
            DataContext = RevitDocument.CurrentViewModels.Page1ViewModel;

        }
    }
}
