using BootScraper.Common;
using BootScraper.Orchestration;
using CommandLine;
 
Parser.Default.ParseArguments<StockLevelRequest>(args).WithParsed(Orchestrator.Run);