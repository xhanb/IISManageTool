/* ==============================
*
* Author: 高海波
* Time：2015/10/9 16:23:39
* FileName：CommandObject
* 说明:
* ===============================
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace IISHelpLib
{
    /// <summary>
    /// 
    /// </summary>
    public class CommandObject : ICommand
    {
        public  Action<object> execute;
        public  Predicate<object> canExecute;

        public CommandObject()
        {
            
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="execute"></param>
        /// <param name="canExecute"></param>
        public CommandObject(Action<object> execute, Predicate<object> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }
        public void Execute(object parameter)
        {
            execute(parameter);
        }

        public bool CanExecute(object parameter)
        {
            if (canExecute != null)
            {
                return canExecute(parameter);
            }
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        public event EventHandler CanExecuteChanged;
    }
}
