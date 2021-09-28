using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitWPFFW.core
{
    /*STORING VIEWMODELS AS INSTANCES
     *The template originally had all viewmodels stored as static instances created as singletons.
     *The issue is that these viewmodels were specific to each instance of Revit, and would not change when
     * a new document was created in the same Revit application instance.
     * Solution was refactored to create instances of each viewmodel.
     * A RevitDocument class was created to keep track of the current document, which it stores by using the document
     * hash code as a reference within a list.
     * A master ViewModel class was created to store the collection of viewmodels per document instances
     * The main WPF main view is instantiated at application startup, when there is no document available yet.
     * Also, a WPF view datacontext is tied to a specific VM instance, and the only way to update that instance
     * is to re-initialize it is to call an instance of the page, and have it initialize and update the datacontext
     * Since in MVVM, the intent is that the VM does not affect the form except through datacontext, I could not find a way
     * to update the master viewmodel after document opened.
     * The solution is to create a static instance of the main viewmodel that supports the page controls (even if no other pages are used)
     * The data viewmodels are instances that are called via commandmethods, which update the specific vm page in the main WPF window
     * CommandMethods trigger valueconverters, which instantiate new pages, which ultimately look for the current VM for that page
     * held in the VM class as a static CurrentVM instance.
     * The CurrentVM instance is updated upon a ViewActivated event registered at startup.
     * The WPF form then must be refreshed after the VM is activated.  Refreshing occurs at the MainVM class
     * by asking it to change its current page to the same page it is currently on, triggering the valueconverter and
     * instantiating the new page DataContext
     *
     */
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
        //public Page2ViewModel Page2ViewModel { get; private set; }

        public ViewModels(string mainVMInfo, string docHash)
        {
            string data = "Main VM: " + mainVMInfo + " || DocHash: " + docHash;
            //MainViewModel = new MainPageViewModel(testData);
            Page1ViewModel = new Page1ViewModel(data);
            Page1BViewModel = new Page1BViewModel();
            //Page2ViewModel = new Page2ViewModel();
        }

        public void SetCurrentViewModels(ViewModels viewModels)
        {
            CurrentViewModels = viewModels;
            //MainPageViewModel.Refresh();
        }

        public void SetMainPageViewModel(MainPageViewModel vm)
        {
            MainPageViewModel = vm;
        }

        private static ViewModels GetCurrentViewModels()
        {
            if (_currentViewModels == null)
                return new ViewModels("Null in ViewModels", "None");
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
