using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 超市管理系统 {
    class LoginControl {

        /// <summary>
        /// 若传入的用户名和密码正确，且权限足够,则返回一个LoginControl类的实例
        /// </summary>
        /// <param name="loginName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static LoginControl login(string loginName, string password) {
            Person p = DB.getStaff(loginName);
            if (p.password.Equals(password)) {
                LoginControl loginControl = new 超市管理系统.LoginControl();
                loginControl.level = p.level;
            }
            else return null;
        }

        public bool addStaff(Person p) {
            if (level != Level.manager) return false;
            try {
                DB.addStaff(p);
            }
            catch (Exception) {
                return false;
            }
            return true;
        }

        public bool deleteStaff(string loginName) {
            if (level != Level.manager) return false;
            try {
                DB.deleteStaff(loginName);
            }
            catch (Exception) {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 权限不够则返回null
        /// </summary>
        /// <returns></returns>
        public Person? returnPersonMes() {
            if (level != Level.manager) return false;
            try {
                DB.addStaff(p);
            }
            catch (Exception) {
                return false;
            }
            return true;
        }
    }
}
