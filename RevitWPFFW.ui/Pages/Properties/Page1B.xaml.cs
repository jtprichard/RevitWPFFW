using System.Windows.Controls;
using RevitWPFFW.core;

namespace RevitWPFFW.ui
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Page1B : UserControl
    {
        public Page1B()
        {
            InitializeComponent();
            DataContext = Page1BViewModel.Instance;

        }
    }
}
