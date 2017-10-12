using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Joan.Cyphers;

namespace Joan
{
    class Program
    {
        static void Main(string[] args)
        {
            /* debug */

            var debugTest = @"D:\Projects_development\OpenSource\Joan\samples\gitw-joan.txt";

            /* bling */

            Console.WriteLine(" Welcome to");

            Console.WriteLine(@"     __     ______     ______     __   __");
            Console.WriteLine(@"    /\ \   /\  __ \   /\  __ \   /\ ""-.\ \   ");
            Console.WriteLine(@"   _\_\ \  \ \ \/\ \  \ \  __ \  \ \ \-.\ \");
            Console.WriteLine(@"  /\_____\  \ \_____\  \ \_\ \_\  \ \_\\""\_\ ");
            Console.WriteLine(@"  \/_____/   \/_____/   \/_/\/_/   \/_/ \/_/");

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            /* input */

            const string separator = "~JIS~";

            Console.Write("Enter file path: ");
            var path = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(path)) path = debugTest;

            var inputs = File.ReadAllText(path)
                .Split(separator, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => new Input(x.Trim()))
                .ToList();

            /* setup */ 

            var cyphers = new List<ICypher>
            {
                new Atbash(),
                new Rot(1),
                new Rot(2),
                new Rot(3),
                new Rot(4),
                new Rot(5),
                new Rot(6),
                new Rot(7),
                new Rot(8),
                new Rot(9),
                new Rot(10),
                new Rot(11),
                new Rot(12),
                new Rot(13),
                new Rot(14),
                new Rot(15),
                new Rot(16),
                new Rot(17),
                new Rot(18),
                new Rot(19),
                new Rot(20),
                new Rot(21),
                new Rot(22),
                new Rot(23),
                new Rot(24),
                new Rot(25),
                new Base64(),
                new DecimalAscii(),
                new OctalAscii(),
                new HexAscii(),
                new MitnickBase36()
            };

            Console.Write("Enter language: ");
            var lang = Console.ReadLine();
            var lDict = ResourceReader.ReadDictionary(lang);

            /* magic */

            var sw = new Stopwatch();
            sw.Start();

            var nInputs = new List<Input>();

            foreach (var input in inputs)
            {
                Console.WriteLine($"Currently attacking: {input.Original}");
                var results = new List<string>();
                foreach (var cypher in cyphers)
                {
                    if (!cypher.SolutionPossible(input.Prepared)) continue;
                    var result = cypher.Run(cypher.NeedsOriginalInput ? input.Original : input.Prepared);
                    if (cypher.ShouldReRunSolution && result != "") nInputs.Add(new Input(result));
                    var rsplit = cypher.NeedsOriginalInput ? result.Split(' ').Select(x => x.ToUpperInvariant()) : result.Split(' ');
                    if (!rsplit.Where(x => x.Length > 1).Any(x => lDict.Contains(x))) continue;
                    results.Add(result);
                    input.ProbablySolved = true;
                }
                if (results.Any())
                {
                    Console.WriteLine($" > {results.OrderBy(x => x.Split(' ').Count(y => lDict.Contains(y))).Last()}");
                }
                Console.WriteLine();
            }

            foreach (var input in nInputs)
            {
                Console.WriteLine($"Currently attacking on a re-run: {input.Original}");
                var results = new List<string>();
                foreach (var cypher in cyphers.Where(x => !x.ShouldReRunSolution))
                {
                    if (!cypher.SolutionPossible(input.Prepared)) continue;
                    var result = cypher.Run(cypher.NeedsOriginalInput ? input.Original : input.Prepared);
                    var rsplit = result.Split(' ');
                    if (!rsplit.Where(x => x.Length > 1).Any(x => lDict.Contains(x))) continue;
                    results.Add(result);
                    input.ProbablySolved = true;
                }
                if (results.Any())
                {
                    Console.WriteLine($" > {results.OrderBy(x => x.Split(' ').Count(y => lDict.Contains(y))).Last()}");
                }
                Console.WriteLine();
            }

            sw.Stop();

            Console.WriteLine();
            Console.WriteLine($"Finished running: probably solved {inputs.Count(x => x.ProbablySolved)} of {inputs.Count} entries in {sw.Elapsed.TotalSeconds}s.");
            Console.ReadLine();
        }
    }
}
