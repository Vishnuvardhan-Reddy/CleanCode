using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PredictionEngine
{
    public class PredictionEngine
    {
        ILanguageModelAlgo languageModelAlgo;

        public PredictionEngine(ILanguageModelAlgo languageModelAlgo)
        {
            this.languageModelAlgo = languageModelAlgo;
        }

        public string Predict(string phrase)
        {
            var lastWord = GetLastWord(phrase);
            if (phrase.EndsWith(" "))
            {
                return languageModelAlgo.predictUsingBigram(lastWord);
            }
            else
                return languageModelAlgo.predictUsingMonogram(lastWord);
        }

        private static string GetLastWord(string phrase)
        {
            var words = phrase.Trim().Split(" ");
            var lastWord = words[words.Length - 1];
            return lastWord;
        }
    }
}
