using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.IO;
using Windows.UI.Popups;
using Windows.Networking.Sockets;
using Windows.Storage.Streams;
using System.Diagnostics;
//using System.Windows.Forms;
namespace 超市管理系统
{
    class DB
    {

        private static bool init_flag = false;
        private static bool read_flag = false;
        private static string server_addr = "123.207.114.37";
        private static string server_port = "1222";
        private static string error_str = "SQL wrong!";
        private static string null_str = "(null)";
        private static StreamSocket socket = new StreamSocket();
        private static DataWriter writer = new DataWriter(socket.OutputStream);
        private static Queue<string> buf = new Queue<string>();
        private static async void Listen()
        {
            try
            {

                DataReader reader = new DataReader(socket.InputStream);
                reader.UnicodeEncoding = Windows.Storage.Streams.UnicodeEncoding.Utf8;
                reader.InputStreamOptions = InputStreamOptions.Partial;
                while (true)
                {
                    while (!read_flag)
                    {
                        await Task.Delay(100);
                    }
                    string tem1 = "";
                    string tem;
                    await reader.LoadAsync(1024);
                    tem = reader.ReadString(reader.UnconsumedBufferLength);
                    tem1 += tem;
                    
                    await reader.LoadAsync(1024);
                    tem = reader.ReadString(reader.UnconsumedBufferLength);
                    tem1 += tem;
                    Debug.WriteLine(tem1);
                    string[] tet = tem1.Split('\n');
                    foreach (string tete in tet)
                    {
                        if (string.Compare(tete, 0, "EOF", 0, 3) != 0)
                        {
                            buf.Enqueue(tete);
                        }
                        else
                        {
                            break;
                        }
                    } 
                    read_flag = false;
                }
            
            }
            catch (Exception)
            {
                init_flag = false;
                //MessageBox.Show("监听线程意外中断！", "致命错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                await new MessageDialog("监听线程意外中断！").ShowAsync();

            }
        }

        private static void start_thread()
        {
            Task l_thread = Task.Factory.StartNew(delegate { Listen(); });
        }

        private static async void send_cmd(string cmd)
        {
            
            if (init_flag)
            {

                writer.UnicodeEncoding = Windows.Storage.Streams.UnicodeEncoding.Utf8;
                //writer.WriteUInt32(writer.MeasureString(str));
                writer.WriteString(cmd);
                await writer.StoreAsync();
            }
        }

        private static Level read_level(int level)
        {
            switch (level)
            {
                case 0:
                    return Level.buyer;
                case 1:
                    return Level.seller;
                case 2:
                    return Level.manager;
                default:
                    return Level.nonperson;
            }
        }

        private static int get_level(Level tem)
        {
            switch (tem)
            {
                case Level.buyer:
                    return 0;
                case Level.seller:
                    return 1;
                case Level.manager:
                    return 2;
                default:
                    return -1;
            }
        }

        public static async Task<bool> init_client()
        {
            try
            {
                await socket.ConnectAsync(new Windows.Networking.HostName(server_addr), server_port);
                start_thread();
            }
            catch (SocketException e)
            {
                throw new ConnectException("Failed to Connect", e);
            }
            init_flag = true;
            return true;
        }
        /*
        public static bool close_client()
        {
            try
            {
                //tcpc.Close();
                socket.Dispose();
            }
            catch (SocketException)
            {
                return false;
            }
            init_flag = false;
            return true;
        }
        */
        public static void ExecuteSQL(string cmd)
        {
            if (!init_flag) throw new NotInitException();
            read_flag = true;
            send_cmd(cmd);
        }

        public static bool addCommodity(CommodityMessage com)
        {
            if (!init_flag) throw new NotInitException();
            read_flag = true;
            buf.Clear();
            send_cmd("select * from comodity where cid = '" + com.id + "'");
            while (read_flag) Task.Delay(100);
            if (string.Compare(error_str, 1, buf.Peek(), 1, error_str.Length) == 0) throw new FatalSQLException();
            if (Convert.ToInt32(buf.Dequeue()) != 0) throw new RepeatException();
            send_cmd("Insert into comodity(name, cid, nums, inprice, outprice) values('" + com.commodityName + "','" + com.id + "','" + com.num.ToString() + "','" + com.inPrice.ToString() + "','" + com.outPrice.ToString() + "');");
            return true;
        }

