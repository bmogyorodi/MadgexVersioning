using System.Text.RegularExpressions;
using System.Runtime.CompilerServices;

namespace versioning
{
    public class VersionIncrement
    {
        private static bool CheckVersionFormat(string version_number)
        {
            var version_format = new Regex("^(0|([1-9][0-9]*))(.(0|([1-9][0-9]*))){3}$");

            Match format_checking = version_format.Match(version_number);

            return format_checking.Success;
        }
        public static string GetLatestVersionNumber(string fileName)
        {
            string version_number = "";
            using (StreamReader sr = new(fileName))
            {
                string? line = sr.ReadLine();

                if (line != null)
                {

                    version_number = line; //Read version number from first line

                    if (!CheckVersionFormat(version_number))
                    {
                        throw new Exception("Retrieved version number doesn't match required format!");
                    }


                }
                else
                {
                    throw new Exception("Product Info file is empty!");
                }

                //Read the next line to make sure file has no more content
                line = sr.ReadLine();



                if (line != null)
                {
                    throw new Exception("Product Info file only supposed to have one line content with a valid version number");
                }
            }
            return version_number;
        }
        public static void SaveVersionNumberChanges(string fileName, string product_version)
        {
            if (!CheckVersionFormat(product_version))
            {
                throw new Exception("Cannot save incorrect version number into file!");
            }
            using (StreamWriter sw = new(fileName))
            {
                sw.WriteLine(product_version);
            }
            Console.WriteLine($"Version number {product_version} saved to: {fileName}");
        }
        private static string IncrementVersionNumber(string version, int index)
        {
            try
            {
                int[] version_numbers = version.Split('.').Select(x => int.Parse(x)).ToArray();
                version_numbers[index]++;
                for (int i = index + 1; i < version_numbers.Length; i++)
                {
                    version_numbers[i] = 0;
                }
                return String.Join(".", version_numbers);
            }
            catch (FormatException ex1)
            {
                return ex1.Message;
            }

        }
        public static string IncrementFeatureVersion(String version)
        {
            return IncrementVersionNumber(version, 2);

        }
        public static string IncrementFixVersion(String version)
        {
            return IncrementVersionNumber(version, 3);

        }
    }
}

