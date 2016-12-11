using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 超市管理系统 {
    class CommodityControl {

        /// <summary>
        /// 进货
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

        /// <summary>
        /// 根据商品id查看商品信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CommodityMessage? getCommodityMessage(string id) {
            CommodityMessage? result = null;
            try {
                result = DB.findCommodityById(id);
            }
            catch (NotFindException) {

            }
            return result;
        }

        /// <summary>
        /// 添加售货信息
        /// </summary>
        /// <param name="Mes"></param>
        /// <returns></returns>
        public bool sellCommodity(LogMessage Mes) {
            DB.addLog(Mes);
            return true;
        }

        /// <summary>
        /// 返回所有商品信息
        /// </summary>
        /// <returns></returns>
        public List<CommodityMessage> getAllCommodityMessage() {
            //List<CommodityMessage> result = DB.
            return new List<CommodityMessage>();
        }


        /// <summary>
        /// 减少某商品的数量
        /// </summary>
        /// <param name="num"></param>
        /// <returns>如果传入的id不正确，或num大于剩余数量则返回false</returns>
        public bool clearRepo(string id, int num) {
            try {
                CommodityMessage com = DB.findCommodityById(id);
                if (com.num < num) return false;
                com.num -= num;
                return DB.modityCommodity(com);
            }
            catch (NotFindException) {
                return false;
            }
        }

        /// <summary>
        /// 修改商品价格
        /// </summary>
        /// <param name="Mes"></param>
        /// <returns></returns>
        public bool modifyPrice(CommodityMessage Mes) {
            return DB.modityCommodity(Mes);
        }
    }
