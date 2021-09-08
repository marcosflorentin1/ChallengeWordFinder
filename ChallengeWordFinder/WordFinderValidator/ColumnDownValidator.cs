using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChallengeWordFinder.Models;

namespace ChallengeWordFinder.WordFinderValidator
{
    public class ColumnDownValidator : AbstractValidator
    {
        public override object Validate(ref ValidatorRequest request)
        {
            var matrix = request.Matrix;
            var word = request.Word;
            var matrixLineIndex = request.MatrixLineIndex;
            var matrixLetterIndex = request.MatrixLetterIndex;

            char[] restColumn = matrix
                                .Skip(matrixLineIndex)
                                .Select(w => w[matrixLetterIndex])
                                .Take(word.Length)
                                .ToArray();

            string columnWordToCheck = new string(restColumn);

            if (columnWordToCheck == word)
            {
                if (request.RepeatedWordCount.ContainsKey(columnWordToCheck))
                {
                    int value = request.RepeatedWordCount[columnWordToCheck];
                    request.RepeatedWordCount[columnWordToCheck] = value + 1;
                }
                else
                {
                    request.RepeatedWordCount.Add(columnWordToCheck, 1);
                }
            }

            return base.Validate(ref request);
        }
    }
}
