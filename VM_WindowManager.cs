using Calculator.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Calculator.Model
{
    class VM_WindowManager
    {
        public Window[] views = new Window[4];
        bool[] Showings = new bool[4];
        public void ShowAllView()
        {
            views[0].Show(); Showings[0] = true;
            views[1].Show(); Showings[1] = true;
            views[2].Show(); Showings[2] = true;
            views[3].Show(); Showings[3] = true;
            showWindowCommand.UpdataCanExecuteChanged();
            hideWindowCommand.UpdataCanExecuteChanged();
        }
        bool canShowWindow(string index)
        {
            int i = int.Parse(index);
            return !Showings[i];
        }
        bool canHideWindow(string index)
        {
            int i = int.Parse(index);
            return Showings[i];
        }
        void doShowWindow(string index)
        {
            int i = int.Parse(index);
            views[i].Show();
            Showings[i] = true;
            showWindowCommand.UpdataCanExecuteChanged();
            hideWindowCommand.UpdataCanExecuteChanged();
        }
        void doHideWindow(string index)
        {
            int i = int.Parse(index);
            if(i == 3)
            {
                var rs = MessageBox.Show("关闭此窗口后将无法管理所有窗口是否关闭?","警告", MessageBoxButton.YesNo);
                if (rs == MessageBoxResult.No) return;
            }
            views[i].Hide();
            Showings[i] = true;
            showWindowCommand.UpdataCanExecuteChanged();
            hideWindowCommand.UpdataCanExecuteChanged();
        }
        DelegateCommand<string> showWindowCommand = null;
        public ICommand ShowWindowCommand
        {
            get
            {
                if (showWindowCommand == null)
                    showWindowCommand = new DelegateCommand<string>(doShowWindow, canShowWindow);
                return showWindowCommand;
            }
        }
        DelegateCommand<string> hideWindowCommand = null;
        public ICommand HideWindowCommand
        {
            get
            {
                if (hideWindowCommand == null)
                    hideWindowCommand = new DelegateCommand<string>(doHideWindow, canHideWindow);
                return hideWindowCommand;
            }
        }
    }
}
