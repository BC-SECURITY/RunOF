﻿using RunBOF.Internals;
using System;
using System.Runtime.CompilerServices;
using System.Diagnostics;

namespace RunBOF
{
    class Program
    {
        private const int ERROR_INVALID_COMMAND_LINE = 0x667;

        static void Main(string[] args)
        {
            Logger.Info("Starting PoshBOF.");

#if DEBUG
            Logger.Level = Logger.LogLevels.DEBUG;
#endif


            var ParsedArgs = new ParsedArgs(args); 


            Logger.Info($"Loading object file {ParsedArgs.filename}");

            try
            {
                BofRunner bof_runner = new BofRunner(ParsedArgs);
                //  bof_runner.LoadBof(filename);

                bof_runner.LoadBof();

                Logger.Info($"About to start BOF in new thread at {bof_runner.entry_point.ToInt64():X}");
#if !DEBUG
                if (ParsedArgs.debug)
                {
#endif
                
                    Logger.Debug("Press enter to start it (✂️ attach debugger here...)");
                    Console.ReadLine();
#if !DEBUG
            }
#endif


                var output = bof_runner.RunBof(30);

                Console.WriteLine("------- BOF OUTPUT ------");
                Console.WriteLine($"{output}");
                Console.WriteLine("------- BOF OUTPUT FINISHED ------");
#if !DEBUG
                if (ParsedArgs.debug)
                {
#endif
                    Logger.Debug("Press enter to continue...");
                    Console.ReadLine();
#if !DEBUG
            }
#endif
                Logger.Info("[*] Thanks for playing!");
            } catch (Exception e)
            {
                Logger.Error($"Error! {e}");
                Environment.Exit(-1);
            }

        }

       
    }
    public static class Logger
    {
        public enum LogLevels
        {
            ERROR,
            INFO,
            DEBUG
        }

        public static LogLevels Level { get; set; } = LogLevels.INFO;


        static Logger()
        {

        }

        public static void Debug(string Message, [CallerMemberName] string caller = "")
        {
            var methodInfo = new StackTrace().GetFrame(1).GetMethod();
            var className = methodInfo.ReflectedType.Name;
            if (Level >= LogLevels.DEBUG) Console.WriteLine($"[=] [{className}:{methodInfo}] {Message}");
        }

        public static void Info(string Message)
        {
            if (Level >= LogLevels.INFO) Console.WriteLine($"[*] {Message}");
        }

        public static void Error(string Message)
        {
            if (Level >= LogLevels.ERROR) Console.WriteLine($"[!!] {Message}");
        }
    }
}
