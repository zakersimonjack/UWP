using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 超市管理系统 {
    class CommodityControl : Control {

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
