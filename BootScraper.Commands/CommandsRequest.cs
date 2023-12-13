namespace BootScraper.Commands
{
    public class CommandsRequest
    {
        public readonly string? OutputLocation;
        public readonly bool Quiet;
        public readonly bool DeduplicateOutput;
        public readonly List<CommandOutputModel> OutputModel;


        public CommandsRequest(string outputLocation, bool quiet, bool deduplicateOutput, List<CommandOutputModel> outputModel)
        {
            OutputLocation = outputLocation;
            Quiet = quiet;
            DeduplicateOutput = deduplicateOutput;
            OutputModel = outputModel;
        }
    }
}
