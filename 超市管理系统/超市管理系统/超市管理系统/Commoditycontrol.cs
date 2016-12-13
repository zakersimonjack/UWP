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
        /// <param name="Mes">进货信息</param>
        /// <returns></returns>
        public stockCode Stock(LogMessage Mes) {
            return new stockCode();
        }

        /// <summary>
        /// 根据商品id查看商品信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CommodityMessage getCommodityMessage(string id) {
            return new CommodityMessage();
        }

        /// <summary>
        /// 添加售货信息
        /// </summary>
        /// <param name="Mes"></param>
        /// <returns></returns>
        public bool sellCommodity(LogMessage Mes) {
            return true;
        }

        /// <summary>
        /// 返回所有商品信息
        /// </summary>
        /// <returns></returns>
        public List<CommodityMessage> getAllCommodityMessage() {
            return new List<超市管理系统.CommodityMessage>();
        }

        /// <summary>
        /// 修改商品价格
        /// </summary>
        /// <param name="Mes"></param>
        /// <returns></returns>
        public bool modifyPrice(CommodityMessage Mes) {
            return true;
        }

        /// <summary>
        /// 减少某商品的数量
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public bool clearRepo(int id, int num) {
            return true;
        }

    }
}
