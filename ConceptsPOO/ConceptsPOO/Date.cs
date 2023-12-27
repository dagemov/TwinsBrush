namespace ConceptsPOO
{
    public class Date
    {
        private int _day { get; set; }
        private int _month { get; set; }
        private int _year { get; set; }

        public Date(int year, int month, int day)
        {
            _day = CheckDay(year, month, day);
            _month = CheckMonth(month);
            _year = year;
        }

        private int CheckDay(int year, int month, int day)
        {
            if (month == 2 && day == 29 && IsLeapYear(year))
            {
                return day;
            }
            int[] daysPerMomth = { 0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31};
            if (day >= 1 && day <= daysPerMomth[month])
            {
                return day;
            }
            throw new DayException("Invalid Day");
        }

        private bool IsLeapYear(int year)
        {
            return year%400 ==0  || year%4==0 && year%100!=0;
            //if (year % 4 == 0 && year % 100 ! = 0 && year % 400==0)
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
        }

        private int CheckMonth(int month)
        {
            if (month >= 1 && month <= 12)
            {
                return month;
            }
            throw new MonthException("Invalid Month");
        }

        public override string ToString()
        {
            return $"{_year}/{_month:00}/{_day:00}";
        }

    }
}
