using BootScraper.Common;
using BootScraper.Orchestration;
using CommandLine;
 
Parser.Default.ParseArguments<BootScraperRequest>(args).WithParsed(Orchestrator.Run);