using System;
using System.Windows.Input;

namespace RepoInsight.Avalonia.ViewModel
{
    public class RelayCommand : ICommand
    {
        private Action<object> execute;
        private Func<object, bool> canExecute;

        private EventHandler CanExecuteChangedHandler;

        public event EventHandler CanExecuteChanged
        {
            add { CanExecuteChangedHandler += value; }
            remove { CanExecuteChangedHandler -= value; }
        }

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return this.canExecute == null || this.canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            this.execute(parameter);
        }
    }
}
