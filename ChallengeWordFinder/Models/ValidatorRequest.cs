using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeWordFinder.Models
{
    public class ValidatorRequest
    {
        public string[] Matrix { get; set; }

        public IDictionary<string, int> RepeatedWordCount { get; set; }

        public string Word { get; set; }

        public int MatrixLineIndex { get; set; }

        public int MatrixLetterIndex { get; set; }
    }
}
