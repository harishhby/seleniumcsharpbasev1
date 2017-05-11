using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POM.Temp
{
    class Cal
    {
        public static void Main(string[] args)
        {
            string date = "12/07/2017";
            DateTime currentDate = DateTime.Now;
            Console.WriteLine(currentDate);

            DateTime dateToBeSelected = Convert.ToDateTime(date);
            Console.WriteLine(currentDate.CompareTo(dateToBeSelected));

            string month = dateToBeSelected.ToString("MMMM");
            Console.WriteLine(month);

            string day = dateToBeSelected.ToString("dd");
            Console.WriteLine(day);

            string year = dateToBeSelected.ToString("yyyy");
            Console.WriteLine(year);

            string monthYearToBeSelected = month + " " + year;
            Console.WriteLine(monthYearToBeSelected);

            Console.ReadKey();

      

        }

    }
}