        public static CommodityMessage findCommodityById(string id)
        {
            CommodityMessage cmes = new CommodityMessage();
            if (!init_flag) throw new NotInitException();
            read_flag = true;
            buf.Clear();
            send_cmd("select * from comodity where cid = '" + id + "'");
            while (read_flag) //Task.Delay(100);
                Task.Delay(100);
            if (string.Compare(error_str, 1, buf.Peek(), 1, error_str.Length) == 0) throw new FatalSQLException();
            if (Convert.ToInt32(buf.Dequeue()) == 0) throw new NotFindException();
            buf.Dequeue();
            cmes.commodityName = buf.Dequeue();
            cmes.id = buf.Dequeue();
            cmes.inPrice = Convert.ToSingle(buf.Dequeue());
            cmes.outPrice = Convert.ToSingle(buf.Dequeue());
            cmes.num = Convert.ToInt32(buf.Dequeue());
            //MessageBox.Show(cmes.commodityName + cmes.id);
            return cmes;
        }

        public static CommodityMessage findCommodityByName(string name)
        {
            CommodityMessage cmes = new CommodityMessage();
            if (!init_flag) throw new NotInitException();
            read_flag = true;
            buf.Clear();
            send_cmd("select * from comodity where name = '" + name + "'");
            while (read_flag) Task.Delay(100);
            if (string.Compare(error_str, 1, buf.Peek(), 1, error_str.Length) == 0) throw new FatalSQLException();
            if (Convert.ToInt32(buf.Dequeue()) == 0) throw new NotFindException();
            buf.Dequeue();
            cmes.commodityName = buf.Dequeue();
            cmes.id = buf.Dequeue();
            cmes.inPrice = Convert.ToSingle(buf.Dequeue());
            cmes.outPrice = Convert.ToSingle(buf.Dequeue());
            cmes.num = Convert.ToInt32(buf.Dequeue());
            //MessageBox.Show(cmes.commodityName + cmes.id);
            return cmes;
        }

        public static bool modityCommodity(CommodityMessage mes)
        {
            if (!init_flag) throw new NotInitException();
            findCommodityById(mes.id);
            send_cmd("Update comodity set name = '" + mes.commodityName + "', cid = '" + mes.id + "', inprice = '" + mes.inPrice.ToString() + "',outprice = '" + mes.outPrice.ToString() + "',nums='" + mes.num.ToString() + "' where cid = '" + mes.id + "';");
            return true;
        }

        public static bool deleteCommodity(string id)
        {
            if (!init_flag) throw new NotInitException();
            findCommodityById(id);
            send_cmd("delete from comodity where cid = '" + id + "'");
            return true;
        }
        public static List<CommodityMessage> getAllCommodity()

        {

            List<CommodityMessage> lmes = new List<CommodityMessage>();

            CommodityMessage cmes = new CommodityMessage();

            int i;

            if (!init_flag) throw new NotInitException();

            read_flag = true;

            buf.Clear();

            send_cmd("select * from comodity");

            while (read_flag) Task.Delay(100);

            if (string.Compare(error_str, 1, buf.Peek(), 1, error_str.Length) == 0) throw new FatalSQLException();

            if ((i = Convert.ToInt32(buf.Dequeue())) == 0) throw new NotFindException();

            buf.Dequeue();

            for (; i > 0; i--)

            {

                cmes.commodityName = buf.Dequeue();

                cmes.id = buf.Dequeue();

                cmes.inPrice = Convert.ToSingle(buf.Dequeue());

                cmes.outPrice = Convert.ToSingle(buf.Dequeue());

                cmes.num = Convert.ToInt32(buf.Dequeue());

                lmes.Add(cmes);

                //MessageBox.Show(cmes.commodityName + cmes.id);

            }

            return lmes;



        }
        public static bool addLog(LogMessage logmes)
        {
            if (!init_flag) throw new NotInitException();
            string flag;
            if (logmes.flag) flag = "1";
            else flag = "0";
            send_cmd("Insert into clog(name,cid,nums,discount,price,year,month,day,hour,minute,second,flag) values('" +
                logmes.commodityName + "','" +
                logmes.id + "','" +
                logmes.num.ToString() + "','" +
                logmes.discount.ToString() + "','" +
                logmes.price.ToString() + "','" +
                logmes.time.Year.ToString() + "','" +
                logmes.time.Month.ToString() + "','" +
                logmes.time.Day.ToString() + "','" +
                logmes.time.Hour.ToString() + "','" +
                logmes.time.Minute.ToString() + "','" +
                logmes.time.Second.ToString() + "','" +
                flag + "');"
                );
            return true;
        }

