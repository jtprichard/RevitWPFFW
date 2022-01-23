using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using PB.MVVMToolkit.Dialogs;

namespace PB.RevitWPFFW.ui
{
    /// <summary>
    /// Interaction logic for PropertiesPageSub1.xaml
    /// </summary>
    public partial class PropertiesPageSub1 : UserControl
    {
        public PropertiesPageSub1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// A dummy command to accept the value in the SeatNumberText textbox on enter press
        /// Temporarily moves visibility to a dummy hidden textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Property5Text_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Return)
            {
                DummyText.Visibility = Visibility.Visible;
                DummyText.Focus();
                DummyText.Visibility = Visibility.Hidden;
                Property5Text.Focus();
            }
        }

        private void VenueEditButton_OnClick(object sender, RoutedEventArgs e)
        {
            DialogOk.Show("Show Venue", "Venue", DialogImage.Info);
        }
    }
}
