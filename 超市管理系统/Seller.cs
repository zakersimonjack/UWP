using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 超市管理系统 {
    class Seller :Staff{
        public Seller() {
            level = Level.seller;
        }

        /// <summary>
        /// 添加售货信息
        /// </summary>
        /// <param name="Mes"></param>
        /// <returns></returns>
        public sellCode sellCommodity(LogMessage Mes) {
            //TODO
            DB.addLog(Mes);
            return sellCode.success;
        }


    }
}
