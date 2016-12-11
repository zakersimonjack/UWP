using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 超市管理系统 {
    class LogControl {
        public List<LogMessage> getLogMessageByMonth(DateTime time) {
            return DB.getLogByMonth(time.Year, time.Month);
        }

        public List<LogMessage> getLogMessageByYear(DateTime time) {
            return DB.getLogByYear(time.Year);
        }

        public bool deleteLogMessageByDay(DateTime time) {
            return DB.deleteByDay(time.Year, time.Month, time.Day);
        }

        public bool deleteLogMessageByMonth(DateTime time) {
            return DB.deleteByMonth(time.Year, time.Month);
        }

        public bool deteleLogMessageByYear(DateTime time) {
            return DB.deleteByYear(time.Year);
        }

        public Money getAmountOfMoneyByYear(DateTime time) {
            return DB.getAmountOfMoneyByYear(time.Year);
        }

        public Money getAmountOfMoneyByMonth(DateTime time) {
            return DB.getAmountOfMoneyByMonth(time.Year, time.Month);
        }

        public Money getAmountOfMoneyByDay(DateTime time) {
            return DB.getAmountOfMoneyByDay(time.Year, time.Month, time.Day);
        }
    }
}
