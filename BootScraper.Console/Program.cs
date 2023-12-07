﻿using BootScraper.Console;
using BootScraper.Console.Orchestration;
using CommandLine;

Parser.Default.ParseArguments<CommandLineOptions>(args).WithParsed(Orchestrator.Run);