using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace ConsoleEnvisoft2
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var reader = new StreamReader("C:\\Users\\iledw\\OneDrive\\Documents\\Visual Studio 2019\\Projects\\ConsoleEnvisoft2\\ConsoleEnvisoft2\\Data.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                List<CustomerInfo> customerInfo = csv.GetRecords<CustomerInfo>().ToList();

                var firstNames = customerInfo.GroupBy(c => c.FirstName);
                var lastNames = customerInfo.GroupBy(c => c.LastName);

                var records = firstNames.Concat(lastNames).OrderByDescending(r => r.Count());

                foreach (var item in records)
                    Console.WriteLine(item.Key + " " + item.Count());

                IEnumerable<CustomerInfo> addresses = from item in customerInfo
                                                      orderby item.Address.Substring(item.Address.IndexOf(" ") + 1, 1)
                                                      select item;

                foreach (var item in addresses)
                    Console.WriteLine(item.Address);
            }
        }
    }
}
