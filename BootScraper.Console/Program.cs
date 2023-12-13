using BootScraper.Orchestration;
using CommandLine;
 
Parser.Default.ParseArguments<BootScraperRequest>(args).WithParsed(request => Orchestrator.Run(request));