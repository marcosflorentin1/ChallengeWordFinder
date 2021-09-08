using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChallengeWordFinder.Models;

namespace ChallengeWordFinder.WordFinderValidator
{
    public class RowRightValidator : AbstractValidator
    {
        public override object Validate(ref ValidatorRequest request)
        {
            var matrix = request.Matrix;
            var word = request.Word;
            var matrixLineIndex = request.MatrixLineIndex;
            var matrixLetterIndex = request.MatrixLetterIndex;

            int restLineLength = matrix[matrixLineIndex].Substring(matrixLetterIndex).Length;

            if (restLineLength >= word.Length)
            {
                var lineWordToCheck = matrix[matrixLineIndex].Substring(matrixLetterIndex, word.Length);

                if (lineWordToCheck == word)
                {
                    if (request.RepeatedWordCount.ContainsKey(lineWordToCheck))
                    {
                        int value = request.RepeatedWordCount[lineWordToCheck];
                        request.RepeatedWordCount[lineWordToCheck] = value + 1;
                    }
                    else
                    {
                        request.RepeatedWordCount.Add(lineWordToCheck, 1);
                    }
                }
            }

            return base.Validate(ref request);
        }
    }
}
