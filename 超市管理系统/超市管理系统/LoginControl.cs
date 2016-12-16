using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 超市管理系统 {
    class LoginControl {

        /// <summary>
        /// 工厂方法：若传入的用户名和密码正确，则返回一个LogControl类的实例
        /// </summary>
        /// <param name="loginName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static LoginControl login(string loginName, string password) {
            return new 超市管理系统.LoginControl();
        }

        public bool addStaff(Person p) {
            return true;
        }

        public bool deleteStaff(string loginName) {
            return true;
        }

        public Person returnPersonMes() {
            return new Person();
        }
    }
}
