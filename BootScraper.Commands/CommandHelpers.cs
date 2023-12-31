﻿using System.Globalization;
using CsvHelper;

namespace BootScraper.Commands
{
    internal static class CommandHelpers
    {
        internal static void CreateCsvHeader<T>(string outputLocation)
        {
            using var stream = File.Open(outputLocation, FileMode.Append);
            using var writer = new StreamWriter(stream);
            using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
            {
                csv.WriteHeader<T>();
                csv.NextRecord();
            }
        }
    }
}
