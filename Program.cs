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

            string[] langs = Directory.GetFiles("lang");

            foreach (string s in langs) {

                string lang = Path.GetFileNameWithoutExtension(s);

                Stopwatch sw = new Stopwatch();
                sw.Start();
                string original = File.ReadAllText("original.txt");


                CesarCypherDecoder decoder = new CesarCypherDecoder();
                decoder.LoadFromFile(s);


                CesarCypherDecoder.DecodeResult res = decoder.AutoDecode(original);
                sw.Stop();

                Console.WriteLine("--------------------");
                Console.WriteLine("Language: " + lang);
                Console.WriteLine("Cesar Code: " + res.code);
                Console.WriteLine("Score: " + res.score + " %");
                Console.WriteLine("Done in: " + sw.Elapsed.ToString("mm\\:ss\\.ff"));
                File.WriteAllText("out/" + lang + ".txt", res.sentence);
                Console.WriteLine("--------------------\n");

            }


            

            Console.ReadKey();
        }
    }
}