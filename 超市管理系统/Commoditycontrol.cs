using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 超市管理系统 {
    class CommodityControl {
        public stockCode Stock(LogMessage Mes) {
            if (!Mes.mes) return stockCode.parsError;
            if (!Mes.commodityName.Equals(DB.query(Mes.id))) return stockCode.repeat;
            if (!DB.addLog()) return stockCode.serverError;
            return stockCode.success;
        }

        public CommodityMessage getCommodityMessage(string id) {

        }

        public bool sellCommodity(LogMessage Mes) {
            
        }

        public List<CommodityMessage> getAllCommodityMessage() {

        }

        public bool modifyCommodity(CommodityMessage Mes) {

        }

        public bool clearRepo(int num) {

        }

    }
}
