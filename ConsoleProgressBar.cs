using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CesarCypherDecoder_CS
{
    internal class ConsoleProgressBar
    {
        public int Maximum { get; set; }
        public int Value { get; set; }

        public ConsoleProgressBar()
        {
            this.Maximum = 100;
        }

        public ConsoleProgressBar(int max)
        {
            this.Maximum = max;
        }

        public string renderBar()
        {
            int progress = (int)Math.Floor((decimal)(20 * this.Value / this.Maximum));
            return $"[{new string('#', progress) + new string('-', 20 - progress)}]";

        }
    }
}
