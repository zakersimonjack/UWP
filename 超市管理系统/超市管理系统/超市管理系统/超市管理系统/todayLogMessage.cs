using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 超市管理系统
{
    public class todayLogMessage
    {

        public string Type { get; set; }
        public string nameOfCMD { get; set; }
        public string codeOfCMD { get; set; }
        public string numbers { get; set; }
        public string price { get; set; }
        public string Category { get; set; }
        public DateTime Time { get; set; }
        public todayLogMessage() { }
        public todayLogMessage(string type, string NameOfCMD, string CodeOfCMD, string num, string Price, string category,DateTime time)
        {
            Type = type;
            nameOfCMD = NameOfCMD;
            codeOfCMD = CodeOfCMD;
            numbers = num;
            price = Price;
            Category = category;
            Time = time;
        }
    }
}
