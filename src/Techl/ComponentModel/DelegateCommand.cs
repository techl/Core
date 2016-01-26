// Copyright (c) techl.com All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Techl.ComponentModel
{
    public class DelegateCommand : DelegateCommand<object>
    {
        public DelegateCommand(Action executeMethod, Func<bool> canExecuteMethod = null) : base(arg => executeMethod(), arg => canExecuteMethod == null ? true : canExecuteMethod())
        {
        }
    }

    public class DelegateCommand<T> : ICommand
    {
        public event EventHandler CanExecuteChanged;

        protected readonly Action<T> ExecuteMethod;
        protected readonly Func<T, bool> CanExecuteMethod;

        private bool isExecuting;
        protected bool IsExecuting
        {
            get
            {
                return isExecuting;
            }
            set
            {
                isExecuting = value;
                RaiseCanExecuteChanged();
            }
        }

        public DelegateCommand(Action<T> executeMethod, Func<T, bool> canExecuteMethod = null)
        {
            if (executeMethod == null)
                throw new ArgumentNullException("executeMethod", "Method cannot be null");

            this.ExecuteMethod = executeMethod;
            this.CanExecuteMethod = canExecuteMethod;
        }

        public virtual bool CanExecute(T parameter)
        {
            if (IsExecuting)
                return false;

            if (CanExecuteMethod == null)
                return true;

            return CanExecuteMethod(parameter);
        }

        bool ICommand.CanExecute(object parameter)
        {
            return CanExecute((T)parameter);
        }

        public void Execute(T parameter)
        {
            if (!CanExecute(parameter))
                return;

            try
            {
                IsExecuting = true;
                ExecuteMethod(parameter);
            }
            finally
            {
                IsExecuting = false;
            }
        }

        void ICommand.Execute(object parameter)
        {
            Execute((T)parameter);
        }

        public void RaiseCanExecuteChanged()
        {
            var handler = CanExecuteChanged;
            if (handler != null)
            {
                handler(this, null);
            }
        }
    }
}
