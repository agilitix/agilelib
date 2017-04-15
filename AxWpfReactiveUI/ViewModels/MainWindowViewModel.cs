using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;

namespace AxWpfReactiveUI.ViewModels
{
    public class MainWindowViewModel : ReactiveObject
    {
        public ReactiveCommand Delete { get; private set; }

        public MainWindowViewModel()
        {
            Delete = ReactiveCommand.CreateFromObservable(Something);
        }

        private IObservable<Unit> Something()
        {

            return Observable.Return(Unit.Default);
        }
    }
}
