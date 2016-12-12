using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 超市管理系统 {
    class LoginControl {

        /// <summary>
        /// 若传入的用户名和密码正确，则返回一个相应的权限的Control类的实例
        /// </summary>
        /// <param name="loginName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static Staff login(string loginName, string password) {
            Person p = DB.getStaff(loginName);
            Staff c = null;
            if (p.password.Equals(password)) {    
                switch (p.level) {
                    case Level.buyer:
                        c = new Buyer();
                        break;
                    case Level.seller:
                        c = new Seller();
                        break;
                    case Level.manager:
                        c = new Manager();
                        break;
                    default:
                        break;
                }
            }
            return c;
        }
    }
}
