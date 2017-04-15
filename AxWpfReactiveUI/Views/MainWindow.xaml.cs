using System.Windows;
using AxWpfReactiveUI.ViewModels;
using ReactiveUI;

namespace AxWpfReactiveUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IViewFor<MainWindowViewModel>
    {
        public MainWindow()
        {
            InitializeComponent();

            ViewModel = AppDependencies.MainWindowViewModel;

            this.WhenAnyValue(x => x.ViewModel).BindTo(this, x => x.DataContext);
            this.BindCommand(ViewModel, vm => vm.Delete, v => v.MainButton);
        }

        object IViewFor.ViewModel
        {
            get { return ViewModel; }
            set { ViewModel = (MainWindowViewModel) value; }
        }

        public MainWindowViewModel ViewModel { get; set; }
    }
}
