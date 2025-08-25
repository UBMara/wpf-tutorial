using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpf_tutorial.Commands
{
    public abstract class AsyncCommandBase : CommandBase
    {
        private bool _isExecuting;

        public bool IsExecuting
        {
            get { return _isExecuting; }
            set
            {
                _isExecuting = value;
                OnCanExecuteChanged();
            }
        }

        public override bool CanExecute(object parameter)
        {
            return !_isExecuting && base.CanExecute(parameter);
        }

        public override async void Execute(object parameter)
        {
            _isExecuting = true;

            try
            {
                await ExecuteAsync(parameter);
            }

            catch (Exception) { }
            finally
            {
                _isExecuting = false;
            }
        }

        public abstract Task ExecuteAsync(object parameter);
    }
}
