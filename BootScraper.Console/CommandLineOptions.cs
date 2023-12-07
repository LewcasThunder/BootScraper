using CommandLine;

namespace BootScraper.Console
{
    public class CommandLineOptions
    {
        [Option('u', "serviceurl", Required = true, HelpText = "The stock checker API's url")]
        public string ServiceUrl { get; set; }

        [Option('p', "productid", Required = true, HelpText = "The product ID to be searched. Defaults to output.csv")]
        public string ProductId{ get; set; }

        [Option('o', "output", Required = false, HelpText = "Filepath/name for output file location")]
        public string OutputLocation { get; set; } = "output.csv";

        [Option('d', "requestdelay", Required = false, HelpText = "The delay in milliseconds between each API call. Defaults to 2000")]
        public int RequestedDelay { get; set; } = 2000;

        [Option('q', "quiet", Required = false, HelpText = "Set to true to remove command line output. Defaults to false")]
        public bool Quiet { get; set; } = false;
    }
}
