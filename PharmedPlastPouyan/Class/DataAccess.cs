using System;
using System.Data;
using System.Data.SqlClient;
using License;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.IO;

namespace PharmedPlastPouyan
{
    public class DataAccess
    {
        ServerConfig server = new ServerConfig();
        public bool Error = false;
        public static UserTable User = new UserTable();
        public static tblAvailability Availability = new tblAvailability { Analiz = "0000000000", Tolid = "0000000000", Ghaleb = "0000000000", Fani = "0000000000", QRD = "0000000000", Anbar = "0000000000", Sanaye = "0000000000" };
        public int Version;
        public bool Repair;
        public string Message;
        public string farsiMessage;
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;

        public static string MessageForUser = "";

        public static int YearDefault { get; set; }

        public DataAccess()
        {
            con = new SqlConnection();
            cmd = new SqlCommand();
            da = new SqlDataAdapter();
            cmd.Connection = con;
            da.SelectCommand = cmd;
        }
        public bool CheckConnection(string Server)
        {
            try
            {
                con.ConnectionString = server.ServerTest(Server);
                con.Open();
                var dbName = con.Database;
                if (con.State.ToString() == "Closed")
                {
                    Disconnect();
                    return false;
                }
                if (dbName.ToString() == "PharmedPlastDB")
                {
                    Disconnect();
                    return true;
                }
                Disconnect();
                return false;
            }
            catch (Exception)
            {
                Disconnect();
                return false;
            }
        }
        public bool CheckConnection()
        {
            try
            {
                Connect();
                var dbName = con.Database;
                if (con.State.ToString() == "Closed")
                {
                    Disconnect();
                    return false;
                }
                if (dbName.ToString() == "PharmedPlastDB")
                {
                    Disconnect();
                    Version = int.Parse(SelectOneCol("tblAdmin", "Parameter", "'version'", "Value").Replace(".", ""));
                    string a = SelectOneCol("tblAdmin", "Parameter", "'Repair'", "Value");
                    if (a == "0")
                        Repair = false;
                    else
                        Repair = true;

                    return true;
                }
                Disconnect();

                return false;
            }
            catch (Exception)
            {
                Disconnect();
                return false;
            }
        }
        public void Connect()
        {
            try
            {
                //string cs = PharmedPlastPouyan.Properties.Settings.Default;
                string cs = "Data Source=;Initial Catalog=;Integrated Security=True";
                con.ConnectionString = cs;
                con.Open();
            }
            catch (Exception ex)
            {
                Message = ex.Message;
                if (ex.Message == "Login failed for user 'plast'.")
                    farsiMessage = "License";
                else
                    farsiMessage = "مشکل در اتصال به بانک اطلاعاتی";
                Error = true;
                Disconnect();
            }

        }

        
        public void Disconnect()
        {
            con.Close();
        }
        public bool login(string textUser, string textPass)
        {
            //Ma be hame goftim zade
            //Shoma ham begoo zade
            try
            {
                LINQDataContext DataBase = new LINQDataContext();
                IQueryable<UserTable> PU;
                PU = from u in DataBase.UserTables
                     where u.UName == textUser && u.Password == textPass
                     select u;
                if (PU.Count() == 1)
                {

                    User = PU.FirstOrDefault();
                    var PA = from u in DataBase.tblAvailabilities
                             where u.IDAv == User.IDAv
                             select u;
                    Availability = PA.FirstOrDefault();
                    YearDefault = Tools.GetPersianYear();
                    string tmp = (SelectOneCol("tblAdmin", "Parameter", "'" + User.PCode + "'", "Value"));
                    if (tmp != "False")
                        MessageForUser = tmp;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Error = true;
                Message = ex.Message;
                farsiMessage = "خطا در دستور بانک اطلاعاتی برنامه با مشکل رو ب رو گردیده است. احتیاط در بستن برنامه است.";
                Disconnect();
                return false;
            }
        }

        /*
         */
        public int CurrentID(string Table, string Col)
        {
            try
            {
                DataTable dt = new DataTable();
                string sql = @"SELECT max({0})+1 as CurrentID FROM {1}";
                sql = string.Format(sql, Col, Table);
                Connect();
                cmd.CommandText = sql;
                da.Fill(dt);
                Disconnect();
                int i = Convert.ToInt16(dt.Rows[0]["CurrentID"]);

                return i;
            }
            catch (Exception ex)
            {

                Error = true;
                Message = ex.Message;
                farsiMessage = "جدولی با این مشخصات یافت نشد";
                Disconnect();
                return 1;
            }
        }

        public int CurrentID(string Table)
        {
            try
            {
                DataTable dt = new DataTable();
                string sql = @"SELECT max(IDPR)+1 as CurrentID FROM {0}";
                sql = string.Format(sql, Table);
                Connect();
                cmd.CommandText = sql;
                da.Fill(dt);
                Disconnect();
                int i = Convert.ToInt16(dt.Rows[0]["CurrentID"]);

                return i;
            }
            catch (Exception ex)
            {

                Error = true;
                Message = ex.Message;
                farsiMessage = "جدولی با این مشخصات یافت نشد";
                Disconnect();
                return 1;
            }
        }

        public string SelectOneCol(string table, string col, string data, string result)
        {
            try
            {
                DataTable dt = new DataTable();
                string sql = @"SELECT * from {0} where {1}={2}";
                sql = string.Format(sql, table, col, data);
                Connect();
                cmd.CommandText = sql;
                da.Fill(dt);
                Disconnect();
                string send = dt.Rows[0][result].ToString();
                return send;
            }
            catch (Exception ex)
            {
                Error = true;
                Message = ex.Message;
                farsiMessage = "جدولی با این مشخصات یافت نشد";
                Disconnect();
                if (Message == "There is no row at position 0.")
                {
                    return "False";
                }
                return "";
            }

        }

        public string SelectOneCol2Where(string table, string shart, string result)
        {
            try
            {
                DataTable dt = new DataTable();
                string sql = @"SELECT * from {0} where {1} order by id DESC";
                sql = string.Format(sql, table, shart);
                Connect();
                cmd.CommandText = sql;
                da.Fill(dt);
                Disconnect();
                string send = dt.Rows[0][result].ToString();
                return send;
            }
            catch (Exception ex)
            {
                Error = true;
                Message = ex.Message;
                farsiMessage = "جدولی با این مشخصات یافت نشد";
                Disconnect();
                if (Message == "There is no row at position 0.")
                {
                    return "False";
                }
                return "";
            }

        }

        public DataTable Select(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                Connect();
                cmd.CommandText = sql;
                da.Fill(dt);
                Disconnect();
            }
            catch (Exception ex)
            {
                Error = true;
                Message = ex.Message;
                farsiMessage = "جدولی با این مشخصات یافت نشد";
                Disconnect();
            }
            return dt;
        }
        public DataTable Select(string Table, string Valid)
        {
            DataTable dt = new DataTable();
            try
            {
                Connect();
                string sql = "Select * From {0} Where {1}";
                cmd.CommandText = string.Format(sql, Table, Valid);
                da.Fill(dt);
                Disconnect();
            }
            catch (Exception ex)
            {
                Error = true;
                Message = ex.Message;
                farsiMessage = "جدولی با این مشخصات یافت نشد";
                Disconnect();
            }
            return dt;
        }

    }
}