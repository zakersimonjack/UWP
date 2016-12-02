using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 超市管理系统 {
    /// <summary>
    /// 0:：插入成功
    /// 1：编号重复
    /// 2：服务器错误
    /// </summary>
    enum stockCode { 0,2,3, } ;

    struct CommodityMessage {
        string commodityName;
        int num;
        float inPrice;
        float outPrice;
        int id;
    }

    struct LogMessage {
        bool mes;
        string commodityName;
        int num;
        float price;    //打完折的价格
        DateTime time;
    }

    struct Money {
        float inMoney;
        float outMoney;
    }
}