
using StudentSignup.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StudentSignup.Commands
{
    class SignupUpdateCommand : ICommand
    {
        public SignupUpdateCommand(StudentViewModel viewModel)
        {
            _ViewModel = viewModel;
        }
        StudentViewModel _ViewModel;

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
