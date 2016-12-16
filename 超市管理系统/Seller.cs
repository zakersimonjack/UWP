using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 超市管理系统 {
    class Seller : Staff {
        public Seller(Level level, string loginName, string password, string name) : base(level, loginName, password, name) {
            
        }

        /// <summary>
        /// 添加售货信息
        /// </summary>
        /// <param name="Mes"></param>
        /// <returns></returns>
        public sellCode sellCommodity(LogMessage Mes) {
            //TODO
            CommodityMessage com;
            try {
                com = DB.findCommodityByName(Mes.commodityName);
                com.num -= Mes.num;
                DB.modityCommodity(com);
                DB.addLog(Mes);
            }
            catch (Exception ){
                return sellCode.miss;
            }
            return sellCode.success;
        }

        public CommodityMessage? getCommodityByName(string name) {
            CommodityMessage? com = null;
            try {
                com = DB.findCommodityByName(name);
                if (com.Value.outPrice == 0) com = null;
            }
            catch (Exception) {

            }
            return com;
        }

        public CommodityMessage? getCommodityById(string id) {
            CommodityMessage? com = null;
            try {
                com = DB.findCommodityById(id);
                if (com.Value.outPrice == 0) com = null;
            }
            catch (Exception) {

            }
            return com;
        }
    }
}
