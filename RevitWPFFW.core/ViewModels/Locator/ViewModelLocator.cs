using PB.MVVMToolkit.DialogServices;

namespace RevitWPFFW.core
{
    public class ViewModelLocator
    {
        private MainPageViewModel mainPageViewModel = null;
        public MainPageViewModel MainPageViewModel
        {
            get { return mainPageViewModel; }
            set { mainPageViewModel = value; }
        }

        public ViewModelLocator()
        {
            var vm = new MainViewModel();
            this.mainPageViewModel = vm.Register<MainPageViewModel>() as MainPageViewModel;
        }
    }
}
