using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;

namespace PredictionEngine.Tests
{
    internal class PredictionEngineTestSuite
    {
        [SetUp]
        public void SetUp()
        {

        }

        [TestCase("", "")]
        [TestCase("Hello how are you do", "do")]
        [TestCase("Hello", "Hello")]
        public void ShouldCallUnigramWhenPartialWordIsGive(string phrase, string lastword)
        {
            var mockAlgo = new Mock<ILanguageModelAlgo>();
            PredictionEngine predictionEngine = new PredictionEngine(mockAlgo.Object);

            var prediction = predictionEngine.Predict(phrase);

            mockAlgo.Verify(p => p.predictUsingMonogram(lastword), Times.Once());
        }

        [TestCase(" ", "")]
        [TestCase("Hello what are you ", "you")]
        [TestCase("Hello ", "Hello")]
        public void ShouldCallBigramWhenPhraseEndsWithSpace(string phrase, string lastword)
        {
            var mockAlgo = new Mock<ILanguageModelAlgo>();
            PredictionEngine predictionEngine = new PredictionEngine(mockAlgo.Object);

            var prediction = predictionEngine.Predict(phrase);

            mockAlgo.Verify(p => p.predictUsingBigram(lastword), Times.Once());
        }

    }
}
