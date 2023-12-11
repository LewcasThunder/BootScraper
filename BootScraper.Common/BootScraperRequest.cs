using CommandLine;

namespace BootScraper.Common
{
    public class BootScraperRequest
    {
        [Option('u', "serviceurl", Required = true, HelpText = "The stock checker API's url")]
        public string ServiceUrl { get; set; }

        [Option('p', "productid", Required = true, HelpText = "The product ID to be searched. Defaults to output.csv")]
        public string ProductId { get; set; }

        [Option('i', "inputstoredata", Required = true, HelpText = "The filepath/name of the store data input. This is currently located in BootScraper.Queries\\LoadStoreData\\StoreData.csv")]
        public string InputStoreData { get; set; }

        [Option('c', "county", Required = false, HelpText = "Sets the county to search")]
        public string? County { get; set; } = null;

        [Option('o', "output", Required = false, HelpText = "Filepath/name for output file location. Will not output file if no value is given")]
        public string? OutputLocation { get; set; }

        [Option('r', "requestdelay", Required = false, HelpText = "The delay in milliseconds between each API call. Defaults to 2000")]
        public int RequestedDelay { get; set; } = 2000;

        [Option('q', "quiet", Required = false, HelpText = "Set to true to remove command line output. Defaults to false")]
        public bool Quiet { get; set; } = false;

        [Option('d', "deduplicateoutput", Required = false, HelpText = "Sets the option to only output one row per store. Defaults to false")]
        public bool DeduplicateOutput { get; set; } = false;
    }
}
