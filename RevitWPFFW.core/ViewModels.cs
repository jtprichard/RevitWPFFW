using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitWPFFW.core
{
    public class ViewModels
    {
        private static ViewModels _currentViewModel;

        public static ViewModels CurrentViewModels => _currentViewModel;

        public MainPageViewModel MainViewModel { get; private set; }
        public Page1BViewModel Page1BViewModel { get; private set; }
        public Page1ViewModel Page1ViewModel { get; private set; }
        public Page2ViewModel Page2ViewModel { get; private set; }

        public ViewModels()
        {
            MainViewModel = new MainPageViewModel();
            Page1ViewModel = new Page1ViewModel();
            Page1BViewModel = new Page1BViewModel();
            Page2ViewModel = new Page2ViewModel();
        }

    }
}
