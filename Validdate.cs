using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter a string that may contain a date in MMDDYYYY format:");
        string input = Console.ReadLine();

        var matches = Regex.Matches(input, @"\b\d{8}\b");

        bool found = false;

        foreach (Match match in matches)
        {
            string dateStr = match.Value;

            // Try to parse the 8-digit number as MMddyyyy
            if (DateTime.TryParseExact(dateStr, "MMddyyyy",
                System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None,
                out DateTime validDate))
            {
                Console.WriteLine($"Valid date found: {dateStr} => {validDate.ToShortDateString()}");
                found = true;
            }
        }

        if (!found)
        {
            Console.WriteLine("No valid MMDDYYYY date found in the input.");
        }
    }
}
