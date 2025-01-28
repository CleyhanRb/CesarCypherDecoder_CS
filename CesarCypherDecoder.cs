using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CesarCypherDecoder_CS
{
    internal class CesarCypherDecoder
    {

        public List<string> WordDB = new List<string>();

        public void LoadFromFile(string path)
        {
            string[] lines = System.IO.File.ReadAllLines(path);
            foreach (string line in lines)
            {
                WordDB.Add(line);
            }
        }

        public static string DecodeWord(string word, int code)
        {
            string decoded = "";
            foreach (char c in word)
            {
                if (c >= 'A' && c <= 'Z')
                {
                    decoded += (char)((c - 'A' + 26 - code) % 26 + 'A');
                }
                else if (c >= 'a' && c <= 'z')
                {
                    decoded += (char)((c - 'a' + 26 - code) % 26 + 'a');
                }
                else
                {
                    decoded += c;
                }
            }
            return decoded;

        }

        public static List<string> DecodeSentence(List<string> sentence, int code)
        {
            List<string> decoded = new List<string>();
            foreach (string word in sentence)
            {
                decoded.Add(DecodeWord(word, code));
            } 
            return decoded;
        }

        public static string JoinSentence(List<string> sentence)
        {
            return String.Join(' ', sentence);
        }

        public double SentenceRate(List<string> sentence)
        {
            int nb = 0;
            foreach (string word in sentence)
            {
                if (WordDB.Contains(word.Replace(".", "")
            .Replace(",", "")
            .Replace("!", "")
            .Replace("?", "")
            .Replace(";", "")
            .Replace(":", "")
            .Replace("(", "")
            .Replace(")", "")
            .Replace("'", "").ToLower()))
                {
                    nb++;
                }
            }
            return Math.Round(100 * (float)nb / sentence.Count, 2);
        }

        public DecodeResult AutoDecode(string encoded)
        {
            Point cursorLocation = new Point(Console.CursorLeft, Console.CursorTop);
            ConsoleProgressBar bar = new ConsoleProgressBar(26);
            Console.WriteLine(bar.renderBar());

            List<DecodeResult> results = new List<DecodeResult>();
            for (int i = 0; i < 26; i++)
            {
                List<string> res = DecodeSentence(encoded.Split(' ').ToList(), i);
                string sentence = JoinSentence(res);
                double score = SentenceRate(res);

                results.Add(new DecodeResult { code = i, sentence = sentence, score = score });

                bar.Value = i+1;



                Console.SetCursorPosition(cursorLocation.X, cursorLocation.Y);
                Console.WriteLine(bar.renderBar());
            }

            results.Sort((DecodeResult a, DecodeResult b) => a.score.CompareTo(b.score));

            return results.Last();
        }


        public struct DecodeResult
        {
            public int code;
            public string sentence;
            public double score;
        }
    }
}
