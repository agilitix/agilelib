using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using AxWpfReactiveUI.ViewModels;
using Splat;

namespace AxWpfReactiveUI
{
    class AppDependencies
    {
        public static MainWindowViewModel MainWindowViewModel  => Locator.CurrentMutable.GetService<MainWindowViewModel>();

        static AppDependencies()
        {
            // Singletons
            Locator.CurrentMutable.RegisterConstant(new MainWindowViewModel(), typeof(MainWindowViewModel));
        }
    }
}
