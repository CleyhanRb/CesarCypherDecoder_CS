using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CesarCypherDecoder_CS;


namespace CesarCypherDecoder_CS
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            string original = File.ReadAllText("original.txt");


            CesarCypherDecoder decoder = new CesarCypherDecoder();
            decoder.LoadFromFile("liste.txt");


            CesarCypherDecoder.DecodeResult res = decoder.AutoDecode(original);
            sw.Stop();

            Console.WriteLine("Cesar Code: " + res.code);
            Console.WriteLine("Score: " + res.score + " %");
            Console.WriteLine("Done in: " + sw.Elapsed.ToString("mm\\:ss\\.ff"));
            File.WriteAllText("out.txt", res.sentence);

            Console.ReadKey();
        }
    }
}