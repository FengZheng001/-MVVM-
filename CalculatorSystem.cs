using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Modle文件夹下存放实现程序核心功能的类文件


namespace Calculator.Model
{
    public class CalculatorSystem
    {
        class Item
        {
            public enum Type { Number,Symbol};
            public Type myType;
            public string src;
            public double Number
            {
                get { return double.Parse(src); }
                set
                {
                    src = value.ToString();
                }
            }
        }
        public static String Calculator(String input)
        {
            List<string> dts = new List<string>();
            char[] sqs = { '+', '-', '*', '/' };
            string temp = "";
            foreach(var v in input)
            {
                if(sqs.Contains(v))
                {
                    dts.Add(temp);
                    dts.Add(""+v);
                    temp = "";
                }
                else
                {
                    temp += v;
                }
            }
            dts.Add(temp);
            List<Item> listItem = new List<Item>();
            foreach(var v in dts)
            {
                Item item = new Item();
                item.src = v;
                if(sqs.Contains(v.FirstOrDefault())) //判断输入内容是数字还是运算符
                {
                    item.myType = Item.Type.Symbol;
                }
                else
                {
                    item.myType=Item.Type.Number;
                }
                listItem.Add(item);
            }
            //用于计算，运算规律，先乘除，后加减
            for(int i = 1; i<listItem.Count; i++)
            {
                if(listItem[i].src == "*")
                {
                    listItem[i - 1].Number *= listItem[i].Number;
                    listItem[i].src = "+";
                    listItem[i + 1].src = "0";
                }
                if(listItem[i].src == "/")
                {
                    listItem[i - 1].Number /= listItem[i + 1].Number;
                    listItem[i].src = "+";
                    listItem[i + 1].src = "0";
                }
            }
            double ret = listItem[0].Number;
            for(int i = 1; i < listItem.Count; i += 2)
            {
                if(listItem[i].src == "+")
                {
                    ret += listItem[i + 1].Number;
                }
                if (listItem[i].src == "-")
                {
                    ret -= listItem[i + 1].Number;
                }
            }
            return ret.ToString();
        }
    }
}
