﻿using CommandLine;
using PersonaMusicScript.Library;
using Serilog;

namespace PersonaMusicScript.CLI;

public class Program
{
    private static readonly Dictionary<string, string> gameNames = new()
    {
        ["p4g-pc"] = "Persona 4 Golden PC x64",
        ["p3p-pc"] = "Persona 3 Portable PC",
        ["p5r-pc"] = "Persona 5 Royal PC",
    };

    public class Options
    {
        [Option('g', "game", Required = true, HelpText = "Game to create patch for. Valid: p4g-pc")]
        public string Game { get; set; } = string.Empty;

        [Option('i', "input", Required = true, HelpText = "Input music script file.")]
        public string InputFile { get; set; } = string.Empty;
    }

    public static void Main(string[] args)
    {
        Console.WriteLine("Persona Music Script by T-Pose Ratkechi");
        Console.WriteLine("Credits\nTupelov: Libellus Library\nPixelguin: Collection fixes and testing\nSierra: Original TV Floor BGM idea");

        Parser.Default.ParseArguments<Options>(args)
            .WithParsed(o =>
            {
                var game = o.Game;
                var inputFile = o.InputFile;

                Log.Logger = new LoggerConfiguration().WriteTo.Console().CreateLogger();

                try
                {
                    var gameName = gameNames[game];
                    var parser = new MusicParser(gameName);
                    var music = parser.Parse(inputFile);
                }
                catch (Exception ex)
                {
                    Log.Error(ex, "Failed to parse music.");
                }
            });
    }
}