        public static List<LogMessage> getLogByDay(int year, int month, int day)
        {
            if (!init_flag) throw new NotInitException();
            List<LogMessage> s_list = new List<LogMessage>();
            read_flag = true;
            buf.Clear();
            send_cmd("select * from clog where year ='" + year.ToString() + "' and month = '" + month.ToString() + "' and day = '" + day.ToString() + "';");
            while (read_flag) Task.Delay(100);
            if (string.Compare(error_str, 1, buf.Peek(), 1, error_str.Length) == 0) throw new FatalSQLException();
            int i;
            if ((i = Convert.ToInt32(buf.Dequeue())) == 0) throw new NotFindException();
            int j = Convert.ToInt32(buf.Dequeue());
            for (; i > 0; i--)
            {
                LogMessage tem = new LogMessage();
                tem.commodityName = buf.Dequeue();
                tem.id = buf.Dequeue();
                tem.num = Convert.ToInt32(buf.Dequeue());
                if (tem.num > 0) tem.flag = true;
                else
                {
                    tem.flag = false;
                    tem.num = -tem.num;
                }
                tem.discount = Convert.ToSingle(buf.Dequeue());
                tem.price = Convert.ToSingle(buf.Dequeue());
                int tyear = Convert.ToInt32(buf.Dequeue());
                int tmonth = Convert.ToInt32(buf.Dequeue());
                int tday = Convert.ToInt32(buf.Dequeue());
                int thour = Convert.ToInt32(buf.Dequeue());
                int tminute = Convert.ToInt32(buf.Dequeue());
                int tsecond = Convert.ToInt32(buf.Dequeue());
                DateTime tem_date = new DateTime(tyear, tmonth, tday, thour, tminute, tsecond);
                tem.time = tem_date;
                int flag = Convert.ToInt32(buf.Dequeue());
                if (flag == 1) tem.flag = true;
                else tem.flag = false;
                //MessageBox.Show(tem.commodityName + tem.id + tem.time.ToString() + "--*--" + tem.flag.ToString());
                s_list.Add(tem);
            }
            return s_list;
        }

        public static List<LogMessage> getLogByMonth(int year, int month)
        {
            if (!init_flag) throw new NotInitException();
            List<LogMessage> s_list = new List<LogMessage>();
            read_flag = true;
            buf.Clear();
            send_cmd("select * from clog where year ='" + year.ToString() + "' and month = '" + month.ToString() + "';");
            while (read_flag) Task.Delay(100);
            if (string.Compare(error_str, 1, buf.Peek(), 1, error_str.Length) == 0) throw new FatalSQLException();
            int i;
            if ((i = Convert.ToInt32(buf.Dequeue())) == 0) throw new NotFindException();
            int j = Convert.ToInt32(buf.Dequeue());
            for (; i > 0; i--)
            {
                LogMessage tem = new LogMessage();
                tem.commodityName = buf.Dequeue();
                tem.id = buf.Dequeue();
                tem.num = Convert.ToInt32(buf.Dequeue());
                if (tem.num > 0) tem.flag = true;
                else
                {
                    tem.flag = false;
                    tem.num = -tem.num;
                }
                tem.discount = Convert.ToSingle(buf.Dequeue());
                tem.price = Convert.ToSingle(buf.Dequeue());
                int tyear = Convert.ToInt32(buf.Dequeue());
                int tmonth = Convert.ToInt32(buf.Dequeue());
                int tday = Convert.ToInt32(buf.Dequeue());
                int thour = Convert.ToInt32(buf.Dequeue());
                int tminute = Convert.ToInt32(buf.Dequeue());
                int tsecond = Convert.ToInt32(buf.Dequeue());
                DateTime tem_date = new DateTime(tyear, tmonth, tday, thour, tminute, tsecond);
                tem.time = tem_date;
                int flag = Convert.ToInt32(buf.Dequeue());
                if (flag == 1) tem.flag = true;
                else tem.flag = false;
                //MessageBox.Show(tem.commodityName + tem.id + tem.time.ToString() + "--*--" + tem.flag.ToString());
                s_list.Add(tem);
            }
            return s_list;
        }

