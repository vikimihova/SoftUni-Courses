using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.DateModifier
{
    public static class DateModifier
    {
        public static int GetDifferenceInDays(string startDate, string endDate)
        {
            DateTime start = DateTime.Parse(startDate);
            DateTime end = DateTime.Parse(endDate);

            TimeSpan difference = end - start;

            return Math.Abs(difference.Days);
        }
    }
}
