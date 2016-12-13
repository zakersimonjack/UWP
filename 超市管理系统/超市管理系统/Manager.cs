using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 超市管理系统 {
    class Manager : Staff{
        public Manager(Level level, string loginName, string password, string name) : base(level, loginName, password, name)
        {
        }

        public bool addStaff(Person p) {
            try {
                DB.addStaff(p);
            }
            catch (Exception) {
                return false;
            }
            return true;
        }

        public bool deleteStaff(string loginName) {
            try {
                DB.deleteStaff(loginName);
            }
            catch (Exception) {
                return false;
            }
            return true;
        }

      
        public bool modifyPassword(Person p, string newpass)
        {
            try
            {
                p.password = newpass;
                DB.modifyStaff(p);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 返回所有员工信息
        /// </summary>
        /// <returns></returns>
        public List<Person> returnPersonMes() {
            try {
                return DB.getAllStaff();
            }
            catch (Exception) {
                return null;
            }
        }

        /// <summary>
        /// 返回所有商品信息
        /// </summary>
        /// <returns></returns>
        public List<CommodityMessage> getAllCommodityMessage() {
            try
            {
                return DB.getAllCommodity();
            }
            catch(Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// 修改商品价格
        /// </summary>
        /// <param name="Mes"></param>
        /// <returns></returns>
        public bool modifyPrice(CommodityMessage Mes) {
            try
            {
                DB.modityCommodity(Mes);
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// 清空某商品的库存
        /// </summary>
        /// <param name="num"></param>
        /// <returns>如果传入的id不正确则返回false</returns>
        public bool clearRepo(string id) {
            try {
                CommodityMessage com = DB.findCommodityById(id);
                com.num = 0;
                return DB.modityCommodity(com);
            }
            catch (NotFindException) {
                return false;
            }
        }

        /// <summary>
        /// 获取一个月的账目流水信息
        /// </summary>
        /// <returns></returns>
        public List<LogMessage> getLogMessageByMonth(DateTime time) {
            List<LogMessage> ls = new List<LogMessage>();
            try
            {
                ls=DB.getLogByMonth(time.Year, time.Month);
                return ls;
            }
            catch(NotFindException e)
            {
                return null;
            }
        }
        public List<LogMessage> getLogMessageByYear(DateTime time)
        {
            List<LogMessage> ls = new List<LogMessage>();
            try
            {
                 ls=DB.getLogByYear(time.Year);
                return ls;
            }
            catch (NotFindException e)
            {
                return null;
            }
            
        }
        public List<LogMessage> getLogMessageByDay(DateTime time)
        {
            List<LogMessage> ls = new List<LogMessage>();
            try
            {
                 ls=DB.getLogByDay(time.Year, time.Month, time.Day);
                return ls;
            }
            catch (NotFindException e)
            {
                return null;
            }
           
        }

        /// <summary>
        /// 删除某范围账目流水信息
        /// </summary>
        /// <param name="time"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public bool deleteLogMessage(DateTime time, flagCode code) {
            try {
                switch (code) {
                    case flagCode.day:
                        DB.deleteByDay(time.Year, time.Month, time.Day);
                        break;
                    case flagCode.month:
                        DB.deleteByMonth(time.Year, time.Month);
                        break;
                    case flagCode.year:
                        DB.deleteByYear(time.Year);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception) {
                return false;
            }
            return true;
        }

        public Money getAmountOfMoney(DateTime time, flagCode code) {
            Money money = new 超市管理系统.Money();
            switch (code) {
                case flagCode.day:
                    money = DB.getAmountOfMoneyByDay(time.Year, time.Month, time.Day);
                    break;
                case flagCode.month:
                    money = DB.getAmountOfMoneyByMonth(time.Year, time.Month);
                    break;
                case flagCode.year:
                    money = DB.getAmountOfMoneyByYear(time.Year);
                    break;
                default:
                    break;
            }
            return money;
        }
    }
}