        public static List<LogMessage> getLogByYear(int year)
        {
            if (!init_flag) throw new NotInitException();
            List<LogMessage> s_list = new List<LogMessage>();
            read_flag = true;
            buf.Clear();
            send_cmd("select * from clog where year ='" + year.ToString() + "';");
            while (read_flag) Task.Delay(100);
            if (string.Compare(error_str, 1, buf.Peek(), 1, error_str.Length) == 0) throw new FatalSQLException();
            int i;
            if ((i = Convert.ToInt32(buf.Dequeue())) == 0) throw new NotFindException();
            int j = Convert.ToInt32(buf.Dequeue());
            for (; i > 0; i--)
            {
                LogMessage tem = new LogMessage();
                tem.commodityName = buf.Dequeue();
                tem.id = buf.Dequeue();
                tem.num = Convert.ToInt32(buf.Dequeue());
                if (tem.num > 0) tem.flag = true;
                else
                {
                    tem.flag = false;
                    tem.num = -tem.num;
                }
                tem.discount = Convert.ToSingle(buf.Dequeue());
                tem.price = Convert.ToSingle(buf.Dequeue());
                int tyear = Convert.ToInt32(buf.Dequeue());
                int tmonth = Convert.ToInt32(buf.Dequeue());
                int tday = Convert.ToInt32(buf.Dequeue());
                int thour = Convert.ToInt32(buf.Dequeue());
                int tminute = Convert.ToInt32(buf.Dequeue());
                int tsecond = Convert.ToInt32(buf.Dequeue());
                DateTime tem_date = new DateTime(tyear, tmonth, tday, thour, tminute, tsecond);
                tem.time = tem_date;
                int flag = Convert.ToInt32(buf.Dequeue());
                if (flag == 1) tem.flag = true;
                else tem.flag = false;
                //MessageBox.Show(tem.commodityName + tem.id + tem.time.ToString() + "--*--" + tem.flag.ToString());
                s_list.Add(tem);
            }
            return s_list;
        }

        public static bool deleteByYear(int year)
        {
            if (!init_flag) throw new NotInitException();
            send_cmd("delete from clog where year = '" + year.ToString() + "'");
            return true;
        }

        public static bool deleteByMonth(int year, int month)
        {
            if (!init_flag) throw new NotInitException();
            send_cmd("delete from clog where year = '" + year.ToString() + "' and month = '" + month.ToString() + "';");
            return true;
        }

        public static bool deleteByDay(int year, int month, int day)
        {
            if (!init_flag) throw new NotInitException();
            send_cmd("delete from clog where year = '" + year.ToString() + "' and month = '" + month.ToString() + "' and day = '" + day.ToString() + "';");
            return true;
        }

        public static bool addStaff(Person p)
        {
            if (!init_flag) throw new NotInitException();
            read_flag = true;
            buf.Clear();
            send_cmd("select * from staff where loginname = '" + p.loginName + "'");
            while (read_flag) Task.Delay(100);
            if (string.Compare(error_str, 1, buf.Peek(), 1, error_str.Length) == 0) throw new FatalSQLException();
            if (Convert.ToInt32(buf.Dequeue()) != 0) throw new RepeatException();
            send_cmd("Insert into staff(name, pwd, loginname, power) values('" + p.name + "','" + p.password + "','" + p.loginName + "','" + get_level(p.level).ToString() + "');");
            return true;
        }

        public static bool deleteStaff(string loginName)
        {
            if (!init_flag) throw new NotInitException();
            getStaff(loginName);
            send_cmd("delete from staff where loginname = '" + loginName + "'");
            return true;
        }

        public static async Task<Person> getStaff(string loginName)
        {
            if (!init_flag) throw new NotInitException();
            Person staff = new Person();
            read_flag = true;
            buf.Clear();
            send_cmd("select * from staff where loginname = '" + loginName + "'");
            while (read_flag) await Task.Delay(100);
            if (string.Compare(error_str, 1, buf.Peek(), 1, error_str.Length) == 0) throw new FatalSQLException();
            if (Convert.ToInt32(buf.Dequeue()) == 0) throw new NotFindException();
            string aaa = buf.Dequeue();
            staff.name = buf.Dequeue();
            staff.password = buf.Dequeue();
            staff.loginName = buf.Dequeue();
            staff.level = read_level(Convert.ToInt32(buf.Dequeue()));
            //MessageBox.Show(staff.name + staff.password + staff.loginName);
            return staff;
        }

        public static List<Person> getAllStaff()
        {
            if (!init_flag) throw new NotInitException();
            List<Person> s_list = new List<Person>();
            read_flag = true;
            buf.Clear();
            send_cmd("select * from staff");
            while (read_flag) Task.Delay(100);
            if (string.Compare(error_str, 1, buf.Peek(), 1, error_str.Length) == 0) throw new FatalSQLException();
            int i;
            if ((i = Convert.ToInt32(buf.Dequeue())) == 0) throw new NotFindException();
            int j = Convert.ToInt32(buf.Dequeue());
            for (; i > 0; i--)
            {
                Person tem;
                tem.name = buf.Dequeue();
                tem.password = buf.Dequeue();
                tem.loginName = buf.Dequeue();
                tem.level = read_level(Convert.ToInt32(buf.Dequeue()));
                //MessageBox.Show(tem.name + tem.password + tem.loginName);
                s_list.Add(tem);
            }
            return s_list;
        }

