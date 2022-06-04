using static versioning.VersionIncrement;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        const string PRODUCT_INFO_FILE = "ProductInfo.cs";



        static void Main()
        {

            try
            {
                var product_version = GetLatestVersionNumber(PRODUCT_INFO_FILE);
                Console.WriteLine($"Current product version: {product_version}");
                Console.WriteLine(); //break line


                Console.WriteLine("Enter release type here to increment version number: (current valid values are Feature or Bug Fix)");

                string? releaseType = Console.ReadLine();
                if (releaseType != null)
                {
                    releaseType = releaseType.ToLower();
                }

                Console.WriteLine(); //break line
                switch (releaseType)
                {
                    case "feature":
                        product_version = IncrementFeatureVersion(product_version);
                        Console.WriteLine($"Version number incremented to: {product_version}");
                        SaveVersionNumberChanges(PRODUCT_INFO_FILE, product_version);
                        break;
                    case "bug fix":
                        product_version = IncrementFixVersion(product_version);
                        Console.WriteLine($"Version number incremented to: {product_version}");
                        SaveVersionNumberChanges(PRODUCT_INFO_FILE, product_version);
                        break;
                    default:
                        Console.WriteLine("Invalid release type was entered! Version number stayed the same!");
                        break;
                }
                

            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }





        }
    }
}


