using LaererVikaren.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace LaererVikaren.Commands
{
    public class FindMatchingSubstitute : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            bool result = true;

            if (parameter is CreateLessonViewModel clvm)
            {
                if (clvm.CheckEntity() == false)
                {
                    result = false;
                }
            }
            return result;
        }

        public void Execute(object parameter)
        {
            if (parameter is CreateLessonViewModel clvm)
            {
                clvm.FindMatchingSub();
            }
            else
            {
                throw new ArgumentException("Illegal parameter type");
            }
        }
    }
}
