using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esra.COMMON
{
    public static class myCommon
    {
        public static string RemoveLastChar(this string s, string Char)
        {
            s = s.TrimEnd();
            if ((s.Length > 0) && (s.Substring(s.Length - 1, 1) == Char)) s = s.Remove(s.Length - 1, 1);
            s = s.TrimEnd();
            if ((s.Length > 0) && (s.Substring(s.Length - 1, 1) == Char)) s = s.RemoveLastChar(Char);
            return s;
        }
        public static string WordCountToShow(this string s, int count, bool normalaizeEnd)
        {
            int orginalCount = count;
            string[] words = s.Split(' ');
            string wordsToShow = "";
            if (words.Count() < count) count = words.Count();
            if (words.Count() > orginalCount)
            {
                if (normalaizeEnd)
                    for (int i = count - 5; i < count + 5; i++)
                        if (words[i].Contains("."))
                        {
                            count = i;
                            break;
                        }
            }
            for (int i = 0; i < count; i++)
                wordsToShow += words[i] + " ";
            if (normalaizeEnd)
                return wordsToShow;
            return wordsToShow + "...";
        }
        public static pager Pager(int page, int pageSize)
        {
            var p = new pager
            {
                Skip = ((page - 1) * pageSize),
                Take = pageSize
            };
            return p;
        }
        public class pager
        {
            public int Take = 15;
            public int Skip = 0;
        }
        public static initPager InitPager(decimal currentPage, decimal stepConst, decimal allRowCount, decimal resultPerPage)
        {
            decimal allPage = Math.Ceiling((allRowCount / resultPerPage));
            if (currentPage == 0) currentPage = 1;

            var p = new initPager
            {
                CurrentStep = Math.Ceiling((currentPage / stepConst)),
                AllStep = Math.Ceiling((allPage / stepConst))
            };
            if (p.CurrentStep > 1 && p.AllStep > 1)
                p.NeedFirst = true;
            if (p.AllStep > 1 && p.CurrentStep != p.AllStep)
            {
                p.NeedEnd = true;
                p.EndPage = Convert.ToInt32((p.CurrentStep * stepConst));
                p.StartPage = Convert.ToInt32(p.EndPage - stepConst + 1);
                p.LastPage = Convert.ToInt32(allPage);
            }
            else
            {
                p.EndPage = allPage > 1 ? Convert.ToInt32(allPage) : 1;
                p.StartPage = p.EndPage > 1 ? Convert.ToInt32((p.AllStep * stepConst) - stepConst + 1) : 1;
            }


            return p;
        }
        public class initPager
        {
            public decimal AllStep;
            public bool NeedFirst = false;
            public bool NeedEnd = false;
            public decimal CurrentStep;
            public int StartPage;
            public int EndPage;
            public int LastPage;
        }
        private static readonly Random Random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[Random.Next(s.Length)]).ToArray());
        }
        public static bool isPersian(this string s)
        {
            char fl = '\0';
            if (s != null && s.Any())
                fl = s.First();
            if ((fl >= 'a' && fl <= 'z') || (fl >= 'A' && fl <= 'Z'))
                return false;
            return true;
        }
        public static string GetPersianDate(this DateTime date)
        {
            PersianCalendar jc = new PersianCalendar();
            return String.Format("{0:0000}/{1:00}/{2:00}", jc.GetYear(date), jc.GetMonth(date), jc.GetDayOfMonth(date));
        }
        public static DateTime GetDateTimeFromJalaliString(this string jalaliDate)
        {
            PersianCalendar jc = new PersianCalendar();
            int year = 0, month = 0, day = 0;
            try
            {
                string[] date = jalaliDate.Split('/');
                if (date.Any()) year = Convert.ToInt32(date[0]);
                if (date.Count() > 0) month = Convert.ToInt32(date[1]);
                if (date.Count() > 1) day = Convert.ToInt32(date[2]);

                DateTime d = jc.ToDateTime(year, month, day, 0, 0, 0, 0, PersianCalendar.PersianEra);

                return d;
            }
            catch (Exception)
            {
                try
                {
                    string[] date = jalaliDate.Split('/');
                    if (date.Any()) year = Convert.ToInt32(date[2]);
                    if (date.Count() > 0) month = Convert.ToInt32(date[1]);
                    if (date.Count() > 1) day = Convert.ToInt32(date[0]);

                    DateTime d = jc.ToDateTime(year, month, day, 0, 0, 0, 0, PersianCalendar.PersianEra);

                    return d;

                }
                catch (Exception)
                {

                    return new DateTime();

                }
            }
        }
        public static string GetDayOfWeekName(this DateTime date)
        {
            switch (date.DayOfWeek)
            {
                case DayOfWeek.Saturday: return "شنبه";
                case DayOfWeek.Sunday: return "يکشنبه";
                case DayOfWeek.Monday: return "دوشنبه";
                case DayOfWeek.Tuesday: return "سه‏ شنبه";
                case DayOfWeek.Wednesday: return "چهارشنبه";
                case DayOfWeek.Thursday: return "پنجشنبه";
                case DayOfWeek.Friday: return "جمعه";
                default: return "";
            }
        }
        public static string GetMonthName(this DateTime date)
        {
            PersianCalendar jc = new PersianCalendar();
            string pdate = String.Format("{0:0000}/{1:00}/{2:00}", jc.GetYear(date), jc.GetMonth(date), jc.GetDayOfMonth(date));

            string[] dates = pdate.Split('/');
            int month = Convert.ToInt32(dates[1]);

            switch (month)
            {
                case 1: return "فررودين";
                case 2: return "ارديبهشت";
                case 3: return "خرداد";
                case 4: return "تير‏";
                case 5: return "مرداد";
                case 6: return "شهريور";
                case 7: return "مهر";
                case 8: return "آبان";
                case 9: return "آذر";
                case 10: return "دي";
                case 11: return "بهمن";
                case 12: return "اسفند";
                default: return "";
            }
        }
        public static string GetPersianDay(this DateTime date)
        {
            PersianCalendar jc = new PersianCalendar();
            string pdate = String.Format("{0:0000}/{1:00}/{2:00}", jc.GetYear(date), jc.GetMonth(date), jc.GetDayOfMonth(date));

            string[] dates = pdate.Split('/');
            int day = Convert.ToInt32(dates[2]);

            return day.ToString();
        }
        public static string GetPersianYear(this DateTime date)
        {
            PersianCalendar jc = new PersianCalendar();
            string pdate = String.Format("{0:0000}/{1:00}/{2:00}", jc.GetYear(date), jc.GetMonth(date), jc.GetDayOfMonth(date));

            string[] dates = pdate.Split('/');
            int day = Convert.ToInt32(dates[0]);

            return day.ToString();
        }
    }
}