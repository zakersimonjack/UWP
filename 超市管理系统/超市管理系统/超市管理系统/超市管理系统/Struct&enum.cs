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
    /// 3: 参数有误
    /// </summary>
    enum stockCode { success, repeat, serverError, parsError } ;

    struct CommodityMessage {
        public string commodityName;
        public int num;
        public float inPrice;
        public float outPrice;
        public string id;
    }

  public  struct LogMessage {
        public bool flag;  // flag=1 为进货
        public string commodityName;
        public string id;
        public int num;
        public float discount;//进货就为1
        public float price;    //打完折的价格
        public DateTime time;
    }

    struct Money {
        public float inMoney;
        public float outMoney;
    }
    public enum Level { buyer, seller, manager }
    public struct Person
    {
        public Level level;
        public string loginName;
        public string password;
        public string name;
    }
    


}