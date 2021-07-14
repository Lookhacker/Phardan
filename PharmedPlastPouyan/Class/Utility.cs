using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PharmedPlastPouyan
{
    public class Utility
    {
        public Utility()
        {

        }

        public static bool CreateTime(int Year, int Month, int Day)
        {
            LINQDataContext DataBase = new LINQDataContext();
            int createTime = int.Parse((from s in DataBase.tblAdmins where s.Parameter == "CR-Time" select s.Value).SingleOrDefault());
            bool limit = Convert.ToBoolean((from s in DataBase.tblAdmins where s.Parameter == "CR-TimeLimit" select s.Value).SingleOrDefault());

            PersianCalendar pc = new PersianCalendar();
            DateTime t1 = new DateTime(Year, Month, Day, pc);
            DateTime t2 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

            if (t1 > t2)
            {
                return true;
            }

            t2 = t2.AddDays(-createTime);

            if (limit)
                return false;

            if (t1 <= t2)
                return true;
            else
                return false;
        }

      
        
        public static DataTable ToDataTable<T>(DataRow[] a)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                var type = (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(prop.PropertyType) : prop.PropertyType);
                dataTable.Columns.Add(prop.Name, type);
            }
            foreach (var item in a)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    if (item[i].ToString() == "")
                        values[i] = null;
                    else
                        values[i] = item[i];
                }
                dataTable.Rows.Add(values);
            }
            return dataTable;
        }
         


        public static DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                var type = (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(prop.PropertyType) : prop.PropertyType);
                dataTable.Columns.Add(prop.Name, type);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            return dataTable;
        }
        public static DataTable CreateTable<T>()
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                var type = (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(prop.PropertyType) : prop.PropertyType);
                dataTable.Columns.Add(prop.Name, type);
            }

            return dataTable;
        }
        
        public static bool NotEqual<T>(T First, T Last)
        {
            bool temp = false;
            PropertyInfo[] E = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var item in E)
            {
                if (item.Name == "uid")
                    continue;
                var a = item.GetValue(First, null);
                if (a != null)
                    if (item.GetValue(First, null).ToString() != item.GetValue(Last, null).ToString())
                    {
                        temp = true;
                        break;
                    }
            }
            return temp;
        }

       

     
    }
}
