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
        private static MainPageViewModel _mainPageViewModel;

        public static ViewModels CurrentViewModels
        {
            get { return GetCurrentViewModels(); }
            set { _currentViewModels = value; }
        }

        public static MainPageViewModel MainPageViewModel
        {
            get { return GetMainPageViewModel(); }
            set { _mainPageViewModel = value; }
        }

        //public MainPageViewModel MainViewModel { get; private set; }
        public Page1BViewModel Page1BViewModel { get; private set; }
        public Page1ViewModel Page1ViewModel { get; private set; }
        public Page2ViewModel Page2ViewModel { get; private set; }

        public ViewModels(string testData)
        {
            //MainViewModel = new MainPageViewModel(testData);
            Page1ViewModel = new Page1ViewModel();
            Page1BViewModel = new Page1BViewModel();
            Page2ViewModel = new Page2ViewModel();
        }

        public void SetCurrentViewModels(ViewModels viewModels)
        {
            CurrentViewModels = viewModels;
        }

        public void SetMainPageViewModel(MainPageViewModel vm)
        {
            MainPageViewModel = vm;
        }

        private static ViewModels GetCurrentViewModels()
        {
            if (_currentViewModels == null)
                return new ViewModels("Created From Null Get");
            return _currentViewModels;
        }

        private static MainPageViewModel GetMainPageViewModel()
        {
            if (_mainPageViewModel == null)
            {
                _mainPageViewModel = new MainPageViewModel("Created From Null Get");
                return _mainPageViewModel;
            }

            return _mainPageViewModel;
        }
    }
}
