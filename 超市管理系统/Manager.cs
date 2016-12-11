using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 超市管理系统 {
    class Manager : Staff{
        public Manager() {
            level = Level.manager;
        }

        public bool addStaff(Person p) {
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

        public List<Person> returnPersonMes() {
            try {
                return DB.getAllStaff();
            }
            catch (Exception) {
                return null;
            }
        }
    }
}
