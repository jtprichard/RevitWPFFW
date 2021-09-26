using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitWPFFW.core
{
    public class ViewModels
    {
        private static ViewModels _currentViewModels;

        public static ViewModels CurrentViewModels => _currentViewModels;

        public MainPageViewModel MainViewModel { get; private set; }
        public Page1BViewModel Page1BViewModel { get; private set; }
        public Page1ViewModel Page1ViewModel { get; private set; }
        public Page2ViewModel Page2ViewModel { get; private set; }

        public ViewModels(string testData)
        {
            MainViewModel = new MainPageViewModel(testData);
            Page1ViewModel = new Page1ViewModel();
            Page1BViewModel = new Page1BViewModel();
            Page2ViewModel = new Page2ViewModel();
        }

        public void SetCurrentViewModels(ViewModels viewModels)
        {
            _currentViewModels = viewModels;
        }

    }
}
