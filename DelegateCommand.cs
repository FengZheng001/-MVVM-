using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Calculator.Command
{
    public class DelegateCommand : ICommand
    {
        Action execute;//注册方法用于执行动作
        Func<bool> canExecute;//或者判断是否可执行当前命令
        //构造函数
        public DelegateCommand(Action execute = null,Func<bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged;//实现ICommand接口

        public bool CanExecute(object parameter)
        {
            if(canExecute == null) return true;
            return canExecute();
        }
         
        public void UpdateCanExecuteChanged()
        {
            if (CanExecuteChanged != null) CanExecuteChanged(this, EventArgs.Empty);
        }
        public void Execute(object parameter)
        {
            if(execute == null) return;
            else execute();
        }
    }
    public class DelegateCommand<T> : ICommand
    {
        Action<T> execute;
        Func<T, bool> canExecute;
        public DelegateCommand(Action<T> execute = null,Func<T,bool> canExecute = null)
        {
            this.execute= execute;
            this.canExecute= canExecute;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
             if(canExecute == null) return true;
            return canExecute((T)parameter);
        }

        public void UpdataCanExecuteChanged()
        {
            if(CanExecuteChanged != null) CanExecuteChanged(this,EventArgs.Empty);
        }
        public void Execute(object parameter)
        {
            if (execute == null) return;
            else execute((T)parameter);
        }
    }
}
