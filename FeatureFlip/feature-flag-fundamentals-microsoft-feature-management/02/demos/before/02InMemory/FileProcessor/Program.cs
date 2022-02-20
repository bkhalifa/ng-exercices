using Microsoft.FeatureManagement;
using System;
using System.Threading.Tasks;
using static System.Console;

namespace FileProcessor
{
    class Program
    {

        static IFeatureManager FeatureManager;

        static async Task Main(string[] args)
        {
            InitializeFeatures();

            WriteLine("File Processor");
            WriteLine("--------------");                      
            
            while (true)
            {
                WriteLine();
                WriteLine("(V)erify only");
                WriteLine("(I)mport into datbase");
                WriteLine("(P)rint");

                if (await FeatureManager.IsEnabledAsync("Convert")) 
                {
                    WriteLine("(C)onvert");
                }

                WriteLine("(E)xit");

                var input = GetUserInput("Please choose an option and press enter");

                switch (input)
                {
                    case "V":
                        Verify();
                        break;
                    case "I":
                        Import();
                        break;
                    case "P":
                        Print();
                        break;
                    case "C":
                        if (await FeatureManager.IsEnabledAsync("Convert"))
                        {
                            Convert();
                        }
                        break;
                    case "E":
                        Environment.Exit(0);
                        break;
                    default:
                        WriteLine("Invalid option.");
                        break;
                }
            }
        }

        private static void InitializeFeatures()
        {
            throw new NotImplementedException();
        }

        private static void Verify()
        {
            WriteLine("Verifying...");
        }
        
        private static void Import()
        {
            WriteLine("Importing...");
        }

        private static void Print()
        {
            WriteLine("Printing...");
        }

        private static void Convert()
        {
            throw new NotImplementedException();
        }

        private static string GetUserInput(string prompt)
        {
            WriteLine(prompt);
            return ReadLine();
        }        
    }
}
