using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using FFXIVAPP.Common.Utilities;
using NLog;

namespace FFXIVAPP.Common.ViewModelBase
{
    // Taken from https://stackoverflow.com/a/43187617
    public sealed class AsyncDelegateCommand : ICommand
    {
        private readonly Func<object, Task> func;
        private readonly Action<Exception> faultHandlerAction;
        private int callRunning = 0;

        public AsyncDelegateCommand(Func<object, Task> func, Logger logger)
            : this (func, exception => Logging.Log(logger, $"Unhandled exception in {nameof(AsyncDelegateCommand)}", exception)) {}

        // Pass in the async delegate (which takes an object parameter and returns a Task) 
        // and a delegate which handles exceptions
        public AsyncDelegateCommand(Func<object, Task> func, Action<Exception> faultHandlerAction)
        {
            this.func = func;
            this.faultHandlerAction = faultHandlerAction;
        }

        public AsyncDelegateCommand(Func<Task> func, Logger logger)
            : this (func, exception => Logging.Log(logger, $"Unhandled exception in {nameof(AsyncDelegateCommand)}", exception)) {}

        // Pass in the async delegate (which takes an object parameter and returns a Task) 
        // and a delegate which handles exceptions
        public AsyncDelegateCommand(Func<Task> func, Action<Exception> faultHandlerAction)
        {
            this.func = obj => func();
            this.faultHandlerAction = faultHandlerAction;
        }

        public bool CanExecute(object parameter)
        {
            return callRunning == 0;
        }

        public void Execute(object parameter)
        {
            // Replace value of callRunning with 1 if 0, otherwise return - (if already 1).
            // This ensures that there is only one running call at a time.
            if (Interlocked.CompareExchange(ref callRunning, 1, 0) == 1)
            {
                return;
            }

            OnCanExecuteChanged();
            func(parameter).ContinueWith((task, _) => ExecuteFinished(task), null, TaskContinuationOptions.ExecuteSynchronously);
        }

        private void ExecuteFinished(Task task)
        {
            // Replace value of callRunning with 0
            Interlocked.Exchange(ref callRunning, 0);
            // Call error handling if task has faulted
            if (task.IsFaulted)
            {
                faultHandlerAction(task.Exception);
            }
            OnCanExecuteChanged();
        }

        public event EventHandler CanExecuteChanged;

        private void OnCanExecuteChanged()
        {
            // Raising this event tells for example a button to display itself as "grayed out" while async operation is still running
            var handler = CanExecuteChanged;
            if (handler != null) handler(this, EventArgs.Empty);
        }
    }
}