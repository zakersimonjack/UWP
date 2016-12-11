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
    /// 3：参数有误
    /// 4：未找到相应商品
    /// </summary>
    enum stockCode { success, repeat, serverError, parsError, miss} ;

    struct CommodityMessage {
        public string commodityName;
        public int num;
        public float inPrice;   //最新进价？
        public float outPrice;
        public string id;
    }

    struct LogMessage {
        public bool flag;  // flag=ture 为进货
        public string commodityName;
        public string id;   //暂时不用
        public int num;
        public float discount;
        public float price;    //原价
        public DateTime time;
    }

    struct Money {
        public float inMoney;
        public float outMoney;
    }

    enum Level { buyer, seller, manager, nonperson}

    struct Person {
        public Level level; 
        public string loginName;
        public string password;
        public string name;
    }
    public class ConnectException: ApplicationException
    {
        public ConnectException()
        {

        }
        public ConnectException(string cont, Exception sr):base(cont, sr)
        {

        }
    }
    public class NotFindException : Exception { }
    public class NotInitException : Exception { }
    public class FatalSQLException : Exception { }
    public class RepeatException : Exception { }
}