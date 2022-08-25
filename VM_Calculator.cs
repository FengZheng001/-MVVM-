using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Calculator.Model;
using Calculator.Command;
using System.Windows.Input;

namespace Calculator.ViewModel
{
    public class VM_Calculator : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// 实现属性变更通知
        /// </summary>
        /// <param name="propertyName"></param>
        public void UpdataProperty(String propertyName)
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string outputString;
        public string OutputString
        {
            get { return outputString; }
            set { outputString = value; }
        }

        private string inputString;
        public string InputString
        {
            get { return inputString; }
            set { inputString = value; }
        }
        void doInput(string ch)
        {
            if(ch == "=")
            {
                outputString = CalculatorSystem.Calculator(inputString);
                UpdataProperty("InputString");
                UpdataProperty("OutputString");
                //inputCommand.UpdataCanExecuteChanged();
            }
        }
        bool isNumber(string ch)
        {
            string[] chs = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };
            return chs.Contains(ch);
        }
        bool isSymbol(string ch)
        {
            string[] chs = { "+", "-", "*", "/" };
            return chs.Contains(ch);
        }
        bool canInput(string ch)
        {
            string lastch = null;
            if(inputString != null) lastch = "" + inputString.LastOrDefault();
            if (isSymbol(lastch) && isSymbol(ch)) return false;
            if (isSymbol(lastch) && isSymbol(ch)) return false;
            return true;
        }
        DelegateCommand<string> inputCommand = null;
        public ICommand InputCommand
        {
            get
            {
                if (InputCommand == null)
                {
                    inputCommand = new DelegateCommand<string>(doInput, canInput);
                } 
                return inputCommand;
            }
        }
        private CalculatorSystem calculatorSystem;
        public CalculatorSystem CalculatorSystem
        {
            get { return calculatorSystem; }
            set { calculatorSystem = value; }
        }
    }
}
