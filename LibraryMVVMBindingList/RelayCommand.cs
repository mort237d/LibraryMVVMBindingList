using System;
using System.Windows.Input;

namespace LibraryMVVMBindingList
{
    public class RelayCommand : ICommand
    {
        private Action<object> _handler;
        public RelayCommand(Action<object> handler)
        {
            _handler = handler;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            _handler(parameter);
        }
    }
}
