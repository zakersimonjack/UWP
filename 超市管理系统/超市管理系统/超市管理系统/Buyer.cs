using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 超市管理系统 {
    class Buyer :Staff {

        public Buyer(Level level, string loginName, string password, string name) : base(level, loginName, password, name) {
        }

        public bool isCommodityExist(string name) {
            try {
                DB.findCommodityByName(name);
            }
            catch (RepeatException) {
                return true;
            }
            catch (NotFindException) {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 进货。若是已存在的商品，则不需要填入comId
        /// </summary>
        /// <param name="id">对于已存在的商品,comId默认为""</param>
        /// <returns></returns>
        public stockCode Stock(string name, int num, float price, DateTime time, string logId, string comId = "") {
            try {
                if (comId != "") {
                    CommodityMessage newCommodity = new CommodityMessage();
                    newCommodity.commodityName = name;
                    newCommodity.id = comId;
                    newCommodity.inPrice = price;
                    newCommodity.num = num;
                    DB.addCommodity(newCommodity);
                }
                else {
                    CommodityMessage dbcommodity = DB.findCommodityByName(name);
                    dbcommodity.num += num;
                    DB.modityCommodity(dbcommodity);
                }
            }
            catch (RepeatException) {
                return stockCode.repeat;
            }
            catch (NotFindException) {
                return stockCode.miss;
            }
            LogMessage log = new LogMessage();
            log.commodityName = name;
            log.flag = true;
            log.id = logId;
            log.num = num;
            log.price = price;
            log.time = time;
            DB.addLog(log);
            return stockCode.success;
        }
    }
}
