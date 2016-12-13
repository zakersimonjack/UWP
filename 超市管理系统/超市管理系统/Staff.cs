using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 超市管理系统 {
   public class Staff {
        public Level level {
            get;
        }
        public string loginName {
            get;
        }

        public string name
        {
            get;
        }
        public string password {
            get;
        }
        public bool modifyPassword(Person p, string newpass)
        {
            try
            {
                p.password = newpass;
                DB.modifyStaff(p);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Staff(Level level, string loginName, string password, string name) {
            this.loginName = loginName;
            this.password = password;
            this.level = level;
            this.name = name;
        }

       
    }
}
