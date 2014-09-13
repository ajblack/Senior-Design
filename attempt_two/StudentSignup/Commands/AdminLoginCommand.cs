using StudentSignup.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StudentSignup.Commands
{
    class AdminLoginCommand : ICommand
    {
        public AdminLoginCommand(AdminLoginViewModel viewModel)
        {
            _ViewModel = viewModel;
        }
        AdminLoginViewModel _ViewModel;

        #region implement Icommand
        public bool CanExecute(object parameter)
        {
            return _ViewModel.CanUpdate;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
            _ViewModel.SaveChanges();
        }

        #endregion
    }
}
