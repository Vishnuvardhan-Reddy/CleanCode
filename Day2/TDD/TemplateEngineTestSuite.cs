using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateEngine.Tests
{
    public class TemplateEngineTestSuite
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase("Vishnu", "Vardhan","Reddy")]
        [TestCase("Harsha","Vardhan", "Reddy")]
        public void ShouldEvaluateForTwoVaraible(string value1, string value2, string value3)
        {
            TemplateEngine templateEngine = new TemplateEngine();
            templateEngine.SetTemplate("Hello {firstName} {secondName} {lastName}");
            templateEngine.SetVariable("firstName", value1);
            templateEngine.SetVariable("secondName", value2);
            templateEngine.SetVariable("lastName", value3);

            string result = templateEngine.Evaluate();

            Assert.That($"Hello {value1} {value2} {value3}", Is.EqualTo(result));
        }


    }
}
