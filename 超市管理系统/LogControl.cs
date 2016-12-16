using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 超市管理系统 {
    class LogControl {
        public List<LogMessage> getLogMessageByMonth(DateTime time) {
            return new List<LogMessage>();
     }

        public List<LogMessage> getLogMessageByYear(DateTime time) {
            return new List<LogMessage>();
        }

        public bool deleteLogMessage(DateTime time) {
            return false;
        }

        /// <summary>
        /// 返回总的进货金额和销售金额
        /// </summary>
        /// <returns></returns>
        public Money getAmountOfMoney() {
            return new Money();
        }
    }
}
