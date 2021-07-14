using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Globalization;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmedPlastPouyan
{
    public class Tools
    {
        public string WeekNum;
        public string BatchNum;
        public string LotNum;
        public int Shift;
        public static int GetLotNumber(int year, int month, int day, int x)
        {
            string a = year.ToString().Remove(0, 3);
            int b;
            if (month - 1 >= 6)
                b = 6;
            else
                b = month - 1;
            int c = (month - 1) * 30 + b + day;
            int d = ((c - 2) / 7) + 1;
            int dayofweek = ((c - 2) % 7);
            string BatchNum = ((Convert.ToInt16(a) * 100) + d).ToString();

            return ((Convert.ToInt16(BatchNum) * 100) + (dayofweek * 10) + x);

        }
        public Tools(string year, string month, string day, int index)
        {
            string a = year.Remove(0, 3);
            int b;
            if (Convert.ToInt16(month) - 1 >= 6)
                b = 6;
            else
                b = Convert.ToInt16(month) - 1;
            int c = (Convert.ToInt16(month) - 1) * 30 + b + Convert.ToInt16(day);
            int d = ((c - 2) / 7) + 1;
            int dayofweek = ((c - 2) % 7);
            WeekNum = d.ToString();
            BatchNum = ((Convert.ToInt16(a) * 100) + d).ToString();
            Shift = (index + 1);
            LotNum = ((Convert.ToInt16(BatchNum) * 100) + (dayofweek * 10) + Shift).ToString();
        }
        public static DateTime GetTimeNow()
        {
            DateTime time = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
            return time;
        }
        public static string GetPersia(string txt)
        {
            //("20-45-12:36") Example

            DateTime DT = Convert.ToDateTime(txt);
            PersianCalendar pc = new PersianCalendar();
            string time = "{0}/{1}/{2}-{3}:{4}";
            time = string.Format(time, pc.GetYear(DT), pc.GetMonth(DT), pc.GetDayOfMonth(DT), DT.Hour, DT.Minute);

            return time;
        }
        public static string GetPersianNoTime(string txt)
        {
            //("20-45-12:36") Example

            DateTime DT = Convert.ToDateTime(txt);
            PersianCalendar pc = new PersianCalendar();
            string time = "{0}/{1}/{2}";
            time = string.Format(time, pc.GetYear(DT), pc.GetMonth(DT), pc.GetDayOfMonth(DT));

            return time;
        }

        public static string GetEnglish(string txt)
        {
            //("20/12/25/") Example

            String[] strlist = txt.Split('/');
            int syear = Convert.ToInt16(strlist[0]) + 1300;
            int sMonth = Convert.ToInt16(strlist[1]);
            int sDay = Convert.ToInt16(strlist[2]);

            PersianCalendar pc = new PersianCalendar();
            DateTime Dt = new DateTime(syear, sMonth, sDay, pc);
            string time = "{0}/{1}/{2}-{3}:{4}:{5}";
            time = string.Format(time, Dt.Year, Dt.Month, Dt.Day, Dt.Hour, Dt.Minute, Dt.Second);

            return time;
        }

        public static int GetPersianYear()
        {
            PersianCalendar pc = new PersianCalendar();
            return pc.GetYear(DateTime.Now);
        }
        public static int GetPersianMonth()
        {
            PersianCalendar pc = new PersianCalendar();
            return pc.GetMonth(DateTime.Now);
        }
        public static int GetPersianDay()
        {
            PersianCalendar pc = new PersianCalendar();
            return pc.GetDayOfMonth(DateTime.Now);
        }
    }
}
