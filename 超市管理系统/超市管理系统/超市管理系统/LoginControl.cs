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
        public static async Task<Staff> login(string loginName, string password)
        {
            Person p;
            try
            {
                p = await DB.getStaff(loginName);
            }
            catch (NotFindException)
            {
                return null;
            }
            Staff c = null;
            if (p.password.Equals(password))
            {
                switch (p.level)
                {
                    case Level.buyer:
                        c = new Buyer(p.level, loginName, password, p.name);
                        break;
                    case Level.seller:
                        c = new Seller(p.level, loginName, password, p.name);
                        break;
                    case Level.manager:
                        c = new Manager(p.level, loginName, password, p.name);
                        break;
                    default:
                        break;
                }
            }
            return c;
        }
    }
}
