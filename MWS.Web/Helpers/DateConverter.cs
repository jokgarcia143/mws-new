using Microsoft.VisualBasic;
using System;
using System.Globalization;

namespace MWS.Web.Helpers
{
    public class DateConverter
    {
        private readonly string _dateformat = "dd/MMM/yyyy";
        public DateTime ConvertStringToDate(string inputDateString)
        {
            // Parse the input date string
            if (DateTime.TryParse(inputDateString, CultureInfo.CurrentCulture.DateTimeFormat, DateTimeStyles.None, out DateTime inputDate))
            {
                Console.WriteLine("Original date string: " + inputDateString);
                //Console.WriteLine("Formatted date: " + Convert.ToDateTime(inputDate.ToString(_dateformat)));
                Console.WriteLine("Formatted date: " + Convert.ToDateTime(inputDate.ToString()));
            }
            else
            {
                Console.WriteLine("Invalid date string format");
            }

            return inputDate;
        }
    }
}