        public static bool modifyStaff(Person p)
        {
            if (!init_flag) throw new NotInitException();
            getStaff(p.loginName);
            send_cmd("Update staff set name = '" + p.name + "', pwd = '" + p.password + "', loginname = '" + p.loginName + "',power = '" + get_level(p.level).ToString() + "' where loginname = '" + p.loginName + "';");
            return true;
        }

        public static Money getAmountOfMoneyByDay(int year, int month, int day)
        {
            Money mon = new Money();
            read_flag = true;
            buf.Clear();
            send_cmd("select sum(price * nums) from clog where flag = '1' and year = '" + year.ToString() + "' and month = '" + month.ToString() + "' and day = '" + day.ToString() + "';");
            while (read_flag) Task.Delay(100);
            if (string.Compare(error_str, 1, buf.Peek(), 1, error_str.Length) == 0) throw new FatalSQLException();
            buf.Dequeue(); buf.Dequeue();
            if (string.Compare(null_str, 0, buf.Peek(), 0, null_str.Length) != 0) mon.inMoney = Convert.ToSingle(buf.Dequeue());
            read_flag = true;
            buf.Clear();
            send_cmd("select sum(price * nums) from clog where flag = '0' and year = '" + year.ToString() + "' and month = '" + month.ToString() + "' and day = '" + day.ToString() + "';");
            while (read_flag) Task.Delay(100);
            if (string.Compare(error_str, 1, buf.Peek(), 1, error_str.Length) == 0) throw new FatalSQLException();
            buf.Dequeue(); buf.Dequeue();
            if (string.Compare(null_str, 0, buf.Peek(), 0, null_str.Length) != 0) mon.outMoney = Convert.ToSingle(buf.Dequeue());
            return mon;
        }

        public static Money getAmountOfMoneyByMonth(int year, int month)
        {
            Money mon = new Money();
            read_flag = true;
            buf.Clear();
            send_cmd("select sum(price * nums) from clog where flag = '1' and year = '" + year.ToString() + "' and month = '" + month.ToString() + "';");
            while (read_flag) Task.Delay(100);
            if (string.Compare(error_str, 1, buf.Peek(), 1, error_str.Length) == 0) throw new FatalSQLException();
            buf.Dequeue(); buf.Dequeue();
            if (string.Compare(null_str, 0, buf.Peek(), 0, null_str.Length) != 0) mon.inMoney = Convert.ToSingle(buf.Dequeue());
            read_flag = true;
            buf.Clear();
            send_cmd("select sum(price * nums) from clog where flag = '0' and year = '" + year.ToString() + "' and month = '" + month.ToString() + "';");
            while (read_flag) Task.Delay(100);
            if (string.Compare(error_str, 1, buf.Peek(), 1, error_str.Length) == 0) throw new FatalSQLException();
            buf.Dequeue(); buf.Dequeue();
            if (string.Compare(null_str, 0, buf.Peek(), 0, null_str.Length) != 0) mon.outMoney = Convert.ToSingle(buf.Dequeue());
            return mon;
        }
        public static Money getAmountOfMoneyByYear(int year)
        {
            Money mon = new Money();
            mon.inMoney = 0;
            mon.outMoney = 0;
            read_flag = true;
            buf.Clear();
            send_cmd("select sum(price * nums) from clog where flag = '1' and year = '" + year.ToString() + "';");
            while (read_flag) Task.Delay(100);
            if (string.Compare(error_str, 1, buf.Peek(), 1, error_str.Length) == 0) throw new FatalSQLException();
            buf.Dequeue();
            buf.Dequeue();
            if (string.Compare(null_str, 0, buf.Peek(), 0, null_str.Length) != 0) mon.inMoney = Convert.ToSingle(buf.Dequeue());
            read_flag = true;
            buf.Clear();
            send_cmd("select sum(price * nums) from clog where flag = '0' and year = '" + year.ToString() + "';");
            while (read_flag) Task.Delay(100);
            if (string.Compare(error_str, 1, buf.Peek(), 1, error_str.Length) == 0) throw new FatalSQLException();
            buf.Dequeue();
            buf.Dequeue();
            if (string.Compare(null_str, 0, buf.Peek(), 0, null_str.Length) != 0) mon.outMoney = Convert.ToSingle(buf.Dequeue());
            return mon;
        }


    }
}
