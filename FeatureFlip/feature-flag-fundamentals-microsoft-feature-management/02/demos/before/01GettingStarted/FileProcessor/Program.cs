using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.FeatureManagement;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static System.Console;

namespace FileProcessor
{
    class Program
    {
        static IFeatureManager featureManager;
        static async Task Main(string[] args)
        {
            initiliazeFeature();

            WriteLine("File Processor");
            WriteLine("--------------");                      
            
            while (true)
            {
                WriteLine();
                WriteLine("(V)erify only");
                WriteLine("(I)mport into database");
                WriteLine("(P)rint");
                if (await featureManager.IsEnabledAsync("Convert"))
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
                        if(await featureManager.IsEnabledAsync("Connvert"))
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

        private static void initiliazeFeature()
        {
            var flags = new Dictionary<string, string>
            {
                {"FeatureManagement:Convert", "true" }
            };

            IConfigurationBuilder builder = new ConfigurationBuilder();
            builder.AddInMemoryCollection(flags);
            IConfigurationRoot configuration = builder.Build();

            IServiceCollection services = new ServiceCollection();
            services.AddFeatureManagement(configuration);
            IServiceProvider serviceProvider = services.BuildServiceProvider();
            featureManager = serviceProvider.GetRequiredService<IFeatureManager>();
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
