using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedinJobApplier.Config
{
    public static class IndexManager
    {
        public static void SaveIndexes(int currentInfoPageIndex, int currentTitleIndex, int currentCountryIndex, string filename = "indexes.txt")
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filename))
                {
                    writer.WriteLine(currentInfoPageIndex);
                    writer.WriteLine(currentTitleIndex);
                    writer.WriteLine(currentCountryIndex);
                }
                Console.WriteLine("Indexes saved successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while saving indexes: {ex.Message}");
            }
        }

        public static void ReadIndexes(out int currentInfoPageIndex, out int currentTitleIndex, out int currentCountryIndex, string filename = "indexes.txt")
        {
            currentInfoPageIndex = 0;
            currentTitleIndex = 0;
            currentCountryIndex = 0;

            try
            {
                using (StreamReader reader = new StreamReader(filename))
                {
                    currentInfoPageIndex = int.Parse(reader.ReadLine());
                    currentTitleIndex = int.Parse(reader.ReadLine());
                    currentCountryIndex = int.Parse(reader.ReadLine());
                }
                Console.WriteLine("Indexes read successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while reading indexes: {ex.Message}");
            }
        }
    }
}
